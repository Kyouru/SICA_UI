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
    public partial class CarritoForm : Form
    {
        public CarritoForm()
        {
            InitializeComponent();
        }

        private void CarritoForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("CARRITO");
            try
            {
                LoadingScreen.iniciarLoading();

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Carrito/buscar");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        tipocarrito = Globals.CarritoSeleccionado,
                        numerocaja = Globals.strnumeroCAJA
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
                    dgvCarrito.DataSource = dt;
                    dgvCarrito.Columns[0].Visible = false;
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
                        GlobalFunctions.casoError(ex, "CarritoForm_Load\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "CarritoForm_Load");
            }
        }

        private void dgvCarrito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count == 1 && Globals.CarritoSeleccionado != Globals.strVerificarCAJA)
            {
                if (dgvCarrito.SelectedRows[0].Cells["ID"].Value.ToString() != "")
                {
                    DialogResult dialogResult = MessageBox.Show("Desea Eliminar este item del carrito?", "Confirmar Eliminar", MessageBoxButtons.YesNo);
                    if (dialogResult != DialogResult.Yes)
                    {
                        return;
                    }

                    LoadingScreen.iniciarLoading();
                    try
                    {
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Carrito/eliminar");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                token = Globals.Token,
                                idaux = dgvCarrito.SelectedRows[0].Cells["ID"].Value.ToString()
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

                        CarritoForm_Load(sender, e);
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
                                GlobalFunctions.casoError(ex, "dgvCarrito_CellDoubleClick\n" + reader.ReadToEnd());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoadingScreen.cerrarLoading();
                        GlobalFunctions.casoError(ex, "dgvCarrito_CellDoubleClick");
                    }
                }
            }
        }
    }
}
