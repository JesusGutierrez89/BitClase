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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public class AulaBaseHelper
    {
        string[] numExpediente;
        public int idAula { get; set; }

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

                    string pcRojo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", "Imagenes", "pcCasa.jpg");
                    string pcVerde = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", "Imagenes", "pcInstituto.jpg");
                    // Verificar si el valor seleccionado ya está en otro ComboBox
                    if (EsDuplicado(nombreAlumno, comboBox))
                    {
                        MessageBox.Show($"El valor '{nombreAlumno}' ya está seleccionado en otro ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBox.SelectedIndex = -1;
                        pictureBox.Image = Image.FromFile(pcRojo);
                    }
                    else
                    {
                        // Cambiar la imagen del PictureBox según la selección
                        pictureBox.Image = Image.FromFile(pcVerde);
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

        public void GuardarAula_Click(int idAula, string horario)
        {
            //Depurar si viene la misma informacion
            foreach (var comboBox in ComboBoxPictureBoxMap.Keys)
            {
                if (comboBox.SelectedItem != null)
                {
                    string nombreCompleto = comboBox.SelectedItem.ToString();

                }
            }
            // 1) Lógica actual: asignar imágenes si no hay selección
            string pcRojo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", "Imagenes", "pcCasa.jpg");
            foreach (var comboBox in ComboBoxPictureBoxMap.Keys)
            {
                if (comboBox.SelectedItem == null)
                {
                    ComboBoxPictureBoxMap[comboBox].Image =
                        Image.FromFile(pcRojo);
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
                $"Excel_Asistencia_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            string rutaJson = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Json_Asistencia_{DateTime.Now:yyyyMMdd_HHmmss}.json");

            try
            {

                GuardarYExportarExcel(
                    profesorNombre,
                    profesorApellidos,
                    asignaturaNombre,
                    listaAlumnos,
                    estadoAula,
                    rutaExcel);

                GuardarYExportarJson(
                    profesorNombre,
                    profesorApellidos,
                    asignaturaNombre,
                    idAula,
                    listaAlumnos,
                    estadoAula,
                    rutaJson);
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
        LEFT JOIN Equipo_Ordenador eq ON eq.mesa_id = me.id
        WHERE me.aula_id = @idAula;";

            var estadoAula = new List<EquipoMesa>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idAula", idAula); // Usa la variable de entorno

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var mesaExistente = estadoAula.Find(m =>
                                    m.FilaMesa == Convert.ToInt32(reader["FilaMesa"]) &&
                                    m.ColumnaMesa == Convert.ToInt32(reader["ColumnaMesa"]));

                                if (mesaExistente == null)
                                {
                                    var nuevaMesa = new EquipoMesa
                                    {
                                        FilaMesa = Convert.ToInt32(reader["FilaMesa"]),
                                        ColumnaMesa = Convert.ToInt32(reader["ColumnaMesa"]),
                                        Equipo = new List<string>()
                                    };

                                    if (reader["Equipo"] != DBNull.Value)
                                    {
                                        nuevaMesa.Equipo.Add(reader["Equipo"].ToString());
                                    }

                                    estadoAula.Add(nuevaMesa);
                                }
                                else
                                {
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
            mat.descripcion AS DescripcionMaterial,
            me.nombre AS NombreM
        FROM 
            Alumnos al
        INNER JOIN Asistencias asi ON asi.alumno_id = al.id
        INNER JOIN Mesas me ON asi.mesa_id = me.id
        LEFT JOIN Material mat ON mat.mesa_id = me.id AND mat.mesa_id IN (SELECT id FROM Mesas WHERE aula_id = @idAula)
        WHERE me.aula_id = @idAula;";

            var materialesAlumnos = new List<MaterialAlumno>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idAula", idAula);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var materialAlumno = new MaterialAlumno
                                {
                                    TipoMaterial = reader["TipoMaterial"]?.ToString(),
                                    DescripcionMaterial = reader["DescripcionMaterial"]?.ToString(),
                                    NombreM = reader["NombreM"]?.ToString()
                                };

                                // Solo añadir si hay material asociado
                                if (!string.IsNullOrEmpty(materialAlumno.TipoMaterial) || !string.IsNullOrEmpty(materialAlumno.DescripcionMaterial))
                                {
                                    materialesAlumnos.Add(materialAlumno);
                                }
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
                // 1) Cabecera general
                // ------------------------------------
                var headerRange = ws.Range(row, 1, row, 5);
                headerRange.Style.Font.SetBold().Font.FontSize = 12;
                headerRange.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                ws.Cell(row, 1).Value = "Nom. Profesor:";
                ws.Cell(row, 2).Value = profesorNombre;
                ws.Cell(row, 4).Value = "Ap. profesor:";
                ws.Cell(row, 5).Value = profesorApellidos;
                row++;

                var subHeaderRange = ws.Range(row, 1, row, 5);
                subHeaderRange.Style.Font.SetBold().Font.FontSize = 12;
                subHeaderRange.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                subHeaderRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                ws.Cell(row, 1).Value = "N. asignatura:";
                ws.Cell(row, 2).Value = asignaturaNombre;
                ws.Cell(row, 4).Value = "FECHA (Hoy):";
                ws.Cell(row, 5).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                row += 2;

                // ------------------------------------
                // 2) Lista de alumnos
                // ------------------------------------
                ws.Cell(row, 1).Value = "AL. SELEC.";
                ws.Cell(row, 1).Style.Font.SetBold().Font.FontColor = XLColor.DarkOrange;
                ws.Cell(row, 1).Style.Font.SetBold().Font.FontSize = 14;
                row++;

                // Sub-encabezado de alumnos
                var alumnosHeader = ws.Range(row, 1, row, 7);
                alumnosHeader.Style.Font.SetBold().Fill.BackgroundColor = XLColor.RedRyb;
                alumnosHeader.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                alumnosHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                ws.Cell(row, 1).Value = "Nombre Al.";
                ws.Cell(row, 2).Value = "Apellidos Al.";
                ws.Cell(row, 3).Value = "Nre";
                ws.Cell(row, 4).Value = "Mesa";
                if (materialesSeleccionados.Count > 0) ws.Cell(row, 5).Value = materialesSeleccionados[0].TipoMaterial;
                if (materialesSeleccionados.Count > 1) ws.Cell(row, 6).Value = materialesSeleccionados[1].TipoMaterial;
                if (materialesSeleccionados.Count > 2) ws.Cell(row, 7).Value = materialesSeleccionados[2].TipoMaterial;
                row++;

               
                var rowAux = row;
                // Datos de los alumnos
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
                    // Alternar color filas
                    if ((row % 2) == 0)
                        ws.Row(row).Style.Fill.BackgroundColor = XLColor.FromArgb(242, 242, 242);

                    row++;
                }

                // Ahora estamos después de los alumnos -> agregar 2 filas de espacio
                row += 2;

                // ------------------------------------
                // 3) Materiales (separados y ordenados)
                // ------------------------------------
                row = rowAux;
                if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
                {
                    // Crear listas separadas
                    var pantallas = materialesSeleccionados
                        .Where(m => m.TipoMaterial != null && m.TipoMaterial.Equals("Pantalla", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    var ratones = materialesSeleccionados
                        .Where(m => m.TipoMaterial != null && m.TipoMaterial.Equals("Raton", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    var teclados = materialesSeleccionados
                        .Where(m => m.TipoMaterial != null && m.TipoMaterial.Equals("Teclado", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    // Máximo número de filas que necesitaremos
                    int maxFilas = Math.Max(pantallas.Count, Math.Max(ratones.Count, teclados.Count));

                    // Rellenar materiales
                    for (int i = 0; i < maxFilas; i++)
                    {
                        // Leer el valor de la celda en la columna 4 (NombreMesa) de la fila actual
                        var nombreMesaCelda = ws.Cell(row, 4).Value.ToString();

                        // Comprobar en la lista de pantallas
                        if (i < pantallas.Count && pantallas[i].DescripcionMaterial != null)
                        {
                            for (int j = 0; j < pantallas.Count; j++)
                            {
                                if (pantallas[j].NombreM.Equals(nombreMesaCelda, StringComparison.OrdinalIgnoreCase))
                                {
                                    ws.Cell(row, 5).Value = pantallas[j].DescripcionMaterial;

                                }
                            }

                        }

                        // Comprobar en la lista de ratones
                        if (i < ratones.Count && ratones[i].DescripcionMaterial != null)
                        {
                            for (int j = 0; j < ratones.Count; j++)
                            {
                                if (ratones[j].NombreM.Equals(nombreMesaCelda, StringComparison.OrdinalIgnoreCase))
                                {
                                    ws.Cell(row, 6).Value = ratones[j].DescripcionMaterial;

                                }
                            }

                        }

                        // Comprobar en la lista de teclados
                        if (i < teclados.Count && teclados[i].DescripcionMaterial != null)
                        {
                            for (int j = 0; j < teclados.Count; j++)
                            {
                                if (teclados[j].NombreM.Equals(nombreMesaCelda, StringComparison.OrdinalIgnoreCase))
                                {
                                    ws.Cell(row, 7).Value = teclados[j].DescripcionMaterial;

                                }
                            }

                        }

                        row++;
                    }

                    row += 2; // Salto de espacio
                }
                else
                {
                    MessageBox.Show("No hay materiales seleccionados para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // ------------------------------------
                // 4) Estado del aula
                // ------------------------------------
                ws.Cell(row, 1).Value = "AULA";
                ws.Cell(row, 1).Style.Font.SetBold().Font.FontColor = XLColor.DarkBlue;
                ws.Cell(row, 1).Style.Font.SetBold().Font.FontSize = 14;
                if (listaAlumnos.Count > 0)
                {
                    ws.Cell(row, 2).Value = listaAlumnos[0].NombreAula;
                    ws.Cell(row, 3).Value = $"{listaAlumnos[0].Planta} - {listaAlumnos[0].Pabellon}";
                }
                row++;

                var aulaHeader = ws.Range(row, 1, row, 3);
                aulaHeader.Style.Font.SetBold().Fill.BackgroundColor = XLColor.MediumPurple;
                aulaHeader.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
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
                    ws.Range(row, 1, row, 6).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    row++;
                }

                // ------------------------------------
                // 5) Ajustes finales
                // ------------------------------------
                ws.Columns().AdjustToContents();
                ws.Column(3).Width = 20;
                ws.SheetView.FreezeRows(1);

                workbook.SaveAs(rutaExcel);
                MessageBox.Show($"Archivo Excel guardado en: {rutaExcel}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el archivo Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void GuardarYExportarJson(
     string profesorNombre,
     string profesorApellidos,
     string asignaturaNombre,
     int idAula,
     List<AsistenciaAlumno> listaAlumnos,
     List<EquipoMesa> estadoAula,
     string rutaJson)
        {

            try
            {

                if (materialesSeleccionados == null || materialesSeleccionados.Count == 0)
                {
                    MessageBox.Show("No hay materiales seleccionados para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. Obtener los nombres de mesa asignados a los alumnos seleccionados (normalizados)
                var mesasAsignadas = listaAlumnos
                    .Where(a => !string.IsNullOrEmpty(a.NombreMesa))
                    .Select(a => NormalizarNombreMesa(a.NombreMesa, idAula))
                    .Distinct()
                    .ToList();

                // 2. Filtrar materiales SOLO de esas mesas (normalizando m.NombreM)
                var materialesPantallas = materialesSeleccionados
                    .Where(m => m.TipoMaterial != null
                        && m.TipoMaterial.Equals("Pantalla", StringComparison.OrdinalIgnoreCase)
                        && m.NombreM != null
                        && mesasAsignadas.Contains(NormalizarNombreMesa(m.NombreM, idAula)))
                    .Select(m => new { NombreMesa = NormalizarNombreMesa(m.NombreM, idAula), m.DescripcionMaterial })
                    .ToList();

                var materialesRatones = materialesSeleccionados
                    .Where(m => m.TipoMaterial != null
                        && m.TipoMaterial.Equals("Raton", StringComparison.OrdinalIgnoreCase)
                        && m.NombreM != null
                        && mesasAsignadas.Contains(NormalizarNombreMesa(m.NombreM, idAula)))
                    .Select(m => new { NombreMesa = NormalizarNombreMesa(m.NombreM, idAula), m.DescripcionMaterial })
                    .ToList();

                var materialesTeclados = materialesSeleccionados
                    .Where(m => m.TipoMaterial != null
                        && m.TipoMaterial.Equals("Teclado", StringComparison.OrdinalIgnoreCase)
                        && m.NombreM != null
                        && mesasAsignadas.Contains(NormalizarNombreMesa(m.NombreM, idAula)))
                    .Select(m => new { NombreMesa = NormalizarNombreMesa(m.NombreM, idAula), m.DescripcionMaterial })
                    .ToList();

                var jsonData = new
                {
                    Profesor = new
                    {
                        Nombre = profesorNombre,
                        Apellidos = profesorApellidos
                    },
                    Asignatura = new
                    {
                        Nombre = asignaturaNombre,
                        Fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                    },
                    Alumnos = listaAlumnos.Select(a =>
                    {
                        var nombreCompleto = $"{a.Nombre} {a.Apellidos}".Trim();
                        var pictureBox = ComboBoxPictureBoxMap.Values
                            .OfType<PictureBox>()
                            .FirstOrDefault(pb => pb.Tag != null &&
                                pb.Tag.ToString().Trim().Equals(nombreCompleto, StringComparison.OrdinalIgnoreCase));
                        var mesa = pictureBox?.Name ?? "Sin mesa";
                        return new
                        {
                            a.Nombre,
                            a.Apellidos,
                            a.NumExpediente,
                            Mesa = mesa
                        };
                    }).ToList(),
                    Materiales = new
                    {
                        Pantallas = materialesPantallas,
                        Ratones = materialesRatones,
                        Teclados = materialesTeclados
                    },
                    Aula = new
                    {
                        Nombre = listaAlumnos.First().NombreAula,
                        Ubicacion = $"{listaAlumnos.First().Planta} - {listaAlumnos.First().Pabellon}",
                        Distribucion = estadoAula.Select(m => new
                        {
                            m.FilaMesa,
                            m.ColumnaMesa,
                            Equipos = m.Equipo
                        }).ToList()
                    }
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                var jsonString = JsonSerializer.Serialize(jsonData, options);

                File.WriteAllText(rutaJson, jsonString, Encoding.UTF8);

                MessageBox.Show($"Archivo JSON guardado en: {rutaJson}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el archivo JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            au.planta AS Planta,
            au.pabellon AS Pabellon,
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
                                Planta = reader["Planta"].ToString(),
                                Pabellon = reader["Pabellon"].ToString(),
                                FilaMesa = Convert.ToInt32(reader["FilaMesa"]),
                                ColumnaMesa = Convert.ToInt32(reader["ColumnaMesa"]),
                                NombreMesa = reader["NombreMesa"].ToString()
                            };
                        }
                        else
                        {
                            MessageBox.Show($"No se encontró información para el alumno: {nombreCompleto}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private string NormalizarNombreMesa(string nombreMesa, int idAula)
        {
            if (string.IsNullOrWhiteSpace(nombreMesa))
                return string.Empty;

            nombreMesa = nombreMesa.Trim();

            // Si ya contiene el prefijo (como ptb2), no hacer nada
            if (nombreMesa.StartsWith($"ptb{idAula}", StringComparison.OrdinalIgnoreCase))
                return nombreMesa;

            // Si es algo como F1C1, añade el prefijo
            if (Regex.IsMatch(nombreMesa, @"^F\d+C\d+$", RegexOptions.IgnoreCase))
                return $"ptb{idAula}{nombreMesa}";

            // Si es como 2F1C1, quitar el aula (2) y añadirlo como prefijo ptb2
            if (Regex.IsMatch(nombreMesa, @"^\dF\d+C\d+$", RegexOptions.IgnoreCase))
                return $"ptb{idAula}{nombreMesa.Substring(1)}";

            return nombreMesa;
        }


        public void InsertarEnRegistro(
      string horario,
      DateTime fecha,
      string pabellon,
      string planta,
      string aula,
      string profesor,
      string asignatura,
      string alumno,
      string mesa,
      string periferico,
      string material)
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        INSERT INTO Registro (Horario, Fecha, Pabellon, Planta, Aula, Profesor, Asignatura, Alumno, Mesa, Periferico, Material)
        VALUES (@Horario, @Fecha, @Pabellon, @Planta, @Aula, @Profesor, @Asignatura, @Alumno, @Mesa, @Periferico, @Material);";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Horario", horario);
                        command.Parameters.AddWithValue("@Fecha", fecha);
                        command.Parameters.AddWithValue("@Pabellon", pabellon);
                        command.Parameters.AddWithValue("@Planta", planta);
                        command.Parameters.AddWithValue("@Aula", aula);
                        command.Parameters.AddWithValue("@Profesor", profesor);
                        command.Parameters.AddWithValue("@Asignatura", asignatura);
                        command.Parameters.AddWithValue("@Alumno", alumno);
                        command.Parameters.AddWithValue("@Mesa", mesa);
                        command.Parameters.AddWithValue("@Periferico", periferico);
                        command.Parameters.AddWithValue("@Material", material);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar en la tabla Registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<string> ObtenerEquiposPorMesa(string nombreMesa)
        {
            var equipos = new List<string>();
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT eq.nombre
        FROM Equipo_Ordenador eq
        INNER JOIN Mesas m ON eq.mesa_id = m.id
        WHERE m.nombre = @NombreMesa;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreMesa", nombreMesa);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            equipos.Add(reader["nombre"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los equipos de la mesa {nombreMesa}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return equipos;
        }

    }
}