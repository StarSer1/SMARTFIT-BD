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

                q = "Create Table Gimnasio(Id_gimnasio INT Identity (1,1) PRIMARY KEY,Nombre VARCHAR(100) NOT NULL," +
                    "Direccion VARCHAR(255) DEFAULT 'No especificado', Telefono VARCHAR(20) UNIQUE NOT NULL," +
                    "Horario_apertura TIME CHECK (Horario_apertura >= '05:00')," +
                    "Horario_cierre TIME CHECK (Horario_cierre <= '23:00'));";
                comando = new SqlCommand(q, conexion.GetConexion());
                comando.ExecuteNonQuery();

                q = "CREATE TRIGGER tr_VerificarHorarioGimnasio\r\nON Gimnasio\r\nAFTER INSERT, UPDATE\r\nAS\r\nBEGIN\r\n    IF EXISTS (\r\n        SELECT 1\r\n        FROM inserted\r\n        WHERE Horario_cierre <= Horario_apertura\r\n    )\r\n    BEGIN\r\n        THROW 50001, 'El horario de cierre debe ser mayor al horario de apertura.', 1;\r\n    END;\r\nEND;";
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

                string Nombre = TxtNombre.Text;
                string Telefono = TxtTelefono.Text;
                string Direccion = TxtDireccion.Text;

                // Para Horario_Apertura, usa TimeSpan directamente
                TimeSpan Apertura = new TimeSpan();  // Asegúrate de que TxtHApertura contenga un formato adecuado como "HH:mm"
                if (int.TryParse(TxtHApertura.Text, out int numero))
                {
                    // Convertimos el número a un TimeSpan (interpretándolo como minutos)
                    Apertura = TimeSpan.FromHours(numero);
                }
                else
                {
                   MessageBox.Show("Ingrese un número válido.");
                }
                // Para Horario_Cierre, usa TimeSpan directamente
                TimeSpan Cierre = new TimeSpan();  // Aquí puedes mantener la hora predeterminada si es fija, o también puedes usar un campo de texto
                if (int.TryParse(TxtHCierre.Text, out int numero2))
                {
                    // Convertimos el número a un TimeSpan (interpretándolo como minutos)
                    Cierre = TimeSpan.FromHours(numero2);
                }
                else
                {
                    MessageBox.Show("Ingrese un número válido.");
                }
                q = "EXEC AgregarGimnasio @NOM,@DIR, @TEL, @HAP, @HAC";

                comando = new SqlCommand(q, conexion.GetConexion());

                comando.Parameters.Clear();
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

                string opcion = cmbConsulta.SelectedItem.ToString();
                switch (opcion)
                {
                    case "Consulta General":
                        q = "SELECT * FROM Gimnasio";
                        break;                   
                    case "Apertura de 06:00 para adelante":
                        q = "SELECT Id_gimnasio, Nombre,Horario_apertura\r\nFROM Gimnasio\r\nWHERE Horario_apertura >= '06:00:00'\r\n";
                        break;
                    case "Gimnasio en Avenida ":
                        q = "SELECT Id_gimnasio, Nombre,Direccion, Horario_cierre\r\nFROM Gimnasio\r\nWHERE Direccion LIKE 'Av.%';\r\n";
                        break;
                    case "Gimnasio en CDMX o Personal con 7 años de exp":
                        q = "SELECT Id_Gimnasio,Gimnasio.Nombre AS Nombre_Gimnasio, Direccion,\r\n       General.Años_de_experiencia\r\nFROM Gimnasio\r\nINNER JOIN General\r\nON Gimnasio.Id_gimnasio = General.Id_Personal\r\nWHERE General.Años_de_experiencia >= 7 OR Direccion LIKE '%CDMX'\r\n";
                        break;
                    case "Personal con 6 años o mas de experiencia":
                        q = "SELECT Gimnasio.Id_gimnasio,Gimnasio.Nombre,\r\n\t   Personal.Id_personal,\r\n\t   General.Id_Personal AS Id_General, General.Años_de_experiencia\r\nFROM Gimnasio\r\nINNER JOIN Personal\r\nON Gimnasio.Id_gimnasio = Personal.Id_gimnasio\r\nINNER JOIN General\r\nON Personal.Id_gimnasio = General.Id_Personal\r\nWHERE General.Años_de_experiencia >=6\r\n";
                        break;
                    case "Gimnasios que abren antes de las 6":
                        q = "SELECT g.Nombre AS Nombre_Gimnasio, g.Horario_apertura, p.Nombre AS Nombre_Personal, p.Salario\r\nFROM Gimnasio g\r\nINNER JOIN Personal p ON g.Id_gimnasio = p.Id_gimnasio\r\nWHERE CONVERT(TIME, g.Horario_apertura) < '06:00' AND p.Salario > 2500\r\nORDER BY p.Salario DESC;";
                        break;
                    case "Gimnasios donde trabajan empleados con el salario más bajo":
                        q = "SELECT Nombre\r\nFROM Gimnasio\r\nWHERE Id_gimnasio IN (\r\n    SELECT DISTINCT Id_gimnasio \r\n    FROM Personal \r\n    WHERE Salario = (SELECT MIN(Salario) FROM Personal)\r\n);";
                        break;
                    case "Gimnasios con personal activo que tenga más experiencia que el promedio de todos los empleados":
                        q = "SELECT g.Nombre AS Nombre_Gimnasio, p.Nombre AS Nombre_Personal, gnl.Años_de_experiencia\r\nFROM Gimnasio g\r\nINNER JOIN Personal p ON g.Id_gimnasio = p.Id_gimnasio\r\nINNER JOIN General gnl ON p.Id_personal = gnl.Id_Personal\r\nWHERE p.Estado = 'Activo' \r\nAND gnl.Años_de_experiencia > (SELECT AVG(Años_de_experiencia) FROM General);";
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DG1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnVista_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGeneral conexion = new ConexionGeneral();
                conexion.AbrirConexion();

                q = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'VistaSalariosPorGimnasio')\r\nBEGIN\r\n    EXEC('\r\n        CREATE VIEW VistaSalariosPorGimnasio AS\r\n        SELECT \r\n            g.Nombre AS Nombre_Gimnasio,\r\n            COUNT(p.Id_personal) AS Total_Empleados,\r\n            AVG(p.Salario) AS Salario_Promedio,\r\n            MIN(p.Salario) AS Salario_Minimo,\r\n            MAX(p.Salario) AS Salario_Maximo\r\n        FROM \r\n            Gimnasio g\r\n        JOIN \r\n            Personal p ON g.Id_gimnasio = p.Id_gimnasio\r\n        GROUP BY \r\n            g.Nombre\r\n    ')\r\n    PRINT 'Vista \"VistaSalariosPorGimnasio\" creada exitosamente.'\r\nEND\r\nELSE\r\nBEGIN\r\n    PRINT 'La vista \"VistaSalariosPorGimnasio\" ya existe.'\r\nEND";
                comando = new SqlCommand(q, conexion.GetConexion());
                conexion.AbrirConexion();
                comando.ExecuteNonQuery();

                q = "SELECT * FROM VistaSalariosPorGimnasio";

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
