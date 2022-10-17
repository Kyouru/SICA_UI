﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Letras
{
    public partial class LetrasBuscar : Form
    {
        public LetrasBuscar()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            LoadingScreen.iniciarLoading();
            strSQL = "SELECT SOCIO, NOMBRE, SOLICITUD, N_LIQ, NUMERO, TO_CHAR(F_GIRO, 'dd/MM/yyyy') AS F_GIRO, TO_CHAR(F_VENCIMIENTO, 'dd/MM/yyyy') AS F_VENCIMIENTO, IMPORTE, ACEPTANTE, MD, NOMBRE_ESTADO";
            strSQL += " FROM ADMIN.LETRA L LEFT JOIN ADMIN.LESTADO LE ON L.ID_ESTADO_FK = LE.ID_ESTADO WHERE 1 = 1";
            if (tbBusquedaLibre.Text != "")
            {
                strSQL += " AND CONCATENADO LIKE @busqueda_libre";
            }
            strSQL += " ORDER BY F_GIRO";
            
            try
            {
                DataTable dt = new DataTable();

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.agregarParametroCommand("@busqueda_libre", "%" + tbBusquedaLibre.Text + "%"))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                Conexion.cerrar();

                dgv.DataSource = dt;
                //dgv.Columns[0].Visible = false;
                dgv.ClearSelection();


                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewCSV(dgv, null);
            //GlobalFunctions.ExportarDGV(dgv, null);
            
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

    }
}
