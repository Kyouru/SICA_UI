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
    public partial class MantenimientoListas : Form
    {
        public MantenimientoListas()
        {
            InitializeComponent();
        }

        private void MantenimientoListas_Load(object sender, EventArgs e)
        {
            DepartamentoLoad();
        }
        private void DepartamentoLoad()
        {
            try
            {
                DataTable dt = new DataTable("Lista Departamento");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadepartamento");
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
                    dgvDepartamento.DataSource = dt;
                    dgvDepartamento.Columns["ORDEN"].Visible = false;
                    dgvDepartamento.Columns["ANULADO"].Visible = false;
                    dgvDepartamento.Columns["ID_DEPARTAMENTO"].Visible = false;
                    dgvDepartamento.Columns["NOMBRE_DEPARTAMENTO"].Width = dgvDepartamento.Width - 2;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ANULADO"].ToString() == "1")
                        {
                            dr["NOMBRE_DEPARTAMENTO"] = dr["NOMBRE_DEPARTAMENTO"].ToString() + " (ANULADO)";
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
                        GlobalFunctions.casoError(ex, "Cargar Departamentos\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Cargar Departamentos\n");
            }
        }
        private void dgvDepartamento_SelectionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dgvDepartamento.SelectedRows.Count.ToString());
            if (dgvDepartamento.SelectedRows.Count == 1)
            {
                DocumentoLoad();
            }
        }
        private void DocumentoLoad()
        {
            if (dgvDepartamento.SelectedRows.Count == 1)
            {
                try
                {
                    DataTable dt = new DataTable("Lista Documento");

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadocumento");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            iddepartamento = dgvDepartamento.SelectedRows[0].Cells["ID_DEPARTAMENTO"].Value.ToString(),
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
                        dgvDocumento.DataSource = dt;
                        dgvDocumento.Columns["ORDEN"].Visible = false;
                        dgvDocumento.Columns["ANULADO"].Visible = false;
                        dgvDocumento.Columns["ID_DOCUMENTO"].Visible = false;
                        dgvDocumento.Columns["ID_DEPARTAMENTO_FK"].Visible = false;
                        dgvDocumento.Columns["NOMBRE_DOCUMENTO"].Width = dgvDocumento.Width - 2;
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["ANULADO"].ToString() == "1")
                            {
                                dr["NOMBRE_DOCUMENTO"] = dr["NOMBRE_DOCUMENTO"].ToString() + " (ANULADO)";
                            }
                        }
                    }
                    else
                    {
                        dgvDocumento.DataSource = null;
                        dgvDetalle.DataSource = null;
                    }
                }

                catch (WebException ex)
                {
                    if (!(ex.Response is null))
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        using (var reader = new StreamReader(stream))
                        {
                            GlobalFunctions.casoError(ex, "Cargar Documentos\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Cargar Documentos\n");
                }
            }
        }

        private void dgvDocumento_SelectionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dgvDepartamento.SelectedRows.Count.ToString());
            if (dgvDocumento.SelectedRows.Count == 1)
            {
                DetalleLoad();
            }
        }

        private void DetalleLoad()
        {
            if (dgvDocumento.SelectedRows.Count == 1)
            {
                try
                {
                    DataTable dt = new DataTable("Lista Documento");

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadetalle");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            iddocumento = dgvDocumento.SelectedRows[0].Cells["ID_DOCUMENTO"].Value.ToString(),
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
                        dgvDetalle.DataSource = dt;
                        dgvDetalle.Columns["ORDEN"].Visible = false;
                        dgvDetalle.Columns["ANULADO"].Visible = false;
                        dgvDetalle.Columns["ID_DETALLE"].Visible = false;
                        dgvDetalle.Columns["ID_DOCUMENTO_FK"].Visible = false;
                        dgvDetalle.Columns["NOMBRE_DETALLE"].Width = dgvDetalle.Width - 2;
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["ANULADO"].ToString() == "1")
                            {
                                dr["NOMBRE_DETALLE"] = dr["NOMBRE_DETALLE"].ToString() + " (ANULADO)";
                            }
                        }
                    }
                    else
                    {
                        dgvDetalle.DataSource = null;
                    }
                }

                catch (WebException ex)
                {
                    if (!(ex.Response is null))
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        using (var reader = new StreamReader(stream))
                        {
                            GlobalFunctions.casoError(ex, "Cargar Detalles\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Cargar Detalles\n");
                }
            }
        }

        private void btAgregarDepartamento_Click(object sender, EventArgs e)
        {
            string nombredepartamento = Microsoft.VisualBasic.Interaction.InputBox("Escriba el nombre del Departamento:", "Nombre Departamento", "");
            if (nombredepartamento != null)
            {
                nombredepartamento = nombredepartamento.ToUpper();
                try
                {
                    int index = dgvDepartamento.SelectedRows[0].Index;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/departamentoagregar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            strdepartamento = nombredepartamento
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            DepartamentoLoad();
                            dgvDepartamento.Rows[index].Selected = true;
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
                            GlobalFunctions.casoError(ex, "Agregar Departamento\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Agregar Departamento\n");
                }
            }
        }

        private void btOrderUpDepartamento_Click(object sender, EventArgs e)
        {
            if (dgvDepartamento.SelectedRows.Count > 0)
            {
                if (dgvDepartamento.SelectedRows[0].Index > 0)
                {
                    int prevrow = dgvDepartamento.SelectedRows[0].Index - 1;
                    DepartamentoOrden(-1);

                    DepartamentoLoad();
                    dgvDepartamento.Rows[prevrow].Selected = true;
                }
            }
        }

        private void btOrderDownDepartamento_Click(object sender, EventArgs e)
        {
            if (dgvDepartamento.SelectedRows.Count > 0)
            {
                if (dgvDepartamento.SelectedRows[0].Index < dgvDepartamento.Rows.Count - 1)
                {
                    int nextrow = dgvDepartamento.SelectedRows[0].Index + 1;

                    DepartamentoOrden(1);

                    DepartamentoLoad();
                    dgvDepartamento.Rows[nextrow].Selected = true;
                }
            }
        }

        private void btAnularDepartamento_Click(object sender, EventArgs e)
        {
            if (dgvDepartamento.SelectedRows.Count > 0)
            {
                try
                {
                    int index = dgvDepartamento.SelectedRows[0].Index;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/departamentoanular");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            iddepartamento = dgvDepartamento.SelectedRows[0].Cells["ID_DEPARTAMENTO"].Value
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            DepartamentoLoad();
                            dgvDepartamento.Rows[index].Selected = true;
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
                            GlobalFunctions.casoError(ex, "Anular Departamento\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Anular Departamento\n");
                }
            }
        }

        private void DepartamentoOrden(int ordendif)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/DepartamentoOrden");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        iddepartamento = dgvDepartamento.Rows[dgvDepartamento.SelectedCells[0].RowIndex].Cells["ID_DEPARTAMENTO"].Value.ToString(),
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
                        GlobalFunctions.casoError(ex, "Ordenar Departamento\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Ordenar Departamento\n");
            }

        }

        private void btAgregarDocumento_Click(object sender, EventArgs e)
        {
            string nombredocumento = Microsoft.VisualBasic.Interaction.InputBox("Escriba el nombre del Documento:", "Nombre Documento", "");
            if (nombredocumento != null)
            {
                nombredocumento = nombredocumento.ToUpper();
                try
                {
                    int index = dgvDepartamento.SelectedRows[0].Index;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/documentoagregar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            iddepartamento = dgvDepartamento.Rows[dgvDepartamento.SelectedCells[0].RowIndex].Cells["ID_DEPARTAMENTO"].Value.ToString(),
                            strdocumento = nombredocumento
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            DocumentoLoad();
                            dgvDepartamento.Rows[index].Selected = true;
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
                            GlobalFunctions.casoError(ex, "Agregar Documento\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Agregar Documento\n");
                }
            }
        }

        private void btOrderUpDocumento_Click(object sender, EventArgs e)
        {
            if (dgvDocumento.SelectedRows.Count > 0)
            {
                if (dgvDocumento.SelectedRows[0].Index > 0)
                {
                    int prevrow = dgvDocumento.SelectedRows[0].Index - 1;
                    DocumentoOrden(-1);

                    DocumentoLoad();
                    dgvDocumento.Rows[prevrow].Selected = true;
                }
            }
        }

        private void DocumentoOrden(int ordendif)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/DocumentoOrden");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        iddocumento = dgvDocumento.Rows[dgvDocumento.SelectedCells[0].RowIndex].Cells["ID_DOCUMENTO"].Value.ToString(),
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
                        GlobalFunctions.casoError(ex, "Ordenar Documento\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Ordenar Documento\n");
            }

        }

        private void btOrderDownDocumento_Click(object sender, EventArgs e)
        {
            if (dgvDocumento.SelectedRows.Count > 0)
            {
                if (dgvDocumento.SelectedRows[0].Index < dgvDocumento.Rows.Count - 1)
                {
                    int nextrow = dgvDocumento.SelectedRows[0].Index + 1;

                    DocumentoOrden(1);

                    DocumentoLoad();
                    dgvDocumento.Rows[nextrow].Selected = true;
                }
            }
        }

        private void btAnularDocumento_Click(object sender, EventArgs e)
        {
            if (dgvDocumento.SelectedRows.Count > 0)
            {
                try
                {
                    int index = dgvDocumento.SelectedRows[0].Index;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/documentoanular");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            iddocumento = dgvDocumento.SelectedRows[0].Cells["ID_DOCUMENTO"].Value
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            DocumentoLoad();
                            dgvDepartamento.Rows[index].Selected = true;
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
                            GlobalFunctions.casoError(ex, "Anular Documento\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Anular Documento\n");
                }
            }
        }

        private void btAgregarDetalle_Click(object sender, EventArgs e)
        {
            string nombredetalle = Microsoft.VisualBasic.Interaction.InputBox("Escriba el nombre del Detalle:", "Nombre Detalle", "");
            if (nombredetalle != null)
            {
                nombredetalle = nombredetalle.ToUpper();
                try
                {
                    int index = dgvDocumento.SelectedRows[0].Index;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/detalleagregar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            iddocumento = dgvDocumento.Rows[dgvDocumento.SelectedCells[0].RowIndex].Cells["ID_DOCUMENTO"].Value.ToString(),
                            strdetalle = nombredetalle
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            DocumentoLoad();
                            dgvDocumento.Rows[index].Selected = true;
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
                    int prevrow = dgvDetalle.SelectedRows[0].Index - 1;
                    DetalleOrden(-1);

                    DetalleLoad();
                    dgvDetalle.Rows[prevrow].Selected = true;
                }
            }
        }
        private void DetalleOrden(int ordendif)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/DetalleOrden");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        iddetalle = dgvDetalle.Rows[dgvDetalle.SelectedCells[0].RowIndex].Cells["ID_DETALLE"].Value.ToString(),
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
                        GlobalFunctions.casoError(ex, "Ordenar Detalle\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Ordenar Detalle\n");
            }

        }

        private void btOrderDownDetalle_Click(object sender, EventArgs e)
        {

            if (dgvDetalle.SelectedRows.Count > 0)
            {
                if (dgvDetalle.SelectedRows[0].Index < dgvDetalle.Rows.Count - 1)
                {
                    int nextrow = dgvDetalle.SelectedRows[0].Index + 1;

                    DetalleOrden(1);

                    DetalleLoad();
                    dgvDetalle.Rows[nextrow].Selected = true;
                }
            }
        }

        private void btAnularDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0)
            {
                try
                {
                    int index = dgvDetalle.SelectedRows[0].Index;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/detalleanular");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            iddetalle = dgvDetalle.SelectedRows[0].Cells["ID_DETALLE"].Value
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            DetalleLoad();
                            dgvDepartamento.Rows[index].Selected = true;
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

    }
}
