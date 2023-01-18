using Newtonsoft.Json;
using SICA.Forms;
using SICA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms.Recibir
{
    public partial class RecibirOK : Form
    {
        public RecibirOK()
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
                dgv.Columns.Clear();
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
                    dgv.Columns["ID"].Visible = false;
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.HeaderText = "OK";
                    chk.Name = "OK";
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
                        GlobalFunctions.casoError(ex, "Error Buscar Documentos Valija\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Buscar Documentos Valija");
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
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bool existe = false;
            try
            {
                LoadingScreen.iniciarLoading();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!(row.Cells["OK"].Value is null))
                    {
                        if (bool.Parse(row.Cells["OK"].Value.ToString()) == true)
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
                                    idubicacionrecibe = 10,
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
                            GlobalFunctions.casoError(ex, "Error Valija OK Web\n" + reader.ReadToEnd());
                        }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Valija OK");
                return;
            }
        }
    }
}
