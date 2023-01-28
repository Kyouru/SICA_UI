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
    public partial class UsuarioExternoModificar : Form
    {
        DataTable dt;
        string nombreanterior;
        public UsuarioExternoModificar()
        {
            InitializeComponent(); 
        }

        private void UsuarioExternoModificar_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalFunctions.UltimaActividad();
                LoadingScreen.iniciarLoading();

                //Lista Usuarios
                dt = new DataTable("Lista Usuarios");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listausuarioexterno");
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

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
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
                    if (row["ID_USUARIO_EXTERNO"].ToString() == Globals.IdUsernameSelect.ToString())
                    {
                        tbNombreUsuario.Text = row["NOMBRE_USUARIO_EXTERNO"].ToString();
                        nombreanterior = row["NOMBRE_USUARIO_EXTERNO"].ToString();
                        tbCorreo.Text = row["EMAIL"].ToString();
                        if (row["NOTIFICAR"].ToString() == "1")
                        {
                            cbNotificar.Checked = true;
                        }
                        break;
                    }
                }

                LoadingScreen.cerrarLoading();
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
    }
}
