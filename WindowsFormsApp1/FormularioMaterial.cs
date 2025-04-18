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
    public partial class FormularioMaterial : Form
    {
        public FormularioMaterial()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(550, 450);

            // Crear los paneles
            Panel panel1 = new Panel();
            Panel panel2 = new Panel();
            Panel panel3 = new Panel();

            // Configurar los paneles
            panel1.Location = new Point(50, 100);
            panel1.Size = new Size(550, 100); // Ajustar el tamaño del panel para que los RadioButton sean visibles

            panel2.Location = new Point(50, 200);
            panel2.Size = new Size(550, 100);

            panel3.Location = new Point(50, 300);
            panel3.Size = new Size(550, 100);

            // Agregar los RadioButton a los paneles y ajustar sus posiciones
            rbPantallaCasa.Location = new Point(10, 12); // Posición relativa dentro del panel
            rbPantallaAula.Location = new Point(400,12);
            panel1.Controls.Add(rbPantallaCasa);
            panel1.Controls.Add(rbPantallaAula);

            rbRatonCasa.Location = new Point(10, 12);
            rbRatonAula.Location = new Point(400, 12);
            panel2.Controls.Add(rbRatonCasa);
            panel2.Controls.Add(rbRatonAula);

            rbTecladoCasa.Location = new Point(10, 12);
            rbTecladoAula.Location = new Point(400, 12);
            panel3.Controls.Add(rbTecladoCasa);
            panel3.Controls.Add(rbTecladoAula);

            // Agregar los paneles al formulario
            this.Controls.Add(panel1);
            this.Controls.Add(panel2);
            this.Controls.Add(panel3);
        }

        private void FormularioMaterial_Load(object sender, EventArgs e)
        {
            // Activar los RadioButton por defecto
            rbPantallaAula.Checked = true;
            rbRatonAula.Checked = true;
            rbTecladoAula.Checked = true;
        }

        private void btGuardarMaterial_Click(object sender, EventArgs e)
        {
            //Aptualizar la base de datos segundo lo guardado, por defecto todo lo que se guarda es aula
        }
    }
}