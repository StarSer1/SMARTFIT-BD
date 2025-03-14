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
                q = "use SMARTFITBD";
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                q = "CREATE TABLE Clientes(" +
                    "Id_cliente INT PRIMARY KEY, " +
                    "Nombre VARCHAR(50) NOT NULL, " +
                    "Apellidos VARCHAR(50) NOT NULL, " +
                    "Correo_electronico VARCHAR(100) UNIQUE NOT NULL, " +
                    "Estado VARCHAR(20) CHECK (estado = 'Activo' OR estado = 'Inactivo') DEFAULT 'Inactivo', " +
                    "Id_plan INT, " +
                    "Id_gimnasio INT, " +
                    "CONSTRAINT fk_plan FOREIGN KEY (Id_plan) REFERENCES Planes_Entrenamiento(Id_plan), " +
                    "CONSTRAINT fk_gimnasio_cliente FOREIGN KEY (Id_gimnasio) REFERENCES Gimnasio(Id_gimnasio)" +
                    ");";

                comando = new SqlCommand(q, conexion.GetConexion());
                comando.ExecuteNonQuery();

                mensaje = "Creacion de las Tablas realizada";

                //nuevo
                conexion.CerrarConexion();
            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error en la creacion de las tablas " + ex.Message;
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
                int IdCliente = Convert.ToInt32(txtIdCliente.Text);
                string Nombre = txtNombre.Text;
                string Apellidos = txtApellidos.Text;
                string CorreoElectronico = txtCorreo.Text;
                string Estado = cmbEstado.SelectedItem.ToString(); // Suponiendo que es un ComboBox
                int IdPlan = Convert.ToInt32(txtIdPlan.Text);
                int IdGimnasio = Convert.ToInt32(txtIdGimnasio.Text);

                // Consulta SQL para la inserción de datos
                q = "INSERT INTO Clientes(Id_cliente, Nombre, Apellidos, Correo_electronico, Estado, Id_plan, Id_gimnasio) " +
                    "VALUES (@ID, @NOM, @APE, @CORR, @EST, @PLAN, @GIM);";

                // Creación del comando SQL
                comando = new SqlCommand(q, conexion.GetConexion());
                comando.Parameters.Clear();

                // Asignación de parámetros
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = IdCliente;
                comando.Parameters.Add("@NOM", SqlDbType.NVarChar).Value = Nombre;
                comando.Parameters.Add("@APE", SqlDbType.NVarChar).Value = Apellidos;
                comando.Parameters.Add("@CORR", SqlDbType.NVarChar).Value = CorreoElectronico;
                comando.Parameters.Add("@EST", SqlDbType.NVarChar).Value = Estado;
                comando.Parameters.Add("@PLAN", SqlDbType.Int).Value = IdPlan;
                comando.Parameters.Add("@GIM", SqlDbType.Int).Value = IdGimnasio;

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
                MessageBox.Show(mensaje);
            }
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void Clientes_Load_1(object sender, EventArgs e)
        {

        }
    }
}
