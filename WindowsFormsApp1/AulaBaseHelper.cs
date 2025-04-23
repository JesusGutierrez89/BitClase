using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace WindowsFormsApp1
{
    public class AulaBaseHelper
    {
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }

        public Dictionary<ComboBox, PictureBox> ComboBoxPictureBoxMap { get; set; }

        public void LlenarComboBox()
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
                SELECT 
                    al.nombre AS NombreAlumno,
                    al.apellidos AS ApellidosAlumno
                FROM 
                    Asignatura asig
                INNER JOIN Alumnos al 
                    ON asig.id_alumno = al.id
                WHERE asig.Nombre = @NombreAsignatura;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreAsignatura", NombreAsignatura);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                string nombreCompleto = $"{row["NombreAlumno"]} {row["ApellidosAlumno"]}";
                                foreach (var comboBox in ComboBoxPictureBoxMap.Keys)
                                {
                                    comboBox.Items.Add(nombreCompleto);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool EsDuplicado(string valorSeleccionado, ComboBox currentComboBox)
        {
            foreach (var comboBox in ComboBoxPictureBoxMap.Keys)
            {
                if (comboBox != currentComboBox &&
                    comboBox.SelectedItem != null &&
                    comboBox.SelectedItem.ToString() == valorSeleccionado)
                {
                    return true;
                }
            }
            return false;
        }

        public void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox && ComboBoxPictureBoxMap.ContainsKey(comboBox))
            {
                PictureBox pictureBox = ComboBoxPictureBoxMap[comboBox];

                if (comboBox.SelectedItem != null)
                {
                    if (EsDuplicado(comboBox.SelectedItem.ToString(), comboBox))
                    {
                        MessageBox.Show($"El valor '{comboBox.SelectedItem}' ya está seleccionado en otro ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBox.SelectedIndex = -1;
                        pictureBox.Image = Image.FromFile("C:\\Users\\Guty\\Documents\\TFS\\Imagenes\\pcCasa.jpg");
                    }
                    else
                    {
                        pictureBox.Image = Image.FromFile("C:\\Users\\Guty\\Documents\\TFS\\Imagenes\\pcInstituto.jpg");
                    }
                }
                else
                {
                    pictureBox.Image = null;
                }
            }
        }

        public void GuardarAula_Click()
        {
            // 1) Lógica actual: asignar imágenes si no hay selección
            foreach (var comboBox in ComboBoxPictureBoxMap.Keys)
            {
                if (comboBox.SelectedItem == null)
                {
                    ComboBoxPictureBoxMap[comboBox].Image =
                        Image.FromFile(@"C:\Users\Guty\Documents\TFS\Imagenes\pcCasa.jpg");
                }
            }

            MessageBox.Show(
                "Todos los alumnos han sido seleccionados correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // 2) Ahora recogemos los datos para el Excel
            // (aquí debes sustituir estos ejemplos por tu acceso real a la BD)

            // Ejemplo: datos del profesor y asignatura
            string profesorNombre = NombreProfesor;
            string profesorApellidos = ApellidosProfesor;
            string asignaturaNombre = NombreAsignatura;   

            // Ejemplo: lista de alumnos asistentes
            var listaAlumnos = new List<AsistenciaAlumno>();
            foreach (var alumno in RecuperarAlumnosAsistentes())  // tu método de BD
            {
                listaAlumnos.Add(new AsistenciaAlumno
                {
                    Nombre = alumno.Nombre,
                    Apellidos = alumno.Apellidos,
                    NumExpediente = alumno.NumExpediente,
                    NombreAula = alumno.NombreAula,
                    Planta = alumno.Planta,
                    Pabellon = alumno.Pabellon,
                    FilaMesa = alumno.FilaMesa,
                    ColumnaMesa = alumno.ColumnaMesa,
                    TipoMaterial = alumno.TipoMaterial,
                    DescripcionMaterial = alumno.DescripcionMaterial
                });
            }

            // Ejemplo: estado del aula (equipos por mesa)
            var estadoAula = new List<EquipoMesa>();
            foreach (var mesa in RecuperarEstadoAula())  // tu método de BD
            {
                estadoAula.Add(new EquipoMesa
                {
                    FilaMesa = mesa.FilaMesa,
                    ColumnaMesa = mesa.ColumnaMesa,
                    Equipo = mesa.Equipo // List<string>
                });
            }

            // 3) Llamamos al método que crea el Excel
            string rutaExcel = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Asistencia_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

            try
            {
                GuardarYExportarExcel(
                    profesorNombre,
                    profesorApellidos,
                    asignaturaNombre,
                    listaAlumnos,
                    estadoAula,
                    rutaExcel);

                MessageBox.Show(
                    $"Informe Excel generado correctamente:\n{rutaExcel}",
                    "Excel Creado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al generar el Excel:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
      
        }
        public List<AsistenciaAlumno> RecuperarAlumnosAsistentes()
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT 
            al.nombre AS Nombre,
            al.apellidos AS Apellidos,
            al.num_expediente AS NumExpediente,
            au.nombre AS NombreAula,
            au.planta AS Planta,
            au.pabellon AS Pabellon,
            me.fila AS FilaMesa,
            me.columna AS ColumnaMesa,
            mat.tipo AS TipoMaterial,
            mat.descripcion AS DescripcionMaterial
        FROM 
            Alumnos al
        INNER JOIN Asistencias asi ON asi.alumno_id = al.id
        INNER JOIN Aulas au ON asi.aula_id = au.id
        INNER JOIN Mesas me ON asi.mesa_id = me.id
        LEFT JOIN Material mat ON mat.mesa_id = me.id;";

            var listaAlumnos = new List<AsistenciaAlumno>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var alumno = new AsistenciaAlumno
                                {
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellidos = reader["Apellidos"].ToString(),
                                    NumExpediente = reader["NumExpediente"].ToString(),
                                    NombreAula = reader["NombreAula"].ToString(),
                                    Planta = reader["Planta"].ToString(),
                                    Pabellon = reader["Pabellon"].ToString(),
                                    FilaMesa = Convert.ToInt32(reader["FilaMesa"]),
                                    ColumnaMesa = Convert.ToInt32(reader["ColumnaMesa"]),
                                    TipoMaterial = reader["TipoMaterial"]?.ToString(),
                                    DescripcionMaterial = reader["DescripcionMaterial"]?.ToString()
                                };

                                listaAlumnos.Add(alumno);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recuperar los alumnos asistentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listaAlumnos;
        }
        public List<EquipoMesa> RecuperarEstadoAula()
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT 
            me.fila AS FilaMesa,
            me.columna AS ColumnaMesa,
            eq.nombre AS Equipo
        FROM 
            Mesas me
        LEFT JOIN Equipo_Ordenador eq ON eq.mesa_id = me.id;";

            var estadoAula = new List<EquipoMesa>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Buscar si ya existe una mesa con la misma fila y columna
                                var mesaExistente = estadoAula.Find(m =>
                                    m.FilaMesa == Convert.ToInt32(reader["FilaMesa"]) &&
                                    m.ColumnaMesa == Convert.ToInt32(reader["ColumnaMesa"]));

                                if (mesaExistente == null)
                                {
                                    // Crear una nueva mesa si no existe
                                    var nuevaMesa = new EquipoMesa
                                    {
                                        FilaMesa = Convert.ToInt32(reader["FilaMesa"]),
                                        ColumnaMesa = Convert.ToInt32(reader["ColumnaMesa"]),
                                    };

                                    if (reader["Equipo"] != DBNull.Value)
                                    {
                                        nuevaMesa.Equipo.Add(reader["Equipo"].ToString());
                                    }

                                    estadoAula.Add(nuevaMesa);
                                }
                                else
                                {
                                    // Agregar el equipo a la mesa existente
                                    if (reader["Equipo"] != DBNull.Value)
                                    {
                                        mesaExistente.Equipo.Add(reader["Equipo"].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recuperar el estado del aula: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return estadoAula;
        }

        public void GuardarYExportarExcel(string profesorNombre,
                    string profesorApellidos,
                    string asignaturaNombre,
                    List<AsistenciaAlumno>listaAlumnos,
                    List<EquipoMesa> estadoAula, 
                    string rutaExcel)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Estado del Aula");

            // Encabezados
            worksheet.Cell(1, 1).Value = "Fila";
            worksheet.Cell(1, 2).Value = "Columna";
            worksheet.Cell(1, 3).Value = "Equipos";

            int fila = 2;

            foreach (var mesa in estadoAula)
            {
                worksheet.Cell(fila, 1).Value = mesa.FilaMesa;
                worksheet.Cell(fila, 2).Value = mesa.ColumnaMesa;
                worksheet.Cell(fila, 3).Value = string.Join(", ", mesa.Equipo);
                fila++;
            }

            workbook.SaveAs(rutaExcel);
            MessageBox.Show($"Archivo Excel guardado en: {rutaExcel}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }

}
