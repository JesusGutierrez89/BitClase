using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class EleccionAsignatura : Form
    {
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }
        public string Rol { get; set; }
        public EleccionAsignatura()
        {
            InitializeComponent();
            this.FormClosing += Presentacion_FormClosing;
            this.ClientSize = new System.Drawing.Size(550, 450);
        }

        private void EleccionAsignatura_Load(object sender, EventArgs e)
        {
            var listaAsignaturas = ObtenerAsignaturasProfesor(NombreProfesor, ApellidosProfesor);
            comboBox1.DataSource = listaAsignaturas;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private List<string> ObtenerAsignaturasProfesor(string nombre, string apellidos)
        {
            var asignaturas = new List<string>();
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT DISTINCT asig.Nombre
        FROM Asignatura asig
        INNER JOIN Profesores prof ON asig.id_profesor = prof.id
        WHERE prof.nombre = @nombre AND prof.apellidos = @apellidos";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellidos", apellidos);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            asignaturas.Add(reader["Nombre"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las asignaturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return asignaturas;
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {

            string asignaturaSeleccionada = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(asignaturaSeleccionada))
            {
                MessageBox.Show("Por favor, selecciona una asignatura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Asignatura Elegida");
            Menu menu = new Menu(Rol, NombreProfesor, ApellidosProfesor, asignaturaSeleccionada);
            menu.Show();
            this.Hide();

        }
        private void Presentacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}
