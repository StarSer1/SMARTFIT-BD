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
                    "Id_plan INT PRIMARY KEY, " +
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

                int IdPlan = Convert.ToInt32(txtIdPlan.Text);
                string NombrePlan = cmbNombre.SelectedItem.ToString();
                int ClientesInscritos = Convert.ToInt32(txtClientesInscritos.Text);
                string Descripcion = txtDescripcion.Text;
                int Costo = Convert.ToInt32(txtCosto.Text);

                q = "INSERT INTO Planes_Entrenamiento (Id_plan, Nombre_plan, Clientes_inscritos, Descripcion, Costo) " +
                    "VALUES (@ID, @NOM, @CLI, @DESC, @COS);";

                comando = new SqlCommand(q, conexion.GetConexion());
                comando.Parameters.AddWithValue("@ID", IdPlan);
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
                MessageBox.Show(mensaje);
            }
        }

        private void Plan_Load(object sender, EventArgs e)
        {

        }
    }
}
