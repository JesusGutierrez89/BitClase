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
    public partial class AulaPb4 : Form
    {
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }
        public AulaPb4()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(750, 580);
        }

        private void AulaPb4_Load(object sender, EventArgs e)
        {
            // Mostrar el nombre, apellidos del profesor y la asignatura en un TextBox o Label
            txNombreApellidoProfesor.Text = $"{NombreProfesor} {ApellidosProfesor}";
            txNombreAsignatura.Text = $"Asignatura: {NombreAsignatura}";

        }

        private void Pcfila1Columna1_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void Pcfila1Columna2_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void Pcfila1Columna3_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void Pcfila1Columna4_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void Pcfila2Columna1_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void Pcfila2Columna2_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void Pcfila2Columna3_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void Pcfila2Columna4_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }
    }
}
