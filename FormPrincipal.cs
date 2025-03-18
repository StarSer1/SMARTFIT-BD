﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTFIT
{
    public partial class FormPrincipal : Form
    {
        //Variables
        private Form activateForm;

        //Variables base de datos
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader Lector;
        public string q;
        public string mensaje;

        public FormPrincipal()
        {
            InitializeComponent();
            OpenChildForm(new FormMenu());

            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;

            this.Text = string.Empty;
            this.ControlBox = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //PANEL
        private void OpenChildForm(Form childForm)
        {
            if (activateForm != null)
            {
                activateForm.Close();
            }
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None; 
            childForm.Dock = DockStyle.Fill;
            this.panelFondo.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();

            label1.Text = childForm.Text;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGimnasio_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panelPersonal.Visible = false;
            panelAdministrativo.Visible = false;
            panelGeneral.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;
            OpenChildForm(new Form1());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //@"Data Source=DESKTOP-0434B1E;Initial Catalog=master;Integrated Security=True;"
                string cadenaConexion = @"Data Source=DESKTOP-0434B1E;Initial Catalog=master;Integrated Security=True;";
                SqlConnection conexion = new SqlConnection(cadenaConexion);

                conexion.Open();
                {

                    // Cambiar a modo de usuario único y forzar cierre de conexiones
                    q = "ALTER DATABASE SMARTFITBD SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                    comando = new SqlCommand(q, conexion);
                    comando.ExecuteNonQuery();

                    // Eliminar la base de datos
                    q = "DROP DATABASE SMARTFITBD;";
                    comando = new SqlCommand(q, conexion);
                    comando.ExecuteNonQuery();

                    mensaje = "La base de datos fue eliminada correctamente.";
                    conexion.Close();
                }
            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error en la eliminacion de la Base de Datos" + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearDB_Click(object sender, EventArgs e)
        {
            try
            {
                //@"Data Source=DESKTOP-0434B1E;Initial Catalog=master;Integrated Security=True;"
                string cadenaConexion = @"Data Source=DESKTOP-0434B1E;Initial Catalog=master;Integrated Security=True;";
                string cadenaConexion2 = @"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;";
                SqlConnection conexion = new SqlConnection(cadenaConexion);

                q = "create database SMARTFITBD";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                //Brandon Procedimientos almacenados
                //Agregar administrativo
                conexion = new SqlConnection(cadenaConexion2);
                q = "CREATE PROCEDURE AgregarAdministrativo\r\n\t@Cargo  VARCHAR(30),\r\n\t@Equipo VARCHAR(30),\r\n\t@Id_Personal INT\r\nAS\r\nBEGIN TRY\r\n\tINSERT INTO Administrativo\r\n\t(Cargo, Equipo, Id_Personal)\r\n\tVALUES\r\n\t(@Cargo, @Equipo, @Id_Personal)\r\nEND TRY\r\nBEGIN CATCH\r\nSELECT ERROR_NUMBER(),ERROR_MESSAGE()\r\nEND CATCH\r\n";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                //Agregar Plan de entrenamiento
                conexion = new SqlConnection(cadenaConexion2);
                q = "CREATE PROCEDURE AgregarPlanEntrenamiento\r\n\t@Nombre_plan VARCHAR(20),\r\n\t@Clientes_inscritos INT,\r\n    @Descripcion VARCHAR,\r\n    @Costo INT\r\nAS\r\nBEGIN TRY\r\n\tINSERT INTO Planes_Entrenamiento\r\n\t(Nombre_plan, Clientes_inscritos, Descripcion, Costo)\r\n\tVALUES\r\n\t(@Nombre_plan, @Clientes_inscritos, @Descripcion, @Costo)\r\nEND TRY\r\nBEGIN CATCH\r\nSELECT ERROR_NUMBER(),ERROR_MESSAGE()\r\nEND CATCH\r\n";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                //Agregar Clientes
                conexion = new SqlConnection(cadenaConexion2);
                q = "CREATE PROCEDURE AgregarClientes\r\n    @Nombre VARCHAR(50),\r\n    @Apellidos VARCHAR(50),\r\n    @Correo_electronico VARCHAR(100),\r\n    @Estado VARCHAR(20),\r\n    @Id_plan INT,\r\n    @Id_gimnasio INT\r\nAS\r\nBEGIN TRY\r\n    INSERT INTO Clientes\r\n    (Nombre, Apellidos, Correo_electronico, Estado, Id_plan, Id_gimnasio)\r\n    VALUES\r\n    (@Nombre, @Apellidos, @Correo_electronico, @Estado, @Id_plan, @Id_gimnasio)\r\nEND TRY\r\nBEGIN CATCH\r\n    SELECT ERROR_NUMBER(), ERROR_MESSAGE()\r\nEND CATCH";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                //Agregar Inventario
                conexion = new SqlConnection(cadenaConexion2);
                q = "CREATE PROCEDURE AgregarInventario\r\n    @Nombre_producto VARCHAR(100),\r\n    @Descripcion VARCHAR(255), \r\n    @Cantidad INT,\r\n\t@Tipo VARCHAR(100),\r\n\t@Id_Gimnasio INT\r\nAS\r\nBEGIN TRY\r\nINSERT INTO Inventario\r\n\t(Nombre_producto, Descripcion, Cantidad, Tipo, Id_Gimnasio)\r\n\tVALUES\r\n\t(@Nombre_producto, @Descripcion, @Cantidad, @Tipo, @Id_Gimnasio)\r\nEND TRY\r\nBEGIN CATCH\r\nSELECT ERROR_NUMBER(),ERROR_MESSAGE()\r\nEND CATCH\r\n";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                
                //Agregar Gimnasio
                conexion = new SqlConnection(cadenaConexion2);
                q = "CREATE PROCEDURE AgregarGimnasio\r\n@Nombre varchar(100),\r\n@Direccion varchar(100),\r\n@Telefono varchar(20),\r\n@Horario_apertura TIME,\r\n@Horario_cierre TIME\r\nAS\r\nBEGIN TRY\r\n\tINSERT INTO Gimnasio\r\n\t(Nombre,Direccion,Telefono,Horario_apertura,Horario_cierre)\r\n\tVALUES\r\n\t(@Nombre,@Direccion,@Telefono,@Horario_apertura,@Horario_cierre)\r\nEND TRY\r\nBEGIN CATCH\r\nSELECT ERROR_NUMBER(),ERROR_MESSAGE()\r\nEND CATCH\r\n";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                //Agregar Personal
                conexion = new SqlConnection(cadenaConexion2);
                q = "CREATE PROCEDURE AgregarPersonal\r\n@Nombre varchar(50),\r\n@Apellidos varchar(50),\r\n@Dni varchar(15),\r\n@Telefono varchar(20),\r\n@Direccion varchar(225),\r\n@Salario INT,\r\n@Horario VARCHAR(100),\r\n@Estado VARCHAR (100),\r\n@Tipo VARCHAR(50),\r\n@Id_gimnasio INT\r\nAS\r\nBEGIN TRY\r\n\tINSERT INTO Personal\r\n\t(Nombre,Apellidos,Dni,Telefono,Direccion,Salario,Horario,Estado,Tipo,Id_gimnasio)\r\n\tVALUES\r\n\t(@Nombre,@Apellidos,@Dni,@Telefono,@Direccion,@Salario,\r\n\t@Horario,@Estado, @Tipo, @Id_gimnasio)\r\nEND TRY\r\nBEGIN CATCH\r\nSELECT ERROR_NUMBER(),ERROR_MESSAGE()\r\nEND CATCH\r\n";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                //Agregar PGeneral
                conexion = new SqlConnection(cadenaConexion2);
                q = "CREATE PROCEDURE AgregarGeneral\r\n@Cedula VARCHAR(30),\r\n@Años_Exp INT,\r\n@Id_Personal INT\r\nAS\r\nBEGIN\r\n    BEGIN TRY\r\n        INSERT INTO General\r\n        ([Cedúla], Años_de_experiencia, Id_Personal)\r\n        VALUES\r\n        (@Cedula, @Años_Exp, @Id_Personal);\r\n\r\n    END TRY\r\n    BEGIN CATCH\r\n        SELECT ERROR_NUMBER() AS Error_Numero, ERROR_MESSAGE() AS Error_Mensaje;\r\n    END CATCH\r\nEND;\r\n";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                //conexion = new SqlConnection(cadenaConexion2);
                //// Trigger IngresarPersonal
                //q = @"
                //CREATE TRIGGER IngresarPersonal
                //ON Personal
                //AFTER INSERT
                //AS
                //BEGIN
                //    SET NOCOUNT ON;
                //    INSERT INTO General (Id_Personal)
                //    SELECT Id_Personal
                //    FROM inserted
                //    WHERE Tipo = 'General';

                //    INSERT INTO Administrativo(Id_Personal)
                //    SELECT Id_Personal
                //    FROM inserted
                //    WHERE Tipo = 'Administrativo';
                //END;";
                //comando = new SqlCommand(q, conexion);
                //conexion.Open();
                //comando.ExecuteNonQuery();

                //conexion = new SqlConnection(cadenaConexion2);

                //// Trigger AlertaStockBajo
                //q = @"
                //CREATE TRIGGER AlertaStockBajo
                //ON Inventario
                //AFTER INSERT, UPDATE
                //AS
                //BEGIN
                //    IF EXISTS (
                //        SELECT 1 
                //        FROM inserted 
                //        WHERE Cantidad < 5
                //    )
                //    BEGIN
                //        PRINT 'Advertencia: Hay productos con stock bajo (menos de 5 unidades).';
                //    END;
                //END;";
                //comando = new SqlCommand(q, conexion);
                //conexion.Open();
                //comando.ExecuteNonQuery();

                //conexion = new SqlConnection(cadenaConexion2);

                //// Trigger ActivarCliente
                //q = @"
                //CREATE TRIGGER ActivarCliente
                //ON Clientes
                //AFTER INSERT, UPDATE
                //AS
                //BEGIN
                //    UPDATE Clientes
                //    SET Estado = 'Activo'
                //    FROM Clientes c
                //    INNER JOIN inserted i ON c.Id_cliente = i.Id_cliente
                //    WHERE i.Id_plan IS NOT NULL;

                //    PRINT 'Cliente activado automáticamente al asignarle un plan.';
                //END;";
                //comando = new SqlCommand(q, conexion);
                //conexion.Open();
                //comando.ExecuteNonQuery();

                //conexion = new SqlConnection(cadenaConexion2);

                //// Trigger ValidarCorreoCliente
                //q = @"
                //CREATE TRIGGER ValidarCorreoCliente
                //ON Clientes
                //AFTER INSERT, UPDATE
                //AS
                //BEGIN
                //    IF EXISTS (
                //        SELECT 1
                //        FROM inserted
                //        WHERE Correo_electronico NOT LIKE '_%@_%._%' 
                //    )
                //    BEGIN
                //        RAISERROR('El formato del correo electrónico es inválido.', 16, 1);
                //        ROLLBACK TRANSACTION;
                //    END;
                //END;";
                //comando = new SqlCommand(q, conexion);
                //conexion.Open();
                //comando.ExecuteNonQuery();

                //conexion = new SqlConnection(cadenaConexion2);

                //// Trigger VerificarGimnasio
                //q = @"
                //CREATE TRIGGER VerificarGimnasio
                //ON Personal
                //AFTER INSERT, UPDATE
                //AS
                //BEGIN
                //    IF EXISTS (
                //        SELECT 1
                //        FROM inserted i
                //        LEFT JOIN Gimnasio g ON i.Id_gimnasio = g.Id_gimnasio
                //        WHERE g.Id_gimnasio IS NULL AND i.Id_gimnasio IS NOT NULL
                //    )
                //    BEGIN
                //        RAISERROR('El gimnasio asignado no existe.', 16, 1);
                //        ROLLBACK TRANSACTION;
                //    END;
                //END;";
                //comando = new SqlCommand(q, conexion);
                //conexion.Open();
                //comando.ExecuteNonQuery();

                //conexion = new SqlConnection(cadenaConexion2);

                //// Trigger ReactivarCliente
                //q = @"
                //CREATE TRIGGER ReactivarCliente
                //ON Clientes
                //AFTER UPDATE
                //AS
                //BEGIN
                //    UPDATE Clientes
                //    SET Estado = 'Activo'
                //    FROM Clientes c
                //    INNER JOIN inserted i ON c.Id_cliente = i.Id_cliente
                //    WHERE i.Id_plan IS NOT NULL AND i.Estado = 'Inactivo';

                //    PRINT 'Cliente reactivado automáticamente al reinscribirse.';
                //END;";
                //comando = new SqlCommand(q, conexion);
                //conexion.Open();
                //comando.ExecuteNonQuery();

                conexion.Close();

                mensaje = "La base de datos fue creada correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Ocurrio un error en la creacion de la Base de Datos " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panelPersonal.Visible = false;
            panelAdministrativo.Visible = false;
            panelGeneral.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;

            OpenChildForm(new FormMenu());
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = true;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;
            OpenChildForm(new Personal());
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelAdministrativo.Visible = false;
            panelGeneral.Visible = true;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;
            OpenChildForm(new General());
        }

        private void btnAdministrativo_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = true;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;
            OpenChildForm(new Administrativo());
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = false;
            panelPlan.Visible = true;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;
            OpenChildForm(new Plan());
        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = true;
            panelInventario.Visible = false;
            OpenChildForm(new Clientes());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = true;
            OpenChildForm(new Inventario());
        }
    }
}
