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

        // Delegado para la acción de guardado
        public Action GuardarAulaAccion { get; set; }

        public GuardadoBD()
        {
            InitializeComponent();
            this.FormClosing += Presentacion_FormClosing;
        }

        private void GuardadoBD_Load(object sender, EventArgs e)
        {
            // Opcional: mostrar datos del profesor/asignatura
            // labelProfesor.Text = $"{NombreProfesor} {ApellidosProfesor}";
            // labelAsignatura.Text = NombreAsignatura;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            // Llama a GuardarAula_Click si lo necesitas (por ejemplo, para refrescar imágenes o lógica extra)
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
            // Lógica alternativa (por ejemplo: solo guardar en BD sin Excel/JSON)
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
