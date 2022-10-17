
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static SICA.GlobalFunctions;

namespace SICA.Forms.Recibir
{
    public partial class RecibirNuevo : Form
    {
        public RecibirNuevo()
        {
            InitializeComponent();

            btIngresoManual.Visible = int2bool(Globals.auRecibirManual);
        }

        private void btBuscarCargo_Click(object sender, EventArgs e)
        {
            Boolean valido = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Libro de Excel|*.xlsx;*.xls|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadingScreen.iniciarLoading();
                try
                {
                    if (!File.Exists(ofd.FileName))
                        return;

                    FileInfo fi = new FileInfo(ofd.FileName);
                    long filesize = fi.Length;

                    Microsoft.Office.Interop.Excel.Application xlApp;
                    Workbook xlWorkBook;
                    Worksheet xlWorkSheet;
                    Range range;
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
                    //int cols = range.Columns.Count;
                    int cols = 12;

                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("STATUS");
                    dt.Columns.Add("NUMERO CAJA");
                    dt.Columns.Add("CODIGO DEPARTAMENTO");
                    dt.Columns.Add("CODIGO DOCUMENTO");
                    dt.Columns.Add("FECHA DESDE");
                    dt.Columns.Add("FECHA HASTA");
                    dt.Columns.Add("DESCRIPCION 1");
                    dt.Columns.Add("DESCRIPCION 2");
                    dt.Columns.Add("DESCRIPCION 3");
                    dt.Columns.Add("DESCRIPCION 4");
                    dt.Columns.Add("DESCRIPCION 5");
                    dt.Columns.Add("EXPEDIENTE");
                    dt.Columns.Add("PAGARE");
                    dt.Columns.Add("ID DEPARTAMENTO");
                    dt.Columns.Add("ID DOCUMENTO");

                    //Lista Departamento
                    System.Data.DataTable dtdep = new System.Data.DataTable("Lista Departamento");

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadepartamento");
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

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            dtdep = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
                        }
                    }
                    //

                    //
                    System.Data.DataTable dtdoc = new System.Data.DataTable("Lista Documento");

