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
                //Brandon
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                //Alex
                //conexion = new SqlConnection(@"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                conexion.Open();

                q = "SELECT * FROM Inventario";
                comando = new SqlCommand(q, conexion);
                Lector = comando.ExecuteReader();

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;

                conexion.Close();
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
                // Conexión a la base de datos
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");

                // Abre la conexión
                conexion.Open();

                // Obtención de valores desde los controles del formulario
                int IdInventario = Convert.ToInt32(txtIdInventario.Text);
                string NombreProducto = txtNombre.Text;
                string Descripcion = txtDescripcion.Text;
                int Cantidad = Convert.ToInt32(txtCantidad.Text);
                string Tipo = cmbTipo.SelectedItem.ToString(); ;
                int IdGimnasio = Convert.ToInt32(txtIdGimnasio.Text);

                // Consulta SQL para la inserción de datos
                q = "INSERT INTO Inventario (Id_inventario, Nombre_producto, Descripcion, Cantidad, Tipo, Id_Gimnasio) " +
                    "VALUES (@ID, @NOM, @DES, @CANT, @TIPO, @ID_GIM);";

                // Creación del comando SQL
                comando = new SqlCommand(q, conexion);
                comando.Parameters.Clear();

                // Asignación de parámetros
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = IdInventario;
                comando.Parameters.Add("@NOM", SqlDbType.NVarChar).Value = NombreProducto;
                comando.Parameters.Add("@DES", SqlDbType.NVarChar).Value = Descripcion;
                comando.Parameters.Add("@CANT", SqlDbType.Int).Value = Cantidad;
                comando.Parameters.Add("@TIPO", SqlDbType.NVarChar).Value = Tipo;
                comando.Parameters.Add("@ID_GIM", SqlDbType.Int).Value = IdGimnasio;

                // Ejecución del comando
                comando.ExecuteNonQuery();

                // Cierra la conexión
                conexion.Close();

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
                //Brandon
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                //Alex
                //conexion = new SqlConnection(@"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                conexion.Open();

                q = "SELECT * FROM Inventario";
                comando = new SqlCommand(q, conexion);
                Lector = comando.ExecuteReader();

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;

                conexion.Close();
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
                //Brandon
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                //Alex
                //conexion = new SqlConnection(@"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                q = "use SMARTFITBD";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                q = "CREATE TABLE Inventario(" +
                    "Id_inventario INT PRIMARY KEY, " +
                    "Nombre_producto VARCHAR(100) UNIQUE NOT NULL, " +
                    "Descripcion VARCHAR(255), " +
                    "Cantidad INT CHECK (cantidad >= 0) DEFAULT 0, " +
                    "Tipo VARCHAR(100) NOT NULL, " +
                    "Id_Gimnasio INT, " +
                    "CONSTRAINT fk_gimnasio_inventario FOREIGN KEY (Id_gimnasio) REFERENCES Gimnasio(Id_gimnasio)" +
                    ");";

                comando = new SqlCommand(q, conexion);
                comando.ExecuteNonQuery();

                mensaje = "Creacion de las Tablas realizada";

                conexion.Close();
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
