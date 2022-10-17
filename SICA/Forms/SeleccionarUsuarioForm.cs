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
            Globals.EntregarConfirmacion = true;
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

                DataTable dt = new DataTable("AREA");
                dt.Columns.Add("ID_AREA");
                dt.Columns.Add("NOMBRE_AREA");
                List<int> idareas = new List<int>();
                foreach(DataRow row in dtUsuarios.Rows)
                {
                    int idarea = Int32.Parse(row["ID_AREA"].ToString());
                    if (!idareas.Contains(idarea))
                    {
                        DataRow row2 = dt.NewRow();
                        idareas.Add(idarea);
                        row2["ID_AREA"] = idarea;
                        row2["NOMBRE_AREA"] = row["NOMBRE_AREA"].ToString();
                        dt.Rows.Add(row2);
                    }
                }

                cmbArea.DataSource = dt;
                cmbArea.ValueMember = "ID_AREA";
                cmbArea.DisplayMember = "NOMBRE_AREA";

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
                Globals.IdAreaSelect = Int32.Parse((cmbArea.SelectedItem as DataRowView)["ID_AREA"].ToString());
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

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex >= 0)
            {
                try
                {
                    DataTable dt = new DataTable("USUARIO");
                    dt.Columns.Add("ID_USUARIO");
                    dt.Columns.Add("NOMBRE_USUARIO");
                    foreach (DataRow row in dtUsuarios.Rows)
                    {
                        int idarea = Int32.Parse(row["ID_AREA"].ToString());
                        if (Int32.Parse((cmbArea.SelectedItem as DataRowView)["ID_AREA"].ToString()) == idarea)
                        {
                            DataRow row2 = dt.NewRow();
                            row2["ID_USUARIO"] = row["ID_USUARIO"].ToString();
                            row2["NOMBRE_USUARIO"] = row["NOMBRE_USUARIO"].ToString();
                            dt.Rows.Add(row2);
                        }
                    }

                    cmbUsuario.DataSource = dt;
                    cmbUsuario.ValueMember = "ID_USUARIO";
                    cmbUsuario.DisplayMember = "NOMBRE_USUARIO";
                }
                catch (Exception ex)
                {
                    LoadingScreen.cerrarLoading();
                    GlobalFunctions.casoError(ex, "Error Selecionar Usuario Usuarios");
                }
            }
            else
            {
                cmbUsuario.DataSource = null;
            }
        }
    }
}
