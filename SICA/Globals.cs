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
        public static bool cerrando = false;
        //public static string api = "https://sica.kyouru.com/api/";
        public static string api = "https://localhost:5001/api/";
        public static String ExportarPath = Application.StartupPath + "\\Exportar\\";
        public static String strQueryArea = "";

        public static String mostrarSQL = "";

        public static String Token = "";
        public static String NombreCargo = "";

        public static Int32 TipoSeleccionarUsuario = -1;
        public static Int32 TipoSeleccionarUbicacion = -1;

        public static Int32 IdInventario = -1;
        public static Int32 IdUsername = -1;
        public static String Username = "";

        public static Int32 IdUbicacionSelect = -1;
        public static String UbicacionSelect = "";
        public static Int32 IdUsernameSelect = -1;
        public static String UsernameSelect = "";

        public static Int32 CantidadCarrito = 0;
        public static String CarritoSeleccionado = "";

        public static String strValijaReingreso = "VALIJA_REINGRESO";
        public static String strValijaConfirmar = "VALIJA_CONFIRMAR";
        public static String strValijaOK = "VALIJA_OK";
        public static String strValijaPendiente = "VALIJA_PENDIENTE";

        public static String strMoverExpediente = "MOVER_EXP";
        public static String strMoverDocumento = "MOVER_DOC";
        public static String strMoverPagare = "MOVER_PAG";
        public static String strMoverPagareSinDesembolsar = "MOVER_PAG_SIN";
        public static String strMoverEstado = "PRESTADO";

        public static String strPagareRecibir = "PAGARE_RECIBIR";
        public static String strPagareEntregar = "PAGARE_ENTREGAR";

        public static String strVerificarCAJA = "VERIFICAR_CAJA";
        public static String strnumeroCAJA = "";

        public static String strLetrasReingreso = "LETRAS_REINGRESO";
        public static String strLetrasEntregar = "LETRAS_ENTREGAR";

        public static String strPrestarPrestar = "PRESTAR_PRESTAR";
        public static String strPrestarRecibir = "PRESTAR_RECIBIR";

        public static String strSeleccionarUsuario = "";

        //Permisos
        public static string Busqueda = "0";
        public static string BusquedaHistorico = "0";
        public static string BusquedaEditar = "0";
        public static string Mover = "0";
        public static string MoverExpediente = "0";
        public static string MoverDocumento = "0";
        public static string MoverMasivo = "0";
        public static string Valija = "0";
        public static string ValijaNuevo = "0";
        public static string ValijaReingreso = "0";
        public static string ValijaConfirmar = "0";
        public static string ValijaManual = "0";
        public static string Pagare = "0";
        public static string PagareBuscar = "0";
        public static string PagareRecibir = "0";
        public static string PagareEntregar = "0";
        public static string Letra = "0";
        public static string LetraNuevo = "0";
        public static string LetraEntregar = "0";
        public static string LetraReingreso = "0";
        public static string LetraBuscar = "0";
        public static string Mantenimiento = "0";
        public static string MantenimientoSocio = "0";
        public static string MantenimientoUsuarioExterno = "0";
        public static string MantenimientoCredito = "0";
        public static string MantenimientoListas = "0";
        public static string Reporte = "0";
        public static string ReporteCajas = "0";
        public static string ReportePrestado = "0";
        public static string ReporteNoCustodiado = "0";
        public static string Pendiente = "0";
        public static string PendienteRegularizar = "0";
        public static string Prestar = "0";
        public static string PrestarPrestar = "0";
        public static string PrestarRecibir = "0";
        public static string Nivel = "0";
    }
}
