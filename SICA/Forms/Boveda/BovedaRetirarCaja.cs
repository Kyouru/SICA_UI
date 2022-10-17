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

namespace SICA.Forms.Boveda
{
    public partial class BovedaRetirarCaja : Form
    {
        public BovedaRetirarCaja()
        {
            InitializeComponent();
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LoadingScreen.iniciarLoading();
                DataTable dt = new DataTable();

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Boveda/buscarretirarcaja");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        numerocaja = tbCaja.Text
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
                    dgv.DataSource = dt;
                    dgv.Columns[0].Visible = false;
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
                        GlobalFunctions.casoError(ex, "btBuscar_Click\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "btBuscar_Click");
            }
        }


        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv.SelectedRows.Count == 1)
                {
                    if (!validarCaja(dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Int32.Parse(dgv.SelectedRows[0].Cells["ID_BOVEDA"].Value.ToString())))
                        return;
                    if (!RetirarCaja(dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Int32.Parse(dgv.SelectedRows[0].Cells["ID_BOVEDA"].Value.ToString())))
                        return;
                }
            }
        }


        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDGV(dgv, null);
        }

        private bool validarCaja(string numero_caja, int id_boveda)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                if (!GlobalFunctions.verificarCaja(numero_caja, id_boveda))
                {
                    DialogResult dialogResult = MessageBox.Show("Hay documentos de esta caja que lo posee otro usuario\nDesea Retirarlo de todas manera?", "Caja Incompleta", MessageBoxButtons.YesNo);
                    if (dialogResult != DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool RetirarCaja (string numero_caja, int id_boveda)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Boveda/retirarcaja");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        token = Globals.Token,
                        idaux = id_boveda,
                        fecha = fecha,
                        numerocaja = numero_caja
                    });
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        LoadingScreen.cerrarLoading();
                        MessageBox.Show("Proceso Completado");
                    }
                }
                return true;
            }
            catch (WebException ex)
            {
                LoadingScreen.cerrarLoading();
                if (!(ex.Response is null))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        GlobalFunctions.casoError(ex, "Error Boveda agregar\n" + reader.ReadToEnd());
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LoadingScreen.cerrarLoading();
                GlobalFunctions.casoError(ex, "Error Boveda agregar");
                return false;
            }
        }
    }
}
