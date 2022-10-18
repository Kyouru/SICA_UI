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
    public partial class CuentaModificar : Form
    {
        DataTable dt;
        public CuentaModificar()
        {
            InitializeComponent(); 
        }

        private void CuentaModificar_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalFunctions.UltimaActividad();
                LoadingScreen.iniciarLoading();

                //Lista Usuarios
                DataTable dt = new DataTable("Lista Usuarios");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Common/listausuarios");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        tiposeleccionarusuario = 3
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

                DataTable dtarea = new DataTable("AREA");
                dtarea.Columns.Add("ID_AREA");
                dtarea.Columns.Add("NOMBRE_AREA");
                foreach (DataRow row in dt.Rows)
                {
                    DataRow dr = dtarea.NewRow();
                    dr["ID_AREA"] = row["ID_AREA"];
                    dr["NOMBRE_AREA"] = row["NOMBRE_AREA"];
                    dtarea.Rows.Add(dr);
                }
                cmbArea.DataSource = dtarea;
                cmbArea.DisplayMember = "NOMBRE_AREA";
                cmbArea.ValueMember = "ID_AREA";

                //Lista Usuarios
                dt = new DataTable("Usuario");

                httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/datousuario");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        idaux = Globals.IdInventario
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
                        tbNombreUsuario.Text = dt.Rows[0]["NOMBRE_USUARIO"].ToString();
                        cmbArea.Text = dt.Rows[0]["NOMBRE_AREA"].ToString();
                        tbCorreo.Text = dt.Rows[0]["EMAIL"].ToString();
                        if (dt.Rows[0]["ANULADO"].ToString() == "1")
                        {
                            cbDesabilitado.Checked = true;
                        }
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
            GlobalFunctions.UltimaActividad();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (tbNombreUsuario.Text != "")
            {
                if (cmbArea.SelectedIndex >= 0)
                {
                    if (tbCorreo.Text != "")
                    {
                        if (!GlobalFunctions.IsValidEmail(tbCorreo.Text))
                        {
                            MessageBox.Show("Email no valido");
                        }
                        else
                        {
                            try
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (row["NOMBRE_USUARIO"].ToString() == tbNombreUsuario.Text)
                                    {
                                        MessageBox.Show("Nombre Duplicado");
                                        return;
                                    }
                                }
                                bool deshabilitado = false;
                                if (cbDesabilitado.Checked)
                                {
                                    deshabilitado = true;
                                }

                                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Mantenimiento/modificarusuario");
                                httpWebRequest.ContentType = "application/json";
                                httpWebRequest.Method = "POST";

                                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                {
                                    string json = new JavaScriptSerializer().Serialize(new
                                    {
                                        token = Globals.Token,
                                        idinventario = Globals.IdInventario,
                                        descripcion1 = tbNombreUsuario.Text,
                                        idaux = Int32.Parse((cmbArea.SelectedItem as DataRowView)["ID_AREA"].ToString()),
                                        descripcion2 = tbCorreo.Text,
                                        anulado = deshabilitado
                                    });

                                    streamWriter.Write(json);
                                }

                                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                if (httpResponse.StatusCode == HttpStatusCode.OK)
                                {
                                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                    {
                                        string result = streamReader.ReadToEnd();
                                        MessageBox.Show("Registro Completado");
                                        this.Close();
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
                                        GlobalFunctions.casoError(ex, "Error Mantenimiento Crear Usuario\n" + reader.ReadToEnd());
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                GlobalFunctions.casoError(ex, "Error Mantenimiento Crear Usuario");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email Vacio");
                    }
                }
                else
                {
                    MessageBox.Show("Falta Area");
                }
            }
            else
            {
                MessageBox.Show("Falta Nombre Usuario");
            }
        }
    }
}
