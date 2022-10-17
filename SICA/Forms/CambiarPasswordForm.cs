using Newtonsoft.Json;
using SimpleLogger;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms
{
    public partial class CambiarPasswordForm : Form
    {
        public CambiarPasswordForm()
        {
            InitializeComponent();
        }

        private void CambiarPasswordForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btGrabarPassword_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text != "")
            {
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Auth/actualizarpassword");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            token = Globals.Token,
                            iduser = Globals.IdUsername,
                            password = tbPassword.Text
                        });

                        streamWriter.Write(json);
                    }

                    HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            Globals.loginsuccess = 1;
                            MessageBox.Show("Nueva Contraseña Establecida");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error estableciendo nueva contraseña");
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
                            GlobalFunctions.casoError(ex, "Error estableciendo nueva contraseña\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoadingScreen.cerrarLoading();
                    GlobalFunctions.casoError(ex, "Error estableciendo nueva contraseña");
                }
            }
            else
            {
                MessageBox.Show("Contraseña Vacia");
            }
        }
    }
}