                    httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadocumento");
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
                            dtdoc = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
                        }
                    }
                    //

                    string concat = "";
                    for (int row = 1; row <= rows; row++)
                    {
                        concat = "";
                        DataRow newrow = dt.NewRow();
                        for (int col = 1; col <= cols; col++)
                        {
                            // lectura como cadena
                            string cellText = xlWorkSheet.Cells[row, col].Text;
                            //cellText = Convert.ToString(cellText);
                            //cellText = cellText.Replace("'", ""); // Comillas simples no pueden pasar en el Texto

                            if (row == 1)
                            {
                                switch (col)
                                {
                                    case 1:
                                        if (!cellText.Equals("NUMERO DE CAJA IRON MOUNTAIN"))
                                        {

                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rNUMERO DE CAJA IRON MOUNTAIN");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 2:
                                        if (!cellText.Equals("CODIGO DEPARTAMENTO"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rCODIGO DEPARTAMENTO");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 3:
                                        if (!cellText.Equals("CODIGO DOCUMENTO"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rCODIGO DOCUMENTO");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 4:
                                        if (!cellText.Equals("FECHA DESDE"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rFECHA DESDE");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 5:
                                        if (!cellText.Equals("FECHA HASTA"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rFECHA HASTA");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 6:
                                        if (!cellText.Equals("DESCRIPCION 1"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rDESCRIPCION 1");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 7:
                                        if (!cellText.Equals("DESCRIPCION 2"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rDESCRIPCION 2");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 8:
                                        if (!cellText.Equals("DESCRIPCION 3"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rDESCRIPCION 3");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 9:
                                        if (!cellText.Equals("DESCRIPCION 4"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rDESCRIPCION 4");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 10:
                                        if (!cellText.Equals("DESCRIPCION 5"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rDESCRIPCION 5");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 11:
                                        if (!cellText.Equals("EXPEDIENTE"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rEXPEDIENTE");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                    case 12:
                                        if (!cellText.Equals("PAGARE"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rPAGARE");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                //newrow[0] es para el status
                                newrow[col] = cellText;

                                switch (col)
                                {
                                    case 2:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Departamento Vacío;";
                                        }
                                        else
                                        {
                                            bool existe = false;
                                            foreach (DataRow dtrow in dtdep.Rows)
                                            {
                                                if (dtrow["NOMBRE_DEPARTAMENTO"].ToString() == cellText)
                                                {
                                                    existe = true;
                                                    newrow[13] = dtrow["ID_DEPARTAMENTO"].ToString();
                                                    concat += dtrow["NOMBRE_DEPARTAMENTO"].ToString() + ";";
                                                    break;
                                                }
                                            }
                                            if (!existe)
                                            {
                                                valido = false;
                                                newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Departamento No es Valido;";
                                            }
                                        }
                                        break;
                                    case 3:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Documento Vacío;";
                                        }
                                        else
                                        {
                                            bool existe = false;
                                            foreach (DataRow dtrow in dtdoc.Rows)
                                            {
                                                if (dtrow["NOMBRE_DOCUMENTO"].ToString() == cellText)
                                                {
                                                    existe = true;
                                                    newrow[14] = dtrow["ID_DOCUMENTO"].ToString();
                                                    concat += dtrow["NOMBRE_DOCUMENTO"].ToString() + ";";
                                                    break;
                                                }
                                            }
                                            if (!existe)
                                            {
                                                valido = false;
                                                newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Documento No es Valido;";
                                            }
                                        }
                                        break;
                                    case 4:
                                        if (cellText != "" && !GlobalFunctions.IsDate(newrow["FECHA DESDE"].ToString()))
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Fecha Desde Invalida;";
                                        }
                                        else if (cellText == "")
                                        {
                                            concat += ";";
                                        }
                                        else
                                        {
                                            concat += DateTime.ParseExact(newrow["FECHA DESDE"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + ";";
                                            newrow["FECHA DESDE"] = DateTime.ParseExact(newrow["FECHA DESDE"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                                        }
                                        break;
                                    case 5:
                                        if (cellText != "" && !GlobalFunctions.IsDate(newrow["FECHA HASTA"].ToString()))
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Fecha Hasta Invalida;";
                                        }
                                        else if (cellText == "")
                                        {
                                            concat += ";";
                                        }
                                        else
                                        {
                                            concat += DateTime.ParseExact(newrow["FECHA HASTA"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + ";";
                                            newrow["FECHA HASTA"] = DateTime.ParseExact(newrow["FECHA HASTA"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                                        }
                                        break;
                                    case 6:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Descripcion 1 Vacío;";
                                        }
                                        else
                                        {
                                            concat += cellText + ";";
                                        }
                                        break;
                                    case 7:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Descripcion 2 Vacío;";
                                        }
                                        else
                                        {
                                            concat += cellText + ";";
                                        }
                                        break;
                                    case 8:
                                        concat += cellText + ";";
                                        break;
                                    case 9:
                                        concat += cellText + ";";
                                        break;
                                    case 10:
                                        concat += cellText + ";";
                                        break;
                                }
                                if (valido)
                                {
                                    newrow["STATUS"] = "OK";
                                }
                            }
                        }
                        //row == 1 Cabecera
                        if (row > 1)
                        {
                            //validar duplicado

                            httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/duplicado");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";
                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    token = Globals.Token,
                                    concat = concat
                                });

                                streamWriter.Write(json);
                            }

                            httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                            if (httpResponse.StatusCode == HttpStatusCode.OK)
                            {
                                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                {
                                    string result = streamReader.ReadToEnd();
                                    if (!(Int32.Parse(result) == 0))
                                    {
                                        newrow["STATUS"] = "DUPLICADO";
                                    }
                                    dt.Rows.Add(newrow);
                                }
                            }
                        }
                    }


                    System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                    xlWorkBook.Close(0);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                    xlApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);


                    dgv.DataSource = dt;

                    //dgv.Columns[0].Visible = false;
                    dgv.ClearSelection();

                    if (valido)
                    {
                        btCargarValido.Visible = true;
                    }
                    btCargarValido.Visible = true;
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
                            GlobalFunctions.casoError(ex, "Error Buscar Cargo\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoadingScreen.cerrarLoading();
                    GlobalFunctions.casoError(ex, "Error Buscar Cargo");
                }
            }
        }

        private void btCargarValido_Click(object sender, EventArgs e)
        {
            Globals.TipoSeleccionarUsuario = 0;
            SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
            suf.ShowDialog();
            if (Globals.IdUsernameSelect > 0)
            {
                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                LoadingScreen.iniciarLoading();

                string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                int pagare, expediente;

                try
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["STATUS"].Value.ToString() != "OK")
                        {
                            continue;
                        }

                        if (row.Cells["PAGARE"].Value.ToString() == "SI")
                        {
                            pagare = 1;
                        }
                        else
                        {
                            pagare = 0;
                        }

                        if (row.Cells["EXPEDIENTE"].Value.ToString() == "SI")
                        {
                            expediente = 1;
                        }
                        else
                        {
                            expediente = 0;
                        }

                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/agregar");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                token = Globals.Token,
                                idaux = Globals.IdUsernameSelect,
                                idareaentrega = Globals.IdAreaSelect,
                                idarearecibe = Globals.IdArea,
                                idinventario = Globals.IdInventario,
                                iddocumento = row.Cells["ID DOCUMENTO"].Value.ToString(),
                                iddepartamento = row.Cells["ID DEPARTAMENTO"].Value.ToString(),
                                nomdocumento = row.Cells["CODIGO DOCUMENTO"].Value.ToString(),
                                nomdepartamento = row.Cells["CODIGO DEPARTAMENTO"].Value.ToString(),
                                numerocaja = row.Cells["NUMERO CAJA"].Value.ToString(),
                                fecha = fecha,
                                fechadesde = row.Cells["FECHA DESDE"].Value.ToString(),
                                fechahasta = row.Cells["FECHA HASTA"].Value.ToString(),
                                descripcion1 = GlobalFunctions.lCadena(row.Cells["DESCRIPCION 1"].Value.ToString()),
                                descripcion2 = GlobalFunctions.lCadena(row.Cells["DESCRIPCION 2"].Value.ToString()),
                                descripcion3 = GlobalFunctions.lCadena(row.Cells["DESCRIPCION 3"].Value.ToString()),
                                descripcion4 = GlobalFunctions.lCadena(row.Cells["DESCRIPCION 4"].Value.ToString()),
                                descripcion5 = GlobalFunctions.lCadena(row.Cells["DESCRIPCION 5"].Value.ToString()),
                                expediente = expediente,
                                pagare = pagare,
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

        private void btIngresoManual_Click(object sender, EventArgs e)
        {
            RecibirManual recibirManual = new RecibirManual();
            recibirManual.ShowDialog();
        }

    }

}
