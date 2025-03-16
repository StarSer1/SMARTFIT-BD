using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTFIT
{
    public partial class FormPrincipal : Form
    {
        //Variables
        private Form activateForm;

        //Variables base de datos
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader Lector;
        public string q;
        public string mensaje;

        public FormPrincipal()
        {
            InitializeComponent();
            OpenChildForm(new FormMenu());

            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;

            this.Text = string.Empty;
            this.ControlBox = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //PANEL
        private void OpenChildForm(Form childForm)
        {
            if (activateForm != null)
            {
                activateForm.Close();
            }
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None; 
            childForm.Dock = DockStyle.Fill;
            this.panelFondo.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();

            label1.Text = childForm.Text;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGimnasio_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panelPersonal.Visible = false;
            panelAdministrativo.Visible = false;
            panelGeneral.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;
            OpenChildForm(new Form1());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //@"Data Source=DESKTOP-0434B1E;Initial Catalog=master;Integrated Security=True;"
                string cadenaConexion = @"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
                SqlConnection conexion = new SqlConnection(cadenaConexion);

                conexion.Open();
                {

                    // Cambiar a modo de usuario único y forzar cierre de conexiones
                    q = "ALTER DATABASE SMARTFITBD SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                    comando = new SqlCommand(q, conexion);
                    comando.ExecuteNonQuery();

                    // Eliminar la base de datos
                    q = "DROP DATABASE SMARTFITBD;";
                    comando = new SqlCommand(q, conexion);
                    comando.ExecuteNonQuery();

                    mensaje = "La base de datos fue eliminada correctamente.";
                    conexion.Close();
                }
            }
            catch (System.Exception ex)
            {
                mensaje = "Ocurrio un error en la eliminacion de la Base de Datos" + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearDB_Click(object sender, EventArgs e)
        {
            try
            {
                //@"Data Source=DESKTOP-0434B1E;Initial Catalog=master;Integrated Security=True;"
                string cadenaConexion = @"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
                string cadenaConexion2 = @"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=SMARTFITBD;Integrated Security=True;";
                SqlConnection conexion = new SqlConnection(cadenaConexion);

                q = "create database SMARTFITBD";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();



                conexion = new SqlConnection(cadenaConexion2);
                q = "CREATE PROCEDURE AgregarGimnasio\r\n@Nombre varchar(100),\r\n@Direccion varchar(100),\r\n@Telefono varchar(20),\r\n@Horario_apertura TIME,\r\n@Horario_cierre TIME\r\nAS\r\nBEGIN TRY\r\n\tINSERT INTO Gimnasio\r\n\t(Nombre,Direccion,Telefono,Horario_apertura,Horario_cierre)\r\n\tVALUES\r\n\t(@Nombre,@Direccion,@Telefono,@Horario_apertura,@Horario_cierre)\r\nEND TRY\r\nBEGIN CATCH\r\nSELECT ERROR_NUMBER(),ERROR_MESSAGE()\r\nEND CATCH\r\n";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                //conexion = new SqlConnection(cadenaConexion2);
                //q = "CREATE PROCEDURE AgregarPersonal\r\n@Nombre varchar(50),\r\n@Apellidos varchar(50),\r\n@Dni varchar(15),\r\n@Telefono varchar(20),\r\n@Direccion varchar(225),\r\n@Salario INT,\r\n@Horario VARCHAR(100),\r\n@Estado VARCHAR (100),\r\n@Tipo VARCHAR(50),\r\n@Id_gimnasio INT\r\nAS\r\nBEGIN TRY\r\n\tINSERT INTO Personal\r\n\t(Nombre,Apellidos,Dni,Telefono,Direccion,Salario,Horario,Estado,Tipo,Id_gimnasio)\r\n\tVALUES\r\n\t(@Nombre,@Apellidos,@Dni,@Telefono,@Direccion,@Salario,\r\n\t@Horario,@Estado, @Tipo, @Id_gimnasio)\r\nEND TRY\r\nBEGIN CATCH\r\nSELECT ERROR_NUMBER(),ERROR_MESSAGE()\r\nEND CATCH";
                //comando = new SqlCommand(q, conexion);
                //conexion.Open();
                //comando.ExecuteNonQuery();

                conexion = new SqlConnection(cadenaConexion2);
                q = "CREATE PROCEDURE AgregarGeneral\r\n@Cedula VARCHAR(30),\r\n@Años_Exp INT,\r\n@Id_Personal INT\r\nAS\r\nBEGIN\r\n    BEGIN TRY\r\n        INSERT INTO General\r\n        ([Cedúla], Años_de_experiencia, Id_Personal)\r\n        VALUES\r\n        (@Cedula, @Años_Exp, @Id_Personal);\r\n\r\n    END TRY\r\n    BEGIN CATCH\r\n        SELECT ERROR_NUMBER() AS Error_Numero, ERROR_MESSAGE() AS Error_Mensaje;\r\n    END CATCH\r\nEND;\r\n";
                comando = new SqlCommand(q, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();

                conexion.Close();

                mensaje = "La base de datos fue creada correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Ocurrio un error en la creacion de la Base de Datos " + ex.Message;
            }
            finally
            {
                MessageBox.Show(mensaje);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panelPersonal.Visible = false;
            panelAdministrativo.Visible = false;
            panelGeneral.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;

            OpenChildForm(new FormMenu());
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = true;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;
            OpenChildForm(new Personal());
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelAdministrativo.Visible = false;
            panelGeneral.Visible = true;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;
            OpenChildForm(new General());
        }

        private void btnAdministrativo_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = true;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;
            OpenChildForm(new Administrativo());
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = false;
            panelPlan.Visible = true;
            PanelClientes.Visible = false;
            panelInventario.Visible = false;
            OpenChildForm(new Plan());
        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = true;
            panelInventario.Visible = false;
            OpenChildForm(new Clientes());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = false;
            panelAdministrativo.Visible = false;
            panelPlan.Visible = false;
            PanelClientes.Visible = false;
            panelInventario.Visible = true;
            OpenChildForm(new Inventario());
        }
    }
}
