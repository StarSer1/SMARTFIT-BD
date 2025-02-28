namespace SMARTFIT
{
    partial class FormPrincipal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEliminarBD = new System.Windows.Forms.Button();
            this.btnCrearDB = new System.Windows.Forms.Button();
            this.btnGimnasio = new System.Windows.Forms.Button();
            this.panelFondo = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 87);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(143, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smart Fit";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.btnEliminarBD);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.btnCrearDB);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btnGimnasio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 478);
            this.panel2.TabIndex = 29;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gold;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 55);
            this.panel3.TabIndex = 6;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 56);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(151, 112);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // btnEliminarBD
            // 
            this.btnEliminarBD.BackColor = System.Drawing.Color.Black;
            this.btnEliminarBD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEliminarBD.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnEliminarBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarBD.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarBD.ForeColor = System.Drawing.Color.Gold;
            this.btnEliminarBD.Location = new System.Drawing.Point(0, 366);
            this.btnEliminarBD.Name = "btnEliminarBD";
            this.btnEliminarBD.Size = new System.Drawing.Size(151, 56);
            this.btnEliminarBD.TabIndex = 4;
            this.btnEliminarBD.Text = "Eliminar\r\nBD\r\n";
            this.btnEliminarBD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarBD.UseVisualStyleBackColor = false;
            this.btnEliminarBD.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCrearDB
            // 
            this.btnCrearDB.BackColor = System.Drawing.Color.Black;
            this.btnCrearDB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCrearDB.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnCrearDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearDB.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearDB.ForeColor = System.Drawing.Color.Gold;
            this.btnCrearDB.Location = new System.Drawing.Point(0, 422);
            this.btnCrearDB.Name = "btnCrearDB";
            this.btnCrearDB.Size = new System.Drawing.Size(151, 56);
            this.btnCrearDB.TabIndex = 2;
            this.btnCrearDB.Text = "Crear BD";
            this.btnCrearDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearDB.UseVisualStyleBackColor = false;
            this.btnCrearDB.Click += new System.EventHandler(this.btnCrearDB_Click);
            // 
            // btnGimnasio
            // 
            this.btnGimnasio.BackColor = System.Drawing.Color.Black;
            this.btnGimnasio.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnGimnasio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGimnasio.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGimnasio.ForeColor = System.Drawing.Color.Gold;
            this.btnGimnasio.Location = new System.Drawing.Point(0, 0);
            this.btnGimnasio.Name = "btnGimnasio";
            this.btnGimnasio.Size = new System.Drawing.Size(151, 56);
            this.btnGimnasio.TabIndex = 0;
            this.btnGimnasio.Text = "Gimnasio";
            this.btnGimnasio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGimnasio.UseVisualStyleBackColor = false;
            this.btnGimnasio.Click += new System.EventHandler(this.btnGimnasio_Click);
            // 
            // panelFondo
            // 
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Location = new System.Drawing.Point(151, 87);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(894, 478);
            this.panelFondo.TabIndex = 30;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SMARTFIT.Properties.Resources.banned;
            this.pictureBox4.Location = new System.Drawing.Point(26, 374);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 35);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SMARTFIT.Properties.Resources.add;
            this.pictureBox3.Location = new System.Drawing.Point(26, 431);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SMARTFIT.Properties.Resources.gym__1_;
            this.pictureBox2.Location = new System.Drawing.Point(26, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::SMARTFIT.Properties.Resources.power;
            this.btnSalir.Location = new System.Drawing.Point(972, 22);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(48, 48);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 1;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SMARTFIT.Properties.Resources.LogoSmart;
            this.pictureBox1.Location = new System.Drawing.Point(26, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 565);
            this.ControlBox = false;
            this.Controls.Add(this.panelFondo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGimnasio;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnCrearDB;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnEliminarBD;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelFondo;
    }
}