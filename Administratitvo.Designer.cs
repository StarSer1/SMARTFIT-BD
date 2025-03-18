namespace SMARTFIT
{
    partial class Administrativo
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
            this.txtIdPersonal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.BtnInsertarDatos = new System.Windows.Forms.Button();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.BtnCrearTabla = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IdPersonal = new System.Windows.Forms.Label();
            this.cmbEquipo = new System.Windows.Forms.ComboBox();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.cmbConsulta = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnVista = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdPersonal
            // 
            this.txtIdPersonal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPersonal.Location = new System.Drawing.Point(185, 248);
            this.txtIdPersonal.Name = "txtIdPersonal";
            this.txtIdPersonal.Size = new System.Drawing.Size(172, 23);
            this.txtIdPersonal.TabIndex = 91;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label7.Location = new System.Drawing.Point(33, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 18);
            this.label7.TabIndex = 90;
            this.label7.Text = "IdPersonal";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Goldenrod;
            this.label3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(392, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(485, 28);
            this.label3.TabIndex = 89;
            this.label3.Text = "Historial de Administrativo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Goldenrod;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 28);
            this.label1.TabIndex = 88;
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
            this.BtnConsultar.Location = new System.Drawing.Point(391, 462);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(484, 37);
            this.BtnConsultar.TabIndex = 86;
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
            this.BtnInsertarDatos.Location = new System.Drawing.Point(189, 462);
            this.BtnInsertarDatos.Name = "BtnInsertarDatos";
            this.BtnInsertarDatos.Size = new System.Drawing.Size(162, 37);
            this.BtnInsertarDatos.TabIndex = 85;
            this.BtnInsertarDatos.Text = "Insertar Datos";
            this.BtnInsertarDatos.UseVisualStyleBackColor = false;
            this.BtnInsertarDatos.Click += new System.EventHandler(this.BtnInsertarDatos_Click);
            // 
            // DG1
            // 
            this.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DG1.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG1.Location = new System.Drawing.Point(393, 126);
            this.DG1.Name = "DG1";
            this.DG1.Size = new System.Drawing.Size(484, 272);
            this.DG1.TabIndex = 87;
            // 
            // BtnCrearTabla
            // 
            this.BtnCrearTabla.BackColor = System.Drawing.Color.Gold;
            this.BtnCrearTabla.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.BtnCrearTabla.FlatAppearance.BorderSize = 5;
            this.BtnCrearTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearTabla.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearTabla.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnCrearTabla.Location = new System.Drawing.Point(21, 462);
            this.BtnCrearTabla.Name = "BtnCrearTabla";
            this.BtnCrearTabla.Size = new System.Drawing.Size(162, 37);
            this.BtnCrearTabla.TabIndex = 84;
            this.BtnCrearTabla.Text = "Crear Tabla";
            this.BtnCrearTabla.UseVisualStyleBackColor = false;
            this.BtnCrearTabla.Click += new System.EventHandler(this.BtnCrearTabla_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(33, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 81;
            this.label2.Text = "Equipo";
            // 
            // IdPersonal
            // 
            this.IdPersonal.AutoSize = true;
            this.IdPersonal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdPersonal.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.IdPersonal.Location = new System.Drawing.Point(34, 126);
            this.IdPersonal.Name = "IdPersonal";
            this.IdPersonal.Size = new System.Drawing.Size(61, 18);
            this.IdPersonal.TabIndex = 80;
            this.IdPersonal.Text = "Cargo";
            // 
            // cmbEquipo
            // 
            this.cmbEquipo.FormattingEnabled = true;
            this.cmbEquipo.Items.AddRange(new object[] {
            "Pesas",
            "Equipo de limpieza",
            "Equipo de computo",
            "Articulos de gimnasio",
            "Maquina"});
            this.cmbEquipo.Location = new System.Drawing.Point(185, 189);
            this.cmbEquipo.Name = "cmbEquipo";
            this.cmbEquipo.Size = new System.Drawing.Size(172, 21);
            this.cmbEquipo.TabIndex = 92;
            // 
            // cmbCargo
            // 
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Items.AddRange(new object[] {
            "Proveedor",
            "Intendente",
            "Tecnico"});
            this.cmbCargo.Location = new System.Drawing.Point(185, 127);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(172, 21);
            this.cmbCargo.TabIndex = 93;
            // 
            // cmbConsulta
            // 
            this.cmbConsulta.FormattingEnabled = true;
            this.cmbConsulta.Items.AddRange(new object[] {
            "Consulta General",
            "Mostrar los id´s y el cargo de los intendentes",
            "Mostrar personal que son del area del administrativo",
            "Mostrar los datos de los tecnicos del area Administrativo"});
            this.cmbConsulta.Location = new System.Drawing.Point(700, 90);
            this.cmbConsulta.Name = "cmbConsulta";
            this.cmbConsulta.Size = new System.Drawing.Size(172, 21);
            this.cmbConsulta.TabIndex = 95;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label10.Location = new System.Drawing.Point(611, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 18);
            this.label10.TabIndex = 94;
            this.label10.Text = "Consulta";
            // 
            // BtnVista
            // 
            this.BtnVista.BackColor = System.Drawing.Color.Gold;
            this.BtnVista.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.BtnVista.FlatAppearance.BorderSize = 5;
            this.BtnVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVista.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVista.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnVista.Location = new System.Drawing.Point(21, 419);
            this.BtnVista.Name = "BtnVista";
            this.BtnVista.Size = new System.Drawing.Size(330, 37);
            this.BtnVista.TabIndex = 96;
            this.BtnVista.Text = "Activar Vista";
            this.BtnVista.UseVisualStyleBackColor = false;
            this.BtnVista.Click += new System.EventHandler(this.BtnVista_Click);
            // 
            // Administrativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(884, 523);
            this.Controls.Add(this.BtnVista);
            this.Controls.Add(this.cmbConsulta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbCargo);
            this.Controls.Add(this.cmbEquipo);
            this.Controls.Add(this.txtIdPersonal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.BtnInsertarDatos);
            this.Controls.Add(this.DG1);
            this.Controls.Add(this.BtnCrearTabla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IdPersonal);
            this.Name = "Administrativo";
            this.Text = "Administratitvo";
            this.Load += new System.EventHandler(this.Administrativo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdPersonal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Button BtnInsertarDatos;
        private System.Windows.Forms.DataGridView DG1;
        private System.Windows.Forms.Button BtnCrearTabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label IdPersonal;
        private System.Windows.Forms.ComboBox cmbEquipo;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.ComboBox cmbConsulta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnVista;
    }
}