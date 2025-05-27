using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public string Rol { get; set; }

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
            this.FormClosing += Presentacion_FormClosing;
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
            string plantaBaja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", "Imagenes", "planoPlantaBaja1.jpg");
            string plantaPrimeraPlanta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", "Imagenes", "planoPlantaPrimera1.jpg");
            string plantaSegundaPlanta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", "Imagenes", "planoSegundaPlanta.jpg");

            // Cambiar el fondo del formulario y ocultar los botones según la opción seleccionada
            switch (comboBox1.SelectedItem.ToString())
            {
                case "PLANTA BAJA":
                    this.BackgroundImage = Image.FromFile(plantaBaja); 
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
                    this.BackgroundImage = Image.FromFile(plantaPrimeraPlanta); 
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
                    this.BackgroundImage = Image.FromFile(plantaSegundaPlanta); 
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
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
            };
            aulaPb1.Show();
            this.Hide();
        }

        private void btAulaSegundaPlanta3_Click(object sender, EventArgs e)
        {
            AulaSP3 aulaSP3 = new AulaSP3
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
            };
            aulaSP3.Show();
            this.Hide();
        }

        private void btAulaSegundaPlanta1_Click(object sender, EventArgs e)
        {
            AulaSP1 aulaSP1 = new AulaSP1
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
            };
            aulaSP1.Show();
            this.Hide();
        }

        private void btAulaPlantaBj3_Click(object sender, EventArgs e)
        {
            AulaPb3 aulaPb3 = new AulaPb3
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
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
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
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
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
            };
            aulaPP1.Show();
            this.Hide();
        }

        private void btAulaPrimeraPlanta2_Click(object sender, EventArgs e)
        {
            AulaPP2 aulaPP2 = new AulaPP2
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
            };
            aulaPP2.Show();
            this.Hide();
        }

        private void btAulaPrimeraPlanta3_Click(object sender, EventArgs e)
        {
            AulaPP3 aulaPP3 = new AulaPP3
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
            };
            aulaPP3.Show();
            this.Hide();
        }

        private void btAulaPrimeraPlanta4_Click(object sender, EventArgs e)
        {
            AulaPP4 aulaPP4 = new AulaPP4
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
            };
            aulaPP4.Show();
            this.Hide();
        }

        private void btAulaSegundaPlanta2_Click(object sender, EventArgs e)
        {
            AulaSP2 aulaSP2 = new AulaSP2
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
            };
            aulaSP2.Show();
            this.Hide();
        }

        private void btAulaSegundaPlanta4_Click(object sender, EventArgs e)
        {
            AulaSP4 aulaSP4 = new AulaSP4
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura,
                //Rol = this.Rol
            };
            aulaSP4.Show();
            this.Hide();
        }

        private void Presentacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
