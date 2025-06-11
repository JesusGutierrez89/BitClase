using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GuardadoBD : Form
    {
        public string Horario { get; set; }
        public AulaBaseHelper Helper { get; set; }
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }
        public int IdAula { get; set; }
        public string Rol { get; set; }

        public Action GuardarAulaAccion { get; set; }

        public GuardadoBD()
        {
            InitializeComponent();
            this.FormClosing += Presentacion_FormClosing;
        }

        private void GuardadoBD_Load(object sender, EventArgs e)
        {
           
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
           
            Helper?.GuardarAula_Click(IdAula, Horario);
            
            Informe informe = new Informe
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                
            };
            informe.Show();
            this.Hide();

        }
        
        private void btNegativo_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Guardado solo en Base de Datos (sin Excel/JSON).");
            Informe informe = new Informe
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,

            };
            informe.Show();
            this.Hide();
        }
        private void Presentacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
