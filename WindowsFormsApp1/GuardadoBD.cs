using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GuardadoBD : Form
    {
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
        }

        private void GuardadoBD_Load(object sender, EventArgs e)
        {
            // Opcional: mostrar datos del profesor/asignatura
            // labelProfesor.Text = $"{NombreProfesor} {ApellidosProfesor}";
            // labelAsignatura.Text = NombreAsignatura;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            // Ejecuta la acción si está definida
            GuardarAulaAccion?.Invoke();
            // Irse al formulario de los informes
            this.Close(); // Cierra el formulario
            Application.Exit();//ESTO QUITAR Y PONER EN EL FORMULARIO DE INFORMES

        }

        private void btNegativo_Click(object sender, EventArgs e)
        {
            // Lógica alternativa (por ejemplo: solo guardar en BD sin Excel/JSON)
            MessageBox.Show("Guardado solo en Base de Datos (sin Excel/JSON).");
            // Irse al formulario de los informes
            this.Close(); // Cierra el formulario
        }
    }
}
