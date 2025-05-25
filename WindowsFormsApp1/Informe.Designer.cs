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
            this.cbFiltradoAsignatura = new System.Windows.Forms.ComboBox();
            this.cbFiltradoAlumno = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btReinicio = new System.Windows.Forms.Button();
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
            this.lvInforme.Location = new System.Drawing.Point(60, 95);
            this.lvInforme.Name = "lvInforme";
            this.lvInforme.Size = new System.Drawing.Size(1565, 478);
            this.lvInforme.TabIndex = 0;
            this.lvInforme.UseCompatibleStateImageBehavior = false;
            this.lvInforme.View = System.Windows.Forms.View.Details;
            this.lvInforme.SelectedIndexChanged += new System.EventHandler(this.lvInforme_SelectedIndexChanged);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 40;
            // 
            // Horario
            // 
            this.Horario.Text = "Horario";
            this.Horario.Width = 108;
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha";
            this.Fecha.Width = 98;
            // 
            // Pabellon
            // 
            this.Pabellon.Text = "Pabellon";
            this.Pabellon.Width = 68;
            // 
            // Planta
            // 
            this.Planta.Text = "Planta";
            this.Planta.Width = 58;
            // 
            // Aula
            // 
            this.Aula.Text = "Aula";
            this.Aula.Width = 63;
            // 
            // Profesor
            // 
            this.Profesor.Text = "Profesor";
            this.Profesor.Width = 141;
            // 
            // Asignatura
            // 
            this.Asignatura.Text = "Asignatura";
            this.Asignatura.Width = 116;
            // 
            // Alumno
            // 
            this.Alumno.Text = "Alumno";
            this.Alumno.Width = 126;
            // 
            // Mesa
            // 
            this.Mesa.Text = "Mesa";
            this.Mesa.Width = 75;
            // 
            // Periferico
            // 
            this.Periferico.Text = "Periferico";
            this.Periferico.Width = 128;
            // 
            // Material
            // 
            this.Material.Text = "Material";
            this.Material.Width = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(497, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "REGISTRO DE AULAS/ALUMNOS/MATERIAL";
            // 
            // cbFiltradoAsignatura
            // 
            this.cbFiltradoAsignatura.FormattingEnabled = true;
            this.cbFiltradoAsignatura.Location = new System.Drawing.Point(376, 615);
            this.cbFiltradoAsignatura.Name = "cbFiltradoAsignatura";
            this.cbFiltradoAsignatura.Size = new System.Drawing.Size(229, 24);
            this.cbFiltradoAsignatura.TabIndex = 4;
            // 
            // cbFiltradoAlumno
            // 
            this.cbFiltradoAlumno.FormattingEnabled = true;
            this.cbFiltradoAlumno.Location = new System.Drawing.Point(693, 615);
            this.cbFiltradoAlumno.Name = "cbFiltradoAlumno";
            this.cbFiltradoAlumno.Size = new System.Drawing.Size(229, 24);
            this.cbFiltradoAlumno.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 587);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filtrado de Asignatura:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(723, 587);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filtrado de Alumno:";
            // 
            // btReinicio
            // 
            this.btReinicio.Location = new System.Drawing.Point(111, 597);
            this.btReinicio.Name = "btReinicio";
            this.btReinicio.Size = new System.Drawing.Size(119, 59);
            this.btReinicio.TabIndex = 8;
            this.btReinicio.Text = "Mostrar Todo";
            this.btReinicio.UseVisualStyleBackColor = true;
            this.btReinicio.Click += new System.EventHandler(this.btReinicio_Click);
            // 
            // Informe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1629, 756);
            this.Controls.Add(this.btReinicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFiltradoAlumno);
            this.Controls.Add(this.cbFiltradoAsignatura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvInforme);
            this.Name = "Informe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe";
            this.Load += new System.EventHandler(this.Informe_Load);
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
        private System.Windows.Forms.ComboBox cbFiltradoAsignatura;
        private System.Windows.Forms.ComboBox cbFiltradoAlumno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btReinicio;
    }
}