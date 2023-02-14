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

namespace SICA.Forms.Busqueda.Historico
{
    public partial class HistoricoGeneral : Form
    {
        public HistoricoGeneral()
        {
            GlobalFunctions.UltimaActividad();
            InitializeComponent();
        }

        private void HistoricoGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalFunctions.UltimaActividad();
                DataTable dt = new DataTable("Historico General");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/historico");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Globals.Token);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        idinventario = Globals.IdInventario
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

                if (dt.Rows.Count == 0)
                    return;
                
                dgv.DataSource = dt;
                dgv.AutoResizeColumns();
                dgv.Columns["ID"].Visible = false;
                dgv.Columns["PRIORIDAD"].Visible = false;

            }
            catch (WebException ex)
            {
                LoadingScreen.cerrarLoading();
                if (!(ex.Response is null))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        GlobalFunctions.casoError(ex, "Error Historico General\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Error Historico General");
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
