using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace WindowsFormsApp1
{
    public class AulaBaseHelper
    {
        string[] numExpediente;
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }

        public Dictionary<ComboBox, PictureBox> ComboBoxPictureBoxMap { get; set; }
        public List<MaterialAlumno> materialesSeleccionados { get; set; }

        public AulaBaseHelper()
        {
            materialesSeleccionados = new List<MaterialAlumno>();
            
        }
        public void LlenarComboBox()
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
                SELECT 
                    al.nombre AS NombreAlumno,
                    al.nre AS NumExpediente,
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
                                numExpediente = row["NumExpediente"].ToString().Split('-');
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
                // Obtener el PictureBox correspondiente al ComboBox
                PictureBox pictureBox = ComboBoxPictureBoxMap[comboBox];

                if (comboBox.SelectedItem != null)
                {
                    // Guardar el nombre del alumno en la propiedad Tag del PictureBox
                    string nombreAlumno = comboBox.SelectedItem.ToString();
                    pictureBox.Tag = nombreAlumno; // Asociar el nombre del alumno al PictureBox
                    MessageBox.Show($"El PictureBox {pictureBox.Name} está relacionado con el alumno: {nombreAlumno}");

                    // Verificar si el valor seleccionado ya está en otro ComboBox
                    if (EsDuplicado(nombreAlumno, comboBox))
                    {
                        MessageBox.Show($"El valor '{nombreAlumno}' ya está seleccionado en otro ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBox.SelectedIndex = -1;
                        pictureBox.Image = Image.FromFile("C:\\Users\\Guty\\Documents\\TFS\\Imagenes\\pcCasa.jpg");
                    }
                    else
                    {
                        // Cambiar la imagen del PictureBox según la selección
                        pictureBox.Image = Image.FromFile("C:\\Users\\Guty\\Documents\\TFS\\Imagenes\\pcInstituto.jpg");
                    }
                }
                else
                {
                    // Limpiar la imagen y la propiedad Tag si no hay selección
                    pictureBox.Image = null;
                    pictureBox.Tag = null;
                }
            }
        }

        public void GuardarAula_Click(int idAula)
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
            // 2) Mostrar información del alumno seleccionado
            var listaAlumnos = new List<AsistenciaAlumno>();
            foreach (var comboBox in ComboBoxPictureBoxMap.Keys)
            {
                if (comboBox.SelectedItem != null)
                {
                    string nombreCompleto = comboBox.SelectedItem.ToString();

                    // Recuperar información del alumno
                    var alumno = RecuperarInformacionAlumno(nombreCompleto, idAula);

                    if (alumno != null)
                    {
                        listaAlumnos.Add(alumno);
                    }
                }
            }
            // Validar si hay alumnos seleccionados
            if (listaAlumnos.Count == 0)
            {
                MessageBox.Show(
                    "No hay alumnos seleccionados para guardar.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Mostrar información de los alumnos seleccionados
            foreach (var alumno in listaAlumnos)
            {
                MessageBox.Show(
                    $"Alumno: {alumno.Nombre} {alumno.Apellidos}\n" +
                    $"Aula: {alumno.NombreAula}\n" +
                    $"Mesa: Fila {alumno.FilaMesa}, Columna {alumno.ColumnaMesa}",
                    "Información del Alumno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            MessageBox.Show(
                "Todos los alumnos seleccionados han sido procesados correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            MessageBox.Show(
                "Todos los alumnos han sido seleccionados correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // 3) Ahora recogemos los datos para el Excel
            // (aquí debes sustituir estos ejemplos por tu acceso real a la BD)

            // Ejemplo: datos del profesor y asignatura
            string profesorNombre = NombreProfesor;
            string profesorApellidos = ApellidosProfesor;
            string asignaturaNombre = NombreAsignatura;

            // Ejemplo: lista de alumnos asistentes
            foreach (var alumno in RecuperarAlumnosAsistentes())
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

                });
            }

            // Ejemplo: estado del aula (equipos por mesa)
            var estadoAula = new List<EquipoMesa>();
            foreach (var mesa in RecuperarEstadoAula())
            {
                estadoAula.Add(new EquipoMesa
                {
                    FilaMesa = mesa.FilaMesa,
                    ColumnaMesa = mesa.ColumnaMesa,
                    Equipo = mesa.Equipo // List<string>
                });
            }

            var materialesAlumnosBd = new List<MaterialAlumno>();
            foreach (var material in RecuperarMaterialesAlumnos())
            {
                materialesAlumnosBd.Add(new MaterialAlumno
                {
                    TipoMaterial = material.TipoMaterial,
                    DescripcionMaterial = material.DescripcionMaterial
                });
            }

            // 4) Llamamos al método que crea el Excel
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
            al.nre AS NumExpediente,
            au.nombre AS NombreAula,
            au.planta AS Planta,
            au.pabellon AS Pabellon,
            me.fila AS FilaMesa,
            me.columna AS ColumnaMesa
        FROM 
            Asistencias asi
        INNER JOIN Alumnos al ON asi.alumno_id = al.id
        INNER JOIN Aulas au ON asi.aula_id = au.id
        INNER JOIN Mesas me ON asi.mesa_id = me.id
        WHERE CAST(asi.fecha AS DATE) = CAST(GETDATE() AS DATE);";

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
        public List<MaterialAlumno> RecuperarMaterialesAlumnos()
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT 
            al.nombre AS NombreAlumno,
            al.apellidos AS ApellidosAlumno,
            mat.tipo AS TipoMaterial,
            mat.descripcion AS DescripcionMaterial
        FROM 
            Alumnos al
        INNER JOIN Asistencias asi ON asi.alumno_id = al.id
        INNER JOIN Mesas me ON asi.mesa_id = me.id
        LEFT JOIN Material mat ON mat.mesa_id = me.id;";

            var materialesAlumnos = new List<MaterialAlumno>();

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
                                var materialAlumno = new MaterialAlumno
                                {
                                    TipoMaterial = reader["TipoMaterial"]?.ToString(),
                                    DescripcionMaterial = reader["DescripcionMaterial"]?.ToString()
                                };

                                materialesAlumnos.Add(materialAlumno);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recuperar los materiales de los alumnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return materialesAlumnos;
        }

        public void GuardarYExportarExcel(
     string profesorNombre,
     string profesorApellidos,
     string asignaturaNombre,
     List<AsistenciaAlumno> listaAlumnos,
     List<EquipoMesa> estadoAula,
     string rutaExcel)
        {
            try
            {
                var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("Estado del Aula");
                int row = 1;

                // ------------------------------------
                // 1) Cabecera general con estilo
                // ------------------------------------
                var headerRange = ws.Range(row, 1, row, 5);
                headerRange.Style.Font.SetBold()
                                      .Font.FontSize = 12;
                headerRange.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                ws.Cell(row, 1).Value = "Nom. Profesor:";
                ws.Cell(row, 2).Value = profesorNombre;
                ws.Cell(row, 4).Value = "Ap. profesor:";
                ws.Cell(row, 5).Value = profesorApellidos;
                row++;

                var subHeaderRange = ws.Range(row, 1, row, 5);
                subHeaderRange.Style.Font.SetBold()
                                          .Font.FontSize = 12;
                subHeaderRange.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                subHeaderRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                ws.Cell(row, 1).Value = "N. asignatura:";
                ws.Cell(row, 2).Value = asignaturaNombre;
                ws.Cell(row, 4).Value = "FECHA (Hoy):";
                ws.Cell(row, 5).Value = DateTime.Today.ToString("dd/MM/yyyy");
                row += 2;

                // ------------------------------------
                // 2) Lista de alumnos seleccionados
                // ------------------------------------
                ws.Cell(row, 1).Value = "AL. SELEC.";
                ws.Cell(row, 1).Style.Font.SetBold()
                                           .Font.FontColor = XLColor.DarkOrange;
                ws.Cell(row, 1).Style.Font.SetBold().Font.FontSize = 14;
                row++;

                // Sub-encabezados alumnos
                var alumnosHeader = ws.Range(row, 1, row, 7); // Cambiar a 7 columnas
                alumnosHeader.Style.Font.SetBold()
                                         .Fill.BackgroundColor = XLColor.RedRyb;
                alumnosHeader.Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                alumnosHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                ws.Cell(row, 1).Value = "Nombre Al.";
                ws.Cell(row, 2).Value = "Apellidos Al.";
                ws.Cell(row, 3).Value = "Nre";
                ws.Cell(row, 4).Value = "Mesa";
                if (materialesSeleccionados.Count > 0)
                {
                    ws.Cell(row, 5).Value = materialesSeleccionados[0].TipoMaterial;
                }
                if (materialesSeleccionados.Count > 1)
                {
                    ws.Cell(row, 6).Value = materialesSeleccionados[1].TipoMaterial;
                }
                if (materialesSeleccionados.Count > 2)
                {
                    ws.Cell(row, 7).Value = materialesSeleccionados[2].TipoMaterial;
                }
                row++;

                // Validar que listaAlumnos no esté vacía
                if (listaAlumnos == null || listaAlumnos.Count == 0)
                {
                    MessageBox.Show("No hay alumnos seleccionados para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Agregar datos de los alumnos seleccionados
                var firstDataRow = row;
                foreach (var a in listaAlumnos)
                {
                    ws.Cell(row, 1).Value = a.Nombre;
                    ws.Cell(row, 2).Value = a.Apellidos;
                    ws.Cell(row, 3).Value = a.NumExpediente;

                    
                    var nombreAlumno = $"{a.Nombre} {a.Apellidos}";
                    foreach (PictureBox pictureBox in ComboBoxPictureBoxMap.Values)
                    {
                        if (pictureBox.Tag != null && pictureBox.Tag.ToString().Trim().Equals(nombreAlumno.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            ws.Cell(row, 4).Value = pictureBox.Name;
                        }
                    }
                    // Mostrar el nombre de la mesa

                    // Alternar color de fila
                    if ((row - firstDataRow) % 2 == 1)
                    {
                        ws.Row(row).Style.Fill.BackgroundColor = XLColor.FromArgb(242, 242, 242);
                    }
                    row++;
                }
                row = firstDataRow;
                // ------------------------------------
                // 3) Lista materiales
                // ------------------------------------

                int materialCounter = 0;
                foreach (var material in materialesSeleccionados)
                {
                    int column = 5 + (materialCounter % 3);
                    ws.Cell(row, column).Value = material.DescripcionMaterial;
                    // Centrar texto de materiales
                    ws.Cell(row, column).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    materialCounter++;
                    if (materialCounter % 3 == 0) row++;
                }
                if (materialCounter % 3 != 0) row++;
                row += 2;


                // ------------------------------------
                // 4) Estado del aula (mesas y equipos)
                // ------------------------------------
                ws.Cell(row, 1).Value = "AULA";
                ws.Cell(row, 1).Style.Font.SetBold()
                                           .Font.FontColor = XLColor.DarkBlue;
                ws.Cell(row, 1).Style.Font.SetBold().Font.FontSize = 14;
                ws.Cell(row, 2).Value = listaAlumnos[0].NombreAula;
                ws.Cell(row, 3).Value = $"{listaAlumnos[0].Planta} - {listaAlumnos[0].Pabellon}";
                row++;

                // Encabezados de tabla
                var aulaHeader = ws.Range(row, 1, row, 3);
                aulaHeader.Style.Font.SetBold()
                                     .Fill.BackgroundColor = XLColor.MediumPurple;
                aulaHeader.Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                aulaHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                ws.Cell(row, 1).Value = "Fila";
                ws.Cell(row, 2).Value = "Columna";
                ws.Cell(row, 3).Value = "Equipos";
                row++;

                foreach (var mesa in estadoAula)
                {
                    ws.Cell(row, 1).Value = mesa.FilaMesa;
                    ws.Cell(row, 2).Value = mesa.ColumnaMesa;
                    ws.Cell(row, 3).Value = string.Join(", ", mesa.Equipo);
                    // Borde en la fila
                    ws.Range(row, 1, row, 6).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    row++;
                }

                // ------------------------------------
                // 5) Ajustes finales de formato
                // ------------------------------------
                ws.Columns().AdjustToContents();
                ws.Column(3).Width = 20;
                ws.SheetView.FreezeRows(1);

                workbook.SaveAs(rutaExcel);
                MessageBox.Show(
                    $"Archivo Excel guardado en: {rutaExcel}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el archivo Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private AsistenciaAlumno RecuperarInformacionAlumno(string nombreCompleto, int idAula)
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT 
            al.nombre AS Nombre,
            al.apellidos AS Apellidos,
            al.nre AS NumExpediente,
            au.nombre AS NombreAula,
            me.fila AS FilaMesa,
            me.columna AS ColumnaMesa,
            me.nombre AS NombreMesa
        FROM 
            Alumnos al
        INNER JOIN Asistencias asi ON asi.alumno_id = al.id
        INNER JOIN Aulas au ON asi.aula_id = au.id
        INNER JOIN Mesas me ON asi.mesa_id = me.id
        WHERE CONCAT(al.nombre, ' ', al.apellidos) = @NombreCompleto
        AND au.id = @IdAula;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                    command.Parameters.AddWithValue("@IdAula", idAula);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AsistenciaAlumno
                            {
                                Nombre = reader["Nombre"].ToString(),
                                Apellidos = reader["Apellidos"].ToString(),
                                NumExpediente = reader["NumExpediente"].ToString(),
                                NombreAula = reader["NombreAula"].ToString(),
                                FilaMesa = Convert.ToInt32(reader["FilaMesa"]),
                                ColumnaMesa = Convert.ToInt32(reader["ColumnaMesa"]),
                               NombreMesa = reader["NombreMesa"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recuperar la información del alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

    }

}
