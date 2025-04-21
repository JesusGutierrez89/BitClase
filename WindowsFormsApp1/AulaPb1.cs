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
    public partial class AulaPb1 : Form
    {
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }
        public AulaPb1()
        {
            InitializeComponent();

            this.ClientSize = new System.Drawing.Size(750, 580);
        }

        private void AulaPb1_Load(object sender, EventArgs e)
        {
            // Mostrar el nombre, apellidos del profesor y la asignatura en un TextBox o Label
            txNombreApellidoProfesor.Text = $"{NombreProfesor} {ApellidosProfesor}";
            txNombreAsignatura.Text = $"Asignatura: {NombreAsignatura}";

        }

        private void pcFila2columna4_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void pcFila2columna3_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void pcFila2columna2_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void pcFila2columna1_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void pcFila1columna4_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void pcFila1columna3_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void pcFila1columna2_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void pcFila1columna1_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void txNombreApellidoProfesor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
