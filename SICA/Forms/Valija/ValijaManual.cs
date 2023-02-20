using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms.Valija
{
    public partial class ValijaManual : Form
    {
        private bool deshabilitarActualizacionDocumento = false;
        private bool deshabilitarActualizacionDetalle = false;

        public ValijaManual()
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            moverVentana();
        }
        private void moverVentana()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        anulado = 0
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


                httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaclasificacion");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        anulado = 0
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

                cmbClasificacion.DataSource = dt;
                cmbClasificacion.DisplayMember = "NOMBRE_CLASIFICACION";
                cmbClasificacion.ValueMember = "ID_CLASIFICACION";

                httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listacentrocosto");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        anulado = 0
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

                cmbCentroCosto.DataSource = dt;
                cmbCentroCosto.DisplayMember = "NOMBRE_CENTRO_COSTO";
                cmbCentroCosto.ValueMember = "ID_CENTRO_COSTO";

                httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaproducto");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        anulado = 0
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

                cmbProducto.DataSource = dt;
                cmbProducto.DisplayMember = "NOMBRE_PRODUCTO";
                cmbProducto.ValueMember = "ID_PRODUCTO";

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
                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                        int iddepartamento = Int32.Parse(cmbDepartamento.SelectedValue.ToString());
                        int iddocumento = Int32.Parse(cmbDocumento.SelectedValue.ToString());
                        int iddetalle = Int32.Parse(cmbDetalle.SelectedValue.ToString());
                        int idcentrocosto = -1;
                        int idclasificacion = -1;
                        int idproducto = -1;

                        try
                        {
                            if(cbCentroCosto.Checked)
                            {
                                idcentrocosto = Int32.Parse(cmbCentroCosto.SelectedValue.ToString());
                            }
                        }
                        catch
                        {
                            idcentrocosto = -1;
                        }
                        try
                        {
                            if (cbClasificacion.Checked)
                            {
                                idclasificacion = Int32.Parse(cmbClasificacion.SelectedValue.ToString());
                            }
                        }
                        catch
                        {
                            idclasificacion = -1;
                        }
                        try
                        {
                            if (cbProducto.Checked)
                            {
                                idproducto = Int32.Parse(cmbProducto.SelectedValue.ToString());
                            }
                        }
                        catch
                        {
                            idproducto = -1;
                        }
                        string numerocaja = "";
                        if (cbCaja.Checked)
                        {
                            numerocaja = tbCaja.Text;
                        }
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                idaux = Globals.IdUsernameSelect,
                                idubicacionentrega = 2, //Usuario Externo
                                idubicacionrecibe = 8, //Valija
                                iddepartamento = iddepartamento,
                                iddocumento = iddocumento,
                                iddetalle = iddetalle,
                                idcentrocosto = idcentrocosto,
                                idclasificacion = idclasificacion,
                                idproducto = idproducto,
                                numerocaja = numerocaja,
                                codigosocio = GlobalFunctions.lCadena(tbCodigoSocio.Text),
                                nombresocio = GlobalFunctions.lCadena(tbNombreSocio.Text),
                                numerosolicitud = GlobalFunctions.lCadena(tbNumeroSolicitud.Text),
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
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
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
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
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
                cmbClasificacion.Visible = true;

            }
            else
            {
                cmbClasificacion.Visible = false;
            }
        }

        private void cbCentroCosto_CheckedChanged(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (cbCentroCosto.Checked)
            {
                cmbCentroCosto.Visible = true;
            }
            else
            {
                cmbCentroCosto.Visible = false;
            }
        }

        private void cbProducto_CheckedChanged(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (cbProducto.Checked)
            {
                cmbProducto.Visible = true;
            }
            else
            {
                cmbProducto.Visible = false;
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btValidarSolicitud_Click(object sender, EventArgs e)
        {
            string strperiodo = tbNumeroSolicitud.Text.Substring(0, 4).Trim();
            string strnumero = tbNumeroSolicitud.Text.Substring(4).Replace("-", "").Trim();
            int periodo = 0, numero = 0;
            try
            {
                periodo = Int32.Parse(strperiodo);
                numero = Int32.Parse(strnumero);
                string res = GlobalFunctions.PrestamoDatos(periodo, numero);
                cbClasificacion.Checked = true;
                cbProducto.Checked = true;
                tbCodigoSocio.Text = Globals.SisgoCIP;
                tbNombreSocio.Text = Globals.SisgoNOMBRE;
                cmbClasificacion.Text = Globals.SisgoTIPO_PERSONA;
                cmbProducto.Text = Globals.SisgoPRODUCTO;
                MessageBox.Show(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbCaja_CheckedChanged(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (cbCaja.Checked)
            {
                tbCaja.Visible = true;
            }
            else
            {
                tbCaja.Visible = false;
            }
        }
    }
}
