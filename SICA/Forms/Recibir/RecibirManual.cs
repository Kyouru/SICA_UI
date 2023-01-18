using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms.Recibir
{
    public partial class RecibirManual : Form
    {
        private bool deshabilitarActualizacionDocumento = false;
        private bool deshabilitarActualizacionDetalle = false;

        public RecibirManual()
        {
            InitializeComponent();
        }

        private void RecibirManual_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalFunctions.UltimaActividad();
                LoadingScreen.iniciarLoading();
                //Lista Departamento
                DataTable dt = new DataTable("Lista Departamento");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadepartamento");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }
                deshabilitarActualizacionDocumento = true;
                cmbDepartamento.DataSource = dt;
                cmbDepartamento.DisplayMember = "NOMBRE_DEPARTAMENTO";
                cmbDepartamento.ValueMember = "ID_DEPARTAMENTO";
                deshabilitarActualizacionDocumento = false;

                LoadingScreen.cerrarLoading();
            }
            catch (WebException ex)
            {
                LoadingScreen.cerrarLoading();
                if (!(ex.Response is null))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        GlobalFunctions.casoError(ex, "RecibirManual_Load\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "RecibirManual_Load");
            }
            cmbDepartamento.SelectedValue = 1;
            this.Activate();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            bool correcto = true;
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (tbCaja.Text == "")
            {
                MessageBox.Show("Numero de Caja Vacio");
                correcto = false;
            }
            if (cmbDepartamento.SelectedIndex == -1)
            {
                MessageBox.Show("Departamento Invalido");
                correcto = false;
            }
            if (cmbDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Documento Invalido");
                correcto = false;
            }
            if (cmbDetalle.SelectedIndex == -1)
            {
                MessageBox.Show("Detalle Invalido");
                correcto = false;
            }

            if (correcto)
            {
                Globals.TipoSeleccionarUsuario = 1;
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                    try
                    {
                        string fechadesde = "", fechahasta = "";
                        if (cbFecha.Checked)
                        {
                            fechadesde = dtpFechaDesde.Value.ToString("yyyy-MM-dd");
                            fechahasta = dtpFechaHasta.Value.ToString("yyyy-MM-dd");
                        }
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/agregar");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";

                        int iddepartamento = Int32.Parse(cmbDepartamento.SelectedValue.ToString());
                        int iddocumento = Int32.Parse(cmbDocumento.SelectedValue.ToString());
                        int iddetalle = Int32.Parse(cmbDetalle.SelectedValue.ToString());
                        int idcentrocosto = -1;
                        int idclasificacion = -1;
                        int idproducto = -1;
                        int pagare = -1;

                        if (cbPagare.Checked)
                        {
                            pagare = 1;
                        }

                        try
                        {
                            idcentrocosto = Int32.Parse(cmbCentroCosto.SelectedValue.ToString());
                        }
                        catch
                        {
                            idcentrocosto = -1;
                        }
                        try
                        {
                            idclasificacion = Int32.Parse(cmbClasificacion.SelectedValue.ToString());
                        }
                        catch
                        {
                            idclasificacion = -1;
                        }
                        try
                        {
                            idproducto = Int32.Parse(cmbProducto.SelectedValue.ToString());
                        }
                        catch
                        {
                            idproducto = -1;
                        }
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                token = Globals.Token,
                                idaux = Globals.IdUsernameSelect,
                                idareaentrega = Globals.IdArea,
                                idarearecibe = Globals.IdAreaSelect,
                                idubicacionentrega = 2, //Usuario Externo
                                idubicacionrecibe = 8, //Valija
                                iddepartamento = iddepartamento,
                                iddocumento = iddocumento,
                                iddetalle = iddetalle,
                                idcentrocosto = idcentrocosto,
                                idclasificacion = idclasificacion,
                                idproducto = idproducto,
                                numerocaja = tbCaja.Text,
                                codigosocio = GlobalFunctions.lCadena(tbCodigoSocio.Text),
                                nombresocio = GlobalFunctions.lCadena(tbNombreSocio.Text),
                                numerosolicitud = GlobalFunctions.lCadena(tbNumeroSolicitud.Text),
                                pagare = pagare,
                                fecha = fecha,
                                fechadesde = fechadesde,
                                fechahasta = fechahasta,
                                observacion = GlobalFunctions.lCadena(observacion)
                            }) ;

                            streamWriter.Write(json);
                        }

                        HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                string result = streamReader.ReadToEnd();
                                }
                        }
                    }
                    catch (WebException ex)
                    {
                        LoadingScreen.cerrarLoading();
                        if (!(ex.Response is null))
                        {
                            using (var stream = ex.Response.GetResponseStream())
                            using (var reader = new StreamReader(stream))
                            {
                                GlobalFunctions.casoError(ex, "Error Recibir Manual\n" + reader.ReadToEnd());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        GlobalFunctions.casoError(ex, "Error Recibir Manual");
                        return;
                    }
                    MessageBox.Show("Registro Completado");
                    this.Close();
                }
            }
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (cbFecha.Checked)
            {
                dtpFechaDesde.Visible = true;
                dtpFechaHasta.Visible = true;
            }
            else
            {
                dtpFechaDesde.Visible = false;
                dtpFechaHasta.Visible = false;
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartamento.SelectedIndex != -1 && !deshabilitarActualizacionDocumento)
            {
                DataTable dt = new DataTable("Lista Documento");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadocumento");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        iddepartamento = cmbDepartamento.SelectedValue
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }
                deshabilitarActualizacionDetalle = true;
                cmbDocumento.DataSource = dt;
                cmbDocumento.DisplayMember = "NOMBRE_DOCUMENTO";
                cmbDocumento.ValueMember = "ID_DOCUMENTO";
                deshabilitarActualizacionDetalle = false;
                cmbDocumento_SelectedIndexChanged(sender, e);
                //cmbDetalle.DataSource = null;
            }
        }

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumento.SelectedIndex != -1 && !deshabilitarActualizacionDetalle)
            {
                DataTable dt = new DataTable("Lista Detalle");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadetalle");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        iddocumento = cmbDocumento.SelectedValue
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }

                cmbDetalle.DataSource = dt;
                cmbDetalle.DisplayMember = "NOMBRE_DETALLE";
                cmbDetalle.ValueMember = "ID_DETALLE";
            }
        }

        private void cbClasificacion_CheckedChanged(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (cbClasificacion.Checked)
            {
                DataTable dt = new DataTable();
                cmbClasificacion.Enabled = true;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaclasificacion");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }

                cmbClasificacion.DataSource = dt;
                cmbClasificacion.DisplayMember = "NOMBRE_CLASIFICACION";
                cmbClasificacion.ValueMember = "ID_CLASIFICACION";

            }
            else
            {
                cmbClasificacion.Enabled = false;
                cmbClasificacion.DataSource = null;
            }
        }

        private void cbCentroCosto_CheckedChanged(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (cbCentroCosto.Checked)
            {
                DataTable dt = new DataTable();
                cmbCentroCosto.Enabled = true;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listacentrocosto");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }

                cmbCentroCosto.DataSource = dt;
                cmbCentroCosto.DisplayMember = "NOMBRE_CENTRO_COSTO";
                cmbCentroCosto.ValueMember = "ID_CENTRO_COSTO";
            }
            else
            {
                cmbCentroCosto.Enabled = false;
                cmbCentroCosto.DataSource = null;
            }
        }

        private void cbProducto_CheckedChanged(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (cbProducto.Checked)
            {
                DataTable dt = new DataTable();
                cmbProducto.Enabled = true;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaproducto");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }

                cmbProducto.DataSource = dt;
                cmbProducto.DisplayMember = "NOMBRE_PRODUCTO";
                cmbProducto.ValueMember = "ID_PRODUCTO";
            }
            else
            {
                cmbProducto.Enabled = false;
                cmbProducto.DataSource = null;
            }
        }
    }
}
