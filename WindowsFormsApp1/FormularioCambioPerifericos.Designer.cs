namespace WindowsFormsApp1
{
    partial class FormularioCambioPerifericos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioCambioPerifericos));
            this.label1 = new System.Windows.Forms.Label();
            this.AULAS = new System.Windows.Forms.Label();
            this.mesas = new System.Windows.Forms.Label();
            this.perifericos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAulas = new System.Windows.Forms.ComboBox();
            this.cbMesas = new System.Windows.Forms.ComboBox();
            this.cbPerifericos = new System.Windows.Forms.ComboBox();
            this.txNombreComponente = new System.Windows.Forms.TextBox();
            this.btModificacion = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "MODIFICACIÓN PERIFÉRICOS";
            // 
            // AULAS
            // 
            this.AULAS.AutoSize = true;
            this.AULAS.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AULAS.Location = new System.Drawing.Point(181, 121);
            this.AULAS.Name = "AULAS";
            this.AULAS.Size = new System.Drawing.Size(84, 23);
            this.AULAS.TabIndex = 1;
            this.AULAS.Text = "AULAS:";
            // 
            // mesas
            // 
            this.mesas.AutoSize = true;
            this.mesas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesas.Location = new System.Drawing.Point(181, 169);
            this.mesas.Name = "mesas";
            this.mesas.Size = new System.Drawing.Size(86, 23);
            this.mesas.TabIndex = 2;
            this.mesas.Text = "MESAS:";
            // 
            // perifericos
            // 
            this.perifericos.AutoSize = true;
            this.perifericos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perifericos.Location = new System.Drawing.Point(114, 214);
            this.perifericos.Name = "perifericos";
            this.perifericos.Size = new System.Drawing.Size(151, 23);
            this.perifericos.TabIndex = 3;
            this.perifericos.Text = "PERIFÉRICOS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "NOMBRE COMPONENTE:";
            // 
            // cbAulas
            // 
            this.cbAulas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAulas.FormattingEnabled = true;
            this.cbAulas.Location = new System.Drawing.Point(298, 113);
            this.cbAulas.Name = "cbAulas";
            this.cbAulas.Size = new System.Drawing.Size(335, 31);
            this.cbAulas.TabIndex = 5;
            this.cbAulas.SelectedIndexChanged += new System.EventHandler(this.cbAulas_SelectedIndexChanged);
            // 
            // cbMesas
            // 
            this.cbMesas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMesas.FormattingEnabled = true;
            this.cbMesas.Location = new System.Drawing.Point(298, 161);
            this.cbMesas.Name = "cbMesas";
            this.cbMesas.Size = new System.Drawing.Size(335, 31);
            this.cbMesas.TabIndex = 6;
            this.cbMesas.SelectedIndexChanged += new System.EventHandler(this.cbMesas_SelectedIndexChanged);
            // 
            // cbPerifericos
            // 
            this.cbPerifericos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPerifericos.FormattingEnabled = true;
            this.cbPerifericos.Location = new System.Drawing.Point(298, 214);
            this.cbPerifericos.Name = "cbPerifericos";
            this.cbPerifericos.Size = new System.Drawing.Size(335, 31);
            this.cbPerifericos.TabIndex = 7;
            this.cbPerifericos.SelectedIndexChanged += new System.EventHandler(this.cbPerifericos_SelectedIndexChanged);
            // 
            // txNombreComponente
            // 
            this.txNombreComponente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txNombreComponente.Location = new System.Drawing.Point(298, 260);
            this.txNombreComponente.Name = "txNombreComponente";
            this.txNombreComponente.Size = new System.Drawing.Size(335, 31);
            this.txNombreComponente.TabIndex = 8;
            this.txNombreComponente.TextChanged += new System.EventHandler(this.txNombreComponente_TextChanged);
            // 
            // btModificacion
            // 
            this.btModificacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btModificacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btModificacion.BackgroundImage")));
            this.btModificacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btModificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btModificacion.ForeColor = System.Drawing.Color.Transparent;
            this.btModificacion.Location = new System.Drawing.Point(432, 336);
            this.btModificacion.Name = "btModificacion";
            this.btModificacion.Size = new System.Drawing.Size(90, 63);
            this.btModificacion.TabIndex = 9;
            this.btModificacion.UseVisualStyleBackColor = false;
            this.btModificacion.Click += new System.EventHandler(this.btModificacion_Click);
            // 
            // btVolver
            // 
            this.btVolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btVolver.BackgroundImage")));
            this.btVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btVolver.Location = new System.Drawing.Point(89, 336);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(88, 68);
            this.btVolver.TabIndex = 10;
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // FormularioCambioPerifericos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(703, 454);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btModificacion);
            this.Controls.Add(this.txNombreComponente);
            this.Controls.Add(this.cbPerifericos);
            this.Controls.Add(this.cbMesas);
            this.Controls.Add(this.cbAulas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.perifericos);
            this.Controls.Add(this.mesas);
            this.Controls.Add(this.AULAS);
            this.Controls.Add(this.label1);
            this.Name = "FormularioCambioPerifericos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioCambioPerifericos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AULAS;
        private System.Windows.Forms.Label mesas;
        private System.Windows.Forms.Label perifericos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAulas;
        private System.Windows.Forms.ComboBox cbMesas;
        private System.Windows.Forms.ComboBox cbPerifericos;
        private System.Windows.Forms.TextBox txNombreComponente;
        private System.Windows.Forms.Button btModificacion;
        private System.Windows.Forms.Button btVolver;
    }
}