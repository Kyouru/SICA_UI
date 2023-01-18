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

namespace SICA.Forms.Recibir
{
    public partial class RecibirPendiente : Form
    {
        public RecibirPendiente()
        {
            GlobalFunctions.UltimaActividad();
            InitializeComponent();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable("BuscarValija");

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/buscarvalija");
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
                    dgv.Columns[0].Visible = false;
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.HeaderText = "PENDIENTE";
                    chk.Name = "PENDIENTE";
                    chk.ValueType = typeof(bool);
                    dgv.Columns.Add(chk);
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
                        GlobalFunctions.casoError(ex, "Error Buscar Confirmaciones Pendientes\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Buscar Confirmaciones Pendientes");
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            GlobalFunctions.ExportarDGV(dgv, null);
        }


        private void btSiguiente_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            bool existe = false;
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                LoadingScreen.iniciarLoading();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!(row.Cells["PENDIENTE"].Value is null))
                    {
                        if (bool.Parse(row.Cells["PENDIENTE"].Value.ToString()) == true)
                        {
                            existe = true;
                            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/ValijaMover");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    token = Globals.Token,
                                    idubicacionentrega = 8,
                                    idubicacionrecibe = 9,
                                    fecha = fecha,
                                    idinventario = row.Cells["ID"].Value.ToString()
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
                }
                if (existe)
                {
                    LoadingScreen.cerrarLoading();
                    dgv.Columns.Clear();
                    //dgv.DataSource = null;
                    //btActualizar_Click(sender, e);
                    MessageBox.Show("Proceso Finalizado");
                }
                else
                {
                    LoadingScreen.cerrarLoading();
                    MessageBox.Show("No hay registros seleccionados");
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
                        GlobalFunctions.casoError(ex, "Error Valija Pendiente\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Valija Pendiente");
                return;
            }
        }
    }
}
