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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SICA.Forms.Mantenimiento
{
    public partial class MantenimientoCentroCosto : Form
    {
        public MantenimientoCentroCosto()
        {
            InitializeComponent();
        }

        private void MantenimientoListas_Load(object sender, EventArgs e)
        {
            CentroCostoLoad();
        }
        private void CentroCostoLoad()
        {
            try
            {
                DataTable dt = new DataTable("Lista Centro Costo");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listacentrocosto");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);


                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        anulado = 1
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
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
                    dgvCentroCosto.DataSource = dt;
                    dgvCentroCosto.Columns["ORDEN"].Visible = false;
                    dgvCentroCosto.Columns["ANULADO"].Visible = false;
                    dgvCentroCosto.Columns["ID_CENTRO_COSTO"].Visible = false;
                    //dgvCentroCosto.Columns["CODIGO_CENTRO_COSTO"].Visible = false;
                    dgvCentroCosto.Columns["NOMBRE_CENTRO_COSTO"].Width = dgvCentroCosto.Width - 25;
                    foreach (DataRow dr in dt.Rows)
                    {
                        //dr["NOMBRE_CENTRO_COSTO"] = dr["NOMBRE_CENTRO_COSTO"].ToString() + " (" + dr["CODIGO_CENTRO_COSTO"].ToString() + ")";
                        if (dr["ANULADO"].ToString() == "1")
                        {
                            dr["NOMBRE_CENTRO_COSTO"] = dr["NOMBRE_CENTRO_COSTO"].ToString() + " (ANULADO)";
                        }
                    }
                    dgvCentroCosto.AutoResizeColumns();
                }
            }

            catch (WebException ex)
            {
                if (!(ex.Response is null))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        GlobalFunctions.casoError(ex, "Cargar Centro Costo\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Cargar Centro Costo\n");
            }
        }

        private void CentroCostoOrden(int ordendif)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/centrocostoorden");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        idcentrocosto = dgvCentroCosto.Rows[dgvCentroCosto.SelectedCells[0].RowIndex].Cells["ID_CENTRO_COSTO"].Value.ToString(),
                        ordendif = ordendif
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
                if (!(ex.Response is null))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        GlobalFunctions.casoError(ex, "Ordenar Centro Costo\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Ordenar Centro Costo\n");
            }

        }

        private void btAgregarCentroCosto_Click(object sender, EventArgs e)
        {
            string nombrecentrocosto = Microsoft.VisualBasic.Interaction.InputBox("Escriba el nombre del Centro Costo:", "Nombre Centro Costo", "");
            if (nombrecentrocosto != null)
            {
                nombrecentrocosto = nombrecentrocosto.ToUpper();
                string codigocentrocosto = Microsoft.VisualBasic.Interaction.InputBox("Escriba el Codigo del Centro Costo:", "Codigo Centro Costo", "");
                if (codigocentrocosto != null)
                {
                    try
                    {
                        int index = -1;
                        if (dgvCentroCosto.SelectedRows.Count > 0)
                        {
                            index = dgvCentroCosto.SelectedRows[0].Index;
                        }
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/centrocostoagregar");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                strnombrecentrocosto = nombrecentrocosto,
                                strcodigocentrocosto = codigocentrocosto
                            });

                            streamWriter.Write(json);
                        }
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                string result = streamReader.ReadToEnd();
                                CentroCostoLoad();
                                if (index >= 0)
                                {
                                    dgvCentroCosto.Rows[index].Selected = true;
                                    if (index > Globals.ListaScrollLimite)
                                    {
                                        dgvCentroCosto.FirstDisplayedScrollingRowIndex = dgvCentroCosto.SelectedRows[0].Index;
                                    }
                                }
                            }
                        }
                    }

                    catch (WebException ex)
                    {
                        if (!(ex.Response is null))
                        {
                            using (var stream = ex.Response.GetResponseStream())
                            using (var reader = new StreamReader(stream))
                            {
                                GlobalFunctions.casoError(ex, "Agregar Centro Costo\n" + reader.ReadToEnd());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        GlobalFunctions.casoError(ex, "Agregar Centro Costo\n");
                    }
                }
            }
        }

        private void btOrderUpCentroCosto_Click(object sender, EventArgs e)
        {
            if (dgvCentroCosto.SelectedRows.Count > 0)
            {
                if (dgvCentroCosto.SelectedRows[0].Index > 0)
                {
                    int prevrow = dgvCentroCosto.SelectedRows[0].Index - 1;
                    CentroCostoOrden(-1);

                    CentroCostoLoad();
                    dgvCentroCosto.Rows[prevrow].Selected = true;
                    if (prevrow > Globals.ListaScrollLimite)
                    {
                        dgvCentroCosto.FirstDisplayedScrollingRowIndex = dgvCentroCosto.SelectedRows[0].Index;
                    }
                }
            }
        }

        private void btOrderDownCentroCosto_Click(object sender, EventArgs e)
        {
            if (dgvCentroCosto.SelectedRows.Count > 0)
            {
                if (dgvCentroCosto.SelectedRows[0].Index < dgvCentroCosto.Rows.Count - 1)
                {
                    int nextrow = dgvCentroCosto.SelectedRows[0].Index + 1;

                    CentroCostoOrden(1);

                    CentroCostoLoad();
                    dgvCentroCosto.Rows[nextrow].Selected = true;
                    if (nextrow > Globals.ListaScrollLimite)
                    {
                        dgvCentroCosto.FirstDisplayedScrollingRowIndex = dgvCentroCosto.SelectedRows[0].Index;
                    }
                }
            }

        }

        private void btAnularCentroCosto_Click(object sender, EventArgs e)
        {

            if (dgvCentroCosto.SelectedRows.Count > 0)
            {
                try
                {
                    int index = dgvCentroCosto.SelectedRows[0].Index;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/centrocostoanular");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            idcentrocosto = dgvCentroCosto.SelectedRows[0].Cells["ID_CENTRO_COSTO"].Value
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            CentroCostoLoad();
                            dgvCentroCosto.Rows[index].Selected = true;
                            if (index > Globals.ListaScrollLimite)
                            {
                                dgvCentroCosto.FirstDisplayedScrollingRowIndex = dgvCentroCosto.SelectedRows[0].Index;
                            }
                        }
                    }
                }

                catch (WebException ex)
                {
                    if (!(ex.Response is null))
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        using (var reader = new StreamReader(stream))
                        {
                            GlobalFunctions.casoError(ex, "Anular Centro Costo\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Anular Centro Costo\n");
                }
            }
        }
    }
}
