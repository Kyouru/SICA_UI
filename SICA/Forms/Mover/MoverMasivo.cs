
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms.Entregar
{
    public partial class MoverMasivo : Form
    {

        public MoverMasivo()
        {
            GlobalFunctions.UltimaActividad();
            InitializeComponent();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            //GlobalFunctions.ExportarDataGridViewCSV(dgv, null);
            GlobalFunctions.ExportarDGV(dgv, null);
        }


        private void btBuscarCargo_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Libro de Excel|*.xlsx;*.xls|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadingScreen.iniciarLoading();
                Workbook xlWorkBook = null;
                Worksheet xlWorkSheet = null;
                Range range = null;
                Microsoft.Office.Interop.Excel.Application xlApp = null;
                try
                {
                    if (!File.Exists(ofd.FileName))
                        return;

                    FileInfo fi = new FileInfo(ofd.FileName);
                    long filesize = fi.Length;

                    var misValue = Type.Missing;

                    // abrir el documento 
                    xlApp = new Microsoft.Office.Interop.Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(ofd.FileName, misValue, misValue,
                        misValue, misValue, misValue, misValue, misValue, misValue,
                        misValue, misValue, misValue, misValue, misValue, misValue);

                    // seleccion de la hoja de calculo
                    // get_item() devuelve object y numera las hojas a partir de 1
                    xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    // seleccion rango activo
                    range = xlWorkSheet.UsedRange;

                    int rows = range.Rows.Count;
                    List<string> concat = new List<string>();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("ID_UBICACIONORIGEN");
                    dt.Columns.Add("ID_UBICACIONDESTINO");
                    dt.Columns.Add("STATUS");
                    dt.Columns.Add("ESTADO");
                    dt.Columns.Add("NUMEROCAJA");
                    dt.Columns.Add("ORIGEN");
                    dt.Columns.Add("DESTINO");
                    dt.Columns.Add("DEPARTAMENTO");
                    dt.Columns.Add("DOCUMENTO");
                    dt.Columns.Add("DETALLE");
                    dt.Columns.Add("FECHA DESDE");
                    dt.Columns.Add("FECHA HASTA");
                    dt.Columns.Add("CODIGO");
                    dt.Columns.Add("NOMBRE");
                    dt.Columns.Add("PRODUCTO");
                    dt.Columns.Add("NUMEROSOLICITUD");

                    int cols = 13;
                    
                    bool archivovalido = true, ignorarorigen = false, ignorarestado = false;
                    for (int row = 1; row <= rows; row++)
                    {
                        if (xlWorkSheet.Cells[row, 1].Text +
                            xlWorkSheet.Cells[row, 2].Text == "")
                        {
                            break;
                        }
                        bool valido = true;
                        string numerocaja = "", ubicacion = "";
                        
                        for (int col = 1; col <= cols; col++)
                        {
                            // lectura como cadena
                            string cellText = xlWorkSheet.Cells[row, col].Text;
                            //pagare = false;
                            //cellText = Convert.ToString(cellText);
                            //cellText = cellText.Replace("'", ""); // Comillas simples no pueden pasar en el Texto

                            if (row == 1)
                            {
                                switch (col)
                                {
                                    case 1:
                                        if (!cellText.Equals("NUMERO DE CAJA"))
                                        {

                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : NUMERO DE CAJA");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 2:
                                        if (!cellText.Equals("NUEVA UBICACION"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : NUEVA UBICACION");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (col)
                                {
                                    case 1:
                                        if (cellText != "")
                                            numerocaja = cellText;
                                        else
                                            valido = false;
                                        break;
                                    case 2:
                                        if (cellText != "")
                                            ubicacion = cellText;
                                        else
                                            valido = false;
                                        break;
                                }
                            }
                        }

                        //row == 1 Cabecera
                        if (valido && row > 1)
                        {
                            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/validarubicacion");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";
                            httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);
                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    strubicacion = ubicacion
                                });

                                streamWriter.Write(json);
                            }

                            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                            if (httpResponse.StatusCode == HttpStatusCode.OK)
                            {
                                //Ubicacion Valida
                                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                {

                                    string result = streamReader.ReadToEnd();
                                    int idubicacion;
                                    try
                                    {
                                        idubicacion = Int32.Parse(result);

                                        var httpWebRequest2 = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/obtenercaja");
                                        httpWebRequest2.ContentType = "application/json";
                                        httpWebRequest2.Method = "POST";
                                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);
                                        using (var streamWriter = new StreamWriter(httpWebRequest2.GetRequestStream()))
                                        {
                                            string json = new JavaScriptSerializer().Serialize(new
                                            {
                                                numerocaja = numerocaja
                                            });

                                            streamWriter.Write(json);
                                        }

                                        var httpResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
                                        if (httpResponse2.StatusCode == HttpStatusCode.OK)
                                        {
                                            using (var streamReader2 = new StreamReader(httpResponse2.GetResponseStream()))
                                            {
                                                result = streamReader2.ReadToEnd();
                                                string primerestado = "", primeraubicacion = "";
                                                bool estadodif = false, ubicaciondif = false;
                                                int i = 0;
                                                System.Data.DataTable dt2 = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
                                                foreach (DataRow row2 in dt2.Rows)
                                                {
                                                    if (i == 0)
                                                    {
                                                        primerestado = row2["ESTADO"].ToString();
                                                        primeraubicacion = row2["UBICACION"].ToString();
                                                        i++;
                                                    }
                                                    else
                                                    {
                                                        if (primerestado != row2["ESTADO"].ToString())
                                                        {
                                                            estadodif = true;
                                                        }
                                                        if (primeraubicacion != row2["UBICACION"].ToString())
                                                        {
                                                            ubicaciondif = true;
                                                        }
                                                    }
                                                }
                                                foreach (DataRow row2 in dt2.Rows)
                                                {
                                                    DataRow newrow = dt.NewRow();
                                                    if (estadodif && !ignorarestado)
                                                    {
                                                        newrow["STATUS"] = "Estado Diferente entre la Caja";
                                                    }
                                                    else if (ubicaciondif && !ignorarorigen)
                                                    {
                                                        newrow["STATUS"] = "Ubicacion Diferente entre la Caja";
                                                    }
                                                    else if (row2["ID_UBICACION"].ToString() == idubicacion.ToString())
                                                    {
                                                        newrow["STATUS"] = "Ubicacion Origen es igual al Destino";
                                                    }
                                                    else
                                                    {
                                                        newrow["STATUS"] = "OK";
                                                    }
                                                    newrow["ID"] = row2["ID"].ToString();
                                                    newrow["ID_UBICACIONORIGEN"] = row2["ID_UBICACION"].ToString();
                                                    newrow["ID_UBICACIONDESTINO"] = idubicacion;
                                                    newrow["ESTADO"] = row2["ESTADO"].ToString();
                                                    newrow["NUMEROCAJA"] = numerocaja;
                                                    newrow["ORIGEN"] = row2["UBICACION"].ToString();
                                                    newrow["DESTINO"] = ubicacion;
                                                    newrow["DEPARTAMENTO"] = row2["DEPARTAMENTO"].ToString();
                                                    newrow["DOCUMENTO"] = row2["DOCUMENTO"].ToString();
                                                    newrow["DETALLE"] = row2["DETALLE"].ToString();
                                                    newrow["FECHA DESDE"] = row2["DESDE"].ToString();
                                                    newrow["FECHA HASTA"] = row2["HASTA"].ToString();
                                                    newrow["CODIGO"] = row2["CODIGO"].ToString();
                                                    newrow["NOMBRE"] = row2["NOMBRE"].ToString();
                                                    newrow["PRODUCTO"] = row2["PRODUCTO"].ToString();
                                                    newrow["NUMEROSOLICITUD"] = row2["NUMEROSOLICITUD"].ToString();

                                                    dt.Rows.Add(newrow);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            archivovalido = false;
                                            DataRow newrow = dt.NewRow();
                                            newrow["STATUS"] = "Error Caja no encontrada";
                                            newrow["NUMEROCAJA"] = numerocaja;
                                            dt.Rows.Add(newrow);
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
                                                archivovalido = false;
                                                DataRow newrow = dt.NewRow();
                                                newrow["STATUS"] = ex.Message + "\n" + reader.ReadToEnd();
                                                newrow["NUMEROCAJA"] = numerocaja;
                                                dt.Rows.Add(newrow);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        archivovalido = false;
                                        DataRow newrow = dt.NewRow();
                                        newrow["STATUS"] = ex.Message;
                                        newrow["NUMEROCAJA"] = numerocaja;
                                        dt.Rows.Add(newrow);
                                    }
                                }
                            }
                            else
                            {
                                archivovalido = false;
                                DataRow newrow = dt.NewRow();
                                newrow["STATUS"] = "Error Ubicacion no existe";
                                newrow["NUMEROCAJA"] = numerocaja;
                                dt.Rows.Add(newrow);
                            }
                        }
                    }

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                    xlWorkBook.Close(0);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                    xlApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);


                    dgv.Columns.Clear();
                    dgv.DataSource = dt;

                    dgv.Columns["ID"].Visible = false;
                    dgv.Columns["ID_UBICACIONORIGEN"].Visible = false;
                    dgv.Columns["ID_UBICACIONDESTINO"].Visible = false;

                    dgv.ClearSelection();

                    if (archivovalido)
                    {
                        btCargarValido.Visible = true;
                    }
                    LoadingScreen.cerrarLoading();
                }
                catch (WebException ex)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                    xlWorkBook.Close(0);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                    xlApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                    LoadingScreen.cerrarLoading();
                    if (!(ex.Response is null))
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        using (var reader = new StreamReader(stream))
                        {
                            GlobalFunctions.casoError(ex, "Error Buscar Cargo\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                        xlWorkBook.Close(0);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                        xlApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                    }
                    catch
                    {

                    }
                    LoadingScreen.cerrarLoading();
                    GlobalFunctions.casoError(ex, "Error Buscar Cargo");
                }
            }
        }

        private void btCargarValido_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            //string observacion = "";
            string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

            LoadingScreen.iniciarLoading();

            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["STATUS"].Value.ToString() != "OK")
                    {
                        continue;
                    }

                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Entregar/entregar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            idinventario = row.Cells["ID"].Value.ToString(),
                            idestado = 1, //Custodiado
                            idubicacionrecibe = row.Cells["ID_UBICACIONDESTINO"].Value.ToString(),
                            fecha = fecha,
                            observacion = GlobalFunctions.lCadena(observacion)
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

                LoadingScreen.cerrarLoading();

                MessageBox.Show("Proceso Finalizado");
                dgv.DataSource = null;
            }
            catch (WebException ex)
            {
                LoadingScreen.cerrarLoading();
                if (!(ex.Response is null))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        GlobalFunctions.casoError(ex, "btCargarValido_Click\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "btCargarValido_Click");
                return;
            }
        }
    }
}
