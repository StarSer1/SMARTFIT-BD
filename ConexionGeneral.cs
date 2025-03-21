using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTFIT
{
    internal class ConexionGeneral
    {

        //// Crear la conexión a la base de datos
        //ConexionGeneral conexion = new ConexionGeneral();
        //conexion.AbrirConexion();

        //laptop brandon
        //public readonly string cadenaConexion = "Server=LocalHost; User ID=sa; pwd=1347;Database=SMARTFITBD";

        //public readonly string cadenaConexion = @"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;";
        public readonly string cadenaConexion = @"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=SMARTFITBD;Integrated Security=True;";

        private SqlConnection conexion;



        public ConexionGeneral()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public void AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
        }
        public void Eliminar(int identificador, string tabla, string id)
        {
            ConexionGeneral conexion = new ConexionGeneral();
            conexion.AbrirConexion();

            // Consulta para eliminar el registro basado en el ID
            string query = "DELETE FROM "+tabla+" WHERE id_"+ id +" = @ID";

            using (SqlCommand cmd = new SqlCommand(query, conexion.GetConexion()))
            {
                try
                {
                    // Agregar el parámetro de ID a la consulta
                    cmd.Parameters.AddWithValue("@ID", identificador);

                    // Ejecutar la consulta de eliminación
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Registro eliminado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un registro con ese ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
        }
        public void EliminarP(int identificador, string tabla, string id)
        {
            ConexionGeneral conexion = new ConexionGeneral();
            conexion.AbrirConexion();

            // Consulta para eliminar el registro basado en el ID
            string query = " UPDATE Clientes\r\nSET Id_plan = NULL,Estado = 'Inactivo'\r\nWHERE Id_plan = @Id_plan_a_eliminar; DELETE FROM " + tabla + " WHERE id_" + id + " = @ID";

            using (SqlCommand cmd = new SqlCommand(query, conexion.GetConexion()))
            {
                try
                {
                    // Agregar el parámetro de ID a la consulta
                    cmd.Parameters.AddWithValue("@ID", identificador);
                    cmd.Parameters.AddWithValue("@Id_plan_a_eliminar", identificador);

                    // Ejecutar la consulta de eliminación
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Registro eliminado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un registro con ese ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
        }
        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        public SqlConnection GetConexion()
        {
            return conexion;
        }
    }
}
