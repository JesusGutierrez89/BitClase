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
    public partial class Informe : Form
    {
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }

        public string Rol { get; set; }



        public Informe()
        {
           
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(1250, 650);
            cbFiltradoAsignatura.SelectedIndexChanged += cbFiltradoAsignatura_SelectedIndexChanged;
            cbFiltradoAlumno.SelectedIndexChanged += cbFiltradoAlumno_SelectedIndexChanged;
            cbFiltradoAula.SelectedIndexChanged += cbFiltradoAula_SelectedIndexChanged;


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

            // Llenar el ComboBox de aulas filtrado por profesor
            cbFiltradoAula.Items.Clear();
            var listaAulas = ObtenerAulasPorProfesor(NombreProfesor, ApellidosProfesor);
            cbFiltradoAula.Items.AddRange(listaAulas.ToArray());
            if (cbFiltradoAula.Items.Count > 0)
                cbFiltradoAula.SelectedIndex = 0;

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

        private List<string> ObtenerAulasPorProfesor(string nombreProfesor, string apellidosProfesor)
        {
            var aulas = new List<string>();
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT DISTINCT Pabellon, Planta, Aula
        FROM Registro
        WHERE Profesor = @Profesor";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Profesor", $"{nombreProfesor} {apellidosProfesor}");
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Puedes mostrarlo como "Pabellon - Planta - Aula"
                            string pabellon = reader["Pabellon"].ToString();
                            string planta = reader["Planta"].ToString();
                            string aula = reader["Aula"].ToString();
                            aulas.Add($"{pabellon} - {planta} - {aula}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las aulas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return aulas;
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

        private void cbFiltradoAula_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aulaSeleccionada = cbFiltradoAula.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(aulaSeleccionada))
                return;

            // Separar los datos
            var partes = aulaSeleccionada.Split(new[] { " - " }, StringSplitOptions.None);
            if (partes.Length != 3)
                return;

            string pabellon = partes[0];
            string planta = partes[1];
            string aula = partes[2];

            var dt = ObtenerRegistrosPorProfesorYAula(NombreProfesor, ApellidosProfesor, pabellon, planta, aula);

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
        private DataTable ObtenerRegistrosPorProfesorYAula(string nombre, string apellidos, string pabellon, string planta, string aula)
        {
            var dt = new DataTable();
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT *
        FROM Registro
        WHERE Profesor = @Profesor AND Pabellon = @Pabellon AND Planta = @Planta AND Aula = @Aula";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Profesor", $"{nombre} {apellidos}");
                    command.Parameters.AddWithValue("@Pabellon", pabellon);
                    command.Parameters.AddWithValue("@Planta", planta);
                    command.Parameters.AddWithValue("@Aula", aula);
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

        private void btSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbVolver_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(Rol, NombreProfesor, ApellidosProfesor, null); 
            menu.Show();
            this.Close();
        }


        private void btGuardarInfor_Click(object sender, EventArgs e)
        {
            if (lvInforme.Items.Count == 0)
            {
                MessageBox.Show("No hay datos para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo CSV (*.csv)|*.csv";
                sfd.Title = "Guardar informe como CSV";
                sfd.FileName = $"Informe_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();

                        
                        for (int i = 0; i < lvInforme.Columns.Count; i++)
                        {
                            sb.Append(lvInforme.Columns[i].Text);
                            if (i < lvInforme.Columns.Count - 1)
                                sb.Append(";");
                        }
                        sb.AppendLine();

                        
                        foreach (ListViewItem item in lvInforme.Items)
                        {
                            for (int i = 0; i < item.SubItems.Count; i++)
                            {
                                
                                string text = item.SubItems[i].Text.Replace("\"", "\"\"");
                                sb.Append($"\"{text}\"");
                                if (i < item.SubItems.Count - 1)
                                    sb.Append(";");
                            }
                            sb.AppendLine();
                        }

                        System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Informe guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
