using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms.Pendiente
{
    public partial class PendienteRegularizar : Form
    {
        DataTable lpendientes = new DataTable();
        public PendienteRegularizar()
        {
            InitializeComponent();
            dgv.DoubleBuffered(true);
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            GlobalFunctions.ExportarDGV(dgv, null);
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            try
            {
                LoadingScreen.iniciarLoading();
                dgv.Columns.Clear();
                DataTable dt = new DataTable("BuscarPendiente");

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/buscarpendiente");
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
                    dgv.DataSource = dt;
                    dgv.Columns["ID"].Visible = false;
                    dgv.Columns["PEN_NOMBRE"].Visible = false;
                    dgv.Columns["PEN_DETALLE"].Visible = false;
                    dgv.Columns["PEN_BANCA"].Visible = false;
                    dgv.Columns["CONCAT"].Visible = false;

                    DataGridViewComboBoxColumn dgcpen = new DataGridViewComboBoxColumn();
                    DataGridViewComboBoxColumn dgcdet = new DataGridViewComboBoxColumn();
                    DataGridViewComboBoxColumn dgcban = new DataGridViewComboBoxColumn();

                    if (lpendientes.Rows.Count == 0)
                    {

                        httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listapendientes");
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

                        httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                string result = streamReader.ReadToEnd();
                                lpendientes = JsonConvert.DeserializeObject<DataTable>(result);
                            }
                        }
                    }

                    foreach (DataRow row in lpendientes.Rows)
                    {
                        if (row["TIPO"].ToString() == "1")
                        {
                            dgcpen.Items.Add(row["NOMBRE"].ToString());
                        }
                        else if (row["TIPO"].ToString() == "2")
                        {
                            dgcdet.Items.Add(row["NOMBRE"].ToString());
                        }
                        else if (row["TIPO"].ToString() == "3")
                        {
                            dgcban.Items.Add(row["NOMBRE"].ToString());
                        }
                    }
                    dgcpen.HeaderText = "PENDIENTE";
                    dgcpen.Name = "PENDIENTE";
                    dgv.Columns.Add(dgcpen);
                    dgv.Columns["PENDIENTE"].Width = 120;

                    dgcdet.HeaderText = "DETALLE_PEN";
                    dgcdet.Name = "DETALLE_PEN";
                    dgv.Columns.Add(dgcdet);
                    dgv.Columns["DETALLE_PEN"].Width = 200;
                    //dgv.Columns["DETALLE_PEN"].ReadOnly = false;

                    dgcban.HeaderText = "BANCA";
                    dgcban.Name = "BANCA";
                    dgv.Columns.Add(dgcban);
                    dgv.Columns["BANCA"].Width = 70;

                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.HeaderText = "OK";
                    chk.Name = "OK";
                    chk.ValueType = typeof(bool);
                    dgv.Columns.Add(chk);

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        row.Cells["PENDIENTE"].Value = row.Cells["PEN_NOMBRE"].Value;
                        row.Cells["DETALLE_PEN"].Value = row.Cells["PEN_DETALLE"].Value;
                        row.Cells["BANCA"].Value = row.Cells["PEN_BANCA"].Value;
                    }
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
                        GlobalFunctions.casoError(ex, "Error Buscar Documentos con Pendientes Web\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Buscar Documentos con Pendientes");
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {

            GlobalFunctions.UltimaActividad();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bool existe = false;
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    bool pendienteok = false, modificado = false;
                    string concat = "";
                    if (!(row.Cells["OK"].Value is null))
                    {
                        if (bool.Parse(row.Cells["OK"].Value.ToString()) == true)
                        {
                            pendienteok = true;
                        }
                    }
                    concat = row.Cells["CAJA"].Value.ToString() + row.Cells["CODIGO_SOCIO"].Value.ToString() + row.Cells["NOMBRE_SOCIO"].Value.ToString();
                    concat += row.Cells["NUMEROSOLICITUD"].Value.ToString() + row.Cells["DESDE"].Value.ToString() + row.Cells["HASTA"].Value.ToString();
                    concat += row.Cells["PENDIENTE"].Value.ToString() + row.Cells["DETALLE_PEN"].Value.ToString() + row.Cells["BANCA"].Value.ToString();

                    if (row.Cells["CONCAT"].Value.ToString() != concat)
                    {
                        modificado = true;
                    }

                    if (modificado || pendienteok )
                    {
                        LoadingScreen.iniciarLoading();
                        existe = true;
                        string fechadesde, fechahasta;
                        if (row.Cells["DESDE"].Value.ToString() != "")
                        {
                            fechadesde = DateTime.ParseExact(row.Cells["DESDE"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            fechadesde = "";
                        }
                        if (row.Cells["HASTA"].Value.ToString() != "")
                        {
                            fechahasta = DateTime.ParseExact(row.Cells["HASTA"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            fechahasta = "";
                        }

                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/ActualizarPendiente");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                token = Globals.Token,
                                fecha = fecha,
                                pendienteok = pendienteok,
                                modificado = modificado,
                                idubicacionentrega = 9,
                                idubicacionrecibe = 8,
                                idinventario = row.Cells["ID"].Value.ToString(),
                                numerocaja = row.Cells["CAJA"].Value.ToString(),
                                codigosocio = row.Cells["CODIGO_SOCIO"].Value.ToString(),
                                nombresocio = row.Cells["NOMBRE_SOCIO"].Value.ToString(),
                                numerosolicitud = row.Cells["NUMEROSOLICITUD"].Value.ToString(),
                                fechadesde = fechadesde,
                                fechahasta = fechahasta,
                                fechamodifica = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                pendiente = row.Cells["PENDIENTE"].Value.ToString(),
                                detallepen = row.Cells["DETALLE_PEN"].Value.ToString(),
                                banca = row.Cells["BANCA"].Value.ToString()
                            });
                            streamWriter.Write(json);
                        }

                        HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                string result = streamReader.ReadToEnd();
                            }
                        }
                    }
                }
                if (existe)
                {
                    LoadingScreen.cerrarLoading();
                    //dgv.DataSource = null;
                    //btActualizar_Click(sender, e);
                    MessageBox.Show("Proceso Finalizado");
                }
                else
                {
                    LoadingScreen.cerrarLoading();
                    MessageBox.Show("No hay registros modificados");
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
                        GlobalFunctions.casoError(ex, "Error Regularizar Pendiente Web\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Regularizar Pendiente");
                return;
            }
        }

        private void datagridview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox 
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                if (dgv.CurrentCell.ColumnIndex == 18)
                {
                    if (dgv[dgv.CurrentCell.ColumnIndex - 1, dgv.CurrentCell.RowIndex].Value.ToString() == "OTROS")
                    {
                        cb.DropDownStyle = ComboBoxStyle.DropDown;
                    }
                }
            }
        }
    }
}
