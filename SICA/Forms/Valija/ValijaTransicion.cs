using Newtonsoft.Json;
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
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SICA.Forms.Valija
{
    public partial class ValijaTransicion : Form
    {
        public ValijaTransicion()
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
                        token = Globals.Token,
                        idubicacion = 7
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
                    dgv.Columns["CONCAT"].Visible = false;
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
                        GlobalFunctions.casoError(ex, "Error Buscar Transicion\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Buscar Transicion");
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
                    string concat = "";
                    concat = row.Cells["CAJA"].Value.ToString() + row.Cells["CODIGO_SOCIO"].Value.ToString() + row.Cells["NOMBRE_SOCIO"].Value.ToString();
                    concat += row.Cells["NUMEROSOLICITUD"].Value.ToString() + row.Cells["DESDE"].Value.ToString() + row.Cells["HASTA"].Value.ToString();
                    
                    if (row.Cells["CONCAT"].Value.ToString() != concat)
                    {
                        string fechadesde, fechahasta;
                        existe = true;

                        try
                        {
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

                            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/guardareditar");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    token = Globals.Token,
                                    idinventario = row.Cells["ID"].Value.ToString(),
                                    numerocaja = row.Cells["CAJA"].Value.ToString(),
                                    fechadesde = fechadesde,
                                    fechahasta = fechahasta,
                                    codigosocio = row.Cells["CODIGO_SOCIO"].Value.ToString(),
                                    nombresocio = row.Cells["NOMBRE_SOCIO"].Value.ToString(),
                                    numerosolicitud = row.Cells["NUMEROSOLICITUD"].Value.ToString(),
                                    usuariocrea = Globals.Username,
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
                                    GlobalFunctions.casoError(ex, "Error Guardar Editar\n" + reader.ReadToEnd());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LoadingScreen.cerrarLoading();
                            GlobalFunctions.casoError(ex, "Error Guardar Editar");
                        }
                    }

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
                                    //idubicacionentrega = 7, //TRANSICION
                                    idubicacionrecibe = 10, //BOVEDA 4
                                    idestado = 1, //Custodiado
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
                    MessageBox.Show("Proceso Finalizado");
                    btActualizar_Click(sender, e);
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
                        GlobalFunctions.casoError(ex, "Error Transicion\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Transicion");
                return;
            }
        }
    }
}
