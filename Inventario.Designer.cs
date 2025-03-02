namespace SMARTFIT
{
    partial class Inventario
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdInventario = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.BtnInsertarDatos = new System.Windows.Forms.Button();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.BtnCrearTabla = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IdPersonal = new System.Windows.Forms.Label();
            this.txtIdGimnasio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(15, 297);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(324, 93);
            this.txtDescripcion.TabIndex = 125;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Goldenrod;
            this.label5.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(23, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 28);
            this.label5.TabIndex = 124;
            this.label5.Text = "Descripción";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(177, 123);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(174, 23);
            this.txtNombre.TabIndex = 123;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label4.Location = new System.Drawing.Point(27, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 122;
            this.label4.Text = "Tipo";
            // 
            // txtIdInventario
            // 
            this.txtIdInventario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdInventario.Location = new System.Drawing.Point(176, 91);
            this.txtIdInventario.Name = "txtIdInventario";
            this.txtIdInventario.Size = new System.Drawing.Size(172, 23);
            this.txtIdInventario.TabIndex = 121;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Pesas",
            "Barras",
            "Cardio",
            "Accesorios",
            "Equipamiento"});
            this.cmbTipo.Location = new System.Drawing.Point(177, 192);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(172, 21);
            this.cmbTipo.TabIndex = 120;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(177, 156);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(172, 23);
            this.txtCantidad.TabIndex = 119;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label7.Location = new System.Drawing.Point(25, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 18);
            this.label7.TabIndex = 118;
            this.label7.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Goldenrod;
            this.label3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(383, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(485, 28);
            this.label3.TabIndex = 117;
            this.label3.Text = "Historial de Inventario";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Goldenrod;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 28);
            this.label1.TabIndex = 116;
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
            this.BtnConsultar.Location = new System.Drawing.Point(385, 452);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(484, 37);
            this.BtnConsultar.TabIndex = 114;
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
            this.BtnInsertarDatos.Location = new System.Drawing.Point(183, 452);
            this.BtnInsertarDatos.Name = "BtnInsertarDatos";
            this.BtnInsertarDatos.Size = new System.Drawing.Size(162, 37);
            this.BtnInsertarDatos.TabIndex = 113;
            this.BtnInsertarDatos.Text = "Insertar Datos";
            this.BtnInsertarDatos.UseVisualStyleBackColor = false;
            this.BtnInsertarDatos.Click += new System.EventHandler(this.BtnInsertarDatos_Click);
            // 
            // DG1
            // 
            this.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DG1.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG1.Location = new System.Drawing.Point(379, 120);
            this.DG1.Name = "DG1";
            this.DG1.Size = new System.Drawing.Size(484, 290);
            this.DG1.TabIndex = 115;
            // 
            // BtnCrearTabla
            // 
            this.BtnCrearTabla.BackColor = System.Drawing.Color.Gold;
            this.BtnCrearTabla.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.BtnCrearTabla.FlatAppearance.BorderSize = 5;
            this.BtnCrearTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearTabla.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearTabla.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnCrearTabla.Location = new System.Drawing.Point(15, 452);
            this.BtnCrearTabla.Name = "BtnCrearTabla";
            this.BtnCrearTabla.Size = new System.Drawing.Size(162, 37);
            this.BtnCrearTabla.TabIndex = 112;
            this.BtnCrearTabla.Text = "Crear Tabla";
            this.BtnCrearTabla.UseVisualStyleBackColor = false;
            this.BtnCrearTabla.Click += new System.EventHandler(this.BtnCrearTabla_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(25, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 111;
            this.label2.Text = "Nombre";
            // 
            // IdPersonal
            // 
            this.IdPersonal.AutoSize = true;
            this.IdPersonal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdPersonal.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.IdPersonal.Location = new System.Drawing.Point(25, 96);
            this.IdPersonal.Name = "IdPersonal";
            this.IdPersonal.Size = new System.Drawing.Size(124, 18);
            this.IdPersonal.TabIndex = 110;
            this.IdPersonal.Text = "Id Inventario";
            // 
            // txtIdGimnasio
            // 
            this.txtIdGimnasio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdGimnasio.Location = new System.Drawing.Point(177, 223);
            this.txtIdGimnasio.Name = "txtIdGimnasio";
            this.txtIdGimnasio.Size = new System.Drawing.Size(174, 23);
            this.txtIdGimnasio.TabIndex = 127;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label6.Location = new System.Drawing.Point(27, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 18);
            this.label6.TabIndex = 126;
            this.label6.Text = "Id Gimnasio";
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(884, 523);
            this.Controls.Add(this.txtIdGimnasio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdInventario);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.BtnInsertarDatos);
            this.Controls.Add(this.DG1);
            this.Controls.Add(this.BtnCrearTabla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IdPersonal);
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdInventario;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Button BtnInsertarDatos;
        private System.Windows.Forms.DataGridView DG1;
        private System.Windows.Forms.Button BtnCrearTabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label IdPersonal;
        private System.Windows.Forms.TextBox txtIdGimnasio;
        private System.Windows.Forms.Label label6;
    }
}