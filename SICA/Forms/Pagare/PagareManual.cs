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

namespace SICA.Forms.Pagare
{
    public partial class PagareManual : Form
    {
        public PagareManual()
        {
            GlobalFunctions.UltimaActividad();
            InitializeComponent();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            GlobalFunctions.UltimaActividad();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (tbSolicitudSISGO.Text != "")
            {
                if (tbCodigoSocio.Text != "")
                {
                    if (tbNombre.Text != "")
                    {
                        Globals.TipoSeleccionarUsuario = 1;
                        SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                        suf.ShowDialog();
                        if (Globals.IdUsernameSelect > 0)
                        {
                            try
                            {
                                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                                LoadingScreen.iniciarLoading();
                                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Globals.api + "Pagare/registrar");
                                httpWebRequest.ContentType = "application/json";
                                httpWebRequest.Method = "POST";

                                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                {
                                    string json = new JavaScriptSerializer().Serialize(new
                                    {
                                        token = Globals.Token,
                                        idaux = Globals.IdUsernameSelect,
                                        fecha = fecha,
                                        descripcion1 = tbSolicitudSISGO.Text,
                                        descripcion2 = tbCodigoSocio.Text,
                                        descripcion3 = tbNombre.Text,
                                        observacion = observacion
                                    }) ;

                                    streamWriter.Write(json);
                                }

                                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                if (httpResponse.StatusCode == HttpStatusCode.OK)
                                {
                                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                    {
                                        string result = streamReader.ReadToEnd();
                                        LoadingScreen.cerrarLoading();
                                        if (result == "Nuevo")
                                        {
                                            MessageBox.Show("Registro Completado");
                                        }
                                        else if (result == "Duplicado")
                                        {
                                            MessageBox.Show("Duplicado");
                                        }
                                    }
                                }
                                this.Close();
                            }
                            catch (WebException ex)
                            {
                                LoadingScreen.cerrarLoading();
                                if (!(ex.Response is null))
                                {
                                    using (var stream = ex.Response.GetResponseStream())
                                    using (var reader = new StreamReader(stream))
                                    {
                                        GlobalFunctions.casoError(ex, "Pagare Manual btRegistrar_Click\n" + reader.ReadToEnd());
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LoadingScreen.cerrarLoading();
                                GlobalFunctions.casoError(ex, "Pagare Manual btRegistrar_Click");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta Nombre");
                    }
                }
                else
                {
                    MessageBox.Show("Falta Codigo Socio");
                }
            }
            else
            {
                MessageBox.Show("Falta Solicitud SISGO");
            }
        }
    }
}
