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
using static System.Windows.Forms.MonthCalendar;

namespace SICA.Forms.Recibir
{
    public partial class UsuarioExternoNueva : Form
    {
        public UsuarioExternoNueva()
        {
            InitializeComponent();
        }

        private void CuentaNueva_Load(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            this.Activate();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int notificar = 0;

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
                            if (cbNotificar.Checked)
                            {
                                notificar = 1;
                            }
                            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/crearusuarioexterno");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";
                            httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                string json = new JavaScriptSerializer().Serialize(new
                                {
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
                            else
                            {
                                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                {
                                    string result = streamReader.ReadToEnd();
                                    MessageBox.Show("Error Mantenimiento Crear Usuario Externo\n" + result);
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
                                    GlobalFunctions.casoError(ex, "Error Mantenimiento Crear Usuario\n" + reader.ReadToEnd());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            GlobalFunctions.casoError(ex, "Error Mantenimiento Crear Usuario");
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
