using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AulaPb3 : Form
    {
        private new Dictionary<ComboBox, PictureBox> comboBoxPictureBoxMap;
        private AulaBaseHelper helper;

        public new string NombreProfesor { get; set; }
        public new string ApellidosProfesor { get; set; }
        public new string NombreAsignatura { get; set; }

        public AulaPb3()
        {
            InitializeComponent();
            this.ClientSize = new Size(750, 580);
        }

        private void AulaPb3_Load(object sender, EventArgs e)
        {
            comboBoxPictureBoxMap = new Dictionary<ComboBox, PictureBox>
            {
                { comboBox1, ptbF2C1 },
                { comboBox2, ptbF1C2 },
                { comboBox3, ptbF2C3 },
                { comboBox4, ptbF3C2 },
                { comboBox5, ptbF3C4 },
                { comboBox6, ptbF4C1 },
                { comboBox7, ptbF4C3 },
                { comboBox8, ptbF4C4 }
            };

            // Inicializa el helper y pásale los datos necesarios
            helper = new AulaBaseHelper
            {
                NombreProfesor = NombreProfesor,
                ApellidosProfesor = ApellidosProfesor,
                NombreAsignatura = NombreAsignatura,
                ComboBoxPictureBoxMap = comboBoxPictureBoxMap
            };

            // Suscribir eventos
            foreach (var comboBox in comboBoxPictureBoxMap.Keys)
            {
                comboBox.SelectedIndexChanged += helper.ComboBox_SelectedIndexChanged;
            }

            helper.LlenarComboBox();

            // Mostrar los datos del profesor y la asignatura
            txNombreApellidoProfesor.Text = $"{NombreProfesor} {ApellidosProfesor}";
            txNombreAsignatura.Text = $"Asignatura: {NombreAsignatura}";
        }

        private void ptbF1C1_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ya no necesario si usas el helper
        }

        private void txNombreAsignatura_TextChanged(object sender, EventArgs e)
        {
            // opcional
        }

        private void btGuardarAula_Click(object sender, EventArgs e)
        {
            helper.GuardarAula_Click();
        }
    }
}
