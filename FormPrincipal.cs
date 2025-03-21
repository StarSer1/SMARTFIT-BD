using System;
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
                string cadenaConexion = @"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
                //string cadenaConexion = @"Data Source=DESKTOP-0434B1E;Initial Catalog=master;Integrated Security=True;";
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
                string cadenaConexion = @"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
                string cadenaConexion2 = @"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=SMARTFITBD;Integrated Security=True;";
                //string cadenaConexion2 = @"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;";
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

        private void btnInsertarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear la conexión general
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                // Insertar datos en la tabla Gimnasio
                string queryGimnasio = "INSERT INTO Gimnasio (Nombre, Direccion, Telefono, Horario_apertura, Horario_cierre) VALUES" +
                    "('Gimnasio Central', 'Av. Principal 123', '555-1234', '05:30:00', '23:00:00')," +
                    "('Gimnasio Sur', 'Calle 45 #567', '555-2345', '06:00:00', '22:00:00')," +
                    "('Gimnasio Norte', 'Calle 78 #910', '555-3456', '06:30:00', '22:00:00')," +
                    "('Gimnasio Este', 'Av. 12 #321', '555-4567', '05:00:00', '23:00:00')," +
                    "('Gimnasio Oeste', 'Calle 22 #112', '555-5678', '07:00:00', '21:00:00')," +
                    "('Gimnasio Centro', 'Calle 13 #45', '555-6789', '06:00:00', '22:00:00')," +
                    "('Gimnasio Playa', 'Av. Costa #101', '555-7890', '05:30:00', '23:00:00')," +
                    "('Gimnasio Montaña', 'Calle Montaña #77', '555-8901', '07:00:00', '20:00:00')," +
                    "('Gimnasio Barrio', 'Calle 5 #212', '555-9012', '06:30:00', '22:00:00')," +
                    "('Gimnasio Los Andes', 'Av. Andes #332', '555-0123', '08:00:00', '20:30:00');";

                SqlCommand cmdGimnasio = new SqlCommand(queryGimnasio, conexion.GetConexion());
                cmdGimnasio.ExecuteNonQuery();

                // Insertar datos en la tabla Personal
                string queryPersonalInsert = @"
                INSERT INTO Personal (Nombre, Apellidos, Dni, Telefono, Direccion, Salario, Horario, Estado, Tipo, Id_gimnasio) VALUES
                ('Juan', 'Perez', '12345678A', '555-1000', 'Av. Principal 123', 2500, '9:00-18:00', 'Activo', 'General', 1),
                ('Ana', 'Lopez', '23456789B', '555-2000', 'Calle 45 #567', 2200, '10:00-19:00', 'Activo', 'General', 2),
                ('Carlos', 'Martinez', '34567890C', '555-3000', 'Calle 78 #910', 2300, '9:30-18:30', 'Activo', 'General', 3),
                ('Maria', 'Garcia', '45678901D', '555-4000', 'Av. 12 #321', 2400, '8:00-17:00', 'Activo', 'General', 4),
                ('Luis', 'Fernandez', '56789012E', '555-5000', 'Calle 22 #112', 2600, '9:00-18:00', 'Activo', 'Administrativo', 5),
                ('Laura', 'Sanchez', '67890123F', '555-6000', 'Calle 14 #555', 2700, '7:30-16:30', 'Activo', 'Administrativo', 6),
                ('Pablo', 'Martinez', '78901234G', '555-7000', 'Calle 15 #123', 2800, '10:00-19:00', 'Activo', 'Administrativo', 7),
                ('Isabel', 'Gomez', '89012345H', '555-8000', 'Calle 16 #432', 2900, '8:30-17:30', 'Activo', 'General', 8),
                ('Raul', 'Fernandez', '90123456I', '555-9000', 'Calle 17 #789', 3000, '9:00-18:00', 'Activo', 'General', 9),
                ('Sofia', 'Ramirez', '01234567J', '555-1001', 'Calle 18 #101', 3100, '10:30-19:30', 'Activo', 'Administrativo', 10);
                ";

                SqlCommand cmdPersonal = new SqlCommand(queryPersonalInsert, conexion.GetConexion());
                cmdPersonal.ExecuteNonQuery();

                // Insertar datos en la tabla General
                string queryGeneral = "INSERT INTO General (Cedúla, Años_de_experiencia, Id_Personal) VALUES" +
                    "('12345678', 5, (SELECT Id_personal FROM Personal WHERE Dni = '12345678A'))," +
                    "('23456789', 3, (SELECT Id_personal FROM Personal WHERE Dni = '23456789B'))," +
                    "('34567890', 4, (SELECT Id_personal FROM Personal WHERE Dni = '34567890C'))," +
                    "('45678901', 6, (SELECT Id_personal FROM Personal WHERE Dni = '45678901D'))," +
                    "('56789012', 2, (SELECT Id_personal FROM Personal WHERE Dni = '56789012E'))," +
                    "('67890123', 7, (SELECT Id_personal FROM Personal WHERE Dni = '67890123F'))," +
                    "('78901234', 8, (SELECT Id_personal FROM Personal WHERE Dni = '78901234G'))," +
                    "('89012345', 6, (SELECT Id_personal FROM Personal WHERE Dni = '89012345H'))," +
                    "('90123456', 10, (SELECT Id_personal FROM Personal WHERE Dni = '90123456I'))," +
                    "('01234567', 3, (SELECT Id_personal FROM Personal WHERE Dni = '01234567J'));";

                SqlCommand cmdGeneral = new SqlCommand(queryGeneral, conexion.GetConexion());
                cmdGeneral.ExecuteNonQuery();

                // Insertar datos en la tabla Administrativo
                string queryAdministrativo = "INSERT INTO Administrativo (Cargo, Equipo, Id_Personal) VALUES" +
                    "('Proveedor', 'Pesas', (SELECT Id_personal FROM Personal WHERE Dni = '12345678A'))," +
                    "('Intendente', 'Equipo de limpieza', (SELECT Id_personal FROM Personal WHERE Dni = '23456789B'))," +
                    "('Tecnico', 'Equipo de computo', (SELECT Id_personal FROM Personal WHERE Dni = '34567890C'))," +
                    "('Proveedor', 'Maquinas', (SELECT Id_personal FROM Personal WHERE Dni = '45678901D'))," +
                    "('Intendente', 'Equipo de limpieza', (SELECT Id_personal FROM Personal WHERE Dni = '56789012E'))," +
                    "('Proveedor', 'Pesas', (SELECT Id_personal FROM Personal WHERE Dni = '67890123F'))," +
                    "('Tecnico', 'Equipo de computo', (SELECT Id_personal FROM Personal WHERE Dni = '78901234G'))," +
                    "('Intendente', 'Equipo de limpieza', (SELECT Id_personal FROM Personal WHERE Dni = '89012345H'))," +
                    "('Proveedor', 'Maquinas', (SELECT Id_personal FROM Personal WHERE Dni = '90123456I'))," +
                    "('Intendente', 'Equipo de limpieza', (SELECT Id_personal FROM Personal WHERE Dni = '01234567J'));";

                SqlCommand cmdAdministrativo = new SqlCommand(queryAdministrativo, conexion.GetConexion());
                cmdAdministrativo.ExecuteNonQuery();

                // Insertar datos en la tabla Planes de Entrenamiento
                string queryPlanesEntrenamiento = "INSERT INTO Planes_Entrenamiento (Nombre_plan, Clientes_inscritos, Descripcion, Costo) VALUES" +
                    "('Plan Básico', 15, 'Plan para principiantes', 50)," +
                    "('Plan Intermedio', 20, 'Plan para nivel intermedio', 75)," +
                    "('Plan Avanzado', 25, 'Plan para nivel avanzado', 100)," +
                    "('Plan Flex', 30, 'Plan flexible con horarios', 60)," +
                    "('Plan Full', 10, 'Plan completo con todos los servicios', 120)," +
                    "('Plan Elite', 50, 'Plan premium para todos los servicios', 200)," +
                    "('Plan Salud', 40, 'Plan de bienestar y salud', 90)," +
                    "('Plan Cardio', 35, 'Plan específico para ejercicios cardiovasculares', 80)," +
                    "('Plan Fuerza', 60, 'Plan para entrenamiento de fuerza', 110)," +
                    "('Plan Flex Plus', 20, 'Plan flexible con más beneficios', 150);";

                SqlCommand cmdPlanesEntrenamiento = new SqlCommand(queryPlanesEntrenamiento, conexion.GetConexion());
                cmdPlanesEntrenamiento.ExecuteNonQuery();

                // Insertar datos en la tabla Clientes
                string queryClientes = "INSERT INTO Clientes (Nombre, Apellidos, Correo_electronico, Estado, Id_plan, Id_gimnasio) VALUES" +
                    "('Sofia', 'Ramirez', 'sofia.ramirez@email.com', 'Activo', 1, 1)," +
                    "('Pedro', 'Alvarez', 'pedro.alvarez@email.com', 'Inactivo', 2, 2)," +
                    "('Lucia', 'Mendez', 'lucia.mendez@email.com', 'Activo', 3, 3)," +
                    "('Carlos', 'Hernandez', 'carlos.hernandez@email.com', 'Activo', 4, 4)," +
                    "('Ana', 'Lopez', 'ana.lopez@email.com', 'Inactivo', 5, 5)," +
                    "('Javier', 'Sosa', 'javier.sosa@email.com', 'Activo', 6, 6)," +
                    "('Bea', 'Morales', 'bea.morales@email.com', 'Activo', 7, 7)," +
                    "('Luis', 'Ruiz', 'luis.ruiz@email.com', 'Activo', 8, 8)," +
                    "('Raul', 'Fernandez', 'raul.fernandez@email.com', 'Inactivo', 9, 9)," +
                    "('Laura', 'Jimenez', 'laura.jimenez@email.com', 'Activo', 10, 10);";

                SqlCommand cmdClientes = new SqlCommand(queryClientes, conexion.GetConexion());
                cmdClientes.ExecuteNonQuery();

                // Insertar datos en la tabla Inventario
                string queryInventario = "INSERT INTO Inventario (Nombre_producto, Descripcion, Cantidad, Tipo, Id_Gimnasio) VALUES" +
                    "('Pesas', 'Pesas de diferentes tamaños', 100, 'Equipamiento', 1)," +
                    "('Bicicletas', 'Bicicletas estáticas para ejercicios cardiovasculares', 50, 'Cardio', 2)," +
                    "('Máquinas de cardio', 'Máquinas para ejercicio cardiovascular', 30, 'Cardio', 3)," +
                    "('Máquinas de fuerza', 'Equipos para entrenamiento de fuerza', 20, 'Fuerza', 4)," +
                    "('Kettlebells', 'Pesas rusas para entrenamiento funcional', 40, 'Funcional', 5)," +
                    "('Colchonetas', 'Colchonetas para yoga y pilates', 60, 'Accesorios', 6)," +
                    "('Barras de pesas', 'Barras para ejercicios de levantamiento', 25, 'Fuerza', 7)," +
                    "('Mancuernas', 'Mancuernas para entrenamiento de fuerza', 80, 'Fuerza', 8)," +
                    "('Balones medicinales', 'Balones para entrenamiento funcional', 35, 'Funcional', 9)," +
                    "('Estación de pesas', 'Estación multifuncional para ejercicios de fuerza', 10, 'Fuerza', 10);";

                SqlCommand cmdInventario = new SqlCommand(queryInventario, conexion.GetConexion());
                cmdInventario.ExecuteNonQuery();

                MessageBox.Show("Datos insertados correctamente.");
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar los datos: " + ex.Message);
            }
        }

    }
}
