using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SICA.Forms;
using SICA.Forms.Busqueda;
using SimpleLogger;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static SICA.GlobalFunctions;

namespace SICA
{
    public partial class BusquedaForm : Form
    {
        public BusquedaForm()
        {
            GlobalFunctions.UltimaActividad();
            InitializeComponent();
            dgvBusqueda.DoubleBuffered(true);

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void BusquedaForm_Load(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();

            btEdit.Visible = int2bool(Globals.BusquedaEditar);
            btHistorial.Visible = int2bool(Globals.BusquedaHistorico);
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (tbBusquedaLibre.Text.Trim() + tbCaja.Text.Trim() == "") // + tbUsuario.Text == "")
            {
                dgvBusqueda.DataSource = null;
                MessageBox.Show("Filtro Vacio");
                return;
            }

            string fecha;

            try
            {
                LoadingScreen.iniciarLoading();

                if (cbFecha.Checked)
                    fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                else
                    fecha = "";
                DataTable dt = new DataTable("INVENTARIO_GENERAL");

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/buscar");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        busquedalibre = tbBusquedaLibre.Text,
                        numerocaja = tbCaja.Text,
                        fecha = fecha
                    });

                    streamWriter.Write(json);
                }

                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
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
                    dgvBusqueda.DataSource = dt;
                    dgvBusqueda.AutoResizeColumns();
                    dgvBusqueda.Columns[0].Visible = false;
                    LoadingScreen.cerrarLoading();
                    //Formatos
                    //dgvBusqueda.Columns["DESC_1"].Width = 250;
                }
                else
                {
                    LoadingScreen.cerrarLoading();
                    dgvBusqueda.DataSource = null;
                    MessageBox.Show("No hay coincidencias");
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

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgvBusqueda.Rows.Count > 0)
            {
                GlobalFunctions.ExportarDataGridViewCSV(dgvBusqueda, null);
            }
            else
            {
                MessageBox.Show("No hay Registros");
            }
        }

        private void dgvBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgvBusqueda.SelectedRows.Count == 1)
                {
                    Globals.IdInventario = Int32.Parse(dgvBusqueda.Rows[dgvBusqueda.SelectedRows[0].Index].Cells["ID"].Value.ToString());
                    HistoricoForm vHistorico = new HistoricoForm();
                    vHistorico.Show();
                }
            }
        }

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (cbFecha.Checked)
            {
                dtpFecha.Enabled = true;
            }
            else
            {
                dtpFecha.Enabled = false;
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgvBusqueda.SelectedRows.Count == 1)
            {
                int selectedrow = dgvBusqueda.SelectedRows[0].Index;
                Globals.IdInventario = Int32.Parse(dgvBusqueda.Rows[selectedrow].Cells["ID"].Value.ToString());
                EditarForm ef = new EditarForm();
                ef.ShowDialog(this);
                btBuscar_Click(sender, e);
                if (!Globals.cerrando)
                {
                    dgvBusqueda.ClearSelection();
                    dgvBusqueda.Rows[selectedrow].Selected = true;
                }
            }
            else
            {
                MessageBox.Show("Seleccione el documento a editar");
            }
        }

        private void btHistorial_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgvBusqueda.SelectedRows.Count == 1)
            {
                Globals.IdInventario = Int32.Parse(dgvBusqueda.Rows[dgvBusqueda.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
                HistoricoForm vHistorico = new HistoricoForm();
                vHistorico.Show();
            }
            else
            {
                MessageBox.Show("Seleccione el documento para ver el historial");
            }
        }

        private void btPrestar_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.SelectedRows.Count == 1)
            {
                Globals.TipoSeleccionarUsuario = 1;
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    try
                    {
                        int selectedrow = dgvBusqueda.SelectedRows[0].Index;
                        string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                        string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Entregar/entregar");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                idrecibe = Globals.IdUsernameSelect,
                                idestado = 2, //Prestado
                                idinventario = Int32.Parse(dgvBusqueda.Rows[selectedrow].Cells["ID"].Value.ToString()),
                                idubicacionrecibe = 2, //USUARIO_EXTERNO
                                fecha = fecha,
                                observacion = observacion
                            });

                            streamWriter.Write(json);
                        }

                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                string result = streamReader.ReadToEnd();
                                //MessageBox.Show("Entregado");
                                btBuscar_Click(sender, e);
                                dgvBusqueda.ClearSelection();
                                dgvBusqueda.Rows[selectedrow].Selected = true;
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
                                GlobalFunctions.casoError(ex, "Prestar Documento\n" + reader.ReadToEnd());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoadingScreen.cerrarLoading();
                        GlobalFunctions.casoError(ex, "Prestar Documento\n");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void btRecibir_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.SelectedRows.Count == 1)
            {
                try
                {
                    Globals.TipoSeleccionarUbicacion = 1;
                    SeleccionarUbicacionForm suf = new SeleccionarUbicacionForm();
                    suf.ShowDialog();
                    if (Globals.IdUbicacionSelect > 0)
                    {
                        int selectedrow = dgvBusqueda.SelectedRows[0].Index;
                        string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                        string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/recibir");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                idrecibe = Globals.IdUsernameSelect,
                                idestado = 1, //Custodiado
                                idinventario = Int32.Parse(dgvBusqueda.Rows[selectedrow].Cells["ID"].Value.ToString()),
                                idubicacionrecibe = Globals.IdUbicacionSelect,
                                fecha = fecha,
                                observacion = observacion
                            });

                            streamWriter.Write(json);
                        }

                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                string result = streamReader.ReadToEnd();
                                //MessageBox.Show("Procesado");
                                btBuscar_Click(sender, e);
                                dgvBusqueda.ClearSelection();
                                dgvBusqueda.Rows[selectedrow].Selected = true;
                            }
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
                            GlobalFunctions.casoError(ex, "Recibir Documento\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoadingScreen.cerrarLoading();
                    GlobalFunctions.casoError(ex, "Recibir Documento\n");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }
    }
}
