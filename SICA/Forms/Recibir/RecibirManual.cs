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

namespace SICA.Forms.Recibir
{
    public partial class RecibirManual : Form
    {
        public RecibirManual()
        {
            InitializeComponent();
        }

        private void RecibirManual_Load(object sender, EventArgs e)
        {
            try
            {
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

                cmbCodDepartamento.DataSource = dt;
                cmbCodDepartamento.DisplayMember = "NOMBRE_DEPARTAMENTO";
                cmbCodDepartamento.ValueMember = "ID_DEPARTAMENTO";
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
                cmbCodDocumento.DataSource = dt;
                cmbCodDocumento.DisplayMember = "NOMBRE_DOCUMENTO";
                cmbCodDocumento.ValueMember = "ID_DOCUMENTO";
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
                        GlobalFunctions.casoError(ex, "RecibirManual_Load\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "RecibirManual_Load");
            }
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int pagare = 0, expediente = 0;
            if (cmbCodDepartamento.Text != "")
            {
                if (cmbCodDocumento.Text != "")
                {
                    if (cmbDescripcion1.Text != "")
                    {
                        if (cbNumeroCaja.Checked && tbNumeroCaja.Text == "")
                        {
                            MessageBox.Show("Falta Número de Caja");
                        }
                        else
                        {
                            Globals.TipoSeleccionarUsuario = 0;
                            SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                            suf.ShowDialog();
                            if (Globals.IdUsernameSelect > 0)
                            {
                                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                                try
                                {
                                    string fechadesde = "", fechahasta = "";
                                    if (cmbPagare.Visible && cmbPagare.Text == "SI")
                                    {
                                        pagare = 1;
                                    }
                                    if (cmbExpediente.Visible && cmbExpediente.Text == "SI")
                                    {
                                        expediente = 1;
                                    }
                                    if (cbFecha.Checked)
                                    {
                                        fechadesde = dtpDesde.Value.ToString("yyyy-MM-dd");
                                        fechahasta = dtpHasta.Value.ToString("yyyy-MM-dd");
                                    }
                                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Recibir/agregar");
                                    httpWebRequest.ContentType = "application/json";
                                    httpWebRequest.Method = "POST";

                                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                    {
                                        string json = new JavaScriptSerializer().Serialize(new
                                        {
                                            token = Globals.Token,
                                            idaux = Globals.IdUsernameSelect,
                                            idareaentrega = Globals.IdArea,
                                            idarearecibe = Globals.IdAreaSelect,
                                            idinventario = Globals.IdInventario,
                                            iddocumento = Int32.Parse((cmbCodDocumento.SelectedItem as DataRowView)["ID_DOCUMENTO"].ToString()),
                                            iddepartamento = Int32.Parse((cmbCodDepartamento.SelectedItem as DataRowView)["ID_DEPARTAMENTO"].ToString()),
                                            nomdocumento = (cmbCodDocumento.SelectedItem as DataRowView)["NOMBRE_DOCUMENTO"].ToString(),
                                            nomdepartamento = (cmbCodDepartamento.SelectedItem as DataRowView)["NOMBRE_DEPARTAMENTO"].ToString(),
                                            numerocaja = tbNumeroCaja.Text,
                                            fecha = fecha,
                                            fechadesde = fechadesde,
                                            fechahasta = fechahasta,
                                            descripcion1 = GlobalFunctions.lCadena((cmbDescripcion1.SelectedItem as DataRowView)["NOMBRE_DESCRIPCION1"].ToString()),
                                            descripcion2 = GlobalFunctions.lCadena(tbDescripcion2.Text),
                                            descripcion3 = GlobalFunctions.lCadena(tbDescripcion3.Text),
                                            descripcion4 = GlobalFunctions.lCadena(tbDescripcion4.Text),
                                            descripcion5 = GlobalFunctions.lCadena(tbDescripcion5.Text),
                                            expediente = expediente,
                                            pagare = pagare,
                                            observacion = GlobalFunctions.lCadena(observacion)
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
                                catch (WebException ex)
                                {
                                    LoadingScreen.cerrarLoading();
                                    if (!(ex.Response is null))
                                    {
                                        using (var stream = ex.Response.GetResponseStream())
                                        using (var reader = new StreamReader(stream))
                                        {
                                            GlobalFunctions.casoError(ex, "Error Recibir Manual\n" + reader.ReadToEnd());
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    GlobalFunctions.casoError(ex, "Error Recibir Manual");
                                    return;
                                }

                                MessageBox.Show("Registro Completado");
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta Descripcion 1");
                    }
                }
                else
                {
                    MessageBox.Show("Falta Codigo Documento");
                }
            }
            else
            {
                MessageBox.Show("Falta Codigo Departamento");
            }
        }

        private void cbNumeroCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNumeroCaja.Checked)
            {
                tbNumeroCaja.Visible = true;
            }
            else
            {
                tbNumeroCaja.Visible = false;
            }
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFecha.Checked)
            {
                dtpDesde.Visible = true;
                dtpHasta.Visible = true;
            }
            else
            {
                dtpDesde.Visible = false;
                dtpHasta.Visible = false;
            }
        }

        private void cbDescripcion2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescripcion2.Checked)
            {
                tbDescripcion2.Visible = true;
            }
            else
            {
                tbDescripcion2.Visible = false;
            }
        }

        private void cbDescripcion3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescripcion3.Checked)
            {
                tbDescripcion3.Visible = true;
            }
            else
            {
                tbDescripcion3.Visible = false;
            }
        }

        private void cbDescripcion4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescripcion4.Checked)
            {
                tbDescripcion4.Visible = true;
            }
            else
            {
                tbDescripcion4.Visible = false;
            }
        }

        private void cbDescripcion5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescripcion5.Checked)
            {
                tbDescripcion5.Visible = true;
            }
            else
            {
                tbDescripcion5.Visible = false;
            }
        }

        private void cmbDescripcion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbDescripcion1.SelectedItem as DataRowView)["ID_DESCRIPCION1"].ToString() == Globals.IdExpediente.ToString())
            {
                cmbExpediente.Text = "SI";
            }
            else
            {
                cmbExpediente.Text = "NO";
            }
        }
    }
}
