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
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }

        public PlanosPorPlantas()
        {

            InitializeComponent();
            btAulaPrimeraPlanta1.Visible = false;
            btAulaPrimeraPlanta2.Visible = false;
            btAulaPrimeraPlanta3.Visible = false;
            btAulaPrimeraPlanta4.Visible = false;
            btAulaSegundaPlanta1.Visible = false;
            btAulaSegundaPlanta2.Visible = false;
            btAulaSegundaPlanta4.Visible = false;
            btAulaSegundaPlanta3.Visible = false;
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
                    btPlantaBj2.Visible = true;
                    btAulaPlantaBj1.Visible = true;
                    btAulaPlantaBj3.Visible = true;
                    btAulaPlantaBj4.Visible = true;
                    btAulaPrimeraPlanta1.Visible = false;
                    btAulaPrimeraPlanta2.Visible = false;
                    btAulaPrimeraPlanta3.Visible = false;
                    btAulaPrimeraPlanta4.Visible = false;
                    btAulaSegundaPlanta1.Visible = false;
                    btAulaSegundaPlanta2.Visible = false;
                    btAulaSegundaPlanta4.Visible = false;
                    btAulaSegundaPlanta3.Visible = false;
                    break;

                case "PRIMERA PLANTA":
                    this.BackgroundImage = Image.FromFile("C:\\Users\\Guty\\Documents\\TFS\\Imagenes\\planoPlantaPrimera1.jpg"); // Cambia la ruta a la imagen correspondiente
                    btPlantaBj2.Visible = false;
                    btAulaPlantaBj1.Visible = false;
                    btAulaPlantaBj3.Visible = false;
                    btAulaPlantaBj4.Visible = false;
                    btAulaPrimeraPlanta1.Visible = true;
                    btAulaPrimeraPlanta2.Visible = true;
                    btAulaPrimeraPlanta3.Visible = true;
                    btAulaPrimeraPlanta4.Visible = true;
                    btAulaSegundaPlanta1.Visible = false;
                    btAulaSegundaPlanta2.Visible = false;
                    btAulaSegundaPlanta4.Visible = false;
                    btAulaSegundaPlanta3.Visible = false;
                    break;

                case "SEGUNDA PLANTA":
                    this.BackgroundImage = Image.FromFile("C:\\Users\\Guty\\Documents\\TFS\\Imagenes\\planoSegundaPlanta.jpg"); // Cambia la ruta a la imagen correspondiente
                    btPlantaBj2.Visible = false;
                    btAulaPlantaBj1.Visible = false;
                    btAulaPlantaBj3.Visible = false;
                    btAulaPlantaBj4.Visible = false;
                    btAulaPrimeraPlanta1.Visible = false;
                    btAulaPrimeraPlanta2.Visible = false;
                    btAulaPrimeraPlanta3.Visible = false;
                    btAulaPrimeraPlanta4.Visible = false;
                    btAulaSegundaPlanta1.Visible = true;
                    btAulaSegundaPlanta2.Visible = true;
                    btAulaSegundaPlanta4.Visible = true;
                    btAulaSegundaPlanta3.Visible = true;
                    break;

                default:
                    this.BackgroundImage = null; // Sin fondo si no se selecciona una opción válida
                    break;

            }

            // Mantener visibles el Label y el ComboBox
            label1.Visible = true;
            comboBox1.Visible = true;
        }

        private void btAulaPlantaBj1_Click(object sender, EventArgs e)
        {
            AulaPb1 aulaPb1 = new AulaPb1
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura
            };
            aulaPb1.Show();
            this.Hide();
        }

        private void btAulaSegundaPlanta3_Click(object sender, EventArgs e)
        {

        }

        private void btAulaSegundaPlanta1_Click(object sender, EventArgs e)
        {

        }

        private void btAulaPlantaBj3_Click(object sender, EventArgs e)
        {
            AulaPb3 aulaPb3 = new AulaPb3
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura
            };
            aulaPb3.Show();
            this.Hide();
        }

        private void btPlantaBj2_Click(object sender, EventArgs e)
        {
            AulaPb2 aulaPb2 = new AulaPb2
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura
            };
            aulaPb2.Show();
            this.Hide();
        }

        private void btAulaPlantaBj4_Click(object sender, EventArgs e)
        {
            AulaPb4 aulaPb4 = new AulaPb4
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura
            };
            aulaPb4.Show();
            this.Hide();
        }
      
        private void btAulaPrimeraPlanta1_Click(object sender, EventArgs e)
        {
            AulaPP1 aulaPP1 = new AulaPP1
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura
            };
            aulaPP1.Show();
            this.Hide();
        }
    }
}
