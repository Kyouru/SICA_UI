
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static SICA.GlobalFunctions;

namespace SICA.Forms.Valija
{
    public partial class ValijaNuevo : Form
    {
        public ValijaNuevo()
        {
            GlobalFunctions.UltimaActividad();
            InitializeComponent();

            btIngresoManual.Visible = int2bool(Globals.auValijaManual);
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
                    dt.Columns.Add("STATUS");
                    dt.Columns.Add("NUMERO SOLICITUD");
                    dt.Columns.Add("CODIGO SOCIO");
                    dt.Columns.Add("NOMBRE SOCIO");
                    dt.Columns.Add("PRODUCTO");
                    dt.Columns.Add("DEPARTAMENTO");
                    dt.Columns.Add("DOCUMENTO");
                    dt.Columns.Add("DETALLE");
                    dt.Columns.Add("CLASIFICACION");
                    dt.Columns.Add("CENTRO COSTO");
                    dt.Columns.Add("FECHA DESDE");
                    dt.Columns.Add("FECHA HASTA");
                    dt.Columns.Add("OBSERVACION");
                    dt.Columns.Add("IDDEPARTAMENTO");
                    dt.Columns.Add("IDDOCUMENTO");
                    dt.Columns.Add("IDDETALLE");
                    dt.Columns.Add("IDCLASIFICACION");
                    dt.Columns.Add("IDPRODUCTO");
                    dt.Columns.Add("IDCENTROCOSTO");

                    int cols = 12;
                    //int cols = 12;
                    /*
                    //Listas Concatenada
                    System.Data.DataTable dtconcat = new System.Data.DataTable("Lista Concat");

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaconcat");
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
                            dtconcat = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
                        }
                    }
                    //

                    //Lista Clasificacion
                    System.Data.DataTable dtclasi = new System.Data.DataTable("Lista Clasificacion");

                    httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaclasificacion");
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
                            dtclasi = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
                        }
                    }
                    //

                    //Lista Producto
                    System.Data.DataTable dtprod = new System.Data.DataTable("Lista Produccion");

                    httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaproduccion");
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
                            dtprod = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
                        }
                    }
                    //

                    //Lista Centro Costo
                    System.Data.DataTable dtccosto = new System.Data.DataTable("Lista Centro Costo");

                    httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listacentrocosto");
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
                            dtccosto = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
                        }
                    }
                    */
                    //
                    //DataRow foundRow;
                    Boolean archivovalido = true;
                    for (int row = 1; row <= rows; row++)
                    {
                        if (xlWorkSheet.Cells[row, 1].Text +
                            xlWorkSheet.Cells[row, 2].Text +
                            xlWorkSheet.Cells[row, 3].Text +
                            xlWorkSheet.Cells[row, 4].Text +
                            xlWorkSheet.Cells[row, 5].Text +
                            xlWorkSheet.Cells[row, 6].Text +
                            xlWorkSheet.Cells[row, 7].Text +
                            xlWorkSheet.Cells[row, 8].Text +
                            xlWorkSheet.Cells[row, 9].Text == "")
                        {
                            break;
                        }
                        string dep = "", doc = "", det = "", cla = "", prod = "", ccosto = "", codigosocio = "", nombresocio = "", numerosolicitud = "";
                        //int iddep = -1, iddoc = -1, iddet = -1, idcla = -1, idprod = -1, idccosto = -1;
                        Boolean valido = true;
                        DataRow newrow = dt.NewRow();
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
                                        if (!cellText.Equals("NUMERO SOLICITUD"))
                                        {

                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : NUMERO SOLICITUD");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 2:
                                        if (!cellText.Equals("CODIGO SOCIO"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : CODIGO SOCIO");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 3:
                                        if (!cellText.Equals("NOMBRE SOCIO"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : NOMBRE SOCIO");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 4:
                                        if (!cellText.Equals("PRODUCTO"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : PRODUCTO");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 5:
                                        if (!cellText.Equals("DEPARTAMENTO"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : DEPARTAMENTO");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 6:
                                        if (!cellText.Equals("DOCUMENTO"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : DOCUMENTO");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 7:
                                        if (!cellText.Equals("DETALLE"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : DETALLE");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 8:
                                        if (!cellText.Equals("CLASIFICACION"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : CLASIFICACION");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 9:
                                        if (!cellText.Equals("CENTRO COSTO"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : CENTRO COSTO");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 10:
                                        if (!cellText.Equals("FECHA DESDE"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : FECHA DESDE");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 11:
                                        if (!cellText.Equals("FECHA HASTA"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : FECHA HASTA");
                                            row = 100000;
                                            col = 100000;
                                            valido = false;
                                            archivovalido = false;
                                        }
                                        break;
                                    case 12:
                                        if (!cellText.Equals("OBSERVACION"))
                                        {
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            LoadingScreen.cerrarLoading();
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\r" + cellText + " : OBSERVACION");
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
                                //newrow[0] es para el status
                                newrow[col] = cellText;
                                switch (col)
                                {
                                    case 1:
                                        numerosolicitud = cellText;
                                        break;
                                    case 2:
                                        codigosocio = cellText;
                                        break;
                                    case 3:
                                        nombresocio = cellText;
                                        break;
                                    case 4:
                                        if (cellText == "")
                                        {
                                            //
                                        }
                                        else
                                        {
                                            /*
                                            foundRow = dtprod.Rows.Find(cellText);

                                            if (foundRow != null)
                                            {
                                                //existe
                                                idprod = Int32.Parse(foundRow["ID_PRODUCCION"].ToString());
                                            }
                                            else
                                            {
                                                newrow["STATUS"] = newrow["STATUS"].ToString() + "Produccion no existe;";
                                                valido = false;
                                            }
                                            */
                                            prod = cellText;
                                        }
                                        break;
                                    case 5:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            archivovalido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Departamento Vacío;";
                                        }
                                        else
                                        {
                                            dep = cellText;
                                        }
                                        break;
                                    case 6:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            archivovalido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Documento Vacío;";
                                        }
                                        else
                                        {
                                            doc = cellText;
                                        }
                                        break;
                                    case 7:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            archivovalido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Detalle Vacío;";
                                        }
                                        else
                                        {
                                            det = cellText;
                                        }
                                        break;
                                    case 8:
                                        if (cellText == "")
                                        {
                                            //
                                        }
                                        else
                                        {
                                            /*
                                            foundRow = dtclasi.Rows.Find(cellText);
                                            if (foundRow != null)
                                            {
                                                //existe
                                                idcla = Int32.Parse(foundRow["ID_CLASIFICACION"].ToString());
                                            }
                                            else
                                            {
                                                newrow["STATUS"] = newrow["STATUS"].ToString() + "Clasificacion no existe;";
                                                valido = false;
                                                archivovalido = false;
                                            }
                                            */
                                            cla = cellText;
                                        }
                                        break;
                                    case 9:
                                        if (cellText == "")
                                        {
                                            //
                                        }
                                        else
                                        {
                                            /*
                                            foundRow = dtccosto.Rows.Find(cellText);

                                            if (foundRow != null)
                                            {
                                                //existe
                                                idccosto = Int32.Parse(foundRow["ID_CENTRO_COSTO"].ToString());
                                            }
                                            else
                                            {
                                                newrow["STATUS"] = newrow["STATUS"].ToString() + "Centro Costo no existe;";
                                                valido = false;
                                                archivovalido = false;
                                            }
                                            */
                                            ccosto = cellText;
                                        }
                                        break;
                                    case 10:
                                        if (cellText != "" && !GlobalFunctions.IsDate(newrow["FECHA DESDE"].ToString()))
                                        {
                                            valido = false;
                                            archivovalido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Fecha Desde Invalida;";
                                        }
                                        else if (cellText == "")
                                        {
                                            //concat += ";";
                                        }
                                        else
                                        {
                                            //concat += DateTime.ParseExact(newrow["FECHA DESDE"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + ";";
                                            newrow["FECHA DESDE"] = DateTime.ParseExact(newrow["FECHA DESDE"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                                        }
                                        break;
                                    case 11:
                                        if (cellText != "" && !GlobalFunctions.IsDate(newrow["FECHA HASTA"].ToString()))
                                        {
                                            valido = false;
                                            archivovalido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Fecha Hasta Invalida;";
                                        }
                                        else if (cellText == "")
                                        {
                                            //concat += ";";
                                        }
                                        else
                                        {
                                            //concat += DateTime.ParseExact(newrow["FECHA HASTA"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + ";";
                                            newrow["FECHA HASTA"] = DateTime.ParseExact(newrow["FECHA HASTA"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                                        }
                                        break;
                                }
                                //dep - doc - det
                                /*
                                foundRow = dtconcat.Rows.Find(dep + doc + det);

                                if (foundRow != null)
                                {
                                    //existe
                                    string[] strids = foundRow["ID"].ToString().Split(';');
                                    iddep = Int32.Parse(strids[0]);
                                    iddoc = Int32.Parse(strids[1]);
                                    iddet = Int32.Parse(strids[2]);
                                }
                                else
                                {
                                    newrow["STATUS"] = newrow["STATUS"].ToString() + "Combinacion Departamento-Documento-Detalle no Existe;";
                                    valido = false;
                                }
                                */
                            }
                        }

                        //row == 1 Cabecera
                        if (valido && row > 1)
                        {
                            /*
                            if (expediente)
                            {
                                dep = "NEGOCIOS";
                                doc = "EXPEDIENTE";
                                det = "EXPEDIENTE";
                                newrow["DEPARTAMENTO"] = "NEGOCIOS";
                                newrow["DOCUMENTO"] = "EXPEDIENTE";
                                newrow["DETALLE"] = "EXPEDIENTE";
                            }*/
                            //validar duplicado en Plantilla
                            string concatenado = dep + doc + det + cla + prod + ccosto + codigosocio + nombresocio + numerosolicitud + newrow["FECHA DESDE"] + newrow["FECHA HASTA"];
                            int encontrado = concat.IndexOf(concatenado);
                            if (encontrado > -1)
                            {
                                valido = false;
                                archivovalido = false;
                                newrow["STATUS"] = "Error Duplicado en Excel;";
                            }
                            concat.Add(concatenado);

                            //validar duplicado en BD
                            if (valido)
                            {
                                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/validar");
                                httpWebRequest.ContentType = "application/json";
                                httpWebRequest.Method = "POST";
                                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                {
                                    string json = new JavaScriptSerializer().Serialize(new
                                    {
                                        token = Globals.Token,
                                        strdepartamento = dep,
                                        strdocumento = doc,
                                        strdetalle = det,
                                        strclasificacion = cla,
                                        strproducto = prod,
                                        strcentrocosto = ccosto,
                                        codigosocio = codigosocio,
                                        nombresocio = nombresocio,
                                        numerosolicitud = numerosolicitud,
                                        fechadesde = newrow["FECHA DESDE"],
                                        fechahasta = newrow["FECHA HASTA"]
                                    });

                                    streamWriter.Write(json);
                                }

                                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                if (httpResponse.StatusCode == HttpStatusCode.OK)
                                {
                                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                    {
                                        string result = streamReader.ReadToEnd();
                                        if (!result.Contains("Error"))
                                        {
                                            string[] ids = result.Split(';');
                                            newrow["IDDEPARTAMENTO"] = ids[0];
                                            newrow["IDDOCUMENTO"] = ids[1];
                                            newrow["IDDETALLE"] = ids[2];
                                            newrow["IDCLASIFICACION"] = ids[3];
                                            newrow["IDPRODUCTO"] = ids[4];
                                            newrow["IDCENTROCOSTO"] = ids[5];
                                            newrow["STATUS"] = "OK";
                                        }
                                        else
                                        {
                                            valido = false;
                                            archivovalido = false;
                                            newrow["STATUS"] = result;
                                        }
                                    }
                                }
                            }
                        }
                        if(row > 1)
                        {
                            dt.Rows.Add(newrow);
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

                    dgv.Columns["IDDEPARTAMENTO"].Visible = false;
                    dgv.Columns["IDDOCUMENTO"].Visible = false;
                    dgv.Columns["IDDETALLE"].Visible = false;
                    dgv.Columns["IDCLASIFICACION"].Visible = false;
                    dgv.Columns["IDPRODUCTO"].Visible = false;
                    dgv.Columns["IDCENTROCOSTO"].Visible = false;
                    //dgv.Columns[0].Visible = false;
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
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                    xlWorkBook.Close(0);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                    xlApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                    LoadingScreen.cerrarLoading();
                    GlobalFunctions.casoError(ex, "Error Buscar Cargo");
                }
            }
        }

        private void btCargarValido_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            Globals.TipoSeleccionarUsuario = 1;
            SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
            suf.ShowDialog();
            if (Globals.IdUsernameSelect > 0)
            {
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

                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/agregar");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                token = Globals.Token,
                                idaux = Globals.IdUsernameSelect,
                                idubicacionentrega = 2, //Usuario Externo
                                idubicacionrecibe = 8, //Valija
                                iddocumento = row.Cells["IDDOCUMENTO"].Value.ToString(),
                                iddepartamento = row.Cells["IDDEPARTAMENTO"].Value.ToString(),
                                iddetalle = row.Cells["IDDETALLE"].Value.ToString(),
                                idcentrocosto = row.Cells["IDCENTROCOSTO"].Value.ToString(),
                                idclasificacion = row.Cells["IDCLASIFICACION"].Value.ToString(),
                                idproducto = row.Cells["IDPRODUCTO"].Value.ToString(),
                                fecha = fecha,
                                fechadesde = row.Cells["FECHA DESDE"].Value.ToString(),
                                fechahasta = row.Cells["FECHA HASTA"].Value.ToString(),
                                codigosocio = GlobalFunctions.lCadena(row.Cells["CODIGO SOCIO"].Value.ToString()),
                                nombresocio = GlobalFunctions.lCadena(row.Cells["NOMBRE SOCIO"].Value.ToString()),
                                numerosolicitud = GlobalFunctions.lCadena(row.Cells["NUMERO SOLICITUD"].Value.ToString()),
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
            ValijaManual valijaManual = new ValijaManual();
            valijaManual.ShowDialog();
        }

    }

}
