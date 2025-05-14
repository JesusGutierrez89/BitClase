using System;
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

        public Menu()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(898, 639); // Tamaño fijo del formulario
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Evitar redimensionamiento
            this.MaximizeBox = false;
        }

        private void btPlanos_Click(object sender, EventArgs e)
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

        private void btCreacion_Click(object sender, EventArgs e)
        {
            if (Rol.Equals("admin")) {
                CreacionAula creacionAulas = new CreacionAula();
                creacionAulas.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show(
                                "No tienes permisos para acceder a esta sección.",
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
    }
}
