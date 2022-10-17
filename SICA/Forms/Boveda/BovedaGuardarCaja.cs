using Newtonsoft.Json;
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

namespace SICA.Forms.Boveda
{
    public partial class BovedaGuardarCaja : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strBovedaGuardarCAJA;
        public BovedaGuardarCaja()
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

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Boveda/buscarguardarcaja");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        numerocaja = tbCaja.Text,
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
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
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

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Globals.TipoSeleccionarUsuario = 2;
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {

                    LoadingScreen.iniciarLoading();
                    try
                    {
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Boveda/guardarcaja");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                token = Globals.Token,
                                idaux = Globals.IdUsernameSelect,
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
                                MessageBox.Show("Proceso Completado");
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
                                GlobalFunctions.casoError(ex, "btSiguiente_Click\n" + reader.ReadToEnd());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoadingScreen.cerrarLoading();
                        GlobalFunctions.casoError(ex, "btSiguiente_Click");
                    }
                }
            }
        }

        private void tbCaja_KeyDown(object sender, KeyEventArgs e)
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
                /*
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    if (GlobalFunctions.verificarCaja(row.Cells["CAJA"].Value.ToString(), Globals.Username))
                    {
                        GlobalFunctions.AgregarCarrito("0", "0", row.Cells["CAJA"].Value.ToString(), tipo_carrito);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Hay documentos la caja " + row.Cells["CAJA"].Value.ToString()  + " que lo posee otro usuario\nDesea guardarlo de todas manera?", "Incompleto", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GlobalFunctions.AgregarCarrito("0", "0", row.Cells["CAJA"].Value.ToString(), tipo_carrito);
                        }
                    }
                }
                btBuscar_Click(sender, e);
                */
                
                if (dgv.SelectedRows.Count == 1)
                {
                    if (GlobalFunctions.verificarCaja(dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.IdUsername))
                    {
                        GlobalFunctions.AgregarCarrito("0", "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), tipo_carrito);
                        btBuscar_Click(sender, e);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Hay documentos de esta caja que lo posee otro usuario\nDesea guardarlo de todas manera?", "Incompleto", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GlobalFunctions.AgregarCarrito("0", "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), tipo_carrito);
                            btBuscar_Click(sender, e);
                        }
                        else
                        {
                            Globals.strnumeroCAJA = dgv.SelectedRows[0].Cells["CAJA"].Value.ToString();
                            CarritoForm vCarrito = new CarritoForm();
                            vCarrito.ShowDialog();
                        }
                    }
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
