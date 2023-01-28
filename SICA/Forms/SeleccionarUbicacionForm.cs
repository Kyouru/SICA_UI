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
    public partial class SeleccionarUbicacionForm : Form
    {
        DataTable dtUsuarios;
        public SeleccionarUbicacionForm()
        {
            InitializeComponent();
        }

        private void SeleccionarUbicacionForm_Load(object sender, EventArgs e)
        {
            Globals.IdUbicacionSelect = -1;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaubicacion");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        tiposeleccionarubicacion = Globals.TipoSeleccionarUbicacion
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
                        cmbUbicacion.DataSource = dtUsuarios;
                        cmbUbicacion.ValueMember = "ID_UBICACION";
                        cmbUbicacion.DisplayMember = "NOMBRE_UBICACION";
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
                        GlobalFunctions.casoError(ex, "Error Seleccionar Ubicacion Load\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Seleccionar Ubicacion Load");
            }
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbUbicacion.SelectedIndex >= 0)
            {
                Globals.IdUbicacionSelect = Int32.Parse((cmbUbicacion.SelectedItem as DataRowView)["ID_UBICACION"].ToString());
                Globals.UbicacionSelect = cmbUbicacion.Text.Trim();
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
