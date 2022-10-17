using Microsoft.Office.Interop.Excel;
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

namespace SICA.Forms.Pagare
{
    public partial class PagareRecibir : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strPagareRecibir;

        public PagareRecibir()
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

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDGV(dgv, null);
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            try
            {
                LoadingScreen.iniciarLoading();

                System.Data.DataTable dt = new System.Data.DataTable("Pagares");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Pagare/buscarentregar");
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
                        dt = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[0].Visible = false;
                    dgv.ClearSelection();

                }

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv.SelectedRows.Count == 1)
                {
                    GlobalFunctions.AgregarCarrito("0", dgv.SelectedRows[0].Cells["ID_PAGARE"].Value.ToString(), dgv.SelectedRows[0].Cells["SOLICITUD_SISGO"].Value.ToString(), Globals.strPagareRecibir);
                    btActualizar_Click(sender, e);
                }
            }
        }

        private void btIngresoManual_Click(object sender, EventArgs e)
        {
            PagareManual pagareManual = new PagareManual();
            pagareManual.ShowDialog();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.ShowDialog();
                btActualizar_Click(sender, e);
            }
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strPagareRecibir);
            btActualizar_Click(sender, e);
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.TipoSeleccionarUsuario = 0;
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Pagare/recibir");
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
                        }
                    }
                    btActualizar_Click(sender, e);
                }
            }
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
                Globals.TipoSeleccionarUsuario = 1;
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    LoadingScreen.iniciarLoading();

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
                    int cols = 5;

                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("STATUS");
                    dt.Columns.Add("SOLICITUD SISGO");
                    dt.Columns.Add("CODIGO SOCIO");
                    dt.Columns.Add("NOMBRE");
                    dt.Columns.Add("OBSERVACION ENTREGA");
                    dt.Columns.Add("OBSERVACION RECIBE");

                    for (int row = 1; row <= rows; row++)
                    {
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
                                        if (!cellText.Equals("SOLICITUD SISGO"))
                                        {
                                            LoadingScreen.cerrarLoading();
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            valido = false;
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rSOLICITUD SISGO");
                                            row = 100000;
                                            col = 100000;
                                        }
                                        break;
                                    case 2:
                                        if (!cellText.Equals("CODIGO SOCIO"))
                                        {
                                            LoadingScreen.cerrarLoading();
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            valido = false;
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rCODIGO SOCIO");
                                            row = 100000;
                                            col = 100000;
                                        }
                                        break;
                                    case 3:
                                        if (!cellText.Equals("NOMBRE"))
                                        {
                                            LoadingScreen.cerrarLoading();
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            valido = false;
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rNOMBRE");
                                            row = 100000;
                                            col = 100000;
                                        }
                                        break;
                                    case 4:
                                        if (!cellText.Equals("OBSERVACION ENTREGA"))
                                        {
                                            LoadingScreen.cerrarLoading();
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            valido = false;
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rOBSERVACION ENTREGA");
                                            row = 100000;
                                            col = 100000;
                                        }
                                        break;
                                    case 5:
                                        if (!cellText.Equals("OBSERVACION RECIBE"))
                                        {
                                            LoadingScreen.cerrarLoading();
                                            GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);
                                            valido = false;
                                            MessageBox.Show("Error Cabecera de la Plantilla\rColumna: " + col + "\rOBSERVACION RECIBE");
                                            row = 100000;
                                            col = 100000;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                newrow[col] = cellText;

                                switch (col)
                                {
                                    case 1:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Solicitud Sisgo Vacío;";
                                        }
                                        break;
                                    case 2:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Codigo Socio Vacío;";
                                        }
                                        break;
                                    case 3:
                                        if (cellText == "")
                                        {
                                            valido = false;
                                            newrow["STATUS"] = newrow["STATUS"].ToString() + "Nombre Vacío;";
                                        }
                                        break;
                                }

                                if (valido)
                                {
                                    newrow["STATUS"] = "OK";
                                }
                            }
                        }

                        if (row > 1)
                            dt.Rows.Add(newrow);
                    }

                    GlobalFunctions.cerrarExcel(xlWorkBook, xlWorkSheet, xlApp);

                    if (!valido)
                    {
                        LoadingScreen.cerrarLoading();
                        MessageBox.Show("Se encontro Solicitud/Socio/Nombre vacío");
                        return;
                    }

                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            int nregistrado = 0, nduplicado = 0;
                            foreach (DataRow row in dt.Rows)
                            {

                                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Pagare/registrar");
                                httpWebRequest.ContentType = "application/json";
                                httpWebRequest.Method = "POST";

                                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                {
                                    string json = new JavaScriptSerializer().Serialize(new
                                    {
                                        token = Globals.Token,
                                        idaux = Globals.IdUsernameSelect,
                                        fecha = fecha,
                                        descripcion1 = row["SOLICITUD SISGO"],
                                        descripcion2 = row["CODIGO SOCIO"],
                                        descripcion3 = row["NOMBRE"],
                                        observacion = row["OBSERVACION RECIBE"]
                                    });

                                    streamWriter.Write(json);
                                }

                                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                if (httpResponse.StatusCode == HttpStatusCode.OK)
                                {
                                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                    {
                                        string result = streamReader.ReadToEnd();
                                        LoadingScreen.cerrarLoading();
                                        if (result == "Nuevo")
                                        {
                                            nregistrado++;
                                        }
                                        else if (result == "Duplicado")
                                        {
                                            nduplicado++;
                                        }
                                    }
                                }

                            }

                            LoadingScreen.cerrarLoading();
                            MessageBox.Show(nregistrado + " Registrados\n" + nduplicado + " Duplicados");
                        }
                        catch (WebException ex)
                        {
                            LoadingScreen.cerrarLoading();
                            if (!(ex.Response is null))
                            {
                                using (var stream = ex.Response.GetResponseStream())
                                using (var reader = new StreamReader(stream))
                                {
                                    GlobalFunctions.casoError(ex, "Pagare btBuscarCargo_Click\n" + reader.ReadToEnd());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LoadingScreen.cerrarLoading();
                            GlobalFunctions.casoError(ex, "Pagare btBuscarCargo_Click");
                        }
                        
                    }
                }
            }
        }
    }
}
