namespace WindowsFormsApp1
{
    partial class FormularioEquipoOrdenador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioEquipoOrdenador));
            this.label1 = new System.Windows.Forms.Label();
            this.cbAula = new System.Windows.Forms.ComboBox();
            this.cbMesa = new System.Windows.Forms.ComboBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.txNombre = new System.Windows.Forms.TextBox();
            this.txDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btActualizar = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "MODIFICACIÓN EQUIPOS DE ORDENADOR";
            // 
            // cbAula
            // 
            this.cbAula.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAula.FormattingEnabled = true;
            this.cbAula.Location = new System.Drawing.Point(283, 124);
            this.cbAula.Name = "cbAula";
            this.cbAula.Size = new System.Drawing.Size(281, 31);
            this.cbAula.TabIndex = 1;
            this.cbAula.SelectedIndexChanged += new System.EventHandler(this.cbAula_SelectedIndexChanged);
            // 
            // cbMesa
            // 
            this.cbMesa.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMesa.FormattingEnabled = true;
            this.cbMesa.Location = new System.Drawing.Point(283, 176);
            this.cbMesa.Name = "cbMesa";
            this.cbMesa.Size = new System.Drawing.Size(281, 31);
            this.cbMesa.TabIndex = 2;
            this.cbMesa.SelectedIndexChanged += new System.EventHandler(this.CbMesa_SelectedIndexChanged);
            // 
            // cbTipo
            // 
            this.cbTipo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(283, 222);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(281, 31);
            this.cbTipo.TabIndex = 3;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // txNombre
            // 
            this.txNombre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txNombre.Location = new System.Drawing.Point(283, 267);
            this.txNombre.Name = "txNombre";
            this.txNombre.Size = new System.Drawing.Size(281, 31);
            this.txNombre.TabIndex = 4;
            this.txNombre.TextChanged += new System.EventHandler(this.txNombre_TextChanged);
            // 
            // txDescripcion
            // 
            this.txDescripcion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txDescripcion.Location = new System.Drawing.Point(283, 316);
            this.txDescripcion.Name = "txDescripcion";
            this.txDescripcion.Size = new System.Drawing.Size(281, 31);
            this.txDescripcion.TabIndex = 5;
            this.txDescripcion.TextChanged += new System.EventHandler(this.txDescripcion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "AULAS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(147, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "MESAS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(156, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "TIPOS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(128, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "NOMBRE:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "CARACTERÍSTICAS:";
            // 
            // btActualizar
            // 
            this.btActualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btActualizar.BackgroundImage")));
            this.btActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btActualizar.Location = new System.Drawing.Point(361, 362);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(140, 67);
            this.btActualizar.TabIndex = 11;
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // btVolver
            // 
            this.btVolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btVolver.BackgroundImage")));
            this.btVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btVolver.Location = new System.Drawing.Point(145, 362);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(88, 68);
            this.btVolver.TabIndex = 12;
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // FormularioEquipoOrdenador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(677, 491);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txDescripcion);
            this.Controls.Add(this.txNombre);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.cbMesa);
            this.Controls.Add(this.cbAula);
            this.Controls.Add(this.label1);
            this.Name = "FormularioEquipoOrdenador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioEquipoOrdenador";
            this.Load += new System.EventHandler(this.FormularioEquipoOrdenador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAula;
        private System.Windows.Forms.ComboBox cbMesa;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.TextBox txNombre;
        private System.Windows.Forms.TextBox txDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Button btVolver;
    }
}