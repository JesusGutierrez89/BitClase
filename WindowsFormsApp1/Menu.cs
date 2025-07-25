﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }
        public string Rol { get; set; }

        public Menu(string Rol, string NombreProfesor, string ApellidosProfesor, string NombreAsignatura)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(898, 639);
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.MaximizeBox = false;
            this.Rol = Rol;
            this.NombreProfesor = NombreProfesor;
            this.ApellidosProfesor = ApellidosProfesor;
            this.NombreAsignatura = NombreAsignatura;
            this.FormClosing += Presentacion_FormClosing;

        }

        private void btPlanos_Click(object sender, EventArgs e)
        {
            if (Rol.Equals("user"))
            {
                PlanosPorPlantas planos = new PlanosPorPlantas
                {
                    NombreProfesor = this.NombreProfesor,
                    ApellidosProfesor = this.ApellidosProfesor,
                    NombreAsignatura = this.NombreAsignatura,
                    Rol = this.Rol
                };
                planos.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show(
                                "No tienes permisos para acceder a esta sección. Solo puede un Usuario.",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error
                                );
            }
           
        }

        private void btCreacion_Click(object sender, EventArgs e)
        {
            if (Rol.Equals("admin")) {
                ActualizacionMaterial creacionAulas = new ActualizacionMaterial();
                creacionAulas.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show(
                                "No tienes permisos para acceder a esta sección. Solo puede el administrador.",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error
                                );
            }
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            btPlanos.Location = new Point(23, 273);
            btPlanos.Size = new Size(161, 116);

            btCreacion.Location = new Point(704, 273);
            btCreacion.Size = new Size(160, 95);

            pictureBox1.Location = new Point(344, 135);
            pictureBox1.Size = new Size(183, 200);

        }

        private void btInforme_Click(object sender, EventArgs e)
        {
            Informe informe = new Informe
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                Rol = this.Rol
            };
            
            informe.Show();
            this.Hide();

        }

        private void Presentacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
