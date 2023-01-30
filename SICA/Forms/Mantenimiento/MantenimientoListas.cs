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
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

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
                            iddepartamento = dgvDepartamento.SelectedRows[0].Cells["ID_DEPARTAMENTO"].Value.ToString()
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
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["ANULADO"].ToString() == "1")
                            {
                                dr["NOMBRE_DOCUMENTO"] = dr["NOMBRE_DOCUMENTO"].ToString() + " (ANULADO)";
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

        private void btAgregarDepartamento_Click(object sender, EventArgs e)
        {
            string nombredepartamento = Microsoft.VisualBasic.Interaction.InputBox("Escriba el nombre del Departamento:", "Nombre Departamento", "");
            if (nombredepartamento != null)
            {
                nombredepartamento = nombredepartamento.ToUpper();
                try
                {
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
                        GlobalFunctions.casoError(ex, "Ordenar Detalle\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Ordenar Detalle\n");
            }

        }

    }
}
