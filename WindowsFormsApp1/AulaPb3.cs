using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AulaPb3 : AulaBase
    {
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }
        private Dictionary<ComboBox, PictureBox> comboBoxPictureBoxMap;
        public AulaPb3()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(750, 580);
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
            // Vincular el evento SelectedIndexChanged a cada ComboBox
            foreach (var comboBox in comboBoxPictureBoxMap.Keys)
            {
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            LlenarComboBox();
            // Mostrar el nombre, apellidos del profesor y la asignatura en un TextBox o Label
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

        }

        private void txNombreAsignatura_TextChanged(object sender, EventArgs e)
        {

        }

        private void btGuardarAula_Click(object sender, EventArgs e)
        {
            guardarAula_Click(sender, e);
        }
    }
}
