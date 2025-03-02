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
    public partial class Administrativo : Form
    {
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader Lector;
        public string q;
        public string mensaje;

        public Administrativo()
        {
            InitializeComponent();

            try
            {
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                conexion.Open();
                q = "SELECT * FROM Administrativo";
                comando = new SqlCommand(q, conexion);
                Lector = comando.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(Lector);
                DG1.DataSource = dt;

                conexion.Close();
                mensaje = "Datos mostrados correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al consultar datos: " + ex.Message;
            }
            finally
            {
            }
        }

        private void BtnCrearTabla_Click(object sender, EventArgs e)
        {
            try
            {
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                q = "CREATE TABLE Administrativo(" +
                    "Cargo VARCHAR(30) CHECK (Cargo = 'Proveedor' OR Cargo = 'Intendente' OR Cargo = 'Tecnico'), " +
                    "Equipo VARCHAR(30) DEFAULT 'Sin equipo', " +
                    "Id_Personal INT, " +
                    "CONSTRAINT fk_personal_administrativo FOREIGN KEY (Id_Personal) REFERENCES Personal(Id_Personal)" +
                    ");";

                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                mensaje = "Tabla Administrativo creada correctamente";
            }
            catch (Exception ex)
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

                string Cargo = cmbCargo.SelectedItem.ToString();
                string Equipo = cmbEquipo.SelectedItem.ToString();
                int IdPersonal = Convert.ToInt32(txtIdPersonal.Text);

                q = "INSERT INTO Administrativo (Cargo, Equipo, Id_Personal) VALUES (@CARGO, @EQUIPO, @IDPERS);";
                comando = new SqlCommand(q, conexion);
                comando.Parameters.Clear();
                comando.Parameters.Add("@CARGO", SqlDbType.NVarChar).Value = Cargo;
                comando.Parameters.Add("@EQUIPO", SqlDbType.NVarChar).Value = Equipo;
                comando.Parameters.Add("@IDPERS", SqlDbType.Int).Value = IdPersonal;

                comando.ExecuteNonQuery();
                conexion.Close();
                mensaje = "Datos insertados correctamente en Administrativo";
            }
            catch (Exception ex)
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
                q = "SELECT * FROM Administrativo";
                comando = new SqlCommand(q, conexion);
                Lector = comando.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(Lector);
                DG1.DataSource = dt;

                conexion.Close();
                mensaje = "Datos mostrados correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al consultar datos: " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void Administrativo_Load(object sender, EventArgs e)
        {

        }
    }
}
