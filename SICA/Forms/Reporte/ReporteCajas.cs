using FontAwesome.Sharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms.Reporte
{
    public partial class ReporteCajas : Form
    {
        public ReporteCajas()
        {
            InitializeComponent();
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            LoadingScreen.iniciarLoading();

            DataTable dt = new DataTable("DOCUMENTOS");
            DataTable dt2 = new DataTable("CAJADOCUMENTOS");

            dt.Columns.Add("ESTADO");
            dt.Columns.Add("UBICACION");
            dt.Columns.Add("CAJA");
            dt.Columns.Add("DEPARTAMENTO");
            dt.Columns.Add("DESDE");
            dt.Columns.Add("HASTA");
            dt.Columns.Add("DOCUMENTO");
            dt.Columns.Add("DETALLE");
            dt.Columns.Add("NUMEROSOLICITUD");
            dt.Columns.Add("CODIGO");
            dt.Columns.Add("NOMBRE");
            dt.Columns.Add("CLASIFICACION");
            dt.Columns.Add("PRODUCTO");

            using (System.IO.StringReader reader = new System.IO.StringReader(tbCargoCajas.Text))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    if (linea != "")
                    {
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/buscar");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                numerocaja = linea
                            });

                            streamWriter.Write(json);
                        }

                        HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                string result = streamReader.ReadToEnd();
                                dt2 = JsonConvert.DeserializeObject<DataTable>(result);
                                foreach (DataRow row in dt2.Rows)
                                {
                                    DataRow newrow = dt.NewRow();

                                    newrow["ESTADO"] = row["ESTADO"].ToString();
                                    newrow["UBICACION"] = row["UBICACION"].ToString();
                                    newrow["CAJA"] = row["CAJA"].ToString();
                                    newrow["DEPARTAMENTO"] = row["DEPARTAMENTO"].ToString();
                                    newrow["DESDE"] = row["DESDE"].ToString();
                                    newrow["HASTA"] = row["HASTA"].ToString();
                                    newrow["DOCUMENTO"] = row["DOCUMENTO"].ToString();
                                    newrow["DETALLE"] = row["DETALLE"].ToString();
                                    newrow["NUMEROSOLICITUD"] = row["NUMEROSOLICITUD"].ToString();
                                    newrow["CODIGO"] = row["CODIGO"].ToString();
                                    newrow["NOMBRE"] = row["NOMBRE"].ToString();
                                    newrow["CLASIFICACION"] = row["CLASIFICACION"].ToString();
                                    newrow["PRODUCTO"] = row["PRODUCTO"].ToString();

                                    dt.Rows.Add(newrow);
                                }
                            }
                        }
                    }
                }
            }

            try
            {
                GlobalFunctions.ExportarDataTableCSV(dt, Globals.ExportarPath + "CARGO_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".csv");

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Error Exportar");
                return;
            }
        }
    }
}
