using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SICA.GlobalFunctions;

namespace SICA.Forms
{
    public partial class ImportarSISGO : Form
    {
        public ImportarSISGO()
        {
            InitializeComponent();
        }

        private void ImportarSISGO_Load(object sender, EventArgs e)
        {
            btImportarActivas.Visible = int2bool(Globals.auImportarActivas);
            btImportarPasivas.Visible = int2bool(Globals.auImportarPasivas);
        }

        private void btImportarCuentasActivas_Click(object sender, EventArgs e)
        {
            int count = 0;
            string strSQL = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV delimitado por comas|*.csv|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //LoadingScreen.iniciarLoading();

                if (!File.Exists(ofd.FileName))
                    return;

                FileInfo fi = new FileInfo(ofd.FileName);
                long filesize = fi.Length;

                System.Data.DataTable dt = new System.Data.DataTable();
                dt = CSVToDataTable(ofd.FileName);

                if (dt is null)
                    return;

                if (dt.Columns[0].ColumnName != "CIP")
                    count++;
                if (dt.Columns[1].ColumnName != "PERSONA")
                    count++;
                if (dt.Columns[2].ColumnName != "NOMBRES")
                    count++;
                if (dt.Columns[3].ColumnName != "PATERNO")
                    count++;
                if (dt.Columns[4].ColumnName != "MATERNO")
                    count++;
                if (dt.Columns[5].ColumnName != "NUMDOC")
                    count++;
                if (dt.Columns[6].ColumnName != "PERIODOSOLICITUD")
                    count++;
                if (dt.Columns[7].ColumnName != "NUMEROSOLICITUD")
                    count++;
                if (dt.Columns[8].ColumnName != "SIP")
                    count++;
                if (dt.Columns[9].ColumnName != "MONTOSOLICITADO")
                    count++;
                if (dt.Columns[10].ColumnName != "MONTOPRESTAMO")
                    count++;
                if (dt.Columns[11].ColumnName != "MONEDA")
                    count++;
                if (dt.Columns[12].ColumnName != "FECHAOTORGADO")
                    count++;
                if (dt.Columns[13].ColumnName != "FECHACANCELADO")
                    count++;
                if (dt.Columns[14].ColumnName != "TIPOPRESTAMO")
                    count++;
                if (dt.Columns[15].ColumnName != "USUARIOREGISTRO")
                    count++;
                if (dt.Columns[16].ColumnName != "PERIODONUMERO")
                    count++;
                if (count == 0)
                {
                    strSQL = "SELECT PERIODOSOLICITUD, NUMEROSOLICITUD FROM ADMIN.SISGO_CUENTASACTIVAS";
                    System.Data.DataTable dtca = new System.Data.DataTable("CuentasActivas");
                    if (!Conexion.conectar())
                        return;

                    if (!Conexion.iniciaCommand(strSQL))
                        return;

                    if (!Conexion.ejecutarQuery())
                        return;

                    dtca = Conexion.llenarDataTable();
                    if (dtca is null)
                        return;
                    
                    //Match dt-dtca
                    var result = from dtEnu in dt.AsEnumerable()
                                 join dtcaEnu in dtca.AsEnumerable()
                                 on new { X1 = dtEnu.Field<string>("PERIODOSOLICITUD"), X2 = dtEnu.Field<string>("NUMEROSOLICITUD") } equals new { X1 = dtcaEnu.Field<string>("PERIODOSOLICITUD"), X2 = dtcaEnu.Field<string>("NUMEROSOLICITUD") }
                                 //on dtEnu.Field<string>("PERIODONUMERO") equals dtcaEnu.Field<string>("PERIODONUMERO_SICA").Trim()
                                 into j
                                 from dtcaEnu in j.DefaultIfEmpty()
                                 where dtcaEnu == null
                                 select new
                                 {
                                     CIP = dtEnu.Field<string>("CIP"),
                                     PERSONA = dtEnu.Field<string>("PERSONA"),
                                     NOMBRES = dtEnu.Field<string>("NOMBRES"),
                                     PATERNO = dtEnu.Field<string>("PATERNO"),
                                     MATERNO = dtEnu.Field<string>("MATERNO"),
                                     NUMDOC = dtEnu.Field<string>("NUMDOC"),
                                     PERIODOSOLICITUD = dtEnu.Field<string>("PERIODOSOLICITUD"),
                                     NUMEROSOLICITUD = dtEnu.Field<string>("NUMEROSOLICITUD"),
                                     SIP = dtEnu.Field<string>("SIP"),
                                     MONTOSOLICITADO = dtEnu.Field<string>("MONTOSOLICITADO"),
                                     MONTOPRESTAMO = dtEnu.Field<string>("MONTOPRESTAMO"),
                                     MONEDA = dtEnu.Field<string>("MONEDA"),
                                     FECHAOTORGADO = dtEnu.Field<string>("FECHAOTORGADO"),
                                     FECHACANCELADO = dtEnu.Field<string>("FECHACANCELADO"),
                                     TIPOPRESTAMO = dtEnu.Field<string>("TIPOPRESTAMO"),
                                     USUARIOREGISTRO = dtEnu.Field<string>("USUARIOREGISTRO")
                                     //,PERIODONUMERO_SICA = (dtcaEnu == null) ? "" : dtcaEnu.Field<string>("PERIODONUMERO")
                                 };

                    dgv.DataSource = result.ToList();
                    //dgv.DataSource = dtca;

                    btCargar.Visible = true;
                    lbCarga.Text = "Activas";
                }
                else
                {
                    //Cuentas Pasivas

                    //Error
                    btCargar.Visible = false;
                    MessageBox.Show("Error");
                }
                
            }
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            int i = 0;
            string strSQL = "";
            bool strNuevo = true;
            int limite = 100;
            if (lbCarga.Text == "Activas")
            {
                LoadingScreen.iniciarLoading();
                for (i = 0; i < dgv.Rows.Count; i++)
                {
                    strSQL = "INSERT INTO ADMIN.SISGO_CUENTASACTIVAS (CIP, PERSONA, NOMBRES, PATERNO, MATERNO, NUMDOC, PERIODOSOLICITUD, NUMEROSOLICITUD, SIP, MONTOSOLICITADO, MONTOPRESTAMO, MONEDA, FECHAOTORGADO, FECHACANCELADO, TIPOPRESTAMO, USUARIOREGISTRO)";
                    strSQL += " SELECT '" + dgv.Rows[i].Cells["CIP"].Value.ToString() + "' AS A1,'" + dgv.Rows[i].Cells["PERSONA"].Value.ToString() + "' AS A2,'" + dgv.Rows[i].Cells["NOMBRES"].Value.ToString().Replace("'", "''") + "' AS A3,'" + dgv.Rows[i].Cells["PATERNO"].Value.ToString().Replace("'", "''") + "' AS A4,'" + dgv.Rows[i].Cells["MATERNO"].Value.ToString().Replace("'", "''") + "' AS A5,'" + dgv.Rows[i].Cells["NUMDOC"].Value.ToString() + "' AS A6,'" + dgv.Rows[i].Cells["PERIODOSOLICITUD"].Value.ToString() + "' AS A7,'" + dgv.Rows[i].Cells["NUMEROSOLICITUD"].Value.ToString() + "' AS A8,'" + dgv.Rows[i].Cells["SIP"].Value.ToString() + "' AS A9,'" + dgv.Rows[i].Cells["MONTOSOLICITADO"].Value.ToString() + "' AS A10,'" + dgv.Rows[i].Cells["MONTOPRESTAMO"].Value.ToString() + "' AS A11,'" + dgv.Rows[i].Cells["MONEDA"].Value.ToString() + "' AS A12," + "TO_DATE('" + dgv.Rows[i].Cells["FECHAOTORGADO"].Value.ToString() + "', 'DD/MM/YYYY HH24:MI:SS') AS A13," + "TO_DATE('" + dgv.Rows[i].Cells["FECHACANCELADO"].Value.ToString() + "', 'DD/MM/YYYY HH24:MI:SS') AS A14,'" + dgv.Rows[i].Cells["TIPOPRESTAMO"].Value.ToString() + "' AS A15,'" + dgv.Rows[i].Cells["USUARIOREGISTRO"].Value.ToString() + "' AS A16 FROM DUAL";
                    strNuevo = false;
                    if (i % limite == 0 && i > 0)
                    {
                        if (!Conexion.conectar())
                           return;

                        if (!Conexion.iniciaCommand(strSQL))
                            return;

                        if (!Conexion.ejecutarQuery())
                            return;
                        strNuevo = true;
                    }

                }
                //Ejecutar ultimos antes del limite
                
                if (!strNuevo)
                {
                    if (!Conexion.conectar())
                        return;

                    if (!Conexion.iniciaCommand(strSQL))
                        return;

                    if (!Conexion.ejecutarQuery())
                        return;
                }
                LoadingScreen.cerrarLoading();
                MessageBox.Show("Carga Completa");
            }
            else if (lbCarga.Text == "Pasivas")
            {

            }
        }

    }
}
