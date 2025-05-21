namespace WindowsFormsApp1
{
    partial class ActualizacionMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizacionMaterial));
            this.label1 = new System.Windows.Forms.Label();
            this.btPerifericos = new System.Windows.Forms.Button();
            this.btPiezasOrdenador = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(196, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "CAMBIO COMPONENTES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btPerifericos
            // 
            this.btPerifericos.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btPerifericos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPerifericos.Location = new System.Drawing.Point(175, 185);
            this.btPerifericos.Name = "btPerifericos";
            this.btPerifericos.Size = new System.Drawing.Size(170, 58);
            this.btPerifericos.TabIndex = 1;
            this.btPerifericos.Text = "CAMBIO PERIFERICOS";
            this.btPerifericos.UseVisualStyleBackColor = false;
            this.btPerifericos.Click += new System.EventHandler(this.btPerifericos_Click);
            // 
            // btPiezasOrdenador
            // 
            this.btPiezasOrdenador.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btPiezasOrdenador.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPiezasOrdenador.Location = new System.Drawing.Point(418, 188);
            this.btPiezasOrdenador.Name = "btPiezasOrdenador";
            this.btPiezasOrdenador.Size = new System.Drawing.Size(154, 55);
            this.btPiezasOrdenador.TabIndex = 2;
            this.btPiezasOrdenador.Text = "CAMBIO PIEZAS ORDENADOR";
            this.btPiezasOrdenador.UseVisualStyleBackColor = false;
            this.btPiezasOrdenador.Click += new System.EventHandler(this.btPiezasOrdenador_Click);
            // 
            // ActualizacionMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(750, 370);
            this.Controls.Add(this.btPiezasOrdenador);
            this.Controls.Add(this.btPerifericos);
            this.Controls.Add(this.label1);
            this.Name = "ActualizacionMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CambioComponentes";
            this.Load += new System.EventHandler(this.ActualizacionMaterial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btPerifericos;
        private System.Windows.Forms.Button btPiezasOrdenador;
        private System.Windows.Forms.Label label1;
    }
}