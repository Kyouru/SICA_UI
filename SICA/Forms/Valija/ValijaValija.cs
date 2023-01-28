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
using System.Globalization;
using SICA.Forms.Busqueda;

namespace SICA.Forms.Valija
{
    public partial class ValijaValija : Form
    {
        public ValijaValija()
        {
            GlobalFunctions.UltimaActividad();
            InitializeComponent();
            dgv.DoubleBuffered(true);
        }

        private void ValijaValija_Load(object sender, EventArgs e)
        {
            btActualizar_Click(sender, e);
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
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        idubicacion = 8
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

                    DataGridViewCheckBoxColumn chkOK = new DataGridViewCheckBoxColumn();
                    chkOK.HeaderText = "OK";
                    chkOK.Name = "OK";
                    chkOK.ValueType = typeof(bool);
                    dgv.Columns.Add(chkOK);

                    DataGridViewCheckBoxColumn chkPen = new DataGridViewCheckBoxColumn();
                    chkPen.HeaderText = "PENDIENTE";
                    chkPen.Name = "PENDIENTE";
                    chkPen.ValueType = typeof(bool);
                    dgv.Columns.Add(chkPen);
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
            if (dgv.Rows.Count > 0)
            {
                GlobalFunctions.ExportarDGV(dgv, null);
            }
            else
            {
                MessageBox.Show("No hay Registros");
            }
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
                    bool valijaok = false, valijapendiente = false, modificado = false;
                    int ubicacionrecibe = 8; //VALIJA

                    string concat = "";
                    concat = row.Cells["CAJA"].Value.ToString() + row.Cells["CODIGO_SOCIO"].Value.ToString() + row.Cells["NOMBRE_SOCIO"].Value.ToString();
                    concat += row.Cells["NUMEROSOLICITUD"].Value.ToString() + row.Cells["DESDE"].Value.ToString() + row.Cells["HASTA"].Value.ToString();

                    if (row.Cells["CONCAT"].Value.ToString() != concat)
                    {
                        modificado = true;
                        ubicacionrecibe = 8; //VALIJA
                    }

                    if (!(row.Cells["OK"].Value is null))
                    {
                        if (bool.Parse(row.Cells["OK"].Value.ToString()) == true)
                        {
                            valijaok = true;
                            ubicacionrecibe = 10; //BOVEDA 4
                        }
                    }

                    if (!(row.Cells["PENDIENTE"].Value is null))
                    {
                        if (bool.Parse(row.Cells["PENDIENTE"].Value.ToString()) == true)
                        {
                            valijapendiente = true;
                            ubicacionrecibe = 9; //PENDIENTE
                        }
                    }

                    if (modificado)
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
                            httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                /*
                                int iddepartamento = Int32.Parse(cmbDepartamento.SelectedValue.ToString());
                                int iddocumento = Int32.Parse(cmbDocumento.SelectedValue.ToString());
                                int iddetalle = Int32.Parse(cmbDetalle.SelectedValue.ToString());
                                int idcentrocosto = -1;
                                int idclasificacion = -1;
                                int idproducto = -1;

                                try
                                {
                                    idcentrocosto = Int32.Parse(cmbCentroCosto.SelectedValue.ToString());
                                }
                                catch
                                {
                                    idcentrocosto = -1;
                                }
                                try
                                {
                                    idclasificacion = Int32.Parse(cmbClasificacion.SelectedValue.ToString());
                                }
                                catch
                                {
                                    idclasificacion = -1;
                                }
                                try
                                {
                                    idproducto = Int32.Parse(cmbProducto.SelectedValue.ToString());
                                }
                                catch
                                {
                                    idproducto = -1;
                                }
                                */
                                string json = new JavaScriptSerializer().Serialize(new
                                {
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

                    if (valijapendiente || valijaok)
                    {
                        existe = true;
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/recibir");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                //idubicacionentrega = 8, //VALIJA
                                idubicacionrecibe = ubicacionrecibe,
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

        private void btCajaMasivo_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (dgv.SelectedCells.Count > 1)
            {
                string numerocaja = Microsoft.VisualBasic.Interaction.InputBox("Escriba el numero de caja:", "Numero de Caja", "");
                bool actualizado = false;
                LoadingScreen.iniciarLoading();
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    try
                    {
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/guardareditar");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                idinventario = row.Cells["ID"].Value.ToString(),
                                numerocaja = numerocaja,
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
                                actualizado = true;
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
                                GlobalFunctions.casoError(ex, "Error Caja Masiva\n" + reader.ReadToEnd());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoadingScreen.cerrarLoading();
                        GlobalFunctions.casoError(ex, "Error Caja Masiva");
                    }
                }
                if (actualizado)
                {
                    LoadingScreen.cerrarLoading();
                    MessageBox.Show("Actualizado");
                    btActualizar_Click(sender, e);
                }
            }
        }
    }
}
