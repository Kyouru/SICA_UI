using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpCompress.Common;
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
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SICA.Forms.Pendiente
{
    public partial class PendienteRegularizar : Form
    {
        DataTable lpendientes = new DataTable();
        AutoCompleteStringCollection ascdet = new AutoCompleteStringCollection();
        DataGridViewComboBoxCell cbdet = new DataGridViewComboBoxCell();
        public PendienteRegularizar()
        {
            InitializeComponent();
            dgv.DoubleBuffered(true);
        }

        private void PendienteRegularizar_Load(object sender, EventArgs e)
        {
            //btActualizar_Click(sender, e);
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgv.Rows.Count > 0)
            {
                GlobalFunctions.ExportarDGV(dgv, null);
            }
            else
            {
                MessageBox.Show("No hay Registros");
            }
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
                //httpWebRequest.ContentType = "application/json";
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
                        //httpWebRequest.ContentType = "application/json";
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
                                lpendientes = JsonConvert.DeserializeObject<DataTable>(result);
                            }
                        }
                    }

                    ascdet.Clear();
                    cbdet.Items.Clear();
                    foreach (DataRow row in lpendientes.Rows)
                    {
                        if (row["TIPO"].ToString() == "1")
                        {
                            dgcpen.Items.Add(row["NOMBRE"].ToString());
                        }
                        else if (row["TIPO"].ToString() == "2")
                        {
                            dgcdet.Items.Add(row["NOMBRE"].ToString());
                            cbdet.Items.Add(row["NOMBRE"].ToString());
                            ascdet.Add(row["NOMBRE"].ToString());
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
                    dgcdet.ReadOnly = false;
                    dgv.Columns.Add(dgcdet);
                    dgv.Columns["DETALLE_PEN"].Width = 200;
                    dgv.Columns["DETALLE_PEN"].ReadOnly = false;

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
                        if (!dgcdet.Items.Contains(row.Cells["PEN_DETALLE"].Value))
                        {
                            row.Cells["DETALLE_PEN"] = new DataGridViewTextBoxCell();
                            //dgcdet.Items.Add(row.Cells["PEN_DETALLE"].Value);
                        }
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
                    int ubicacionrecibe = 8;
                    string concat = "";
                    concat = row.Cells["CAJA"].Value.ToString() + row.Cells["CODIGO_SOCIO"].Value.ToString() + row.Cells["NOMBRE_SOCIO"].Value.ToString();
                    concat += row.Cells["NUMEROSOLICITUD"].Value.ToString() + row.Cells["DESDE"].Value.ToString() + row.Cells["HASTA"].Value.ToString();
                    concat += row.Cells["PENDIENTE"].Value.ToString() + row.Cells["DETALLE_PEN"].Value.ToString() + row.Cells["BANCA"].Value.ToString();

                    if (row.Cells["CONCAT"].Value.ToString() != concat)
                    {
                        modificado = true;
                        ubicacionrecibe = 9;
                    }

                    if (!(row.Cells["OK"].Value is null))
                    {
                        if (bool.Parse(row.Cells["OK"].Value.ToString()) == true)
                        {
                            pendienteok = true;
                            ubicacionrecibe = 7; //Transicion 7
                        }
                    }

                    if (modificado || pendienteok)
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
                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                fecha = fecha,
                                pendienteok = pendienteok,
                                modificado = modificado,
                                idubicacionentrega = 9, //PENDIENTE
                                idubicacionrecibe = ubicacionrecibe,  //TRANSICION 7 o PENDIENTE 9
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
                    dgv.Columns.Clear();
                    MessageBox.Show("Proceso Finalizado");
                    btActualizar_Click(sender, e);
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
            /*
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox 
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
            */
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            /*
            if (dgv.CurrentCell.ColumnIndex == 18)
            {
                if (dgv[17, dgv.CurrentCell.RowIndex].Value.ToString() == "OTROS")
                {
                    TextBox prodCode = e.Control as TextBox;
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodCode.AutoCompleteCustomSource = ascdet;
                        prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }
                else
                {

                }
            }
            */
            /*
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                if (dgv.CurrentCell.ColumnIndex == 18)
                {
                    if (dgv[dgv.CurrentCell.ColumnIndex - 1, dgv.CurrentCell.RowIndex].Value.ToString() == "OTROS")
                    {
                        cb.DropDownStyle = ComboBoxStyle.DropDown;
                        cb.Text = otrosvalue;
                    }
                }
            }
            */
        }

        private void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            /*
            // Check if the column is the combobox column
            if (e.ColumnIndex == 18)
            {
                DataGridViewComboBoxCell cboCell = (DataGridViewComboBoxCell)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string value = cboCell.EditedFormattedValue.ToString();
                // Check if the entered value is in the data source
                if (!cboCell.Items.Contains(value))
                {
                    // Add the value to the data source
                    cboCell.Items.Add(value);
                    otrosvalue = value;
                    cboCell.Value = value;
                }
            }
            */
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //return;
        }

        private void btCajaMasivo_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgv.SelectedCells.Count > 1)
            {
                string numerocaja = Microsoft.VisualBasic.Interaction.InputBox("Escriba el numero de caja:", "Numero de Caja", "");
                bool actualizado = false;
                LoadingScreen.iniciarLoading();
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    try
                    {
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/guardareditar");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                idinventario = row.Cells["ID"].Value.ToString(),
                                numerocaja = numerocaja,
                                fechamodifica = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            });
                            streamWriter.Write(json);
                        }

                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                string result = streamReader.ReadToEnd();
                                actualizado = true;
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
                                GlobalFunctions.casoError(ex, "Error Caja Masiva\n" + reader.ReadToEnd());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoadingScreen.cerrarLoading();
                        GlobalFunctions.casoError(ex, "Error Caja Masiva");
                    }
                }
                if (actualizado)
                {
                    LoadingScreen.cerrarLoading();
                    MessageBox.Show("Actualizado");
                    btActualizar_Click(sender, e);
                }
            }
        }

        private void dgv_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 17)
                {
                    string prevalue = dgv[18, dgv.CurrentCell.RowIndex].Value.ToString();
                    //MessageBox.Show(dgv[17, dgv.CurrentCell.RowIndex].Value.ToString());
                    if (dgv[17, dgv.CurrentCell.RowIndex].Value.ToString() == "OTROS")
                    {
                        dgv[18, dgv.CurrentCell.RowIndex] = new DataGridViewTextBoxCell();
                    }
                    else
                    {
                        DataGridViewComboBoxCell newcbdet = new DataGridViewComboBoxCell();
                        foreach (var cbi in cbdet.Items)
                        {
                            newcbdet.Items.Add(cbi.ToString());
                        }
                        dgv[18, dgv.CurrentCell.RowIndex] = newcbdet;
                        dgv[18, dgv.CurrentCell.RowIndex].Value = prevalue;
                    }
                }
            }
            catch
            {

            }
        }
    }
}
