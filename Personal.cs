﻿using System;
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
    public partial class Personal : Form
    {
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader Lector;
        public string q;
        public string mensaje;

        public Personal()
        {
            InitializeComponent();

            try
            {
                //Brandon
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                //Alex
                //conexion = new SqlConnection(@"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                conexion.Open();

                q = "SELECT * FROM Personal";
                comando = new SqlCommand(q, conexion);
                Lector = comando.ExecuteReader();

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;

                conexion.Close();
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

        private void BtnCrearTabla_Click(object sender, EventArgs e)
        {
            try
            {
                //Brandon
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                //Alex
                //conexion = new SqlConnection(@"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                q = "use SMARTFITBD";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                q = "CREATE TABLE Personal(" + "Id_personal INT PRIMARY KEY, " + "Nombre VARCHAR(50) NOT NULL, " + "Apellidos VARCHAR(50) NOT NULL, " +
                "Dni VARCHAR(15) UNIQUE NOT NULL, " + "Telefono VARCHAR(20) DEFAULT '0000-000-000', " + "Direccion VARCHAR(255), " + "Salario INT CHECK (Salario >= 1800), " + "Horario VARCHAR(100), " + "Estado VARCHAR(20) CHECK " +
                "(Estado = 'Activo' OR Estado = 'Inactivo'), " + "Id_gimnasio INT, " + "CONSTRAINT fk_gimnasio_personal FOREIGN KEY (Id_gimnasio) REFERENCES Gimnasio(Id_gimnasio)" +");";

                comando = new SqlCommand(q, conexion);
                comando.ExecuteNonQuery();

                mensaje = "Creacion de las Tablas realizada";

                //nuevo
                conexion.Close();
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
                // Conexión a la base de datos
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");

                // Abre la conexión
                conexion.Open();

                // Obtención de valores desde los controles del formulario
                int IdPersonal = Convert.ToInt32(txtIdPersonal.Text);
                string Nombre = txtNombre.Text;
                string Apellidos = txtApellidos.Text;
                string Dni = txtDni.Text;
                string Telefono = txtTelefono.Text;
                string Direccion = txtDireccion.Text;
                int Salario = Convert.ToInt32(txtSalario.Text);
                string Horario = txtHorario.Text;
                string Estado = cmbEstado.SelectedItem.ToString(); // Suponiendo que es un ComboBox
                int IdGimnasio = Convert.ToInt32(txtIdGimnasio.Text);

                // Consulta SQL para la inserción de datos
                string q = "INSERT INTO Personal (Id_personal, Nombre, Apellidos, Dni, Telefono, Direccion, Salario, Horario, Estado, Id_gimnasio) " +
                           "VALUES (@ID, @NOM, @APE, @DNI, @TEL, @DIR, @SAL, @HOR, @EST, @ID_GIM);";

                // Creación del comando SQL
                comando = new SqlCommand(q, conexion);
                comando.Parameters.Clear();

                // Asignación de parámetros
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = IdPersonal;
                comando.Parameters.Add("@NOM", SqlDbType.NVarChar).Value = Nombre;
                comando.Parameters.Add("@APE", SqlDbType.NVarChar).Value = Apellidos;
                comando.Parameters.Add("@DNI", SqlDbType.NVarChar).Value = Dni;
                comando.Parameters.Add("@TEL", SqlDbType.NVarChar).Value = Telefono;
                comando.Parameters.Add("@DIR", SqlDbType.NVarChar).Value = Direccion;
                comando.Parameters.Add("@SAL", SqlDbType.Int).Value = Salario;
                comando.Parameters.Add("@HOR", SqlDbType.NVarChar).Value = Horario;
                comando.Parameters.Add("@EST", SqlDbType.NVarChar).Value = Estado;
                comando.Parameters.Add("@ID_GIM", SqlDbType.Int).Value = IdGimnasio;

                // Ejecución del comando
                comando.ExecuteNonQuery();

                // Cierra la conexión
                conexion.Close();

                mensaje = "Datos almacenados correctamente";
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
                //Brandon
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                //Alex
                //conexion = new SqlConnection(@"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=SMARTFITBD;Integrated Security=True;");
                conexion.Open();

                q = "SELECT * FROM Personal";
                comando = new SqlCommand(q, conexion);
                Lector = comando.ExecuteReader();

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;

                conexion.Close();
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

        private void Personal_Load(object sender, EventArgs e)
        {

        }
    }
}
