using Microsoft.VisualBasic;
using Newtonsoft.Json;
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

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void BusquedaForm_Load(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            //tbUsuario.Text = Globals.Username;
            //dtpFecha.Value = DateTime.Now;

            btEdit.Visible = int2bool(Globals.auBusquedaEditar);
            btHistorial.Visible = int2bool(Globals.auBusquedaHistorico);
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

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
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
                LoadingScreen.cerrarLoading();
                if (dt.Rows.Count > 0)
                {
                    dgvBusqueda.DataSource = dt;
                    dgvBusqueda.AutoResizeColumns();
                    dgvBusqueda.Columns[0].Visible = false;
                    //Formatos
                    //dgvBusqueda.Columns["DESC_1"].Width = 250;
                }
                else
                {
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
            GlobalFunctions.ExportarDataGridViewCSV(dgvBusqueda, null);
        }

        private void dgvBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgvBusqueda.SelectedCells.Count == 1)
                {
                    Globals.IdInventario = Int32.Parse(dgvBusqueda.Rows[dgvBusqueda.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
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
            if (dgvBusqueda.SelectedCells.Count == 1)
            {
                Globals.IdInventario = Int32.Parse(dgvBusqueda.Rows[dgvBusqueda.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
                EditarForm ef = new EditarForm();
                ef.ShowDialog(this);
                btBuscar_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Seleccione el documento a editar");
            }
        }

        private void btHistorial_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgvBusqueda.SelectedCells.Count == 1)
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
            if (dgvBusqueda.SelectedCells.Count == 1)
            {
                Globals.TipoSeleccionarUsuario = 1;
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    try
                    {
                        string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                        string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Entregar/entregar");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                token = Globals.Token,
                                idrecibe = Globals.IdUsernameSelect,
                                idestado = 2, //Prestado
                                idinventario = Int32.Parse(dgvBusqueda.Rows[dgvBusqueda.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString()),
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
                                MessageBox.Show("Entregado");
                                btBuscar_Click(sender, e);
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
                                GlobalFunctions.casoError(ex, "Entregar Documento\n" + reader.ReadToEnd());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoadingScreen.cerrarLoading();
                        GlobalFunctions.casoError(ex, "Entregar Documento\n");
                    }
                }
            }
        }

        private void btRecibir_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.SelectedCells.Count == 1)
            {
                try
                {
                    Globals.TipoSeleccionarUbicacion = 1;
                    SeleccionarUbicacionForm suf = new SeleccionarUbicacionForm();
                    suf.ShowDialog();
                    if (Globals.IdUbicacionSelect > 0)
                    {
                        string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                        string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/ValijaMover");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                token = Globals.Token,
                                idrecibe = Globals.IdUsernameSelect,
                                idestado = 1, //Custodiado
                                idinventario = Int32.Parse(dgvBusqueda.Rows[dgvBusqueda.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString()),
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
                                MessageBox.Show("Recibido");
                                btBuscar_Click(sender, e);
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
                            GlobalFunctions.casoError(ex, "Entregar Documento\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoadingScreen.cerrarLoading();
                    GlobalFunctions.casoError(ex, "Entregar Documento\n");
                }
            }
        }
    }
}
