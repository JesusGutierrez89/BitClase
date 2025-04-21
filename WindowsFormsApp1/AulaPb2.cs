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
    public partial class AulaPb2 : Form
    {
        private Dictionary<ComboBox, PictureBox> comboBoxPictureBoxMap;
        private AulaBaseHelper helper;

        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }

        public AulaPb2()
        {
            InitializeComponent();
            this.ClientSize = new Size(750, 580);
        }

        private void AulaPb2_Load(object sender, EventArgs e)
        {
            comboBoxPictureBoxMap = new Dictionary<ComboBox, PictureBox>
            {
                { comboBox1, ptbF1C1 },
                { comboBox2, ptbF1C2 },
                { comboBox3, ptbF1C3 },
                { comboBox4, ptbF2C1 },
                { comboBox5, ptbF3C2 },
                { comboBox6, ptbF3C3 },
                { comboBox7, ptbF3C4 },
                { comboBox8, ptbF3C5 }
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

        // Métodos para PictureBox con código repetido
        private void PcFila1Columna1_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void PcFila1Columna2_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void PcFila1Columna3_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void PcFila2Columna1_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void PcFila3Columna2_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void PcFila3Columna3_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void PcFila3Columna4_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void PcFila3Columna5_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void PcFila2Columna6_Click(object sender, EventArgs e) => AbrirFormularioMaterial();
        private void PcFila3Columna6_Click(object sender, EventArgs e) => AbrirFormularioMaterial();

        private void txNombreAsignatura_TextChanged(object sender, EventArgs e)
        {
        }

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
