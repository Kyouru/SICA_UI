using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Reflection;
using SICA.Forms;
using SimpleLogger;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using SICA.Clases;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Drawing;
using System.Net.Mail;
using Oracle.ManagedDataAccess.Client;

namespace SICA
{
    public class GlobalFunctions
    {

        public static string sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        public static System.Data.DataTable ConvertExcelToDataTable(string FileName, int index)
        {
            try
            {
                if (!File.Exists(FileName))
                    return null;

                FileInfo fi = new FileInfo(FileName);
                long filesize = fi.Length;

                Microsoft.Office.Interop.Excel.Application xlApp;
                Workbook xlWorkBook;
                Worksheet xlWorkSheet;
                Range range;
                var misValue = Type.Missing;

                // abrir el documento 
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(FileName, misValue, misValue,
                    misValue, misValue, misValue, misValue, misValue, misValue,
                    misValue, misValue, misValue, misValue, misValue, misValue);

                // seleccion de la hoja de calculo
                // get_item() devuelve object y numera las hojas a partir de 1
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(index);

                // seleccion rango activo
                range = xlWorkSheet.UsedRange;

                int rows = range.Rows.Count;

                System.Data.DataTable dt = new System.Data.DataTable();

                int i = 1;

                //no mas de 50 columnas
                while (i < 50 && xlWorkSheet.Cells[1, i].Text != "")
                {
                    dt.Columns.Add(Convert.ToString(xlWorkSheet.Cells[1, i].Text));
                    ++i;
                }
                --i;

                for (int row = 2; row <= rows; row++)
                {
                    DataRow newrow = dt.NewRow();
                    for (int col = 1; col <= i; col++)
                    {
                        // lectura como cadena
                        string cellText = xlWorkSheet.Cells[row, col].Text;
                        cellText = Convert.ToString(cellText);
                        //cellText = cellText.Replace("'", ""); // Comillas simples no pueden pasar en el Texto

                        newrow[col - 1] = cellText;
                    }
                    dt.Rows.Add(newrow);
                }

                xlWorkBook.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();

                // liberar
                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);

                return dt;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "ConvertExcelToDataTable");
                return null;
            }
        }

        public static void ExportarDGV(DataGridView dgv, string fileName)
        {
            ExportarDataGridViewExcel(dgv, fileName);
            //ExportarDataGridViewCSV(dgv, fileName);
        }
        public static void ExportarDataGridViewExcel(DataGridView dgv, string fileName)
        {

            if (dgv.Rows.Count > 3000)
            {
                DialogResult dialogResult = MessageBox.Show("Tabla tiene mas de 3000 filas\nDesea Continuar", "Muchas Filas", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            LoadingScreen.iniciarLoading();
            if (!Directory.Exists(Globals.ExportarPath))
            {
                Directory.CreateDirectory(Globals.ExportarPath);
            }
            if (fileName is null)
            {
                fileName = Globals.ExportarPath + "EXPORTAR_" + Globals.Username + "_" + DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            else
            {
                fileName = Globals.ExportarPath + fileName;
            }

            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                Worksheet xlWorkSheet = null;

                xlWorkSheet = xlWorkBook.Sheets[1];

                xlWorkSheet.EnableCalculation = false;
                xlApp.Calculation = XlCalculation.xlCalculationManual;
                xlApp.ScreenUpdating = false;
                xlWorkSheet.Name = "Exportado";

                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                {
                    xlWorkSheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }

                xlWorkSheet.EnableCalculation = true;
                xlApp.ScreenUpdating = true;
                xlApp.Calculation = XlCalculation.xlCalculationAutomatic;
                xlApp.Visible = true;

                xlWorkBook.SaveAs(fileName, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                LoadingScreen.cerrarLoading();

            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return;
            }
        }

        public static void ExportarDataTableExcel(System.Data.DataTable dt, string nombre_cargo = "", Boolean cabecera = false, string fileName = null)
        {

            if (dt.Rows.Count > 3000)
            {
                DialogResult dialogResult = MessageBox.Show("Tabla tiene mas de 3000 filas\nDesea Continuar", "Muchas Filas", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            if (!Directory.Exists(Globals.ExportarPath))
            {
                Directory.CreateDirectory(Globals.ExportarPath);
            }
            if (fileName is null)
            {
                fileName = Globals.ExportarPath + "EXPORTAR_" + Globals.Username + "_" + DateTime.Now.ToString("yyyyMMddhhmmss");
            }

            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                Worksheet xlWorkSheet = null;


                xlWorkSheet = xlWorkBook.Sheets[1];

                xlWorkSheet.EnableCalculation = false;
                xlApp.Calculation = XlCalculation.xlCalculationManual;
                xlApp.ScreenUpdating = false;


                xlWorkSheet.Name = "Hoja1";

                int offset = 1;
                if (nombre_cargo != "" && cabecera)
                {
                    xlWorkSheet.Cells[2, 2] = Globals.NombreCargo;
                    xlWorkSheet.Cells[2, 4] = "FECHA";
                    xlWorkSheet.Cells[2, 5] = DateTime.Now.ToString("yyyy-MM-dd");
                    offset = 4;
                }
                else
                {
                    offset = 1;
                }
                for (int i = 1; i < dt.Columns.Count + 1; i++)
                {
                    xlWorkSheet.Cells[offset, i] = dt.Columns[i - 1].ColumnName;
                }
                offset++;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        xlWorkSheet.Cells[i + offset, j + 1] = dt.Rows[i][j].ToString();
                    }
                }

                offset--;
                if (nombre_cargo != "" && cabecera)
                {
                    xlWorkSheet.Range["A:A"].ColumnWidth = 0;
                    xlWorkSheet.Range["B:B"].ColumnWidth = 5;
                    xlWorkSheet.Range["C:C"].ColumnWidth = 30;
                    xlWorkSheet.Range["D:D"].ColumnWidth = 16;
                    xlWorkSheet.Range["E:E"].ColumnWidth = 20;
                    xlWorkSheet.Range["F:F"].ColumnWidth = 50;
                    xlWorkSheet.get_Range("B" + offset, "B" + (dt.Rows.Count + offset)).Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("B" + offset, "F" + (dt.Rows.Count + offset)).Borders.LineStyle = XlLineStyle.xlContinuous;
                }

                xlApp.ScreenUpdating = true;
                xlApp.Calculation = XlCalculation.xlCalculationAutomatic;
                xlApp.Visible = true;

                xlWorkBook.SaveAs(fileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return;
            }
        }

        public static void ExportarDataGridViewCSV(DataGridView dgv, string fileName)
        {
            LoadingScreen.iniciarLoading();

            if (!Directory.Exists(Globals.ExportarPath))
            {
                Directory.CreateDirectory(Globals.ExportarPath);
            }
            if (fileName is null)
            {
                fileName = Globals.ExportarPath + "EXPORTAR_" + Globals.Username + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
            }

            try
            {
                string[] outputCsv = new string[dgv.Rows.Count + 1];
                string columnNames = "";
                outputCsv = new string[dgv.Rows.Count + 1];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    columnNames += dgv.Columns[i].HeaderText.ToString() + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                }
                outputCsv[0] += columnNames;

                //Recorremos el DataTable rellenando la hoja de trabajo
                for (int i = 1; (i - 1) <= dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Rows[i - 1].Cells[j] != null)
                        {
                            outputCsv[i] += dgv.Rows[i - 1].Cells[j].Value.ToString() + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                        }
                    }
                }
                File.WriteAllLines(fileName, outputCsv, Encoding.UTF8);

                Process.Start(fileName);

                LoadingScreen.cerrarLoading();

            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return;
            }
        }

        public static void ExportarDataTableCSV(System.Data.DataTable dt, string fileName, string nombre_cargo = "", Boolean cabecera = false)
        {
            LoadingScreen.iniciarLoading();

            if (!Directory.Exists(Globals.ExportarPath))
            {
                Directory.CreateDirectory(Globals.ExportarPath);
            }
            if (fileName is null)
            {
                fileName = Globals.ExportarPath + "EXPORTAR_" + Globals.Username + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
            }

            try
            {
                string[] outputCsv = new string[dt.Rows.Count + 1];
                string columnNames = "";
                int offset = 0;
                if (nombre_cargo != "" && cabecera)
                {
                    outputCsv = new string[dt.Rows.Count + 4];
                    outputCsv[0] = "";
                    outputCsv[1] = nombre_cargo + ",,,FECHA," + DateTime.Now.ToString("yyyy-MM-dd") + ",";
                    outputCsv[2] = "";
                    offset = 3;
                }
                else
                {
                    outputCsv = new string[dt.Rows.Count + 1];
                }
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    columnNames += dt.Columns[i].ColumnName + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                }
                outputCsv[0 + offset] += columnNames;

                //Recorremos el DataTable rellenando la hoja de trabajo
                for (int i = 1; (i - 1) <= dt.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i - 1][j] != null)
                        {
                            outputCsv[i + offset] += dt.Rows[i - 1][j].ToString() + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                        }
                    }
                }
                File.WriteAllLines(fileName, outputCsv, Encoding.UTF8);

                Process.Start(fileName);

                LoadingScreen.cerrarLoading();

            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return;
            }

        }

        public static System.Data.DataTable CSVToDataTable(string path)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string csvData;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    csvData = sr.ReadToEnd().ToString();
                    string[] row = csvData.Split('\n');
                    for (int i = 0; i < row.Length - 1; i++)
                    {
                        string[] rowData = row[i].Split(',');
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < rowData.Length; j++)
                                {
                                    dt.Columns.Add(rowData[j].Trim());
                                }
                            }
                            else
                            {
                                DataRow dr = dt.NewRow();
                                for (int k = 0; k < rowData.Length; k++)
                                {
                                    dr[k] = rowData[k].ToString();
                                }
                                dt.Rows.Add(dr);
                            }
                        }
                    }

                    return dt;
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Leyendo .csv");
                return null;
            }
        }

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool AgregarCarrito(string id_inventario, string id_aux, string caja, string tipocarrito)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Carrito/agregarcarrito");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        idinventario = id_inventario,
                        idaux = id_aux,
                        caja = caja,
                        tipocarrito = tipocarrito
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (result == "OK")
                        return true;
                    else
                    {
                        //GlobalFunctions.casoError(result, "AgregarCarrito");
                        return false;
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
                        GlobalFunctions.casoError(ex, "AgregarCarrito\n" + reader.ReadToEnd());
                    }
                }
                return false;
            }
        }

        public static int CantidadCarrito(string tipocarrito)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Carrito/cantidadcarrito");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        tipocarrito = tipocarrito
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (IsNumeric(result))
                    {
                        return Int32.Parse(result);
                    }
                    else
                    {
                        //GlobalFunctions.casoError(result, "AgregarCarrito");
                        return -1;
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
                        GlobalFunctions.casoError(ex, "CantidadCarrito\n" + reader.ReadToEnd());
                    }
                }
                return -1;
            }
        }
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        public static System.Data.DataTable ToDataTable<T>(List<T> items)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static string SinTildes(string texto)
        {
            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            //Regex reg = new Regex("[^a-zA-Z0-9]");
            //return reg.Replace(textoNormalizado, "");
            return textoNormalizado;
        }

        public static bool LimpiarCarrito(string tipocarrito)
        {
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Carrito/limpiarcarrito");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        tipocarrito = tipocarrito
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (IsNumeric(result))
                    {
                        return true;
                    }
                    else
                    {
                        //GlobalFunctions.casoError(result, "AgregarCarrito");
                        return false;
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
                        GlobalFunctions.casoError(ex, "LimpiarCarrito\n" + reader.ReadToEnd());
                    }
                }
                return false;
            }
        }

        public static void casoError(Exception ex, string strSQL)
        {
            Globals.lastSQL = strSQL;
            SimpleLog.Log(ex);
            LoadingScreen.cerrarLoading();
            if (ex.Message.Contains("ORA-28219:"))
            {
                MessageBox.Show(ex.Message + "\n" + "Contraseña debe tener entre 12 a 30 caracteres, 1 minuscula, 1 mayuscula y 1 numero." + "\n" + "No puede contener el nombre del usuario.");
            }
            else if (ex.Message.Contains("ORA-28007:"))
            {
                MessageBox.Show(ex.Message + "\n" + "No puede repetir la contraseña usada previamente");
            }
            else
            {
                MessageBox.Show(ex.Message + "\n" + strSQL);
            }
        }

        public static bool verificarCaja(string numero_caja, int id_usuario)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Carrito/verificarcarrito");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        numerocaja = numero_caja
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (result == "true")
                    {
                        return true;
                    }
                    else if (result == "false")
                    {
                        //GlobalFunctions.casoError(result, "AgregarCarrito");
                        return false;
                    }
                    else
                    {
                        return false;
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
                        GlobalFunctions.casoError(ex, "verificarCaja\n" + reader.ReadToEnd());
                    }
                }
                return false;
            }
            
        }

        public static int pendienteConfirmarRecepcion()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/pendienteconfirmarrecepcion");
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
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (IsNumeric(result))
                    {
                        return Int32.Parse(result);
                    }
                    else
                    {
                        return -1;
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
                        GlobalFunctions.casoError(ex, "pendienteConfirmarRecepcion\n" + reader.ReadToEnd());
                    }
                }
                return -1;
            }
            
        }

        public static void limpiarTodoCarrito()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Carrito/limpiarcarrito");
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
            }
            catch (WebException ex)
            {
                LoadingScreen.cerrarLoading();
                if (!(ex.Response is null))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        GlobalFunctions.casoError(ex, "limpiarTodoCarrito\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "limpiarTodoCarrito\n");
            }
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to release the object(object:{0})\n" + ex.Message, obj.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public static void cerrarExcel(Workbook xlWorkBook, Worksheet xlWorkSheet, Microsoft.Office.Interop.Excel.Application xlApp)
        {
            try
            {
                ReleaseObject(xlWorkSheet);
                xlWorkBook.Close(true);
                ReleaseObject(xlWorkBook);
                xlApp.Quit();
                ReleaseObject(xlApp);
            }
            catch
            {

            }
        }

        public static string lCadena(string input)
        {
            return input.Replace("'", "''").Trim().TrimEnd('\r', '\n');
        }

        public static bool int2bool(string entero)
        {
            if (entero == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool obtenerToken(string username, string password)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Auth/login");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        username = username,
                        password = password
                    });

                    streamWriter.Write(json);
                }

                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    UserData usuario = JsonConvert.DeserializeObject<UserData>(result);
                    Globals.IdUsername = usuario.IdUser;
                    Globals.Token = usuario.Token;

                    Globals.Busqueda = usuario.Busqueda.ToString();
                    Globals.BusquedaHistorico = usuario.BusquedaHistorico.ToString();
                    Globals.BusquedaEditar = usuario.BusquedaEditar.ToString();
                    Globals.Mover = usuario.Mover.ToString();
                    Globals.MoverExpediente = usuario.MoverExpediente.ToString();
                    Globals.MoverDocumento = usuario.MoverDocumento.ToString();
                    Globals.MoverMasivo = usuario.MoverMasivo.ToString();
                    Globals.Valija = usuario.Valija.ToString();
                    Globals.ValijaNuevo = usuario.ValijaNuevo.ToString();
                    Globals.ValijaReingreso = usuario.ValijaReingreso.ToString();
                    Globals.ValijaConfirmar = usuario.ValijaConfirmar.ToString();
                    Globals.ValijaManual = usuario.ValijaManual.ToString();
                    Globals.Pagare = usuario.Pagare.ToString();
                    Globals.PagareBuscar = usuario.PagareBuscar.ToString();
                    Globals.PagareRecibir = usuario.PagareRecibir.ToString();
                    Globals.PagareEntregar = usuario.PagareEntregar.ToString();
                    Globals.Letra = usuario.Letra.ToString();
                    Globals.LetraNuevo = usuario.LetraNuevo.ToString();
                    Globals.LetraEntregar = usuario.LetraEntregar.ToString();
                    Globals.LetraReingreso = usuario.LetraReingreso.ToString();
                    Globals.LetraBuscar = usuario.LetraBuscar.ToString();
                    Globals.Mantenimiento = usuario.Mantenimiento.ToString();
                    Globals.MantenimientoUsuarioExterno = usuario.MantenimientoUsuarioExterno.ToString();
                    Globals.MantenimientoCredito = usuario.MantenimientoCredito.ToString();
                    Globals.MantenimientoSocio = usuario.MantenimientoSocio.ToString();
                    Globals.MantenimientoListas = usuario.MantenimientoListas.ToString();
                    Globals.Pendiente = usuario.Pendiente.ToString();
                    Globals.PendienteRegularizar = usuario.PendienteRegularizar.ToString();
                    Globals.Reporte = usuario.Reporte.ToString();
                    Globals.ReporteCajas = usuario.ReporteCajas.ToString();
                    Globals.Prestar = usuario.Prestar.ToString();
                    Globals.PrestarPrestar = usuario.PrestarPrestar.ToString();
                    Globals.PrestarRecibir = usuario.PrestarRecibir.ToString();

                    Globals.Nivel = usuario.Nivel.ToString();
                    Globals.Username = username;
                    //Acceso Permitido
                    if (usuario.CambiarPassword == 1 && usuario.AccesoPermitido == 1)
                    {
                        Globals.loginsuccess = 0;
                        CambiarPasswordForm vCambiar = new CambiarPasswordForm();
                        vCambiar.ShowDialog();
                        if (Globals.loginsuccess == 1)
                        {
                            SimpleLog.Info(username + " cambió su contraseña");
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (usuario.AccesoPermitido == 1)
                    {
                        SimpleLog.Info(username + " inicio Session Exitosamente");
                        Globals.loginsuccess = 1;
                        //Cambiar Password
                        return true;
                    }
                    else
                    {
                        Globals.loginsuccess = 0;
                        MessageBox.Show("Acceso no permitido\nContactarse con el Administrador");
                        return false;
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
                        GlobalFunctions.casoError(ex, "obtenerToken\n" + reader.ReadToEnd());
                    }
                }
                else
                {
                    GlobalFunctions.casoError(ex, "obtenerToken\n");
                }
                return false;
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "obtenerToken\n");
                return false;
            }
        }

        public static System.Data.DataTable ObtenerCarrito(string tipocarrito)
        {
            System.Data.DataTable dt = new System.Data.DataTable("OBTENER_CARRITO");
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Carrito/obtenercarrito");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        tipocarrito = tipocarrito
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
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
                        GlobalFunctions.casoError(ex, "ObtenerCarrito\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "ObtenerCarrito\n" + tipocarrito);
            }
            return dt;
        }

        public static void UltimaActividad()
        {
            Globals.UltimaActividad = DateTime.Now;
            //No registra en bd
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string PrestamoDatos(int periodo, int numero)
        {
            string ambiente = "DESA";
            string strconn = "";
            string res = "";
            string strSQL = "SELECT * FROM TABLE(PKG_CUSTODIA.F_OBT_DATOSCREDITO(" + periodo + ", " + numero  + "))";
            try
            {
                Globals.SisgoCIP = "";
                Globals.SisgoNOMBRE = "";
                Globals.SisgoTIPO_PERSONA = "";
                Globals.SisgoPRODUCTO = "";
                strconn = ds.getString(ambiente);

                using (OracleConnection con = new OracleConnection(strconn))
                {
                    con.Open();
                    using (OracleCommand command = new OracleCommand(strSQL, con))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            reader.Read();
                            //Validar que el query ha devuelto alguna fila
                            if (reader.HasRows)
                            {
                                Globals.SisgoCIP = reader.GetString(0);
                                Globals.SisgoNOMBRE = reader.GetString(1);
                                Globals.SisgoTIPO_PERSONA = reader.GetString(2);
                                Globals.SisgoPRODUCTO = reader.GetString(3);
                                res = "OK";
                            }
                            else
                            {
                                res = "NO EXISTE";
                            }
                        }
                        command.Dispose();
                    }
                    con.Close();
                    con.Dispose();
                }
                return res;
            }
            catch (Exception ex)
            {
                return "error:" + ex.Message + res;
            }
        }
    }
}
