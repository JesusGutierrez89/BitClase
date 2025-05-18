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
            this.label1 = new System.Windows.Forms.Label();
            this.btPerifericos = new System.Windows.Forms.Button();
            this.btPiezasOrdenador = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CAMBIO COMPONENTES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btPerifericos
            // 
            this.btPerifericos.Location = new System.Drawing.Point(165, 148);
            this.btPerifericos.Name = "btPerifericos";
            this.btPerifericos.Size = new System.Drawing.Size(143, 70);
            this.btPerifericos.TabIndex = 1;
            this.btPerifericos.Text = "CAMBIO PERIFERICOS";
            this.btPerifericos.UseVisualStyleBackColor = true;
            this.btPerifericos.Click += new System.EventHandler(this.btPerifericos_Click);
            // 
            // btPiezasOrdenador
            // 
            this.btPiezasOrdenador.Location = new System.Drawing.Point(439, 148);
            this.btPiezasOrdenador.Name = "btPiezasOrdenador";
            this.btPiezasOrdenador.Size = new System.Drawing.Size(142, 70);
            this.btPiezasOrdenador.TabIndex = 2;
            this.btPiezasOrdenador.Text = "CAMBIO PIEZAS ORDENADOR";
            this.btPiezasOrdenador.UseVisualStyleBackColor = true;
            this.btPiezasOrdenador.Click += new System.EventHandler(this.btPiezasOrdenador_Click);
            // 
            // ActualizacionMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 370);
            this.Controls.Add(this.btPiezasOrdenador);
            this.Controls.Add(this.btPerifericos);
            this.Controls.Add(this.label1);
            this.Name = "ActualizacionMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreacionAula";
            this.Load += new System.EventHandler(this.ActualizacionMaterial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPerifericos;
        private System.Windows.Forms.Button btPiezasOrdenador;
    }
}