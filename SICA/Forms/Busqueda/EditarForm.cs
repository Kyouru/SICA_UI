using Newtonsoft.Json;
using System;
using System.Collections;
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

namespace SICA.Forms.Busqueda
{
    public partial class EditarForm : Form
    {
        private bool deshabilitarActualizacionDocumento = false;
        private bool deshabilitarActualizacionDetalle = false;
        public EditarForm()
        {
            GlobalFunctions.UltimaActividad();
            InitializeComponent();
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (cbFecha.Checked)
            {
                lbDesde.Visible = true;
                lbHasta.Visible = true;
                dtpFechaDesde.Visible = true;
                dtpFechaHasta.Visible = true;
            }
            else
            {
                lbDesde.Visible = false;
                lbHasta.Visible = false;
                dtpFechaDesde.Visible = false;
                dtpFechaHasta.Visible = false;
            }
        }

        private void EditarForm_Load(object sender, EventArgs e)
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

                dt = new DataTable("Datos Editar");

                httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/datoseditar");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        idinventario = Globals.IdInventario
                    });

                    streamWriter.Write(json);
                }

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    tbCaja.Text = dt.Rows[0]["NUMERO_DE_CAJA"].ToString();
                    cmbDepartamento.SelectedValue = dt.Rows[0]["ID_DEPARTAMENTO_FK"].ToString();
                    cmbDocumento.SelectedValue = dt.Rows[0]["ID_DOCUMENTO_FK"].ToString();
                    cmbDetalle.SelectedValue = dt.Rows[0]["ID_DETALLE_FK"].ToString();
                    try
                    {
                        dtpFechaDesde.Value = (DateTime)dt.Rows[0]["FECHA_DESDE"];
                    }
                    catch
                    {

                    }
                    try
                    {
                        dtpFechaHasta.Value = (DateTime)dt.Rows[0]["FECHA_HASTA"];
                    }
                    catch
                    {

                    }

                    tbNumeroSolicitud.Text = dt.Rows[0]["NUMEROSOLICITUD"].ToString();
                    tbCodigoSocio.Text = dt.Rows[0]["CODIGO_SOCIO"].ToString();
                    tbNombreSocio.Text = dt.Rows[0]["NOMBRE_SOCIO"].ToString();

                    if (dt.Rows[0]["ID_CLASIFICACION_FK"].ToString() != "" && dt.Rows[0]["ID_CLASIFICACION_FK"].ToString() != "-1")
                    {
                        cbClasificacion.Checked = true;
                        cmbClasificacion.SelectedValue = dt.Rows[0]["ID_CLASIFICACION_FK"].ToString();
                    }
                    else
                    {
                        cbClasificacion.Checked = false;
                        cmbClasificacion.Enabled = false;
                    }

                    tbObservacion.Text = dt.Rows[0]["OBSERVACION"].ToString();

                    if (dt.Rows[0]["ID_CENTRO_COSTO_FK"].ToString() != "" && dt.Rows[0]["ID_CENTRO_COSTO_FK"].ToString() != "-1")
                    {
                        cbCentroCosto.Checked = true;
                        cmbCentroCosto.SelectedValue = dt.Rows[0]["ID_CENTRO_COSTO_FK"].ToString();
                    }
                    else
                    {
                        cbCentroCosto.Checked = false;
                        cmbCentroCosto.Enabled = false;
                    }

                    if (dt.Rows[0]["ID_PRODUCTO_FK"].ToString() != "" && dt.Rows[0]["ID_PRODUCTO_FK"].ToString() != "-1")
                    {
                        cbProducto.Checked = true;
                        cmbProducto.SelectedValue = dt.Rows[0]["ID_PRODUCTO_FK"].ToString();
                    }
                    else
                    {
                        cbProducto.Checked = false;
                        cmbProducto.Enabled = false;
                    }

                    if (dt.Rows[0]["FECHA_DESDE"].ToString() != "")
                    {
                        cbFecha.Checked = true;
                    }
                }
                LoadingScreen.cerrarLoading();
                //this.Focus();
                this.Activate();
            }
            catch (WebException ex)
            {
                LoadingScreen.cerrarLoading();
                if (!(ex.Response is null))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        GlobalFunctions.casoError(ex, "Error Datos Editar\n" + reader.ReadToEnd());
                    }
                }
            }

            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Datos Editar");
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            bool correcto = true;
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

                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/guardareditar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    string fechadesde, fechahasta;
                    if (cbFecha.Checked)
                    {
                        fechadesde = dtpFechaDesde.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        fechahasta = dtpFechaHasta.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        fechadesde = "";
                        fechahasta = "";
                    }
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        int iddepartamento = Int32.Parse(cmbDepartamento.SelectedValue.ToString());
                        int iddocumento = Int32.Parse(cmbDocumento.SelectedValue.ToString());
                        int iddetalle = Int32.Parse(cmbDetalle.SelectedValue.ToString());
                        int idcentrocosto = -1;
                        int idclasificacion = -1;
                        int idproducto = -1;

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

                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            token = Globals.Token,
                            idinventario = Globals.IdInventario,
                            numerocaja = tbCaja.Text,
                            iddepartamento = iddepartamento,
                            iddocumento = iddocumento,
                            iddetalle = iddetalle,
                            idcentrocosto = idcentrocosto,
                            idclasificacion = idclasificacion,
                            idproducto = idproducto,
                            fechadesde = fechadesde,
                            fechahasta = fechahasta,
                            codigosocio = GlobalFunctions.lCadena(tbCodigoSocio.Text),
                            nombresocio = GlobalFunctions.lCadena(tbNombreSocio.Text),
                            numerosolicitud = GlobalFunctions.lCadena(tbNumeroSolicitud.Text),
                            observacion = GlobalFunctions.lCadena(tbObservacion.Text),
                            usuariocrea = Globals.Username,
                            fechamodifica = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        });
                        streamWriter.Write(json);
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                        }
                        MessageBox.Show("Actualizado");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error");
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
                            GlobalFunctions.casoError(ex, "Error Guardar Editar\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoadingScreen.cerrarLoading();
                    GlobalFunctions.casoError(ex, "Error Guardar Editar");
                }
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

    }
}
