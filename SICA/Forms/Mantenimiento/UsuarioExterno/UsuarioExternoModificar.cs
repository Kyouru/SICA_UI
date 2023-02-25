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

namespace SICA.Forms.Recibir
{
    public partial class UsuarioExternoModificar : Form
    {
        DataTable dt;
        string nombreanterior;
        public UsuarioExternoModificar()
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
        private void moverVentana()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            moverVentana();
        }

        private void UsuarioExternoModificar_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalFunctions.UltimaActividad();
                LoadingScreen.iniciarLoading();

                this.Activate();
                DataTable dtarea = new DataTable("Lista Area");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaarea");
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
                        dtarea = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }

                if (dtarea.Rows.Count > 0)
                {
                    cmbArea.DataSource = dtarea;
                    cmbArea.DisplayMember = "NOMBRE_AREA";
                    cmbArea.ValueMember = "ID_AREA";
                }

                //Lista Usuarios
                dt = new DataTable("Lista Usuarios");

                httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listausuarioexterno");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        tiposeleccionarusuario = 1
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

                foreach (DataRow row in dt.Rows)
                {
                    if (row["ID"].ToString() == Globals.IdUsernameSelect.ToString())
                    {
                        tbNombreUsuario.Text = row["NOMBRE_USUARIO_EXTERNO"].ToString();
                        nombreanterior = row["NOMBRE_USUARIO_EXTERNO"].ToString();
                        tbCorreo.Text = row["EMAIL"].ToString();
                        if (dtarea.Rows.Count > 0 && row["ID_AREA_FK"].ToString() != "")
                        {
                            cmbArea.SelectedValue = row["ID_AREA_FK"].ToString();
                        }
                        
                        if (row["NOTIFICAR"].ToString() == "1")
                        {
                            cbNotificar.Checked = true;
                        }
                        break;
                    }
                }

                this.Activate();
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
                        GlobalFunctions.casoError(ex, "Error Usuario Externo Modificar\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Usuario Externo Modificar");
            }
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (tbNombreUsuario.Text != "")
            {

                if (tbCorreo.Text != "")
                {
                    if (!GlobalFunctions.IsValidEmail(tbCorreo.Text))
                    {
                        MessageBox.Show("Email no valido");
                    }
                    else
                    {
                        try
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["NOMBRE_USUARIO_EXTERNO"].ToString() == tbNombreUsuario.Text && nombreanterior != tbNombreUsuario.Text)
                                {
                                    MessageBox.Show("Nombre Duplicado");
                                    return;
                                }
                            }
                            int notificar = 0;
                            if (cbNotificar.Checked)
                            {
                                notificar = 1;
                            }

                            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/modificarusuarioexterno");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";
                            httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    idaux = Globals.IdUsernameSelect,
                                    nombreusuario = tbNombreUsuario.Text,
                                    correousuario = tbCorreo.Text,
                                    idarea = cmbArea.SelectedValue,
                                    notificar = notificar
                                });

                                streamWriter.Write(json);
                            }

                            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                            if (httpResponse.StatusCode == HttpStatusCode.OK)
                            {
                                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                {
                                    string result = streamReader.ReadToEnd();
                                    MessageBox.Show("Registro Completado");
                                    this.Close();
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
                                    GlobalFunctions.casoError(ex, "Error Mantenimiento Modificar Usuario Externo\n" + reader.ReadToEnd());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            GlobalFunctions.casoError(ex, "Error Mantenimiento Modificar Usuario Externo");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Email Vacio");
                }
            }
            else
            {
                MessageBox.Show("Falta Nombre Usuario");
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
