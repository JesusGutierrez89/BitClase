using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AulaPP1 : Form
    {
        private Dictionary<ComboBox, PictureBox> comboBoxPictureBoxMap;
        private AulaBaseHelper helper;
        private int idAula = 9;
        private string nombreMesa = "";
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }

        public AulaPP1()
        {
            InitializeComponent();
            this.ClientSize = new Size(830, 580);
        }

        private void AulaPP1_Load(object sender, EventArgs e)
        {
            // 1. Configura el diccionario con tus ComboBox y PictureBox (vacío por defecto)
            comboBoxPictureBoxMap = new Dictionary<ComboBox, PictureBox>
            {
                 { comboBox1, ptbF1C1 },
                 { comboBox2, ptbF1C2 },
                 { comboBox3, ptbF2C1 },
                 { comboBox4, ptbF2C2 },
                 { comboBox5, ptbF3C1 },
                 { comboBox6, ptbF3C2 },
                 { comboBox7, ptbF4C1 },
                 { comboBox8, ptbF4C2 }
            };

            // 2. Inicializa el helper con los datos y el map
            helper = new AulaBaseHelper
            {
                NombreProfesor = NombreProfesor,
                ApellidosProfesor = ApellidosProfesor,
                NombreAsignatura = NombreAsignatura,
                ComboBoxPictureBoxMap = comboBoxPictureBoxMap
            };

            // 3. Suscribe eventos de SelectedIndexChanged si hay comboBoxes
            foreach (var comboBox in comboBoxPictureBoxMap.Keys)
            {
                comboBox.SelectedIndexChanged += helper.ComboBox_SelectedIndexChanged;
            }

            // 4. Rellena los combos (no hará nada si map está vacío)
            helper.LlenarComboBox();

            // 5. Muestra los datos del profesor y asignatura
            txNombreApellidoProfesor.Text = $"{NombreProfesor} {ApellidosProfesor}";
            txNombreAsignatura.Text = $"Asignatura: {NombreAsignatura}";
        }

        private void txNombreApellidoProfesor_TextChanged(object sender, EventArgs e)
        {
            // opcional: validaciones al cambiar texto
        }

        private void txNombreAsignatura_TextChanged(object sender, EventArgs e)
        {
            // opcional: validaciones al cambiar texto
        }

        private void btGuardarAula_Click(object sender, EventArgs e)
        {
            // Llama al helper para ejecutar la lógica de guardado
            helper.GuardarAula_Click(idAula);
        }

        private void ptbF1C2_Click(object sender, EventArgs e)
        {
            AbrirFormularioMaterial();
        }
        private void AbrirFormularioMaterial()
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.Show();
            this.Hide();
        }

        private void ptbF1C1_Click(object sender, EventArgs e)
        {
            AbrirFormularioMaterial();
        }

        private void ptbF2C1_Click(object sender, EventArgs e)
        {
            AbrirFormularioMaterial();
        }

        private void ptbF2C2_Click(object sender, EventArgs e)
        {
            AbrirFormularioMaterial();
        }

        private void ptbF3C1_Click(object sender, EventArgs e)
        {
            AbrirFormularioMaterial();
        }

        private void ptbF3C2_Click(object sender, EventArgs e)
        {
            AbrirFormularioMaterial();
        }

        private void ptbF4C1_Click(object sender, EventArgs e)
        {
            AbrirFormularioMaterial();
        }

        private void ptbF4C2_Click(object sender, EventArgs e)
        {
            AbrirFormularioMaterial();
        }
    }
}
