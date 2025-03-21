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
                q = "USE SMARTFITBD";
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                // Crear la tabla Inventario
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

                //// Crear la vista VistaInventarioStockBajo
                //q = "CREATE VIEW VistaInventarioStockBajo AS " +
                //    "SELECT " +
                //    "    Id_inventario, " +
                //    "    Nombre_producto, " +
                //    "    Cantidad, " +
                //    "    Tipo " +
                //    "FROM " +
                //    "    Inventario " +
                //    "WHERE " +
                //    "    Cantidad < 5;";
                //comando = new SqlCommand(q, conexion.GetConexion());
                //comando.ExecuteNonQuery();

                // Trigger AlertaStockBajo
                q = @"
                CREATE TRIGGER AlertaStockBajo
                ON Inventario
                AFTER INSERT, UPDATE
                AS
                BEGIN
                    IF EXISTS (
                        SELECT 1 
                        FROM inserted 
                        WHERE Cantidad < 5
                    )
                    BEGIN
                        PRINT 'Advertencia: Hay productos con stock bajo (menos de 5 unidades).';
                    END;
                END;";
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                mensaje = "Creación de la tabla y la vista realizada con éxito";

                conexion.CerrarConexion();
            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrió un error en la creación de las tablas y la vista: " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();

                // Verifica si la vista ya existe y, si no, la crea
                q = @"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'VistaInventarioStockBajo')
                BEGIN
                    EXEC('
                        CREATE VIEW VistaInventarioStockBajo AS
                        SELECT 
                            Id_inventario, 
                            Nombre_producto, 
                            Cantidad, 
                            Tipo
                        FROM 
                            Inventario
                        WHERE 
                            Cantidad < 100;
                    ')
                    PRINT 'Vista VistaInventarioStockBajo creada exitosamente.'
                END
                ELSE
                BEGIN
                    PRINT 'La vista VistaInventarioStockBajo ya existe.'
                END
                ";


                // Ejecuta el comando de creación o validación de la vista
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                // Consulta los datos de la vista para mostrarlos en el DataGridView
                q = "SELECT * FROM VistaInventarioStockBajo";
                comando = new SqlCommand(q, conexion.GetConexion());
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                // Asigna los datos al DataGridView
                DG1.DataSource = dt;

                // Cierra la conexión
                conexion.CerrarConexion();
            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error al mostrar la vista: " + ex.Message;
            }
            finally
            {
                // Muestra el mensaje de resultado
                MessageBox.Show(mensaje);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            ConexionGeneral conexion = new ConexionGeneral();
            conexion.AbrirConexion();
            string query = "SELECT Nombre_producto, Descripcion, Cantidad, Tipo, Id_Gimnasio FROM Inventario WHERE Id_inventario = @ID";

            using (SqlCommand cmd = new SqlCommand(query, conexion.GetConexion()))
            {
                cmd.Parameters.AddWithValue("@ID", txtId.Text);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // Si hay resultados
                    {
                        txtNombre.Text = reader["Nombre_producto"].ToString();
                        txtCantidad.Text = reader["Cantidad"].ToString();
                        cmbTipo.Text = reader["Tipo"].ToString();
                        txtIdGimnasio.Text = reader["Id_Gimnasio"].ToString();
                        txtDescripcion.Text = reader["Descripcion"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            ConexionGeneral conexion = new ConexionGeneral();
            conexion.AbrirConexion();
            string queryUpdate = "UPDATE Inventario SET Nombre_producto = @NOM, Descripcion = @DES, Cantidad = @CAN, TIpo = @TIP WHERE Id_inventario = @ID";


            using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conexion.GetConexion()))
            {

                try
                {
                    int identificador = Convert.ToInt32(txtId.Text);
                    string nombre = txtNombre.Text;
                    string descripcion = txtDescripcion.Text;
                    int cantidad = Convert.ToInt32(txtCantidad.Text);
                    string tipo = cmbTipo.Text; 

                    // Agregar parámetros a la consulta de actualización
                    cmdUpdate.Parameters.AddWithValue("@NOM", nombre);
                    cmdUpdate.Parameters.AddWithValue("@DES", descripcion);
                    cmdUpdate.Parameters.AddWithValue("@CAN", cantidad);
                    cmdUpdate.Parameters.AddWithValue("@TIP", tipo);
                    cmdUpdate.Parameters.AddWithValue("@ID", identificador); // Este es el ID del registro a actualizar

                    // Ejecutar la consulta de actualización
                    int filasAfectadas = cmdUpdate.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Registro actualizado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un registro con ese ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }


            try
            {
                ConexionGeneral conexion2 = new ConexionGeneral();
                conexion2.AbrirConexion();

                q = "SELECT * FROM Inventario";
                comando = new SqlCommand(q, conexion2.GetConexion());
                Lector = comando.ExecuteReader();

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;


            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error al mostrar los datos " + ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
                
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionGeneral conexion = new ConexionGeneral();
            conexion.AbrirConexion();
            conexion.Eliminar(Convert.ToInt32(txtId.Text),"Inventario","Inventario");
            try
            {
                ConexionGeneral conexion2 = new ConexionGeneral();
                conexion2.AbrirConexion();

                q = "SELECT * FROM Inventario";
                comando = new SqlCommand(q, conexion2.GetConexion());
                Lector = comando.ExecuteReader();

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;


            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error al mostrar los datos " + ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();

            }
        }

    }
}
