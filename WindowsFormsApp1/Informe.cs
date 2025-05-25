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
    public partial class Informe : Form
    {
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }



        public Informe()
        {
           
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(1250, 600);
            cbFiltradoAsignatura.SelectedIndexChanged += cbFiltradoAsignatura_SelectedIndexChanged;
            cbFiltradoAlumno.SelectedIndexChanged += cbFiltradoAlumno_SelectedIndexChanged;

        }

        private void Informe_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox con las asignaturas del profesor
            cbFiltradoAsignatura.Items.Clear();
            var listaAsignaturas = ObtenerAsignaturasProfesor(NombreProfesor, ApellidosProfesor);
            cbFiltradoAsignatura.Items.AddRange(listaAsignaturas.ToArray());
            if (cbFiltradoAsignatura.Items.Count > 0)
                cbFiltradoAsignatura.SelectedIndex = 0;

            // Obtener la asignatura seleccionada (después de llenar el ComboBox)
            string asignaturaSeleccionada = cbFiltradoAsignatura.SelectedItem?.ToString();

            // Llenar el ComboBox de alumnos filtrado por profesor y asignatura
            cbFiltradoAlumno.Items.Clear();
            var listaAlumnos = ObtenerAlumnosPorProfesorYAsignatura(NombreProfesor, ApellidosProfesor, asignaturaSeleccionada);
            cbFiltradoAlumno.Items.AddRange(listaAlumnos.ToArray());
            if (cbFiltradoAlumno.Items.Count > 0)
                cbFiltradoAlumno.SelectedIndex = 0;

            lvInforme.View = View.Details;
            lvInforme.FullRowSelect = true;
            lvInforme.Columns.Clear();

            // Define las columnas según la estructura de la tabla Registro
            lvInforme.Columns.Add("Horario");
            lvInforme.Columns.Add("Fecha");
            lvInforme.Columns.Add("Pabellon");
            lvInforme.Columns.Add("Planta");
            lvInforme.Columns.Add("Aula");
            lvInforme.Columns.Add("Profesor");
            lvInforme.Columns.Add("Asignatura");
            lvInforme.Columns.Add("Alumno");
            lvInforme.Columns.Add("Mesa");
            lvInforme.Columns.Add("Periferico");
            lvInforme.Columns.Add("Material");

            var dt = ObtenerRegistrosPorProfesor(NombreProfesor, ApellidosProfesor);

            foreach (DataRow row in dt.Rows)
            {
                var item = new ListViewItem(row["Horario"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy HH:mm"));
                item.SubItems.Add(row["Pabellon"].ToString());
                item.SubItems.Add(row["Planta"].ToString());
                item.SubItems.Add(row["Aula"].ToString());
                item.SubItems.Add(row["Profesor"].ToString());
                item.SubItems.Add(row["Asignatura"].ToString());
                item.SubItems.Add(row["Alumno"].ToString());
                item.SubItems.Add(row["Mesa"].ToString());
                item.SubItems.Add(row["Periferico"].ToString());
                item.SubItems.Add(row["Material"].ToString());
                lvInforme.Items.Add(item);
            }
            for (int i = 0; i < lvInforme.Columns.Count; i++)
            {
                lvInforme.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }
        
        private DataTable ObtenerRegistrosPorProfesor(string nombre, string apellidos)
        {
            var dt = new DataTable();
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT *
        FROM Registro
        WHERE Profesor = @Profesor";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Profesor", $"{nombre} {apellidos}");
                    connection.Open();
                    using (var adapter = new System.Data.SqlClient.SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

      
        private void cbFiltradoAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            string asignaturaSeleccionada = cbFiltradoAsignatura.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(asignaturaSeleccionada))
                return;

            // Filtra la consulta por profesor y asignatura
            var dt = ObtenerRegistrosPorProfesorYAsignatura(NombreProfesor, ApellidosProfesor, asignaturaSeleccionada);

            lvInforme.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListViewItem(row["Horario"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy HH:mm"));
                item.SubItems.Add(row["Pabellon"].ToString());
                item.SubItems.Add(row["Planta"].ToString());
                item.SubItems.Add(row["Aula"].ToString());
                item.SubItems.Add(row["Profesor"].ToString());
                item.SubItems.Add(row["Asignatura"].ToString());
                item.SubItems.Add(row["Alumno"].ToString());
                item.SubItems.Add(row["Mesa"].ToString());
                item.SubItems.Add(row["Periferico"].ToString());
                item.SubItems.Add(row["Material"].ToString());
                lvInforme.Items.Add(item);
            }
            for (int i = 0; i < lvInforme.Columns.Count; i++)
            {
                lvInforme.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void cbFiltradoAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string asignaturaSeleccionada = cbFiltradoAsignatura.SelectedItem?.ToString();
            string alumnoSeleccionado = cbFiltradoAlumno.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(asignaturaSeleccionada) || string.IsNullOrEmpty(alumnoSeleccionado))
                return;

            var dt = ObtenerRegistrosPorProfesorAsignaturaYAlumno(NombreProfesor, ApellidosProfesor, asignaturaSeleccionada, alumnoSeleccionado);

            lvInforme.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListViewItem(row["Horario"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy HH:mm"));
                item.SubItems.Add(row["Pabellon"].ToString());
                item.SubItems.Add(row["Planta"].ToString());
                item.SubItems.Add(row["Aula"].ToString());
                item.SubItems.Add(row["Profesor"].ToString());
                item.SubItems.Add(row["Asignatura"].ToString());
                item.SubItems.Add(row["Alumno"].ToString());
                item.SubItems.Add(row["Mesa"].ToString());
                item.SubItems.Add(row["Periferico"].ToString());
                item.SubItems.Add(row["Material"].ToString());
                lvInforme.Items.Add(item);
            }
            for (int i = 0; i < lvInforme.Columns.Count; i++)
            {
                lvInforme.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private DataTable ObtenerRegistrosPorProfesorYAsignatura(string nombre, string apellidos, string asignatura)
        {
            var dt = new DataTable();
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT *
        FROM Registro
        WHERE Profesor = @Profesor AND Asignatura = @Asignatura";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Profesor", $"{nombre} {apellidos}");
                    command.Parameters.AddWithValue("@Asignatura", asignatura);
                    connection.Open();
                    using (var adapter = new System.Data.SqlClient.SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        private DataTable ObtenerRegistrosPorProfesorAsignaturaYAlumno(string nombre, string apellidos, string asignatura, string alumno)
        {
            var dt = new DataTable();
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT *
        FROM Registro
        WHERE Profesor = @Profesor AND Asignatura = @Asignatura AND Alumno = @Alumno";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Profesor", $"{nombre} {apellidos}");
                    command.Parameters.AddWithValue("@Asignatura", asignatura);
                    command.Parameters.AddWithValue("@Alumno", alumno);
                    connection.Open();
                    using (var adapter = new System.Data.SqlClient.SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
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

        private List<string> ObtenerAlumnosPorProfesorYAsignatura(string nombreProfesor, string apellidosProfesor, string asignatura)
        {
            var alumnos = new List<string>();
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT DISTINCT al.nombre + ' ' + al.apellidos AS NombreCompleto
        FROM Alumnos al
        INNER JOIN Asignatura asig ON asig.id_alumno = al.id
        INNER JOIN Profesores prof ON asig.id_profesor = prof.id
        WHERE prof.nombre = @nombre AND prof.apellidos = @apellidos";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombreProfesor);
                    command.Parameters.AddWithValue("@apellidos", apellidosProfesor);
                    //command.Parameters.AddWithValue("@asignatura", asignatura);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            alumnos.Add(reader["NombreCompleto"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los alumnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return alumnos;
        }

        private void lvInforme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btReinicio_Click(object sender, EventArgs e)
        {
            // Limpia la selección de los ComboBox de filtro
            cbFiltradoAsignatura.SelectedIndex = -1;
            cbFiltradoAlumno.SelectedIndex = -1;

            // Limpia el ListView
            lvInforme.Items.Clear();

            // Obtiene todos los registros filtrados solo por el profesor
            var dt = ObtenerRegistrosPorProfesor(NombreProfesor, ApellidosProfesor);

            foreach (DataRow row in dt.Rows)
            {
                var item = new ListViewItem(row["Horario"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy HH:mm"));
                item.SubItems.Add(row["Pabellon"].ToString());
                item.SubItems.Add(row["Planta"].ToString());
                item.SubItems.Add(row["Aula"].ToString());
                item.SubItems.Add(row["Profesor"].ToString());
                item.SubItems.Add(row["Asignatura"].ToString());
                item.SubItems.Add(row["Alumno"].ToString());
                item.SubItems.Add(row["Mesa"].ToString());
                item.SubItems.Add(row["Periferico"].ToString());
                item.SubItems.Add(row["Material"].ToString());
                lvInforme.Items.Add(item);
            }

            // Ajusta el ancho de las columnas al contenido
            for (int i = 0; i < lvInforme.Columns.Count; i++)
            {
                lvInforme.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }
    }
}
