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
    public partial class General : Form
    {
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader Lector;
        public string q;
        public string mensaje;

        public General()
        {
            InitializeComponent();

            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                q = "SELECT * FROM General";
                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(Lector);
                DG1.DataSource = dt;

                conexion.CerrarConexion();
                mensaje = "Datos mostrados correctamente.";
            }
            catch (System.Exception ex)
            {
                mensaje = "Error al mostrar los datos: " + ex.Message;
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
                q = "CREATE TABLE General (\r\n    Cedúla VARCHAR(30) UNIQUE NOT NULL,\r\n   " +
                    " Años_de_experiencia INT CHECK (Años_de_experiencia >= 0) DEFAULT 0,\r\n  " +
                    "  Id_Personal INT UNIQUE, -- Evita que un mismo Id_Personal esté en otra tabla\r\n  " +
                    "  CONSTRAINT fk_personal_general FOREIGN KEY (Id_Personal) REFERENCES Personal(Id_Personal),\r\n  " +
                    "  CONSTRAINT chk_general_tipo CHECK (\r\n    " +
                    "    EXISTS (SELECT 1 FROM Personal WHERE Personal.Id_Personal = General.Id_Personal AND Personal.Tipo = 'General')\r\n    )\r\n);";

                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();
                conexion.CerrarConexion();

                mensaje = "Tabla 'General' creada correctamente.";
            }
            catch (System.Exception ex)
            {
                mensaje = "Error al crear la tabla: " + ex.Message;
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

                string Cedula = txtCedula.Text;
                int AniosExperiencia = Convert.ToInt32(txtAñosDeExperiencia.Text);
                int IdPersonal = Convert.ToInt32(txtIdPersonal.Text);

                q = "EXEC AgregarGeneral @CED, @EXP, @IDP;";
                comando = new SqlCommand(q, conexion.GetConexion());
                comando.Parameters.AddWithValue("@CED", Cedula);
                comando.Parameters.AddWithValue("@EXP", AniosExperiencia);
                comando.Parameters.AddWithValue("@IDP", IdPersonal);

                comando.ExecuteNonQuery();
                conexion.CerrarConexion();

                mensaje = "Datos insertados correctamente en 'General'.";
            }
            catch (System.Exception ex)
            {
                mensaje = "Error al insertar datos: " + ex.Message;
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

                q = "SELECT * FROM General";
                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(Lector);
                DG1.DataSource = dt;

                conexion.CerrarConexion();
                mensaje = "Datos mostrados correctamente.";
            }
            catch (System.Exception ex)
            {
                mensaje = "Error al mostrar los datos: " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void General_Load(object sender, EventArgs e)
        {

        }
    }
}