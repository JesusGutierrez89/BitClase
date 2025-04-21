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
        private Dictionary<ComboBox, PictureBox> comboBoxPictureBoxMap;
        private AulaBaseHelper helper;

        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }

        public AulaPb4()
        {
            InitializeComponent();
            this.ClientSize = new Size(750, 580);
        }

        private void AulaPb4_Load(object sender, EventArgs e)
        {
            comboBoxPictureBoxMap = new Dictionary<ComboBox, PictureBox>
            {
                { comboBox1, ptbF1C1 },
                { comboBox2, ptbF1C2 },
                { comboBox3, ptbF1C3 },
                { comboBox4, ptbF1C4 },
                { comboBox5, ptbF1C1 },
                { comboBox6, ptbF2C2 },
                { comboBox7, ptbF2C3 },
                { comboBox8, ptbF2C4 }
            };

            helper = new AulaBaseHelper
            {
                NombreProfesor = NombreProfesor,
                ApellidosProfesor = ApellidosProfesor,
                NombreAsignatura = NombreAsignatura,
                ComboBoxPictureBoxMap = comboBoxPictureBoxMap
            };

            foreach (var comboBox in comboBoxPictureBoxMap.Keys)
            {
                comboBox.SelectedIndexChanged += helper.ComboBox_SelectedIndexChanged;
            }

            helper.LlenarComboBox();

            txNombreApellidoProfesor.Text = $"{NombreProfesor} {ApellidosProfesor}";
            txNombreAsignatura.Text = $"Asignatura: {NombreAsignatura}";
        }

        // Método para PictureBox con código repetido
        private void Pcfila1Columna1_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void Pcfila1Columna2_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void Pcfila1Columna3_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void Pcfila1Columna4_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void Pcfila2Columna1_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void Pcfila2Columna2_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void Pcfila2Columna3_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void Pcfila2Columna4_Click(object sender, EventArgs e) => AbrirFormularioMaterial();

        // Método para abrir el formulario de material
        private void AbrirFormularioMaterial()
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void btGuardarAula_Click(object sender, EventArgs e)
        {
            helper.GuardarAula_Click();
        }
    }
}
