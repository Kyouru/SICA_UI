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
    public partial class MantenimientoProducto : Form
    {
        public MantenimientoProducto()
        {
            InitializeComponent();
        }

        private void MantenimientoListas_Load(object sender, EventArgs e)
        {
            ProductoLoad();
        }
        private void ProductoLoad()
        {
            try
            {
                DataTable dt = new DataTable("Lista Producto");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listaproducto");
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
                    dgvProducto.DataSource = dt;
                    dgvProducto.Columns["ORDEN"].Visible = false;
                    dgvProducto.Columns["ANULADO"].Visible = false;
                    dgvProducto.Columns["ID_PRODUCTO"].Visible = false;
                    dgvProducto.Columns["NOMBRE_PRODUCTO"].Width = dgvProducto.Width - 25;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ANULADO"].ToString() == "1")
                        {
                            dr["NOMBRE_PRODUCTO"] = dr["NOMBRE_PRODUCTO"].ToString() + " (ANULADO)";
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
                        GlobalFunctions.casoError(ex, "Cargar Producto\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Cargar Producto\n");
            }
        }

        private void ProductoOrden(int ordendif)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/productoorden");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        idproducto = dgvProducto.Rows[dgvProducto.SelectedCells[0].RowIndex].Cells["ID_PRODUCTO"].Value.ToString(),
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
                        GlobalFunctions.casoError(ex, "Ordenar Producto\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Ordenar Producto\n");
            }

        }

        private void btAgregarProducto_Click(object sender, EventArgs e)
        {
            string nombreproducto = Microsoft.VisualBasic.Interaction.InputBox("Escriba el nombre del Producto:", "Nombre Producto", "");
            if (nombreproducto != null)
            {
                nombreproducto = nombreproducto.ToUpper();
                try
                {
                    int index = -1;
                    if (dgvProducto.SelectedRows.Count > 0)
                    {
                        index = dgvProducto.SelectedRows[0].Index;
                    }
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/productoagregar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            strproducto = nombreproducto
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            ProductoLoad();
                            if (index >= 0)
                            {
                                dgvProducto.Rows[index].Selected = true;
                                if (index > Globals.ListaScrollLimite)
                                {
                                    dgvProducto.FirstDisplayedScrollingRowIndex = dgvProducto.SelectedRows[0].Index;
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
                            GlobalFunctions.casoError(ex, "Agregar Producto\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Agregar Producto\n");
                }
            }
        }

        private void btOrderUpProducto_Click(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count > 0)
            {
                if (dgvProducto.SelectedRows[0].Index > 0)
                {
                    int prevrow = dgvProducto.SelectedRows[0].Index - 1;
                    ProductoOrden(-1);

                    ProductoLoad();
                    dgvProducto.Rows[prevrow].Selected = true;
                    if (prevrow > Globals.ListaScrollLimite)
                    {
                        dgvProducto.FirstDisplayedScrollingRowIndex = dgvProducto.SelectedRows[0].Index;
                    }
                }
            }
        }

        private void btOrderDownProducto_Click(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count > 0)
            {
                if (dgvProducto.SelectedRows[0].Index < dgvProducto.Rows.Count - 1)
                {
                    int nextrow = dgvProducto.SelectedRows[0].Index + 1;

                    ProductoOrden(1);

                    ProductoLoad();
                    dgvProducto.Rows[nextrow].Selected = true;
                    if (nextrow > Globals.ListaScrollLimite)
                    {
                        dgvProducto.FirstDisplayedScrollingRowIndex = dgvProducto.SelectedRows[0].Index;
                    }
                }
            }
        }

        private void btAnularProducto_Click(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count > 0)
            {
                try
                {
                    int index = dgvProducto.SelectedRows[0].Index;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/productoanular");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            idproducto = dgvProducto.SelectedRows[0].Cells["ID_PRODUCTO"].Value
                        });

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            ProductoLoad();
                            dgvProducto.Rows[index].Selected = true;
                            if (index > Globals.ListaScrollLimite)
                            {
                                dgvProducto.FirstDisplayedScrollingRowIndex = dgvProducto.SelectedRows[0].Index;
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
                            GlobalFunctions.casoError(ex, "Anular Producto\n" + reader.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, "Anular Producto\n");
                }
            }
        }
    }
}
