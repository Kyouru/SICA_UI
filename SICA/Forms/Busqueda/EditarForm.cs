using Newtonsoft.Json;
using System;
using System.Collections;
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

namespace SICA.Forms.Busqueda
{
    public partial class EditarForm : Form
    {

        public EditarForm()
        {
            GlobalFunctions.UltimaActividad();
            InitializeComponent();
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            if (cbFecha.Checked)
            {
                lbDesde.Visible = true;
                lbHasta.Visible = true;
                dtpFechaDesde.Visible = true;
                dtpFechaHasta.Visible = true;
            }
            else
            {
                lbDesde.Visible = false;
                lbHasta.Visible = false;
                dtpFechaDesde.Visible = false;
                dtpFechaHasta.Visible = false;
            }
        }

        private void EditarForm_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalFunctions.UltimaActividad();
                LoadingScreen.iniciarLoading();
                //Lista Departamento
                DataTable dt = new DataTable("Lista Departamento");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadepartamento");
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

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }

                cmbDepartamento.DataSource = dt;
                cmbDepartamento.DisplayMember = "NOMBRE_DEPARTAMENTO";
                cmbDepartamento.ValueMember = "ID_DEPARTAMENTO";
                //

                //
                dt = new DataTable("Lista Documento");

                httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadocumento");
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

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }
                cmbDocumento.DataSource = dt;
                cmbDocumento.DisplayMember = "NOMBRE_DOCUMENTO";
                cmbDocumento.ValueMember = "ID_DOCUMENTO";
                //

                //Lista Descripcion
                dt = new DataTable("Lista Descripcion");

                httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listadescripcion");
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

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        dt = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }

                cmbDescripcion1.DataSource = dt;
                cmbDescripcion1.DisplayMember = "NOMBRE_DESCRIPCION1";
                cmbDescripcion1.ValueMember = "TIPO_DESCRIPCION1";
                //

                //
                dt = new DataTable("Datos Editar");

                httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/datoseditar");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        idinventario = Globals.IdInventario
                    });

                    streamWriter.Write(json);
                }

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
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
                    tbCaja.Text = dt.Rows[0]["NUMERO_DE_CAJA"].ToString();
                    cmbDepartamento.SelectedValue = dt.Rows[0]["ID_DEPARTAMENTO_FK"].ToString();
                    cmbDocumento.SelectedValue = dt.Rows[0]["ID_DOCUMENTO_FK"].ToString();
                    try
                    {
                        dtpFechaDesde.Value = (DateTime)dt.Rows[0]["FECHA_DESDE"];
                    }
                    catch
                    {

                    }
                    try
                    {
                        dtpFechaHasta.Value = (DateTime)dt.Rows[0]["FECHA_HASTA"];
                    }
                    catch
                    {

                    }
                    cmbDescripcion1.Text = dt.Rows[0]["DESCRIPCION_1"].ToString();
                    tbDescripcion2.Text = dt.Rows[0]["DESCRIPCION_2"].ToString();
                    tbDescripcion3.Text = dt.Rows[0]["DESCRIPCION_3"].ToString();
                    tbDescripcion4.Text = dt.Rows[0]["DESCRIPCION_4"].ToString();
                    tbDescripcion5.Text = dt.Rows[0]["DESCRIPCION_5"].ToString();

                    if (dt.Rows[0]["EXPEDIENTE"].ToString() == "1")
                    {
                        cmbExpediente.Text = "SI";
                    }
                    else
                    {
                        cmbExpediente.Text = "NO";
                    }

                    if (dt.Rows[0]["FECHA_DESDE"].ToString() != "")
                    {
                        cbFecha.Checked = true;
                    }
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
                        GlobalFunctions.casoError(ex, "Error Datos Editar\n" + reader.ReadToEnd());
                    }
                }
            }

            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Datos Editar");
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            bool correcto = true;
            if (tbCaja.Text == "")
            {
                MessageBox.Show("Numero de Caja Vacio");
                correcto = false;
            }
            if (cmbDepartamento.SelectedIndex == -1)
            {
                MessageBox.Show("Departamento Invalido");
                correcto = false;
            }
            if (cmbDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Documento Invalido");
                correcto = false;
            }

            if (correcto)
            {

                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/guardareditar");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    int expediente;
                    
                    if (cmbExpediente.Text == "SI")
                    {
                        expediente = 1;
                    }
                    else
                    {
                        expediente = 0;
                    }

                    string fechadesde, fechahasta;
                    if (cbFecha.Checked)
                    {
                        fechadesde = dtpFechaDesde.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        fechahasta = dtpFechaHasta.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        fechadesde = "";
                        fechahasta = "";
                    }
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            token = Globals.Token,
                            idinventario = Globals.IdInventario,
                            numerocaja = tbCaja.Text,
                            iddepartamento = Int32.Parse(cmbDepartamento.SelectedValue.ToString()),
                            iddocumento = Int32.Parse(cmbDocumento.SelectedValue.ToString()),
                            fechadesde = fechadesde,
                            fechahasta = fechahasta,
                            descripcion1 = GlobalFunctions.lCadena(cmbDescripcion1.Text),
                            descripcion2 = GlobalFunctions.lCadena(tbDescripcion2.Text),
                            descripcion3 = GlobalFunctions.lCadena(tbDescripcion3.Text),
                            descripcion4 = GlobalFunctions.lCadena(tbDescripcion4.Text),
                            descripcion5 = GlobalFunctions.lCadena(tbDescripcion5.Text),
                            expediente = expediente,
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
                        MessageBox.Show("Actualizado");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error");
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
        }
    }
}
