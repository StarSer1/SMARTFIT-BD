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
    public partial class Plan : Form
    {
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader Lector;
        public string q;
        public string mensaje;

        public Plan()
        {
            InitializeComponent();

            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                q = "SELECT * FROM Planes_Entrenamiento";
                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(Lector);
                DG1.DataSource = dt;

                conexion.CerrarConexion();
                mensaje = "Datos mostrados correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Error al consultar los datos: " + ex.Message;
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

                // Crear la tabla Planes_Entrenamiento
                q = "USE SMARTFITBD; " +
                    "CREATE TABLE Planes_Entrenamiento (" +
                    "Id_plan INT PRIMARY KEY Identity (1,1), " +
                    "Nombre_plan VARCHAR(20) NOT NULL, " +
                    "Clientes_inscritos INT, " +
                    "Descripcion VARCHAR(255) DEFAULT 'Sin descripción', " +
                    "Costo INT CHECK (Costo >= 0) " +
                    ");";

                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                //// Crear la vista VistaPlanesConClientes
                //q = "CREATE VIEW VistaPlanesConClientes AS " +
                //    "SELECT " +
                //    "    p.Id_plan, " +
                //    "    p.Nombre_plan, " +
                //    "    p.Descripcion, " +
                //    "    COUNT(c.Id_cliente) AS Total_Clientes " +
                //    "FROM " +
                //    "    Planes_Entrenamiento p " +
                //    "LEFT JOIN " +
                //    "    Clientes c ON p.Id_plan = c.Id_plan " +
                //    "GROUP BY " +
                //    "    p.Id_plan, p.Nombre_plan, p.Descripcion;";

                //comando = new SqlCommand(q, conexion.GetConexion());
                //comando.ExecuteNonQuery();
                conexion.CerrarConexion();

                mensaje = "Creación de la tabla y la vista realizada correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Error en la creación de la tabla y la vista: " + ex.Message;
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

                string NombrePlan = cmbNombre.SelectedItem.ToString();
                int ClientesInscritos = Convert.ToInt32(txtClientesInscritos.Text);
                string Descripcion = txtDescripcion.Text;
                int Costo = Convert.ToInt32(txtCosto.Text);

                q = "EXEC AgregarPlanEntrenamiento @NOM, @CLI, @DESC, @COS;";
                comando = new SqlCommand(q, conexion.GetConexion());
                comando.Parameters.AddWithValue("@NOM", NombrePlan);
                comando.Parameters.AddWithValue("@CLI", ClientesInscritos);
                comando.Parameters.AddWithValue("@DESC", Descripcion);
                comando.Parameters.AddWithValue("@COS", Costo);

                comando.ExecuteNonQuery();
                conexion.CerrarConexion();
                mensaje = "Datos insertados correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Error en la inserción de datos: " + ex.Message;
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
                        q = "SELECT * FROM Planes_Entrenamiento";
                        break;
                    case "Planes de entrenamiento en orden ascendente":
                        q = "SELECT * \r\nFROM Planes_Entrenamiento \r\nORDER BY Clientes_inscritos";
                        break;
                    case "Planes con clientes inscritos en gimnasio Santa Fe":
                        q = "SELECT \r\n    P.Id_plan, \r\n    P.Nombre_plan, \r\n    P.Descripcion, \r\n    P.Costo, \r\n    COUNT(C.Id_cliente) AS Clientes_Inscritos\r\nFROM \r\n    Planes_Entrenamiento P\r\nINNER JOIN \r\n    Clientes C ON P.Id_plan = C.Id_plan\r\nINNER JOIN \r\n    Gimnasio G ON C.Id_gimnasio = G.Id_gimnasio\r\nWHERE \r\n    G.Nombre LIKE '%Santa Fe%'  -- Filtro por el nombre del gimnasio\r\nGROUP BY \r\n    P.Id_plan, \r\n    P.Nombre_plan, \r\n    P.Descripcion, \r\n    P.Costo\r\nORDER BY \r\n    P.Costo DESC;  -- Ordenar por costo de manera descendente";
                        break;
                    case "Mostrar el plan con mas clientes inscritos":
                        q = "SELECT P.Id_plan, P.Nombre_plan, P.Descripcion, P.Costo, P.Clientes_inscritos " +
                            "FROM Planes_Entrenamiento P " +
                            "WHERE P.Clientes_inscritos = (SELECT MAX(Clientes_inscritos) FROM Planes_Entrenamiento);";
                        break;



                }
                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(Lector);
                DG1.DataSource = dt;

                conexion.CerrarConexion();
                mensaje = "Datos mostrados correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Error al consultar los datos: " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void Plan_Load(object sender, EventArgs e)
        {

        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();

                // Verifica si la vista ya existe
                string q = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'VistaPlanesConClientes')\r\n" +
                           "BEGIN\r\n" +
                           "    EXEC('\r\n" +
                           "        CREATE VIEW VistaPlanesConClientes AS\r\n" +
                           "        SELECT \r\n" +
                           "            p.Id_plan, \r\n" +
                           "            p.Nombre_plan, \r\n" +
                           "            p.Descripcion, \r\n" +
                           "            COUNT(c.Id_cliente) AS Total_Clientes \r\n" +
                           "        FROM \r\n" +
                           "            Planes_Entrenamiento p \r\n" +
                           "        LEFT JOIN \r\n" +
                           "            Clientes c ON p.Id_plan = c.Id_plan \r\n" +
                           "        GROUP BY \r\n" +
                           "            p.Id_plan, p.Nombre_plan, p.Descripcion;\r\n" +
                           "    ')\r\n" +
                           "    PRINT 'Vista \"VistaPlanesConClientes\" creada exitosamente.'\r\n" +
                           "END\r\n" +
                           "ELSE\r\n" +
                           "BEGIN\r\n" +
                           "    PRINT 'La vista \"VistaPlanesConClientes\" ya existe.'\r\n" +
                           "END\r\n";

                SqlCommand comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                // Ahora consulta los datos de la vista
                q = "SELECT * FROM VistaPlanesConClientes";
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

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            ConexionGeneral conexion = new ConexionGeneral();
            conexion.AbrirConexion();
            string query = "SELECT Nombre_plan, Clientes_inscritos, Descripcion, Costo FROM Planes_Entrenamiento WHERE Id_plan = @ID";

            using (SqlCommand cmd = new SqlCommand(query, conexion.GetConexion()))
            {
                cmd.Parameters.AddWithValue("@ID", txtId.Text);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // Si hay resultados
                    {
                        cmbNombre.Text = reader["Nombre_plan"].ToString();
                        txtClientesInscritos.Text = reader["Clientes_inscritos"].ToString();
                        txtCosto.Text = reader["Costo"].ToString();
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
            string queryUpdate = "UPDATE Planes_Entrenamiento SET Nombre_plan = @NOM, Descripcion = @DES, Clientes_inscritos = @CAN, Costo = @COS WHERE Id_plan = @ID";


            using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conexion.GetConexion()))
            {

                try
                {
                    int identificador = Convert.ToInt32(txtId.Text);
                    string nombre = cmbNombre.Text;
                    string descripcion = txtDescripcion.Text;
                    int clientesI = Convert.ToInt32(txtClientesInscritos.Text);
                    int costo = Convert.ToInt32(txtCosto.Text);

                    // Agregar parámetros a la consulta de actualización
                    cmdUpdate.Parameters.AddWithValue("@NOM", nombre);
                    cmdUpdate.Parameters.AddWithValue("@DES", descripcion);
                    cmdUpdate.Parameters.AddWithValue("@CAN", clientesI);
                    cmdUpdate.Parameters.AddWithValue("@COS", costo);
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

                q = "SELECT * FROM Planes_Entrenamiento";
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
            conexion.EliminarP(Convert.ToInt32(txtId.Text), "Planes_Entrenamiento", "plan");

            try
            {
                ConexionGeneral conexion2 = new ConexionGeneral();
                conexion2.AbrirConexion();

                q = "SELECT * FROM Planes_Entrenamiento";
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
