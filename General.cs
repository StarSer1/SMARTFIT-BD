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
        }

        private void BtnCrearTabla_Click(object sender, EventArgs e)
        {
            try
            {
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                q = "CREATE TABLE General (" +
                    "Cedúla VARCHAR(30) UNIQUE NOT NULL, " +
                    "Años_de_experiencia INT CHECK (Años_de_experiencia >= 0) DEFAULT 0, " +
                    "Id_Personal INT, " +
                    "CONSTRAINT fk_personal_general FOREIGN KEY (Id_Personal) REFERENCES Personal(Id_Personal));";

                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

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
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                conexion.Open();

                string Cedula = txtCedula.Text;
                int AniosExperiencia = Convert.ToInt32(txtAñosDeExperiencia.Text);
                int IdPersonal = Convert.ToInt32(txtIdPersonal.Text);

                q = "INSERT INTO General (Cedúla, Años_de_experiencia, Id_Personal) VALUES (@CED, @EXP, @IDP);";
                comando = new SqlCommand(q, conexion);
                comando.Parameters.AddWithValue("@CED", Cedula);
                comando.Parameters.AddWithValue("@EXP", AniosExperiencia);
                comando.Parameters.AddWithValue("@IDP", IdPersonal);

                comando.ExecuteNonQuery();
                conexion.Close();

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
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                conexion.Open();

                q = "SELECT * FROM General";
                comando = new SqlCommand(q, conexion);
                Lector = comando.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(Lector);
                DG1.DataSource = dt;

                conexion.Close();
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
    }
}