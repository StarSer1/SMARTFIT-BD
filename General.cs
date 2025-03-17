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
                conexion.AbrirConexion();
                q = "use SMARTFITBD";
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();


                q = "CREATE TABLE General (\r\n    Cedúla VARCHAR(30) UNIQUE NOT NULL,\r\n    Años_de_experiencia INT CHECK (Años_de_experiencia >= 0) DEFAULT 0,\r\n    Id_Personal INT UNIQUE, -- Evita que un mismo Id_Personal esté en otra tabla\r\n    CONSTRAINT fk_personal_general FOREIGN KEY (Id_Personal) REFERENCES Personal(Id_Personal)\r\n);";

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

                string opcion = cmbConsulta.SelectedItem.ToString();
                switch (opcion)
                {
                    case "Consulta General":
                        q = "SELECT * FROM General";
                        break;
                    case "Personal entre 4 y 7 años de exp":
                        q = "SELECT Id_Personal,Cedúla, Años_de_experiencia\r\nFROM General\r\nWHERE Años_de_experiencia BETWEEN 4 AND 7\r\n";
                        break;
                    case "Personal que trabaja en gimnasios que cierran más tarde que el promedio":
                        q = "SELECT p.Nombre, g.Nombre AS Nombre_Gimnasio, g.Horario_cierre\r\nFROM Personal p\r\nINNER JOIN Gimnasio g ON p.Id_gimnasio = g.Id_gimnasio\r\nWHERE DATEDIFF(SECOND, '00:00:00', g.Horario_cierre) > (\r\n    SELECT AVG(DATEDIFF(SECOND, '00:00:00', Horario_cierre)) FROM Gimnasio\r\n);";
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


        
        private void BtnVista_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                q = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'VistaPersonalInactivo')\r\nBEGIN\r\n    EXEC('\r\n        CREATE VIEW VistaPersonalInactivo AS\r\n        SELECT \r\n            Id_personal,\r\n            Nombre,\r\n            Apellidos,\r\n            Tipo,\r\n            Estado\r\n        FROM \r\n            Personal\r\n        WHERE \r\n            Estado = ''Inactivo''\r\n    ')\r\n    PRINT 'Vista \"VistaPersonalInactivo\" creada exitosamente.'\r\nEND\r\nELSE\r\nBEGIN\r\n    PRINT 'La vista \"VistaPersonalInactivo\" ya existe.'\r\nEND\r\n";

                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                q = "SELECT * FROM VistaPersonalInactivo";

                comando = new SqlCommand(q, conexion.GetConexion());
                Lector = comando.ExecuteReader();

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();
                dt.Load(Lector);

                // Asignar el DataTable al DataGridView
                DG1.DataSource = dt;

                conexion.CerrarConexion();
                //nuevo

            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error al mostrar la vista " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }
    }
}