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
    public partial class ActualizacionMaterial : Form
    {
        public ActualizacionMaterial()
        {
            InitializeComponent();
        }

        private void ActualizacionMaterial_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btPerifericos_Click(object sender, EventArgs e)
        {
            FormularioCambioPerifericos perifericos = new FormularioCambioPerifericos();
            perifericos.Show();
            this.Hide();
        }

        private void btPiezasOrdenador_Click(object sender, EventArgs e)
        {
            FormularioEquipoOrdenador ordenador = new FormularioEquipoOrdenador();
            ordenador.Show();
            this.Hide();

        }
    }
}
