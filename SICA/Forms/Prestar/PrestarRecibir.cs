
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms.Prestar
{
    public partial class PrestarRecibir : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strPrestarRecibir;

        public PrestarRecibir()
        {
            GlobalFunctions.UltimaActividad();
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

            GlobalFunctions.UltimaActividad();
            LoadingScreen.iniciarLoading();

            try
            {
                DataTable dt = new DataTable("PRESTAR_RECIBER");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Prestar/buscarrecibir");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
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

                actualizarCantidad();

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
                        GlobalFunctions.casoError(ex, "Error Prestar Buscar Documento\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Prestar Buscar Documento");
                return;
            }
        }

        private void btEntregar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (lbCantidad.Text != "(0)")
            {
                Globals.TipoSeleccionarUsuario = 1;
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                    Globals.NombreCargo = "PRESTAR RECIBIR";

                    try
                    {
                        LoadingScreen.iniciarLoading();

                        DataTable dt = GlobalFunctions.ObtenerCarrito(tipo_carrito);

                        string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        if (dt.Rows.Count > 0)
                        {
                            HttpWebRequest httpWebRequest;
                            HttpWebResponse httpResponse;
                            foreach (DataRow row in dt.Rows)
                            {
                                httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Prestar/recibir");
                                httpWebRequest.ContentType = "application/json";
                                httpWebRequest.Method = "POST";
                                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                {
                                    string json = new JavaScriptSerializer().Serialize(new
                                    {
                                        fecha = fecha,
                                        observacion = observacion
                                    });

                                    streamWriter.Write(json);
                                }

                                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                if (httpResponse.StatusCode == HttpStatusCode.OK)
                                {
                                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                    {
                                        string result = streamReader.ReadToEnd();
                                    }
                                }
                            }

                            httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Carrito/limpiarcarrito");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "GET";
                            httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                            /*
                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    token = Globals.Token
                                });

                                streamWriter.Write(json);
                            }
                            */
                            httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                            if (httpResponse.StatusCode == HttpStatusCode.OK)
                            {
                                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                {
                                    string result = streamReader.ReadToEnd();
                                }
                            }

                            actualizarCantidad(0);
                            LoadingScreen.cerrarLoading();
                            GlobalFunctions.ExportarDataTableExcel(dt, Globals.NombreCargo, true);
                        }
                        else
                        {
                            LoadingScreen.cerrarLoading();
                            MessageBox.Show("No hay Documentos en el Carrito " + tipo_carrito);
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
                                GlobalFunctions.casoError(ex, "Prestar Entregar Carrito Documentos\n" + reader.ReadToEnd());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoadingScreen.cerrarLoading();
                        GlobalFunctions.casoError(ex, "Prestar Entregar Carrito Documentos\n" + tipo_carrito);
                    }
                }
            }
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

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            //GlobalFunctions.ExportarDataGridViewCSV(dgv, null);
            GlobalFunctions.ExportarDGV(dgv, null);
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            actualizarCantidad(0);
            btBuscar_Click(sender, e);
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                LoadingScreen.iniciarLoading();
                try
                {
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                    {
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Carrito/agregarcarrito");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                idinventario = Int32.Parse(row.Cells["ID"].Value.ToString()),
                                tipocarrito = tipo_carrito,
                                numerocaja = row.Cells["CAJA"].Value.ToString()
                            });

                            streamWriter.Write(json);
                        }

                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            ++cantidadcarrito;
                        }
                    }

                    actualizarCantidad(cantidadcarrito);
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                    {
                        if (!row.IsNewRow)
                            dgv.Rows.Remove(row);
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
                            GlobalFunctions.casoError(ex, "Error Prestar Recibir Agregar\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoadingScreen.cerrarLoading();
                    GlobalFunctions.casoError(ex, "Error Prestar Recibir Agregar");
                    return;
                }
            }
        }
    }
}
