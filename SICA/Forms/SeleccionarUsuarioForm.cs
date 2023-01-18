using Newtonsoft.Json;
using SimpleLogger;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms
{
    public partial class SeleccionarUsuarioForm : Form
    {
        DataTable dtUsuarios;
        public SeleccionarUsuarioForm()
        {
            InitializeComponent();
        }

        private void SeleccionarUsuarioForm_Load(object sender, EventArgs e)
        {
            Globals.IdUsernameSelect = -1;
            //Globals.EntregarConfirmacion = true;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listausuarios");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        tiposeleccionarusuario = Globals.TipoSeleccionarUsuario
                        //1: Externos
                    });

                    streamWriter.Write(json);
                }

                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dtUsuarios = JsonConvert.DeserializeObject<DataTable>(result);
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
                        GlobalFunctions.casoError(ex, "Error Seleccionar Usuario Load\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Seleccionar Usuario Load");
            }
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex >= 0)
            {
                Globals.IdUsernameSelect = Int32.Parse((cmbUsuario.SelectedItem as DataRowView)["ID_USUARIO"].ToString());
                Globals.UsernameSelect = cmbUsuario.Text.Trim();
                this.Close();
            }
            else
            {
                MessageBox.Show("No ha seleccionar un usuario");
            }
        }

        private void cmbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

    }
}
