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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SMARTFIT
{
    public partial class Inventario : Form
    {
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader Lector;
        public string q;
        public string mensaje;

        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                q = "SELECT * FROM Inventario";
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


        private void BtnInsertarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                // Obtención de valores desde los controles del formulario
                string NombreProducto = txtNombre.Text;
                string Descripcion = txtDescripcion.Text;
                int Cantidad = Convert.ToInt32(txtCantidad.Text);
                string Tipo = cmbTipo.SelectedItem.ToString(); ;
                int IdGimnasio = Convert.ToInt32(txtIdGimnasio.Text);

                // Consulta SQL para la inserción de datos
                q = "EXEC AgregarInventario @NOM, @DES, @CANT, @TIPO, @ID_GIM;";

                // Creación del comando SQL
                comando = new SqlCommand(q, conexion.GetConexion());
                comando.Parameters.Clear();

                // Asignación de parámetros
                comando.Parameters.Add("@NOM", SqlDbType.NVarChar).Value = NombreProducto;
                comando.Parameters.Add("@DES", SqlDbType.NVarChar).Value = Descripcion;
                comando.Parameters.Add("@CANT", SqlDbType.Int).Value = Cantidad;
                comando.Parameters.Add("@TIPO", SqlDbType.NVarChar).Value = Tipo;
                comando.Parameters.Add("@ID_GIM", SqlDbType.Int).Value = IdGimnasio;

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
                        q = "SELECT * FROM Inventario";
                        break;
                    case "Mayor base su cantidad":
                        q = "SELECT * \r\nFROM Inventario\r\nWHERE Cantidad > (SELECT AVG(Cantidad) FROM Inventario)\r\nORDER BY Cantidad DESC;";
                        break;
                    case "Mostrar inventario y nombre del gimnasio":
                        q = "SELECT I.Nombre_producto, I.Cantidad, G.Nombre\r\nFROM Inventario I\r\nINNER JOIN Gimnasio G ON I.Id_Gimnasio = G.Id_Gimnasio;";
                        break;
                    case "Mostrar inventario con gimnasios con id entre 3 y 10":
                        q = "SELECT I.Nombre_producto, I.Cantidad, G.Nombre\r\nFROM Inventario I\r\nINNER JOIN Gimnasio G ON I.Id_Gimnasio = G.Id_Gimnasio\r\nwhere G.Id_Gimnasio BETWEEN '3' AND '10';";
                        break;
                    case "Mostrar el gimnasio donde su inventario hay pesas":
                        q = "SELECT DISTINCT G.Nombre\r\nFROM Gimnasio G\r\nINNER JOIN Inventario I ON G.Id_Gimnasio = I.Id_Gimnasio\r\nWhere Tipo = 'Pesas';";
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

        private void BtnCrearTabla_Click_1(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                q = "use SMARTFITBD";
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                q = "CREATE TABLE Inventario(" +
                    "Id_inventario INT PRIMARY KEY Identity (1,1), " +
                    "Nombre_producto VARCHAR(100) UNIQUE NOT NULL, " +
                    "Descripcion VARCHAR(255), " +
                    "Cantidad INT CHECK (cantidad >= 0) DEFAULT 0, " +
                    "Tipo VARCHAR(100) NOT NULL, " +
                    "Id_Gimnasio INT, " +
                    "CONSTRAINT fk_gimnasio_inventario FOREIGN KEY (Id_gimnasio) REFERENCES Gimnasio(Id_gimnasio)" +
                    ");";

                comando = new SqlCommand(q, conexion.GetConexion());
                comando.ExecuteNonQuery();

                mensaje = "Creacion de las Tablas realizada";

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
    }
}
