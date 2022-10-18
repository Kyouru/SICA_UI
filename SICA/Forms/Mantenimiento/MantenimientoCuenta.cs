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
    public partial class MantenimientoCuenta : Form
    {
        public MantenimientoCuenta()
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
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/buscarcuenta");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token
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
                        /*
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["NOMBRE_USUARIO"].ToString() == "BOVEDA_1")
                            {
                                dr.Delete();
                            }
                            else if (dr["NOMBRE_USUARIO"].ToString() == "BOVEDA_2")
                            {
                                dr.Delete();
                            }
                            else if (dr["NOMBRE_USUARIO"].ToString() == "IRONMOUNTAIN")
                            {
                                dr.Delete();
                            }
                        }*/
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
                        GlobalFunctions.casoError(ex, "Error Mantenimiento Buscar Cuenta\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Mantenimiento Buscar Cuenta");
                return;
            }
        }

        private void btModificarCuenta_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgv.SelectedCells.Count == 1)
            {
                Globals.IdInventario = Int32.Parse(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
                CuentaModificar vModificar = new CuentaModificar();
                vModificar.Show();
            }
        }

        private void btCrearCuenta_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            CuentaNueva vNueva = new CuentaNueva();
            vNueva.Show();
        }
    }
}
