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
using System.Security.Cryptography;

namespace SMARTFIT
{
    public partial class Form1 : Form
    {
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader Lector;
        public string q;
        public string mensaje;
        public Form1()
        {
            InitializeComponent();
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                q = "SELECT * FROM Gimnasio";
                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;

                conexion.CerrarConexion();
                mensaje = "Datos Mostrados Correctamente";

            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error al mostrar los datos " + ex.Message;
            }
            finally
            {
            }
        }

        private void BtnInsercion_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();
                q = "use SMARTFITBD";
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                q = "Create Table Gimnasio(Id_gimnasio INT PRIMARY KEY,Nombre VARCHAR(100) NOT NULL," +
                    "Direccion VARCHAR(255) DEFAULT 'No especificado', Telefono VARCHAR(20) UNIQUE NOT NULL," +
                    "Horario_apertura TIME CHECK (Horario_apertura >= '05:00')," +
                    "Horario_cierre TIME CHECK (Horario_cierre <= '23:00'));";
                comando = new SqlCommand(q, conexion.GetConexion());
                comando.ExecuteNonQuery();

                mensaje = "Creacion de las Tablas realizada";

                //nuevo
                conexion.CerrarConexion();
            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error en la creacion de las tablas " + ex.Message;
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

                int IdGimnasio = Convert.ToInt32(SpnCve.Text);
                string Nombre = TxtNombre.Text;
                string Telefono = TxtTelefono.Text;
                string Direccion = TxtDireccion.Text;

                // Para Horario_Apertura, usa TimeSpan directamente
                TimeSpan Apertura = new TimeSpan(06, 00, 0);  // Asegúrate de que TxtHApertura contenga un formato adecuado como "HH:mm"

                // Para Horario_Cierre, usa TimeSpan directamente
                TimeSpan Cierre = new TimeSpan(22, 00, 0);  // Aquí puedes mantener la hora predeterminada si es fija, o también puedes usar un campo de texto

                q = "INSERT INTO Gimnasio (Id_Gimnasio, Nombre,Direccion, Telefono, Horario_Apertura, Horario_Cierre) " +
                "VALUES (@ID, @NOM,@DIR, @TEL, @HAP, @HAC)";

                comando = new SqlCommand(q, conexion.GetConexion());

                comando.Parameters.Clear();
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = IdGimnasio;
                comando.Parameters.Add("@NOM", SqlDbType.NVarChar).Value = Nombre;
                comando.Parameters.Add("@TEL", SqlDbType.NVarChar).Value = Telefono;
                comando.Parameters.Add("@DIR", SqlDbType.NVarChar).Value = Direccion;

                // Asegúrate de pasar TimeSpan correctamente al parámetro @HAP
                comando.Parameters.Add("@HAP", SqlDbType.Time).Value = Apertura;

                // Asegúrate de pasar TimeSpan correctamente al parámetro @HAC
                comando.Parameters.Add("@HAC", SqlDbType.Time).Value = Cierre;

                comando.ExecuteNonQuery();
                conexion.CerrarConexion();
                mensaje = "Datos Almacenados correctamente";
            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error en la insersion de datos " + ex.Message;
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

                q = "SELECT * FROM Gimnasio";
                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;

                conexion.CerrarConexion();
                mensaje = "Datos Mostrados Correctamente";

            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error al mostrar los datos " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DG1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
