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
            buscarUsuarios();
            mostrarUsuarios();
        }


        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                Globals.IdUsernameSelect = Int32.Parse(dgv.SelectedRows[0].Cells["ID"].Value.ToString());
                Globals.UsernameSelect = dgv.SelectedRows[0].Cells["NOMBRE_USUARIO_EXTERNO"].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("No ha seleccionar un usuario");
            }
        }

        private void tbBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                buscarUsuarios();
                mostrarUsuarios();
            }
        }
        private void buscarUsuarios()
        {
            //Globals.EntregarConfirmacion = true;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listausuarioexterno");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        tiposeleccionarusuario = Globals.TipoSeleccionarUsuario,
                        busquedalibre = tbBuscar.Text
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
                        GlobalFunctions.casoError(ex, "Error Buscar Usuario Load\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Buscar Usuario Load");
            }
        }

        private void mostrarUsuarios()
        {
            dgv.DataSource = dtUsuarios;
            if (dgv.Rows.Count > 0)
            {
                dgv.Columns["ID"].Visible = false;
                dgv.Columns["EMAIL"].Visible = false;
                dgv.Columns["NOTIFICAR"].Visible = false;
                dgv.Columns["NOMBRE_USUARIO_EXTERNO"].Width = 200;
                dgv.Columns["NOMBRE_USUARIO_EXTERNO"].HeaderText = "NOMBRE";
            }
        }
    }
}
