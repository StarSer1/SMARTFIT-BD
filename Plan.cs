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

                q = "USE SMARTFITBD; CREATE TABLE Planes_Entrenamiento (" +
                    "Id_plan INT PRIMARY KEY Identity (1,1), " +
                    "Nombre_plan VARCHAR(20) NOT NULL, " +
                    "Clientes_inscritos INT, " +
                    "Descripcion VARCHAR(255) DEFAULT 'Sin descripción', " +
                    "Costo INT CHECK (Costo >= 0) " +
                    ");";

                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();
                conexion.CerrarConexion();
                mensaje = "Creación de la tabla realizada correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Error en la creación de la tabla: " + ex.Message;
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
    }
}
