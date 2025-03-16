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
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();
                q = "SELECT * FROM Administrativo";
                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(Lector);
                DG1.DataSource = dt;

                conexion.CerrarConexion();
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
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();
                q = "CREATE TABLE Administrativo (\r\n    Cargo VARCHAR(30) CHECK (Cargo = 'Proveedor' OR Cargo = " +
                    "'Intendente' OR Cargo = 'Tecnico'),\r\n    Equipo VARCHAR(30) DEFAULT 'Sin equipo',\r\n " +
                    "   Id_Personal INT UNIQUE, -- Evita que un mismo Id_Personal esté en otra tabla\r\n  " +
                    "  CONSTRAINT fk_personal_administrativo FOREIGN KEY (Id_Personal) REFERENCES Personal(Id_Personal),\r\n  " +
                    "  CONSTRAINT chk_administrativo_tipo CHECK (\r\n   " +
                    "     EXISTS (SELECT 1 FROM Personal WHERE Personal.Id_Personal = Administrativo.Id_Personal AND Personal.Tipo = 'Administrativo')\r\n    )\r\n);";

                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();
                conexion.CerrarConexion();
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
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();


                string Cargo = cmbCargo.SelectedItem.ToString();
                string Equipo = cmbEquipo.SelectedItem.ToString();
                int IdPersonal = Convert.ToInt32(txtIdPersonal.Text);

                q = "EXEC AgregarAdministrativo @Cargo, @Equipo, @Id_Personal;";
                comando = new SqlCommand(q, conexion.GetConexion());
                comando.Parameters.Clear();
                comando.Parameters.Add("@Cargo", SqlDbType.VarChar, 30).Value = Cargo;
                comando.Parameters.Add("@Equipo", SqlDbType.VarChar, 30).Value = Equipo;
                comando.Parameters.Add("@Id_Personal", SqlDbType.Int).Value = IdPersonal;

                comando.ExecuteNonQuery();
                conexion.CerrarConexion();
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
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();
                q = "SELECT * FROM Administrativo";
                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(Lector);
                DG1.DataSource = dt;

                conexion.CerrarConexion();
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
