namespace SMARTFIT
{
    partial class Plan
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
            this.txtClientesInscritos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.BtnInsertarDatos = new System.Windows.Forms.Button();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.BtnCrearTabla = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNombre = new System.Windows.Forms.ComboBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbConsulta = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnVista = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtClientesInscritos
            // 
            this.txtClientesInscritos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientesInscritos.Location = new System.Drawing.Point(210, 158);
            this.txtClientesInscritos.Name = "txtClientesInscritos";
            this.txtClientesInscritos.Size = new System.Drawing.Size(145, 23);
            this.txtClientesInscritos.TabIndex = 103;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label7.Location = new System.Drawing.Point(31, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 18);
            this.label7.TabIndex = 102;
            this.label7.Text = "Clientes inscritos";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Goldenrod;
            this.label3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(392, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(485, 28);
            this.label3.TabIndex = 101;
            this.label3.Text = "Historial de Plan";
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
            this.label1.TabIndex = 100;
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
            this.BtnConsultar.Location = new System.Drawing.Point(393, 465);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(484, 37);
            this.BtnConsultar.TabIndex = 98;
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
            this.BtnInsertarDatos.Location = new System.Drawing.Point(191, 465);
            this.BtnInsertarDatos.Name = "BtnInsertarDatos";
            this.BtnInsertarDatos.Size = new System.Drawing.Size(163, 37);
            this.BtnInsertarDatos.TabIndex = 97;
            this.BtnInsertarDatos.Text = "Insertar Datos";
            this.BtnInsertarDatos.UseVisualStyleBackColor = false;
            this.BtnInsertarDatos.Click += new System.EventHandler(this.BtnInsertarDatos_Click);
            // 
            // DG1
            // 
            this.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DG1.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG1.Location = new System.Drawing.Point(388, 127);
            this.DG1.Name = "DG1";
            this.DG1.Size = new System.Drawing.Size(484, 290);
            this.DG1.TabIndex = 99;
            // 
            // BtnCrearTabla
            // 
            this.BtnCrearTabla.BackColor = System.Drawing.Color.Gold;
            this.BtnCrearTabla.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.BtnCrearTabla.FlatAppearance.BorderSize = 5;
            this.BtnCrearTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearTabla.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearTabla.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnCrearTabla.Location = new System.Drawing.Point(30, 465);
            this.BtnCrearTabla.Name = "BtnCrearTabla";
            this.BtnCrearTabla.Size = new System.Drawing.Size(155, 37);
            this.BtnCrearTabla.TabIndex = 96;
            this.BtnCrearTabla.Text = "Crear Tabla";
            this.BtnCrearTabla.UseVisualStyleBackColor = false;
            this.BtnCrearTabla.Click += new System.EventHandler(this.BtnCrearTabla_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(31, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 95;
            this.label2.Text = "Nombre";
            // 
            // cmbNombre
            // 
            this.cmbNombre.FormattingEnabled = true;
            this.cmbNombre.Items.AddRange(new object[] {
            "Plan Smart",
            "Plan Fit",
            "Plan Black"});
            this.cmbNombre.Location = new System.Drawing.Point(183, 127);
            this.cmbNombre.Name = "cmbNombre";
            this.cmbNombre.Size = new System.Drawing.Size(172, 21);
            this.cmbNombre.TabIndex = 104;
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(212, 194);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(142, 23);
            this.txtCosto.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label4.Location = new System.Drawing.Point(33, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 18);
            this.label4.TabIndex = 106;
            this.label4.Text = "Costo de plan";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Goldenrod;
            this.label5.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(25, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 28);
            this.label5.TabIndex = 108;
            this.label5.Text = "Descripción";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(30, 314);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(324, 93);
            this.txtDescripcion.TabIndex = 109;
            // 
            // cmbConsulta
            // 
            this.cmbConsulta.FormattingEnabled = true;
            this.cmbConsulta.Items.AddRange(new object[] {
            "Consulta General",
            "Planes de entrenamiento en orden ascendente",
            "Planes con clientes inscritos en gimnasio Santa Fe",
            "Mostrar el plan con mas clientes inscritos"});
            this.cmbConsulta.Location = new System.Drawing.Point(700, 100);
            this.cmbConsulta.Name = "cmbConsulta";
            this.cmbConsulta.Size = new System.Drawing.Size(172, 21);
            this.cmbConsulta.TabIndex = 111;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label10.Location = new System.Drawing.Point(611, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 18);
            this.label10.TabIndex = 110;
            this.label10.Text = "Consulta";
            // 
            // btnVista
            // 
            this.btnVista.BackColor = System.Drawing.Color.Gold;
            this.btnVista.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnVista.FlatAppearance.BorderSize = 5;
            this.btnVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVista.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVista.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnVista.Location = new System.Drawing.Point(30, 422);
            this.btnVista.Name = "btnVista";
            this.btnVista.Size = new System.Drawing.Size(324, 37);
            this.btnVista.TabIndex = 112;
            this.btnVista.Text = "Activar Vista";
            this.btnVista.UseVisualStyleBackColor = false;
            this.btnVista.Click += new System.EventHandler(this.btnVista_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Gold;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnModificar.FlatAppearance.BorderSize = 5;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnModificar.Location = new System.Drawing.Point(650, 510);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(227, 37);
            this.btnModificar.TabIndex = 138;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.Gold;
            this.btnMostrar.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnMostrar.FlatAppearance.BorderSize = 5;
            this.btnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrar.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnMostrar.Location = new System.Drawing.Point(181, 510);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(178, 37);
            this.btnMostrar.TabIndex = 137;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(28, 510);
            this.txtId.Multiline = true;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(148, 38);
            this.txtId.TabIndex = 136;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Gold;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnEliminar.FlatAppearance.BorderSize = 5;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnEliminar.Location = new System.Drawing.Point(393, 510);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(229, 37);
            this.btnEliminar.TabIndex = 135;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(884, 559);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnVista);
            this.Controls.Add(this.cmbConsulta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbNombre);
            this.Controls.Add(this.txtClientesInscritos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.BtnInsertarDatos);
            this.Controls.Add(this.DG1);
            this.Controls.Add(this.BtnCrearTabla);
            this.Controls.Add(this.label2);
            this.Name = "Plan";
            this.Text = "Plan";
            this.Load += new System.EventHandler(this.Plan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtClientesInscritos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Button BtnInsertarDatos;
        private System.Windows.Forms.DataGridView DG1;
        private System.Windows.Forms.Button BtnCrearTabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNombre;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbConsulta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnVista;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnEliminar;
    }
}