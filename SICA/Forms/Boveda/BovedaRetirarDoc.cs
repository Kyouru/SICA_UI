using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms.Boveda
{
    public partial class BovedaRetirarDoc : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strBovedaRetirarDOC;
        public BovedaRetirarDoc()
        {
            InitializeComponent();
            Globals.CarritoSeleccionado = tipo_carrito;
            actualizarCantidad();
        }
        public void actualizarCantidad(int cantidad = -1)
        {
            if (cantidad >= 0)
            {
                cantidadcarrito = cantidad;
            }
            else
            {
                cantidadcarrito = GlobalFunctions.CantidadCarrito(tipo_carrito);
            }
            lbCantidad.Text = "(" + cantidadcarrito + ")";
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LoadingScreen.iniciarLoading();
                DataTable dt = new DataTable();

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Boveda/buscarretirardocumento");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        busquedalibre = tbBusquedaLibre.Text
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
                    dgv.Columns[1].Visible = false;
                    dgv.ClearSelection();

                }

                actualizarCantidad();
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
                        GlobalFunctions.casoError(ex, "btBuscar_Click\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "btBuscar_Click");
            }
        }

        private void agregar()
        {
            int repetidos = 0;
            LoadingScreen.iniciarLoading();

            try
            {
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Boveda/agregarcarritodocumento");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            token = Globals.Token,
                            idinventario = row.Cells["ID"].Value.ToString(),
                            idaux = dgv.SelectedRows[0].Cells["ID_BOVEDA"].Value.ToString(),
                            tipocarrito = tipo_carrito,
                            numerocaja = row.Cells["CAJA"].Value.ToString()
                        });

                        streamWriter.Write(json);
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            if (result == "OK")
                            {
                                ++cantidadcarrito;
                            }
                            else
                            {
                                repetidos++;
                            }
                        }
                    }
                }

                if (repetidos > 0)
                {
                    LoadingScreen.cerrarLoading();
                    MessageBox.Show(repetidos + " Documentos se encuentra en Carrito de otro usuario");
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
                        GlobalFunctions.casoError(ex, "Error Boveda agregar\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Boveda agregar");
            }
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                agregar();
                btBuscar_Click(sender, e);
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                LoadingScreen.iniciarLoading();
                string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Boveda/retirardocumento");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            token = Globals.Token,
                            fecha = fecha,
                            tipocarrito = tipo_carrito
                        });

                        streamWriter.Write(json);
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            actualizarCantidad(0);
                            LoadingScreen.cerrarLoading();
                        }
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
                            GlobalFunctions.casoError(ex, "btSiguiente_Click\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoadingScreen.cerrarLoading();
                    GlobalFunctions.casoError(ex, "btSiguiente_Click");
                    return;
                }
                
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDGV(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            btBuscar_Click(sender, e);
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.ShowDialog();
                btBuscar_Click(sender, e);
            }
        }
    }
}
