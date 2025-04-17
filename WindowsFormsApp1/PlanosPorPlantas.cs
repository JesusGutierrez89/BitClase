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
    public partial class PlanosPorPlantas : Form
    {

        public PlanosPorPlantas()
        {

            InitializeComponent();
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            this.ClientSize = new System.Drawing.Size(908, 573); // Tamaño fijo del formulario
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Evitar redimensionamiento
            this.MaximizeBox = false; // Desactivar el botón de maximizar
        }

        private void Plano1_Load(object sender, EventArgs e)
        {
            // Configurar la posición y tamaño del ComboBox
            comboBox1.Location = new Point(564, 39);
            comboBox1.Size = new Size(253, 24);

            // Configurar la posición del Label
            label1.Location = new Point(591, 9);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            // Cambiar el fondo del formulario y ocultar los botones según la opción seleccionada
            switch (comboBox1.SelectedItem.ToString())
            {
                case "PLANTA BAJA":
                    this.BackgroundImage = Image.FromFile("C:\\Users\\Guty\\Documents\\TFS\\planoPlantaBaja1.jpg"); // Cambia la ruta a la imagen correspondiente
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = false;
                    button6.Visible = false;
                    button7.Visible = false;
                    button8.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    button12.Visible = false;
                    break;

                case "PRIMERA PLANTA":
                    this.BackgroundImage = Image.FromFile("C:\\Users\\Guty\\Documents\\TFS\\Imagenes\\planoPlantaPrimera1.jpg"); // Cambia la ruta a la imagen correspondiente
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;
                    button8.Visible = true;
                    button9.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    button12.Visible = false;
                    break;

                case "SEGUNDA PLANTA":
                    this.BackgroundImage = Image.FromFile("C:\\Users\\Guty\\Documents\\TFS\\Imagenes\\planoSegundaPlanta.jpg"); // Cambia la ruta a la imagen correspondiente
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    button7.Visible = false;
                    button8.Visible = false;
                    button9.Visible = true;
                    button10.Visible = true;
                    button11.Visible = true;
                    button12.Visible = true;
                    break;

                default:
                    this.BackgroundImage = null; // Sin fondo si no se selecciona una opción válida
                    break;

            }

            // Mantener visibles el Label y el ComboBox
            label1.Visible = true;
            comboBox1.Visible = true;
        }
    }
}
