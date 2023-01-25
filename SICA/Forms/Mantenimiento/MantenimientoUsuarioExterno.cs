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

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
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
                Globals.IdUsernameSelect = Int32.Parse(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells["ID_USUARIO_EXTERNO"].Value.ToString());
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
    }
}
