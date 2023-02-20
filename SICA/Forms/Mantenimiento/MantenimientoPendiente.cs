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
    public partial class MantenimientoPendiente : Form
    {
        public MantenimientoPendiente()
        {
            InitializeComponent();
        }

        private void MantenimientoListas_Load(object sender, EventArgs e)
        {
            PendienteLoad();
        }
        private void PendienteLoad()
        {
            try
            {
                int index = -1, index2 = -1, index3 = -1;
                if (dgvNombre.SelectedRows.Count > 0)
                {
                    index = dgvNombre.SelectedRows[0].Index;
                }
                if (dgvDetalle.SelectedRows.Count > 0)
                {
                    index2 = dgvDetalle.SelectedRows[0].Index;
                }
                if (dgvBanca.SelectedRows.Count > 0)
                {
                    index3 = dgvBanca.SelectedRows[0].Index;
                }

                DataTable dt = new DataTable("Lista Pendiente Nombre");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listapendientes");
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
                    //NOMBRE 1
                    DataTable nombre = new DataTable("Pendientes Nombre");
                    nombre.Columns.Add("ID_LPENDIENTE");
                    nombre.Columns.Add("NOMBRE");
                    nombre.Columns.Add("ORDEN");
                    nombre.Columns.Add("ANULADO");

                    //DETALLE 2
                    DataTable detalle = new DataTable("Pendientes Detalle");
                    detalle.Columns.Add("ID_LPENDIENTE");
                    detalle.Columns.Add("NOMBRE");
                    detalle.Columns.Add("ORDEN");
                    detalle.Columns.Add("ANULADO");

                    //BANCA 3
                    DataTable banca = new DataTable("Pendientes Banca");
                    banca.Columns.Add("ID_LPENDIENTE");
                    banca.Columns.Add("NOMBRE");
                    banca.Columns.Add("ORDEN");
                    banca.Columns.Add("ANULADO");

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["ANULADO"].ToString() == "1")
                        {
                            row["NOMBRE"] = row["NOMBRE"].ToString() + " (ANULADO)";
                        }
                        if (row["TIPO"].ToString() == "1")
                        {
                            DataRow drNombre = nombre.NewRow();
                            drNombre["ID_LPENDIENTE"] = row["ID_LPENDIENTE"];
                            drNombre["NOMBRE"] = row["NOMBRE"];
                            drNombre["ORDEN"] = row["ORDEN"];
                            drNombre["ANULADO"] = row["ANULADO"];
                            nombre.Rows.Add(drNombre);
                        }
                        else if (row["TIPO"].ToString() == "2")
                        {
                            DataRow drDetalle = detalle.NewRow();
                            drDetalle["ID_LPENDIENTE"] = row["ID_LPENDIENTE"];
                            drDetalle["NOMBRE"] = row["NOMBRE"];
                            drDetalle["ORDEN"] = row["ORDEN"];
                            drDetalle["ANULADO"] = row["ANULADO"];
                            detalle.Rows.Add(drDetalle);
                        }
                        else if (row["TIPO"].ToString() == "3")
                        {
                            DataRow drBanca = banca.NewRow();
                            drBanca["ID_LPENDIENTE"] = row["ID_LPENDIENTE"];
                            drBanca["NOMBRE"] = row["NOMBRE"];
                            drBanca["ORDEN"] = row["ORDEN"];
                            drBanca["ANULADO"] = row["ANULADO"];
                            banca.Rows.Add(drBanca);
                        }
                    }

                    dgvNombre.DataSource = nombre;
                    dgvNombre.Columns["ID_LPENDIENTE"].Visible = false;
                    dgvNombre.Columns["ORDEN"].Visible = false;
                    dgvNombre.Columns["ANULADO"].Visible = false;
                    dgvNombre.Columns["NOMBRE"].Width = dgvNombre.Width - 2;

                    dgvDetalle.DataSource = detalle;
                    dgvDetalle.Columns["ID_LPENDIENTE"].Visible = false;
                    dgvDetalle.Columns["ORDEN"].Visible = false;
                    dgvDetalle.Columns["ANULADO"].Visible = false;
                    dgvDetalle.Columns["NOMBRE"].Width = dgvDetalle.Width - 2;

                    dgvBanca.DataSource = banca;
                    dgvBanca.Columns["ID_LPENDIENTE"].Visible = false;
                    dgvBanca.Columns["ORDEN"].Visible = false;
                    dgvBanca.Columns["ANULADO"].Visible = false;
                    dgvBanca.Columns["NOMBRE"].Width = dgvBanca.Width - 2;

                    if (dgvNombre.SelectedRows.Count > index && index >= 0)
                    {
                        dgvNombre.Rows[index + 1].Selected = true;
                    }
                    if (dgvDetalle.SelectedRows.Count > index2 && index2 >= 0)
                    {
                        dgvDetalle.Rows[index2].Selected = true;
                    }
                    if (dgvBanca.SelectedRows.Count > index3 && index3 >= 0)
                    {
                        dgvBanca.Rows[index3].Selected = true;
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
                        GlobalFunctions.casoError(ex, "Cargar Lista Pendientes\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Cargar Lista Pendientes\n");
            }
        }

        private void btAgregarNombre_Click(object sender, EventArgs e)
        {
            string nombrependiente = Microsoft.VisualBasic.Interaction.InputBox("Escriba el nombre:", "Nombre Pendiente", "");
            if (nombrependiente != null)
            {
                nombrependiente = nombrependiente.ToUpper();
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/pendienteagregar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            strpendiente = nombrependiente,
                            tipo = 1
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            PendienteLoad();
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
                            GlobalFunctions.casoError(ex, "Agregar Nombre\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Agregar Nombre\n");
                }
            }
        }

        private void btOrderUpNombre_Click(object sender, EventArgs e)
        {
            if (dgvNombre.SelectedRows.Count > 0)
            {
                if (dgvNombre.SelectedRows[0].Index > 0)
                {
                    PendienteOrden(dgvNombre, 1, -1);

                    PendienteLoad();
                    if (dgvNombre.SelectedRows.Count > 0)
                    {
                        dgvNombre.Rows[dgvNombre.SelectedRows[0].Index - 1].Selected = true;
                    }
                }
            }
        }

        private void btOrderDownNombre_Click(object sender, EventArgs e)
        {
            if (dgvNombre.SelectedRows.Count > 0)
            {
                if (dgvNombre.SelectedRows[0].Index < dgvNombre.Rows.Count - 1)
                {
                    PendienteOrden(dgvNombre, 1, 1);

                    PendienteLoad();
                    if (dgvNombre.SelectedRows.Count > 0)
                    {
                        dgvNombre.Rows[dgvNombre.SelectedRows[0].Index + 1].Selected = true;
                    }
                }
            }
        }

        private void btAnularNombre_Click(object sender, EventArgs e)
        {
            if (dgvNombre.SelectedRows.Count > 0)
            {
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/pendienteanular");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            idpendiente = dgvNombre.SelectedRows[0].Cells["ID_LPENDIENTE"].Value
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            PendienteLoad();
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
                            GlobalFunctions.casoError(ex, "Anular Nombre\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Anular Nombre\n");
                }
            }
        }


        private void btAgregarDetalle_Click(object sender, EventArgs e)
        {
            string detallependiente = Microsoft.VisualBasic.Interaction.InputBox("Escriba el Detalle:", "Detalle Pendiente", "");
            if (detallependiente != null)
            {
                detallependiente = detallependiente.ToUpper();
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/pendienteagregar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            strpendiente = detallependiente,
                            tipo = 2
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            PendienteLoad();
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
                            GlobalFunctions.casoError(ex, "Agregar Detalle\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Agregar Detalle\n");
                }
            }
        }

        private void btOrderUpDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0)
            {
                if (dgvDetalle.SelectedRows[0].Index > 0)
                {
                    PendienteOrden(dgvDetalle, 2, -1);

                    PendienteLoad();
                    if (dgvDetalle.SelectedRows.Count > 0)
                    {
                        dgvDetalle.Rows[dgvDetalle.SelectedRows[0].Index - 1].Selected = true;
                    }
                }
            }
        }

        private void btOrderDownDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0)
            {
                if (dgvDetalle.SelectedRows[0].Index < dgvDetalle.Rows.Count - 1)
                {
                    PendienteOrden(dgvDetalle, 2, 1);
                    PendienteLoad();
                    if (dgvDetalle.SelectedRows.Count > 0)
                    {
                        dgvDetalle.Rows[dgvDetalle.SelectedRows[0].Index + 1].Selected = true;
                    }
                }
            }
        }

        private void btAnularDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0)
            {
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/pendienteanular");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            idpendiente = dgvDetalle.SelectedRows[0].Cells["ID_LPENDIENTE"].Value
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            PendienteLoad();
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
                            GlobalFunctions.casoError(ex, "Anular Detalle\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Anular Detalle\n");
                }
            }
        }

        private void btAgregarBanca_Click(object sender, EventArgs e)
        {
            string bancapendiente = Microsoft.VisualBasic.Interaction.InputBox("Escriba la Banca:", "Banca Pendiente", "");
            if (bancapendiente != null)
            {
                bancapendiente = bancapendiente.ToUpper();
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/pendienteagregar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            strpendiente = bancapendiente,
                            tipo = 3
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            PendienteLoad();
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
                            GlobalFunctions.casoError(ex, "Agregar Banca\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Agregar Banca\n");
                }
            }
        }

        private void btOrderUpBanca_Click(object sender, EventArgs e)
        {
            if (dgvBanca.SelectedRows.Count > 0)
            {
                if (dgvBanca.SelectedRows[0].Index > 0)
                {
                    PendienteOrden(dgvBanca, 2, -1);

                    PendienteLoad();
                    if (dgvBanca.SelectedRows.Count > 0)
                    {
                        dgvBanca.Rows[dgvBanca.SelectedRows[0].Index - 1].Selected = true;
                    }
                }
            }
        }

        private void btOrderDownBanca_Click(object sender, EventArgs e)
        {
            if (dgvBanca.SelectedRows.Count > 0)
            {
                if (dgvBanca.SelectedRows[0].Index < dgvBanca.Rows.Count - 1)
                {
                    PendienteOrden(dgvBanca, 2, 1);
                    PendienteLoad();
                    if (dgvBanca.SelectedRows.Count > 0)
                    {
                        dgvBanca.Rows[dgvBanca.SelectedRows[0].Index + 1].Selected = true;
                    }
                }
            }
        }

        private void btAnularBanca_Click(object sender, EventArgs e)
        {
            if (dgvBanca.SelectedRows.Count > 0)
            {
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/pendienteanular");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            idpendiente = dgvBanca.SelectedRows[0].Cells["ID_LPENDIENTE"].Value
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            PendienteLoad();
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
                            GlobalFunctions.casoError(ex, "Anular Banca\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Anular Banca\n");
                }
            }
        }

        private void PendienteOrden(DataGridView dgv, int tipo, int ordendif)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/PendienteOrden");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        idpendiente = dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells["ID_LPENDIENTE"].Value.ToString(),
                        ordendif = ordendif,
                        tipo = tipo
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
                        GlobalFunctions.casoError(ex, "Ordenar Pendiente\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Ordenar Pendiente\n");
            }

        }
    }
}
