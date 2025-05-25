namespace WindowsFormsApp1
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btPlanos = new System.Windows.Forms.Button();
            this.btCreacion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btInforme = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btPlanos
            // 
            this.btPlanos.BackColor = System.Drawing.Color.Transparent;
            this.btPlanos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btPlanos.BackgroundImage")));
            this.btPlanos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btPlanos.Location = new System.Drawing.Point(23, 273);
            this.btPlanos.Name = "btPlanos";
            this.btPlanos.Size = new System.Drawing.Size(161, 116);
            this.btPlanos.TabIndex = 0;
            this.btPlanos.UseVisualStyleBackColor = false;
            this.btPlanos.Click += new System.EventHandler(this.btPlanos_Click);
            // 
            // btCreacion
            // 
            this.btCreacion.BackColor = System.Drawing.Color.Transparent;
            this.btCreacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btCreacion.BackgroundImage")));
            this.btCreacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btCreacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCreacion.Location = new System.Drawing.Point(704, 273);
            this.btCreacion.Name = "btCreacion";
            this.btCreacion.Size = new System.Drawing.Size(160, 95);
            this.btCreacion.TabIndex = 1;
            this.btCreacion.UseVisualStyleBackColor = false;
            this.btCreacion.Click += new System.EventHandler(this.btCreacion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Location = new System.Drawing.Point(344, 126);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btInforme
            // 
            this.btInforme.BackColor = System.Drawing.Color.Transparent;
            this.btInforme.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btInforme.BackgroundImage")));
            this.btInforme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInforme.Location = new System.Drawing.Point(527, 610);
            this.btInforme.Name = "btInforme";
            this.btInforme.Size = new System.Drawing.Size(151, 128);
            this.btInforme.TabIndex = 3;
            this.btInforme.UseVisualStyleBackColor = false;
            this.btInforme.Click += new System.EventHandler(this.btInforme_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "PLANOS AULAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(943, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "ADMINISTRADOR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(548, 741);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "INFORMES";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1193, 785);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btInforme);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btCreacion);
            this.Controls.Add(this.btPlanos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Menu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btPlanos;
        private System.Windows.Forms.Button btCreacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btInforme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}