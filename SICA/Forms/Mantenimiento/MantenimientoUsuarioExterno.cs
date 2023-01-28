using Newtonsoft.Json;
using SICA.Forms.Recibir;
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

namespace SICA.Forms.Mantenimiento
{
    public partial class MantenimientoUsuarioExterno : Form
    {
        public MantenimientoUsuarioExterno()
        {
            InitializeComponent();
        }

        private void MantenimientoCuenta_Load(object sender, EventArgs e)
        {

            GlobalFunctions.UltimaActividad();
            LoadingScreen.iniciarLoading();

            try
            {
                DataTable dt = new DataTable("");
                DataTable dtcuentas = new DataTable("");
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

                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[0].Visible = false;
                    dgv.ClearSelection();
                }
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
                        GlobalFunctions.casoError(ex, "Error Mantenimiento Buscar Usuario Externo\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Mantenimiento Buscar Usuario Externo");
                return;
            }
        }

        private void btModificarUsuario_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgv.SelectedRows.Count == 1)
            {
                Globals.IdUsernameSelect = Int32.Parse(dgv.Rows[dgv.SelectedRows[0].Index].Cells["ID"].Value.ToString());
                UsuarioExternoModificar vModificar = new UsuarioExternoModificar();
                vModificar.ShowDialog(this);
                MantenimientoCuenta_Load(sender, e);
            }
        }

        private void btCrearUsuario_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            UsuarioExternoNueva vNueva = new UsuarioExternoNueva();
            vNueva.ShowDialog(this);
            MantenimientoCuenta_Load(sender, e);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btOrderUp_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgv.SelectedRows.Count == 1)
            {
                if (dgv.SelectedRows[0].Index > 0)
                {
                    int prevrow = dgv.SelectedRows[0].Index - 1;
                    UsuarioExternoOrden(-1);

                    MantenimientoCuenta_Load(sender, e);
                    dgv.Rows[prevrow].Selected = true;
                }
            }
        }

        private void btOrderDown_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgv.SelectedRows.Count == 1)
            {
                if (dgv.SelectedRows[0].Index < dgv.Rows.Count - 1)
                {
                    int nextrow = dgv.SelectedRows[0].Index + 1;

                    UsuarioExternoOrden(1);

                    MantenimientoCuenta_Load(sender, e);
                    dgv.Rows[nextrow].Selected = true;
                }
            }
        }

        private void UsuarioExternoOrden(int ordendif)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/UsuarioExternoOrden");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        idaux = dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString(),
                        ordendif = ordendif
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
                }
            }
            catch (WebException ex)
            {
                if (!(ex.Response is null))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        GlobalFunctions.casoError(ex, "Ordenar Usuario Externo\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Ordenar Usuario Externo\n");
            }
            
        }

    }
}
