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

namespace SICA.Forms.Busqueda
{
    public partial class HistoricoMovimiento : Form
    {
        public HistoricoMovimiento()
        {
            InitializeComponent();
        }

        private void HistoricoMovimiento_Load(object sender, EventArgs e)
        {
            try {

                DataTable dt = new DataTable("Historico Movimiento");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Busqueda/historicomovimiento");
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
                dgv.Columns[0].Visible = false;

            }
            catch (WebException ex)
            {
                LoadingScreen.cerrarLoading();
                if (!(ex.Response is null))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        GlobalFunctions.casoError(ex, "Error Historico Movimiento\n" + reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "Error Historico Movimiento");
            }
        }
    }
}
