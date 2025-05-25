namespace WindowsFormsApp1
{
    partial class Informe
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
            this.lvInforme = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Horario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pabellon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Planta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Aula = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Profesor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Asignatura = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Alumno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mesa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Periferico = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Material = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvInforme
            // 
            this.lvInforme.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Horario,
            this.Fecha,
            this.Pabellon,
            this.Planta,
            this.Aula,
            this.Profesor,
            this.Asignatura,
            this.Alumno,
            this.Mesa,
            this.Periferico,
            this.Material});
            this.lvInforme.HideSelection = false;
            this.lvInforme.Location = new System.Drawing.Point(100, 96);
            this.lvInforme.Name = "lvInforme";
            this.lvInforme.Size = new System.Drawing.Size(876, 404);
            this.lvInforme.TabIndex = 0;
            this.lvInforme.UseCompatibleStateImageBehavior = false;
            this.lvInforme.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 40;
            // 
            // Horario
            // 
            this.Horario.Text = "Horario";
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha";
            // 
            // Pabellon
            // 
            this.Pabellon.Text = "Pabellon";
            this.Pabellon.Width = 76;
            // 
            // Planta
            // 
            this.Planta.Text = "Planta";
            // 
            // Aula
            // 
            this.Aula.Text = "Aula";
            // 
            // Profesor
            // 
            this.Profesor.Text = "Profesor";
            this.Profesor.Width = 71;
            // 
            // Asignatura
            // 
            this.Asignatura.Text = "Asignatura";
            this.Asignatura.Width = 86;
            // 
            // Alumno
            // 
            this.Alumno.Text = "Alumno";
            // 
            // Mesa
            // 
            this.Mesa.Text = "Mesa";
            // 
            // Periferico
            // 
            this.Periferico.Text = "Periferico";
            this.Periferico.Width = 91;
            // 
            // Material
            // 
            this.Material.Text = "Material";
            this.Material.Width = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(309, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "REGISTRO DE AULAS/ALUMNOS/MATERIAL";
            // 
            // Informe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1030, 631);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvInforme);
            this.Name = "Informe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvInforme;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Horario;
        private System.Windows.Forms.ColumnHeader Fecha;
        private System.Windows.Forms.ColumnHeader Pabellon;
        private System.Windows.Forms.ColumnHeader Planta;
        private System.Windows.Forms.ColumnHeader Aula;
        private System.Windows.Forms.ColumnHeader Profesor;
        private System.Windows.Forms.ColumnHeader Asignatura;
        private System.Windows.Forms.ColumnHeader Alumno;
        private System.Windows.Forms.ColumnHeader Mesa;
        private System.Windows.Forms.ColumnHeader Periferico;
        private System.Windows.Forms.ColumnHeader Material;
        private System.Windows.Forms.Label label1;
    }
}