﻿using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.IronMountain
{
    public partial class DataManagerSolicitar : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strIronMountainSolicitar;

        public DataManagerSolicitar()
        {
            InitializeComponent();
            Globals.CarritoSeleccionado = tipo_carrito;
            actualizarCantidad();
        }

        public void actualizarCantidad(int cantidad = -1)
        {
            if (cantidad >= 0)
            {
                cantidadcarrito = cantidad;
            }
            else
            {
                cantidadcarrito = GlobalFunctions.CantidadCarrito(tipo_carrito);
            }
            lbCantidad.Text = "(" + cantidadcarrito + ")";
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (tbBusquedaLibre.Text + tbCaja.Text == "")
            {
                MessageBox.Show("Filtro Vacio");
                return;
            }

            string strSQL = "";
            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable("INVENTARIO_GENERAL");

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, DEP.NOMBRE_DEPARTAMENTO AS DEPART, DOC.NOMBRE_DOCUMENTO AS DOC, TO_CHAR(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, TO_CHAR(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, LE.NOMBRE_ESTADO AS CUSTODIADO, U.NOMBRE_USUARIO AS POSEE, TO_CHAR(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                strSQL += " FROM ((((ADMIN.INVENTARIO_GENERAL IG LEFT JOIN ADMIN.TMP_CARRITO TC ON IG.NUMERO_DE_CAJA = TC.NUMERO_CAJA)";
                strSQL += " LEFT JOIN ADMIN.LDEPARTAMENTO DEP ON IG.ID_DEPARTAMENTO_FK = DEP.ID_DEPARTAMENTO)";
                strSQL += " LEFT JOIN ADMIN.LDOCUMENTO DOC ON IG.ID_DOCUMENTO_FK = DOC.ID_DOCUMENTO)";
                strSQL += " LEFT JOIN ADMIN.USUARIO U ON U.ID_USUARIO = IG.ID_USUARIO_POSEE)";
                strSQL += " LEFT JOIN ADMIN.LESTADO LE ON LE.ID_ESTADO = IG.ID_ESTADO_FK";
                strSQL += " WHERE TC.ID_TMP_CARRITO IS NULL AND IG.ID_USUARIO_POSEE = " + Globals.IdIM;

                if (tbCaja.Text != "")
                {
                    strSQL += " AND NUMERO_DE_CAJA LIKE '%" + tbCaja.Text + "%'";
                }

                if (tbBusquedaLibre.Text != "")
                {
                    strSQL += " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL += " ORDER BY DOC.NOMBRE_DOCUMENTO";

                if (!Conexion.conectar())
                    return;
                if (!Conexion.iniciaCommand(strSQL))
                    return;
                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                actualizarCantidad();
                Conexion.cerrar();

                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;
                dgv.ClearSelection();


                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                IronMountainFunctions.SolicitarCajasCarrito();
                actualizarCantidad(0);
            }
        }


        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (!Conexion.conectar())
                    return;
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    string strSQL = "INSERT INTO ADMIN.TMP_CARRITO (ID_INVENTARIO_GENERAL_FK, ID_AUX_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (";
                    strSQL += row.Cells[0].Value.ToString() + ", " + 0 + ", " + Globals.IdUsername + ", '" + tipo_carrito + "', '" + row.Cells["CAJA"].Value.ToString() + "')";
                    try
                    {
                        if (!Conexion.iniciaCommand(strSQL))
                            return;
                        if (!Conexion.ejecutarQuery())
                            return;
                    }
                    catch (Exception ex)
                    {
                        GlobalFunctions.casoError(ex, strSQL);
                        return;
                    }
                    ++cantidadcarrito;
                }
                btBuscar_Click(sender, e);
                Conexion.cerrar();
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDGV(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            btBuscar_Click(sender, e);
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.ShowDialog();
                btBuscar_Click(sender, e);
            }
        }

        private void tbCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }
    }
}
