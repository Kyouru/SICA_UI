using SICA.Clases;
using System;
using System.Windows.Forms;

namespace SICA
{
    public static class Globals
    {
        public static Int32 loginsuccess = 0;
        public static string lastSQL = "";
        public static Int32 SesionDuracion = 10;
        public static Int32 SesionAlerta = 3;
        public static DateTime UltimaActividad = DateTime.Now;

        public static string api = "http://sica.kyouru.com/api/";
        //public static string api = "http://localhost:5000/api/";
        public static String ExportarPath = Application.StartupPath + "\\Exportar\\";
        public static String strQueryArea = "";

        public static String mostrarSQL = "";

        public static String Token = "";
        public static String NombreCargo = "";

        public static Int32 TipoSeleccionarUsuario = -1;
        public static Int32 IdArea = -1;
        public static Int32 IdInventario = -1;
        public static Int32 IdUsername = -1;
        public static String Username = "";

        public static Int32 IdAreaSelect = -1;
        public static Int32 IdUsernameSelect = -1;
        public static String UsernameSelect = "";
        public static bool EntregarConfirmacion = true;

        public static Int32 CantidadCarrito = 0;
        public static String CarritoSeleccionado = "";

        public static Int32 IdAreaCustodia = 1;
        public static Int32 IdIM = 2;
        public static Int32 IdDC = 10;
        public static Int32 IdAreaBoveda = 9;

        public static Int32 IdExpediente = 1;

        public static Int32 IdCustodiado = 1;
        public static Int32 IdPrestado = 2;
        public static Int32 IdMigrado = 3;
        public static Int32 IdTransito = 4;
        public static Int32 IdStandBy = 5;

        public static String strIronMountainSolicitar = "IM_SOLICITAR";
        public static String strIronMountainRecibir = "IM_RECIBIR";
        public static String strIronMountainArmar = "IM_ARMAR";
        public static String strIronMountainEnviar = "IM_ENVIAR";
        public static String strIronMountainEntregar = "IM_ENTREGAR";

        public static String strRecibirReingreso = "RECIBIR_REINGRESO";
        public static String strRecibirConfirmar = "RECIBIR_CONFIRMAR";

        public static String strEntregarExpediente = "ENTREGAR_EXP";
        public static String strEntregarDocumento = "ENTREGAR_DOC";
        public static String strEntregarPagare = "ENTREGAR_PAG";
        public static String strEntregarPagareSinDesembolsar = "ENTREGAR_PAG_SIN";
        public static String strEntregarEsctado = "PRESTADO";

        public static String strBovedaRetirarDOC = "BOVEDA_RETIRAR_DOC";
        public static String strBovedaGuardarDOC = "BOVEDA_GUARDAR_DOC";
        public static String strBovedaRetirarCAJA = "BOVEDA_RETIRAR_CAJA";
        public static String strBovedaGuardarCAJA = "BOVEDA_GUARDAR_CAJA";

        public static String strPagareRecibir = "PAGARE_RECIBIR";
        public static String strPagareEntregar = "PAGARE_ENTREGAR";

        public static String strVerificarCAJA = "VERIFICAR_CAJA";
        public static String strnumeroCAJA = "";

        public static String strDocuClassEntregar = "DOCUCLASS_ENTREGAR";
        public static String strDocuClassRecibir = "DOCUCLASS_RECIBIR";

        public static String strLetrasReingreso = "LETRAS_REINGRESO";
        public static String strLetrasEntregar = "LETRAS_ENTREGAR";

        public static String strSeleccionarUsuario = "";

        //Permisos
        public static string auBusqueda = "0";
        public static string auBusquedaHistorico = "0";
        public static string auBusquedaEditar = "0";
        public static string auEntregar = "0";
        public static string auEntregarExpediente = "0";
        public static string auEntregarDocumento = "0";
        public static string auRecibir = "0";
        public static string auRecibirNuevo = "0";
        public static string auRecibirReingreso = "0";
        public static string auRecibirConfirmar = "0";
        public static string auRecibirManual = "0";
        public static string auPagare = "0";
        public static string auPagareBuscar = "0";
        public static string auPagareRecibir = "0";
        public static string auPagareEntregar = "0";
        public static string auLetra = "0";
        public static string auLetraNuevo = "0";
        public static string auLetraEntregar = "0";
        public static string auLetraReingreso = "0";
        public static string auLetraBuscar = "0";
        public static string auIronMountain = "0";
        public static string auIronMountainSolicitar = "0";
        public static string auIronMountainRecibir = "0";
        public static string auIronMountainArmar = "0";
        public static string auIronMountainEnviar = "0";
        public static string auIronMountainEntregar = "0";
        public static string auIronMountainCargo = "0";
        public static string auBoveda = "0";
        public static string auBovedaCajaRetirar = "0";
        public static string auBovedaCajaGuardar = "0";
        public static string auBovedaDocumentoRetirar = "0";
        public static string auBovedaDocumentoGuardar = "0";
        public static string auImportar = "0";
        public static string auImportarActivas = "0";
        public static string auImportarPasivas = "0";
        public static string auMantenimiento = "0";
        public static string auMantenimientoSocio = "0";
        public static string auMantenimientoCuenta = "0";
        public static string auMantenimientoCredito = "0";
        public static string auReporte = "0";
        public static string auReportePrestado = "0";
        public static string auReporteNoCustodiado = "0";
        public static string auNivel = "0";
    }
}
