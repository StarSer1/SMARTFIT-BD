using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

                // Crear la tabla Administrativo
                q = "CREATE TABLE Administrativo (" +
                    "Cargo VARCHAR(30) CHECK (Cargo = 'Proveedor' OR Cargo = 'Intendente' OR Cargo = 'Tecnico'), " +
                    "Equipo VARCHAR(30) DEFAULT 'Sin equipo', " +
                    "Id_Personal INT, " +
                    "CONSTRAINT fk_personal_administrativo FOREIGN KEY (Id_Personal) REFERENCES Personal(Id_Personal)" +
                    ");";

                comando = new SqlCommand(q, conexion.GetConexion());
                comando.ExecuteNonQuery();  // Ejecutar la creación de la tabla

                conexion.CerrarConexion();
                mensaje = "Tabla Administrativo creada e insertados los datos correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Error al crear la tabla o insertar los datos: " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);  // Mostrar mensaje final
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

                string opcion = cmbConsulta.SelectedItem.ToString();
                switch (opcion)
                {
                    case "Consulta General":
                        q = "SELECT * FROM Administrativo";
                        break;
                    case "Mostrar los id´s y el cargo de los intendentes":
                        q = "SELECT Id_Personal, Cargo FROM Administrativo WHERE Equipo = 'Equipo de limpieza'";
                        break;
                    case "Mostrar personal que son del area del administrativo":
                        q = "SELECT DISTINCT P.Nombre\r\nFROM Personal P\r\nINNER JOIN Administrativo A ON A.Id_Personal = P.Id_personal";
                        break;
                    case "Mostrar los datos de los tecnicos del area Administrativo":
                        q = "SELECT A.Id_Personal, A.Cargo, A.Equipo, P.Nombre, P.Apellidos " +
                            "FROM Administrativo A " +
                            "INNER JOIN Personal P ON P.Id_personal = A.Id_Personal " +
                            "WHERE A.Cargo = 'Tecnico';";
                        break;

                }
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

        private void BtnVista_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();

                // Verifica si la vista ya existe
                string q = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'VistaAdministrativo')\r\n" +
                           "BEGIN\r\n" +
                           "    EXEC('\r\n" +
                           "        CREATE VIEW VistaAdministrativo AS\r\n" +
                           "        SELECT \r\n" +
                           "            P.Nombre, \r\n" +
                           "            P.Apellidos, \r\n" +
                           "            A.Cargo, \r\n" +
                           "            A.Equipo \r\n" +
                           "        FROM \r\n" +
                           "            Administrativo A \r\n" +
                           "        INNER JOIN Personal P ON A.Id_Personal = P.Id_personal;\r\n" +
                           "    ')\r\n" +
                           "    PRINT 'Vista \"VistaAdministrativo\" creada exitosamente.'\r\n" +
                           "END\r\n" +
                           "ELSE\r\n" +
                           "BEGIN\r\n" +
                           "    PRINT 'La vista \"VistaAdministrativo\" ya existe.'\r\n" +
                           "END\r\n";

                SqlCommand comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                // Ahora consulta los datos de la vista
                q = "SELECT * FROM VistaAdministrativo";
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
    }
}