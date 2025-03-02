namespace SMARTFIT
{
    partial class Clientes
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
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtIdGimnasio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.BtnInsertarDatos = new System.Windows.Forms.Button();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.BtnCrearTabla = new System.Windows.Forms.Button();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtIdPlan = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.Label();
            this.Telefono = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IdPersonal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(183, 291);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(172, 21);
            this.cmbEstado.TabIndex = 85;
            // 
            // txtIdGimnasio
            // 
            this.txtIdGimnasio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdGimnasio.Location = new System.Drawing.Point(185, 372);
            this.txtIdGimnasio.Name = "txtIdGimnasio";
            this.txtIdGimnasio.Size = new System.Drawing.Size(172, 23);
            this.txtIdGimnasio.TabIndex = 84;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label8.Location = new System.Drawing.Point(34, 377);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 18);
            this.label8.TabIndex = 83;
            this.label8.Text = "IdGimnasio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label6.Location = new System.Drawing.Point(32, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 18);
            this.label6.TabIndex = 82;
            this.label6.Text = "Estado";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(183, 206);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(172, 23);
            this.txtApellidos.TabIndex = 79;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label7.Location = new System.Drawing.Point(32, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 18);
            this.label7.TabIndex = 78;
            this.label7.Text = "Apellidos";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Goldenrod;
            this.label3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(391, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(485, 28);
            this.label3.TabIndex = 77;
            this.label3.Text = "Historial de Clientes";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Goldenrod;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 28);
            this.label1.TabIndex = 76;
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
            this.BtnConsultar.Location = new System.Drawing.Point(392, 462);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(484, 37);
            this.BtnConsultar.TabIndex = 74;
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
            this.BtnInsertarDatos.Location = new System.Drawing.Point(190, 462);
            this.BtnInsertarDatos.Name = "BtnInsertarDatos";
            this.BtnInsertarDatos.Size = new System.Drawing.Size(162, 37);
            this.BtnInsertarDatos.TabIndex = 73;
            this.BtnInsertarDatos.Text = "Insertar Datos";
            this.BtnInsertarDatos.UseVisualStyleBackColor = false;
            this.BtnInsertarDatos.Click += new System.EventHandler(this.BtnInsertarDatos_Click);
            // 
            // DG1
            // 
            this.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DG1.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG1.Location = new System.Drawing.Point(392, 121);
            this.DG1.Name = "DG1";
            this.DG1.Size = new System.Drawing.Size(484, 274);
            this.DG1.TabIndex = 75;
            // 
            // BtnCrearTabla
            // 
            this.BtnCrearTabla.BackColor = System.Drawing.Color.Gold;
            this.BtnCrearTabla.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.BtnCrearTabla.FlatAppearance.BorderSize = 5;
            this.BtnCrearTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearTabla.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearTabla.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnCrearTabla.Location = new System.Drawing.Point(22, 462);
            this.BtnCrearTabla.Name = "BtnCrearTabla";
            this.BtnCrearTabla.Size = new System.Drawing.Size(162, 37);
            this.BtnCrearTabla.TabIndex = 72;
            this.BtnCrearTabla.Text = "Crear Tabla";
            this.BtnCrearTabla.UseVisualStyleBackColor = false;
            this.BtnCrearTabla.Click += new System.EventHandler(this.BtnCrearTabla_Click);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(183, 247);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(172, 23);
            this.txtCorreo.TabIndex = 70;
            // 
            // txtIdPlan
            // 
            this.txtIdPlan.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPlan.Location = new System.Drawing.Point(184, 333);
            this.txtIdPlan.Name = "txtIdPlan";
            this.txtIdPlan.Size = new System.Drawing.Size(172, 23);
            this.txtIdPlan.TabIndex = 68;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(183, 162);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(172, 23);
            this.txtNombre.TabIndex = 67;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(183, 121);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(172, 23);
            this.txtIdCliente.TabIndex = 66;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.txt.Location = new System.Drawing.Point(32, 247);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(69, 18);
            this.txt.TabIndex = 64;
            this.txt.Text = "Correo";
            // 
            // Telefono
            // 
            this.Telefono.AutoSize = true;
            this.Telefono.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Telefono.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.Telefono.Location = new System.Drawing.Point(33, 333);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(97, 18);
            this.Telefono.TabIndex = 61;
            this.Telefono.Text = "Id de Plan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(32, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 65;
            this.label2.Text = "Nombre";
            // 
            // IdPersonal
            // 
            this.IdPersonal.AutoSize = true;
            this.IdPersonal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdPersonal.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.IdPersonal.Location = new System.Drawing.Point(32, 121);
            this.IdPersonal.Name = "IdPersonal";
            this.IdPersonal.Size = new System.Drawing.Size(119, 18);
            this.IdPersonal.TabIndex = 60;
            this.IdPersonal.Text = "Id de Cliente";
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(884, 523);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtIdGimnasio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.BtnInsertarDatos);
            this.Controls.Add(this.DG1);
            this.Controls.Add(this.BtnCrearTabla);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtIdPlan);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.Telefono);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IdPersonal);
            this.Name = "Clientes";
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtIdGimnasio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Button BtnInsertarDatos;
        private System.Windows.Forms.DataGridView DG1;
        private System.Windows.Forms.Button BtnCrearTabla;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtIdPlan;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label Telefono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label IdPersonal;
    }
}