using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTFIT
{
    public partial class Clientes : Form
    {
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader Lector;
        public string q;
        public string mensaje;

        public Clientes()
        {
            InitializeComponent();

            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                q = "SELECT * FROM Clientes";
                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;

                conexion.CerrarConexion();
                mensaje = "Datos Mostrados Correctamente";

            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error al mostrar los datos " + ex.Message;
            }
            finally
            {
            }
        }

        private void BtnCrearTabla_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                // Cambiar a la base de datos SMARTFITBD
                q = "USE SMARTFITBD";
                comando = new SqlCommand(q, conexion.GetConexion());
                comando.ExecuteNonQuery();

                // Crear la tabla Clientes
                q = "CREATE TABLE Clientes(" +
                 "Id_cliente INT PRIMARY KEY Identity (1,1), " +
                 "Nombre VARCHAR(50) NOT NULL, " +
                 "Apellidos VARCHAR(50) NOT NULL, " +
                 "Correo_electronico VARCHAR(100) UNIQUE NOT NULL, " +
                 "Estado VARCHAR(20) CHECK (Estado IN ('Activo', 'Inactivo')) DEFAULT 'Inactivo', " +
                 "Id_plan INT, " +
                 "Id_gimnasio INT, " +
                 "CONSTRAINT fk_plan FOREIGN KEY (Id_plan) REFERENCES Planes_Entrenamiento(Id_plan), " +
                 "CONSTRAINT fk_gimnasio_cliente FOREIGN KEY (Id_gimnasio) REFERENCES Gimnasio(Id_gimnasio)" +
                 ");";

                comando = new SqlCommand(q, conexion.GetConexion());
                comando.ExecuteNonQuery();

                //// Crear la vista VistaClientesActivosConPlanYGimnasio
                //q = "CREATE VIEW VistaClientesActivosConPlanYGimnasio AS " +
                //    "SELECT " +
                //    "c.Id_cliente, " +
                //    "c.Nombre AS Nombre_Cliente, " +
                //    "c.Apellidos, " +
                //    "c.Correo_electronico, " +
                //    "p.Nombre_plan, " +
                //    "g.Nombre AS Nombre_Gimnasio " +
                //    "FROM " +
                //    "Clientes c " +
                //    "LEFT JOIN " +
                //    "Planes_Entrenamiento p ON c.Id_plan = p.Id_plan " +
                //    "LEFT JOIN " +
                //    "Gimnasio g ON c.Id_gimnasio = g.Id_gimnasio " +
                //    "WHERE " +
                //    "c.Estado = 'Activo';";
                //comando = new SqlCommand(q, conexion.GetConexion());
                //comando.ExecuteNonQuery();


                /*// Trigger ValidarCorreoCliente
                q = @"
                CREATE TRIGGER ValidarCorreoCliente
                ON Clientes
                AFTER INSERT, UPDATE
                AS
                BEGIN
                    IF EXISTS (
                        SELECT 1
                        FROM inserted
                        WHERE Correo_electronico NOT LIKE '_%@_%._%' 
                    )
                    BEGIN
                        RAISERROR('El formato del correo electrónico es inválido.', 16, 1);
                        ROLLBACK TRANSACTION;
                    END;
                END;";
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();*/

                // Trigger ReactivarCliente
                q = @"
                CREATE TRIGGER ReactivarCliente
                ON Clientes
                AFTER UPDATE
                AS
                BEGIN
                    UPDATE Clientes
                    SET Estado = 'Activo'
                    FROM Clientes c
                    INNER JOIN inserted i ON c.Id_cliente = i.Id_cliente
                    WHERE i.Id_plan IS NOT NULL AND i.Estado = 'Inactivo';

                    PRINT 'Cliente reactivado automáticamente al reinscribirse.';
                END;";
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                mensaje = "Creación de la tabla y vista realizada correctamente.";

                conexion.CerrarConexion();
            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrió un error en la creación de las tablas o vista: " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void BtnInsertarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                // Obtención de valores desde los controles del formulario
                string Nombre = txtNombre.Text;
                string Apellidos = txtApellidos.Text;
                string CorreoElectronico = txtCorreo.Text;
                string Estado = cmbEstado.SelectedItem.ToString(); // Suponiendo que es un ComboBox
                int IdPlan = Convert.ToInt32(txtIdPlan.Text);
                int IdGimnasio = Convert.ToInt32(txtIdGimnasio.Text);

                // Consulta SQL para la inserción de datos
                q = "EXEC AgregarClientes @Nombre, @Apellidos, @Correo_electronico, @Estado, @Id_plan, @Id_gimnasio;";

                // Creación del comando SQL
                comando = new SqlCommand(q, conexion.GetConexion());
                comando.Parameters.Clear();

                // Asignación de parámetros
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar).Value = Apellidos;
                comando.Parameters.Add("@Correo_electronico", SqlDbType.NVarChar).Value = CorreoElectronico;
                comando.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = Estado;
                comando.Parameters.Add("@Id_plan", SqlDbType.Int).Value = IdPlan;
                comando.Parameters.Add("@Id_gimnasio", SqlDbType.Int).Value = IdGimnasio;


                // Ejecución del comando
                comando.ExecuteNonQuery();

                // Cierra la conexión
                conexion.CerrarConexion();

                mensaje = "Datos almacenados correctamente";
            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error en la insersion de datos " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                string opcion = cmbConsulta.SelectedItem.ToString();
                switch (opcion)
                {
                    case "Consulta General":
                        q = "SELECT * FROM Clientes";
                        break;
                    case "Mostrar clientes con correo gmail":
                        q = "SELECT * \r\nFROM Clientes \r\nwhere Estado = 'Activo' AND Correo_electronico Like '%@gmail.com'";
                        break;
                    case "Mostrar los Clientes inactivos de todos los gimnasios":
                        q = "SELECT C.Id_cliente, C.Nombre, C.Apellidos, C.Correo_electronico, C.Estado, G.Nombre AS Gimnasio " +
                            "FROM Clientes C " +
                            "INNER JOIN Gimnasio G ON C.Id_gimnasio = G.Id_gimnasio " +
                            "WHERE C.Estado = 'Inactivo';";
                        break;
                    case "Mostrar Clientes que estan en el Smarfit de Santa Fe":
                        q = "SELECT C.Id_cliente, C.Nombre, C.Apellidos, C.Correo_electronico, C.Estado " +
                            "FROM Clientes C " +
                            "INNER JOIN Gimnasio G ON C.Id_gimnasio = G.Id_gimnasio " +
                            "WHERE G.Nombre LIKE '%Santa Fe';";
                        break;
                    case "Mostrar los clientes con el plan Black":
                        q = "SELECT C.Id_cliente, C.Nombre, C.Apellidos, C.Correo_electronico, C.Estado " +
                            "FROM Clientes C " +
                            "INNER JOIN Planes_Entrenamiento P ON C.Id_plan = P.Id_plan " +
                            "WHERE P.Nombre_plan = 'Plan Black';";
                        break;

                }
                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();
                
                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;

                conexion.CerrarConexion();
                mensaje = "Datos Mostrados Correctamente";

            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error al mostrar los datos " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void Clientes_Load_1(object sender, EventArgs e)
        {

        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();

                // Verifica si la vista ya existe
                string q = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'VistaClientesActivosConPlanYGimnasio')\r\n" +
                           "BEGIN\r\n" +
                           "    EXEC('\r\n" +
                           "        CREATE VIEW VistaClientesActivosConPlanYGimnasio AS\r\n" +
                           "        SELECT \r\n" +
                           "            c.Id_cliente, \r\n" +
                           "            c.Nombre AS Nombre_Cliente, \r\n" +
                           "            c.Apellidos, \r\n" +
                           "            c.Correo_electronico, \r\n" +
                           "            p.Nombre_plan, \r\n" +
                           "            g.Nombre AS Nombre_Gimnasio \r\n" +
                           "        FROM \r\n" +
                           "            Clientes c \r\n" +
                           "        LEFT JOIN \r\n" +
                           "            Planes_Entrenamiento p ON c.Id_plan = p.Id_plan \r\n" +
                           "        LEFT JOIN \r\n" +
                           "            Gimnasio g ON c.Id_gimnasio = g.Id_gimnasio \r\n" +
                           "    ')\r\n" +
                           "    PRINT 'Vista \"VistaClientesActivosConPlanYGimnasio\" creada exitosamente.'\r\n" +
                           "END\r\n" +
                           "ELSE\r\n" +
                           "BEGIN\r\n" +
                           "    PRINT 'La vista \"VistaClientesActivosConPlanYGimnasio\" ya existe.'\r\n" +
                           "END\r\n";

                SqlCommand comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                // Ahora consulta los datos de la vista
                q = "SELECT * FROM VistaClientesActivosConPlanYGimnasio";
                comando = new SqlCommand(q, conexion.GetConexion());
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la vista: " + ex.Message);
            }
        }
    }
}
