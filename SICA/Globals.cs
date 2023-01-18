﻿using SICA.Clases;
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

        public static String strValijaReingreso = "VALIJA_REINGRESO";
        public static String strValijaConfirmar = "VALIJA_CONFIRMAR";
        public static String strValijaOK = "VALIJA_OK";
        public static String strValijaPendiente = "VALIJA_PENDIENTE";

        public static String strMoverExpediente = "MOVER_EXP";
        public static String strMoverDocumento = "MOVER_DOC";
        public static String strMoverPagare = "MOVER_PAG";
        public static String strMoverPagareSinDesembolsar = "MOVER_PAG_SIN";
        public static String strMoverEstado = "PRESTADO";

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

        public static String strPrestarPrestar = "PRESTAR_PRESTAR";
        public static String strPrestarRecibir = "PRESTAR_RECIBIR";

        public static String strSeleccionarUsuario = "";

        //Permisos
        public static string auBusqueda = "0";
        public static string auBusquedaHistorico = "0";
        public static string auBusquedaEditar = "0";
        public static string auMover = "0";
        public static string auMoverExpediente = "0";
        public static string auMoverDocumento = "0";
        public static string auMoverMasivo = "0";
        public static string auValija = "0";
        public static string auValijaNuevo = "0";
        public static string auValijaReingreso = "0";
        public static string auValijaConfirmar = "0";
        public static string auValijaManual = "0";
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
        public static string auReporteCajas = "0";
        public static string auReportePrestado = "0";
        public static string auReporteNoCustodiado = "0";
        public static string auPendiente = "0";
        public static string auPendienteRegularizar = "0";
        public static string auPrestar = "0";
        public static string auPrestarPrestar = "0";
        public static string auPrestarRecibir = "0";
        public static string auNivel = "0";
    }
}
