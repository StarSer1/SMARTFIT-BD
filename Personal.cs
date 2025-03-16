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
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                q = "SELECT * FROM Personal";
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

        private void BtnCrearTabla_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                
                q = "use SMARTFITBD";
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                q = "CREATE TABLE Personal (\r\n    Id_personal INT PRIMARY KEY Identity (1,1),\r\n    Nombre VARCHAR(50) NOT NULL,\r\n  " +
                    "  Apellidos VARCHAR(50) NOT NULL,\r\n    Dni VARCHAR(15) UNIQUE NOT NULL,\r\n    Telefono VARCHAR(20)" +
                    " DEFAULT '0000-000-000',\r\n    Direccion VARCHAR(255),\r\n    Salario INT CHECK (Salario >= 1800),\r\n " +
                    "   Horario VARCHAR(100),\r\n    Estado VARCHAR(20) CHECK (Estado = 'Activo' OR Estado = 'Inactivo'),\r\n" +
                    "    Tipo VARCHAR(15) CHECK (Tipo = 'General' OR Tipo = 'Administrativo'), -- Nuevo campo\r\n   " +
                    " Id_gimnasio INT,\r\n    CONSTRAINT fk_gimnasio_personal FOREIGN KEY (Id_gimnasio) REFERENCES Gimnasio(Id_gimnasio)\r\n);";

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

                // Obtención de valores desde los controles del formulario
                string Nombre = txtNombre.Text;
                string Apellidos = txtApellidos.Text;
                string Dni = txtDni.Text;
                string Telefono = txtTelefono.Text;
                string Direccion = txtDireccion.Text;
                int Salario = Convert.ToInt32(txtSalario.Text);
                string Horario = txtHorario.Text;
                string Tipo = CmbTipo.SelectedItem.ToString();
                string Estado = cmbEstado.SelectedItem.ToString(); // Suponiendo que es un ComboBox
                int IdGimnasio = Convert.ToInt32(txtIdGimnasio.Text);

                // Consulta SQL para la inserción de datos
                string q = "INSERT INTO Personal ( Nombre, Apellidos, Dni, Telefono, Direccion, Salario, Horario, Tipo, Estado, Id_gimnasio) " +
                           "VALUES (@NOM, @APE, @DNI, @TEL, @DIR, @SAL, @HOR, @TIP, @EST, @ID_GIM);";

                //string q = "INSERT INTO Personal ( Nombre, Apellidos, Dni, Telefono, Direccion, Salario, Horario, Estado, Id_gimnasio) " +
                //"VALUES (@NOM, @APE, @DNI, @TEL, @DIR, @SAL, @HOR, @EST, @ID_GIM);";

                // Creación del comando SQL
                comando = new SqlCommand(q, conexion.GetConexion());
                comando.Parameters.Clear();

                // Asignación de parámetros
                comando.Parameters.Add("@NOM", SqlDbType.NVarChar).Value = Nombre;
                comando.Parameters.Add("@APE", SqlDbType.NVarChar).Value = Apellidos;
                comando.Parameters.Add("@DNI", SqlDbType.NVarChar).Value = Dni;
                comando.Parameters.Add("@TEL", SqlDbType.NVarChar).Value = Telefono;
                comando.Parameters.Add("@DIR", SqlDbType.NVarChar).Value = Direccion;
                comando.Parameters.Add("@SAL", SqlDbType.Int).Value = Salario;
                comando.Parameters.Add("@HOR", SqlDbType.NVarChar).Value = Horario;
                comando.Parameters.Add("@TIP", SqlDbType.NVarChar).Value = Tipo;
                comando.Parameters.Add("@EST", SqlDbType.NVarChar).Value = Estado;
                comando.Parameters.Add("@ID_GIM", SqlDbType.Int).Value = IdGimnasio;

                // Ejecución del comando
                comando.ExecuteNonQuery();

                // Cierra la conexión
                conexion.CerrarConexion();

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
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();
                string opcion = cmbConsulta.SelectedItem.ToString();
                switch (opcion)
                {
                    case "Consulta General":
                        q = "SELECT * FROM Personal";
                        break;
                    case "Salario superior a 2000":
                        q = "SELECT Id_personal, Nombre,Salario,Id_gimnasio\r\nFROM Personal\r\nWHERE Salario >= 2000\r\n";
                        break;
                    case "Personal Activo":
                        q = "SELECT Id_personal, Nombre,Estado,Id_gimnasio\r\nFROM Personal\r\nWHERE Estado = 'Activo'";
                        break;
                    case "Salario Promedio":
                        q = "SELECT AVG(Salario) AS Prom_Salario\r\nFROM Personal";
                        break;

                }
                
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

        private void Personal_Load(object sender, EventArgs e)
        {

        }
    }
}
