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

namespace SICA.Forms.Mantenimiento
{
    public partial class MantenimientoArea : Form
    {
        public MantenimientoArea()
        {
            InitializeComponent();
        }

        private void MantenimientoListas_Load(object sender, EventArgs e)
        {
            AreaLoad();
        }
        private void AreaLoad()
        {
            try
            {
                DataTable dt = new DataTable("Lista Area");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaarea");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);


                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        anulado = 0
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
                    dgvArea.DataSource = dt;
                    dgvArea.Columns["ORDEN"].Visible = false;
                    dgvArea.Columns["ANULADO"].Visible = false;
                    dgvArea.Columns["ID_AREA"].Visible = false;
                    dgvArea.Columns["NOMBRE_Area"].Width = dgvArea.Width - 2;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ANULADO"].ToString() == "1")
                        {
                            dr["NOMBRE_AREA"] = dr["NOMBRE_AREA"].ToString() + " (ANULADO)";
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
                        GlobalFunctions.casoError(ex, "Cargar Area\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Cargar Area\n");
            }
        }

        private void AreaOrden(int ordendif)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/AreaOrden");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        idarea = dgvArea.Rows[dgvArea.SelectedCells[0].RowIndex].Cells["ID_AREA"].Value.ToString(),
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
                        GlobalFunctions.casoError(ex, "Ordenar Area\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Ordenar Area\n");
            }

        }

        private void btAgregarArea_Click(object sender, EventArgs e)
        {
            string nombrearea = Microsoft.VisualBasic.Interaction.InputBox("Escriba el nombre del Area:", "Nombre Area", "");
            if (nombrearea != null)
            {
                nombrearea = nombrearea.ToUpper();
                try
                {
                    int index = dgvArea.SelectedRows[0].Index;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/areaagregar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            strarea = nombrearea
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            AreaLoad();
                            dgvArea.Rows[index].Selected = true;
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
                            GlobalFunctions.casoError(ex, "Agregar Area\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Agregar Area\n");
                }
            }
        }

        private void btOrderUpArea_Click(object sender, EventArgs e)
        {
            if (dgvArea.SelectedRows.Count > 0)
            {
                if (dgvArea.SelectedRows[0].Index > 0)
                {
                    int prevrow = dgvArea.SelectedRows[0].Index - 1;
                    AreaOrden(-1);

                    AreaLoad();
                    dgvArea.Rows[prevrow].Selected = true;
                }
            }
        }

        private void btOrderDownArea_Click(object sender, EventArgs e)
        {
            if (dgvArea.SelectedRows.Count > 0)
            {
                if (dgvArea.SelectedRows[0].Index < dgvArea.Rows.Count - 1)
                {
                    int nextrow = dgvArea.SelectedRows[0].Index + 1;

                    AreaOrden(1);

                    AreaLoad();
                    dgvArea.Rows[nextrow].Selected = true;
                }
            }
        }

        private void btAnularArea_Click(object sender, EventArgs e)
        {

            if (dgvArea.SelectedRows.Count > 0)
            {
                try
                {
                    int index = dgvArea.SelectedRows[0].Index;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/areaanular");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            idarea = dgvArea.SelectedRows[0].Cells["ID_AREA"].Value
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            AreaLoad();
                            dgvArea.Rows[index].Selected = true;
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
                            GlobalFunctions.casoError(ex, "Anular Area\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Anular Area\n");
                }
            }
        }
    }
}
