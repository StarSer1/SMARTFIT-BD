using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMARTFIT
{
    internal class ConexionGeneral
    {

        //// Crear la conexión a la base de datos
        //ConexionGeneral conexion = new ConexionGeneral();
        //conexion.AbrirConexion();

        //laptop brandon
        public readonly string cadenaConexion = "Server=LocalHost; User ID=sa; pwd=1347;Database=SMARTFITBD";

        //public readonly string cadenaConexion = @"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;";
        //public readonly string cadenaConexion = @"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=SMARTFITBD;Integrated Security=True;";

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
