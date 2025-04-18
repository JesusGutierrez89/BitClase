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
    public partial class AulaPb3 : Form
    {
        public AulaPb3()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(750, 580);
        }

        private void AulaPb3_Load(object sender, EventArgs e)
        {

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
    }
}
