using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AulaPb1 : Form
    {
        private Dictionary<ComboBox, PictureBox> comboBoxPictureBoxMap;
        public List<MaterialAlumno> materialesSeleccionados;
        private AulaBaseHelper helper;
        private int idAula = 3;
        private string nombreMesa = "";
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }

        public AulaPb1()
        {
            InitializeComponent();
            this.ClientSize = new Size(750, 580);
        }

        private void AulaPb1_Load(object sender, EventArgs e)
        {
            comboBoxPictureBoxMap = new Dictionary<ComboBox, PictureBox>
            {
                { comboBox1, ptbF1C1 },
                { comboBox2, ptbF1C2 },
                { comboBox3, ptbF1C3 },
                { comboBox4, ptbF1C4 },
                { comboBox5, ptbF2C1 },
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

       
        private void txNombreApellidoProfesor_TextChanged(object sender, EventArgs e)
        {
        }

        private void btGuardarAula_Click(object sender, EventArgs e)
        {
            helper.GuardarAula_Click(idAula);
            foreach (var material in helper.materialesSeleccionados)
            {
                //MessageBox.Show(
                //    $"Mesa: {material.NombreM}\nMaterial: {material.TipoMaterial}\nDescripción: {material.DescripcionMaterial}",
                //    "Detalles del Material",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Information
                //);
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ptbF1C1_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptbF1C1";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF1C2_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptbF1C2";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF1C3_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptbF1C3";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF1C4_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptbF1C4";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF2C1_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptbF2C1";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF2C2_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptbF2C2";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF2C3_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptbF2C3";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF2C4_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptbF2C4";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }
    }
}
