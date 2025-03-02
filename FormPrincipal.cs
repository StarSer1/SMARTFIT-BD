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
            OpenChildForm(new Form1());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Brandon
                using (conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=master;Integrated Security=True;"))
                //Alex
                //using (conexion = new SqlConnection(@"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;"))
                {
                    conexion.Open();

                    // Cambiar a modo de usuario único y forzar cierre de conexiones
                    q = "ALTER DATABASE SMARTFIT SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                    comando = new SqlCommand(q, conexion);
                    comando.ExecuteNonQuery();

                    // Eliminar la base de datos
                    q = "DROP DATABASE SMARTFITBD;";
                    comando = new SqlCommand(q, conexion);
                    comando.ExecuteNonQuery();

                    mensaje = "La base de datos fue eliminada correctamente.";
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
                //conexion Brandon
                conexion = new SqlConnection(@"Data Source=DESKTOP-0434B1E;Initial Catalog=master;Integrated Security=True;");
                //conexion Alex
                //conexion = new SqlConnection(@"Data Source=DESKTOP-GQ6Q9HG\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;");
                q = "create database SMARTFITBD";
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
            //panel3.Height = pictureBox1.Height;
            //panel3.Top = panel1.Top;
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
            OpenChildForm(new Personal());
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelPersonal.Visible = false;
            panelGeneral.Visible = true;
            OpenChildForm(new General());
        }
    }
}
