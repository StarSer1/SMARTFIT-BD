namespace SMARTFIT
{
    partial class Personal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.BtnInsertarDatos = new System.Windows.Forms.Button();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.BtnCrearTabla = new System.Windows.Forms.Button();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.Label();
            this.txtt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Telefono = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHorario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdGimnasio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbConsulta = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Goldenrod;
            this.label3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(387, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(485, 28);
            this.label3.TabIndex = 50;
            this.label3.Text = "Historial de Personal";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Goldenrod;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 28);
            this.label1.TabIndex = 49;
            this.label1.Text = "Datos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.BackColor = System.Drawing.Color.Gold;
            this.BtnConsultar.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.BtnConsultar.FlatAppearance.BorderSize = 5;
            this.BtnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConsultar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsultar.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnConsultar.Location = new System.Drawing.Point(388, 460);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(484, 37);
            this.BtnConsultar.TabIndex = 47;
            this.BtnConsultar.Text = "Consultar Datos";
            this.BtnConsultar.UseVisualStyleBackColor = false;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // BtnInsertarDatos
            // 
            this.BtnInsertarDatos.BackColor = System.Drawing.Color.Gold;
            this.BtnInsertarDatos.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.BtnInsertarDatos.FlatAppearance.BorderSize = 5;
            this.BtnInsertarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInsertarDatos.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInsertarDatos.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnInsertarDatos.Location = new System.Drawing.Point(186, 460);
            this.BtnInsertarDatos.Name = "BtnInsertarDatos";
            this.BtnInsertarDatos.Size = new System.Drawing.Size(162, 37);
            this.BtnInsertarDatos.TabIndex = 46;
            this.BtnInsertarDatos.Text = "Insertar Datos";
            this.BtnInsertarDatos.UseVisualStyleBackColor = false;
            this.BtnInsertarDatos.Click += new System.EventHandler(this.BtnInsertarDatos_Click);
            // 
            // DG1
            // 
            this.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DG1.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG1.Location = new System.Drawing.Point(388, 113);
            this.DG1.Name = "DG1";
            this.DG1.Size = new System.Drawing.Size(484, 283);
            this.DG1.TabIndex = 48;
            // 
            // BtnCrearTabla
            // 
            this.BtnCrearTabla.BackColor = System.Drawing.Color.Gold;
            this.BtnCrearTabla.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.BtnCrearTabla.FlatAppearance.BorderSize = 5;
            this.BtnCrearTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearTabla.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearTabla.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnCrearTabla.Location = new System.Drawing.Point(18, 460);
            this.BtnCrearTabla.Name = "BtnCrearTabla";
            this.BtnCrearTabla.Size = new System.Drawing.Size(162, 37);
            this.BtnCrearTabla.TabIndex = 45;
            this.BtnCrearTabla.Text = "Crear Tabla";
            this.BtnCrearTabla.UseVisualStyleBackColor = false;
            this.BtnCrearTabla.Click += new System.EventHandler(this.BtnCrearTabla_Click);
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.Location = new System.Drawing.Point(180, 171);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(172, 23);
            this.txtDni.TabIndex = 43;
            // 
            // txtSalario
            // 
            this.txtSalario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalario.Location = new System.Drawing.Point(180, 256);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(172, 23);
            this.txtSalario.TabIndex = 42;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(180, 227);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(172, 23);
            this.txtDireccion.TabIndex = 44;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(180, 199);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(172, 23);
            this.txtTelefono.TabIndex = 41;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(178, 113);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(172, 23);
            this.txtNombre.TabIndex = 40;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.txt.Location = new System.Drawing.Point(29, 171);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(42, 18);
            this.txt.TabIndex = 37;
            this.txt.Text = "DNI";
            // 
            // txtt
            // 
            this.txtt.AutoSize = true;
            this.txtt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtt.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.txtt.Location = new System.Drawing.Point(29, 261);
            this.txtt.Name = "txtt";
            this.txtt.Size = new System.Drawing.Size(68, 18);
            this.txtt.TabIndex = 35;
            this.txtt.Text = "Salario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label4.Location = new System.Drawing.Point(29, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "Dirección";
            // 
            // Telefono
            // 
            this.Telefono.AutoSize = true;
            this.Telefono.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Telefono.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.Telefono.Location = new System.Drawing.Point(29, 199);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(86, 18);
            this.Telefono.TabIndex = 34;
            this.Telefono.Text = "Telefono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(27, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "Nombre";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(179, 142);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(172, 23);
            this.txtApellidos.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label7.Location = new System.Drawing.Point(28, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 18);
            this.label7.TabIndex = 51;
            this.label7.Text = "Apellidos";
            // 
            // txtHorario
            // 
            this.txtHorario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHorario.Location = new System.Drawing.Point(180, 285);
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.Size = new System.Drawing.Size(172, 23);
            this.txtHorario.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label5.Location = new System.Drawing.Point(29, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 18);
            this.label5.TabIndex = 53;
            this.label5.Text = "Horario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label6.Location = new System.Drawing.Point(29, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 18);
            this.label6.TabIndex = 55;
            this.label6.Text = "Estado";
            // 
            // txtIdGimnasio
            // 
            this.txtIdGimnasio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdGimnasio.Location = new System.Drawing.Point(180, 368);
            this.txtIdGimnasio.Name = "txtIdGimnasio";
            this.txtIdGimnasio.Size = new System.Drawing.Size(172, 23);
            this.txtIdGimnasio.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label8.Location = new System.Drawing.Point(29, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 18);
            this.label8.TabIndex = 57;
            this.label8.Text = "IdGimnasio";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(180, 341);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(172, 21);
            this.cmbEstado.TabIndex = 59;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label9.Location = new System.Drawing.Point(28, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 18);
            this.label9.TabIndex = 55;
            this.label9.Text = "Tipo";
            // 
            // CmbTipo
            // 
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Items.AddRange(new object[] {
            "General",
            "Administrativo"});
            this.CmbTipo.Location = new System.Drawing.Point(179, 314);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(172, 21);
            this.CmbTipo.TabIndex = 59;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label10.Location = new System.Drawing.Point(610, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 18);
            this.label10.TabIndex = 55;
            this.label10.Text = "Consulta";
            // 
            // cmbConsulta
            // 
            this.cmbConsulta.FormattingEnabled = true;
            this.cmbConsulta.Items.AddRange(new object[] {
            "Consulta General",
            "Salario superior a 2000",
            "Personal Activo",
            "Salario Promedio"});
            this.cmbConsulta.Location = new System.Drawing.Point(700, 77);
            this.cmbConsulta.Name = "cmbConsulta";
            this.cmbConsulta.Size = new System.Drawing.Size(172, 21);
            this.cmbConsulta.TabIndex = 59;
            // 
            // Personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(884, 523);
            this.Controls.Add(this.cmbConsulta);
            this.Controls.Add(this.CmbTipo);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtIdGimnasio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHorario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.BtnInsertarDatos);
            this.Controls.Add(this.DG1);
            this.Controls.Add(this.BtnCrearTabla);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.txtt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Telefono);
            this.Controls.Add(this.label2);
            this.Name = "Personal";
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.Personal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Button BtnInsertarDatos;
        private System.Windows.Forms.DataGridView DG1;
        private System.Windows.Forms.Button BtnCrearTabla;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label txtt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Telefono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHorario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdGimnasio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbConsulta;
    }
}