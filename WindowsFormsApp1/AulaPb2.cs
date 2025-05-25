using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class AulaPb2 : Form
    {
        private Dictionary<ComboBox, PictureBox> comboBoxPictureBoxMap;
        public List<MaterialAlumno> materialesSeleccionados;
        private AulaBaseHelper helper;
        private Dictionary<string, List<MaterialAlumno>> materialesPorMesa = new Dictionary<string, List<MaterialAlumno>>();
        private int idAula = 4;
        private string nombreMesa = "";
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }
        public string Rol { get; set; }

        public AulaPb2()
        {
            InitializeComponent();
            this.ClientSize = new Size(750, 580);
        }

        private void AulaPb2_Load(object sender, EventArgs e)
        {
            comboBoxPictureBoxMap = new Dictionary<ComboBox, PictureBox>
            {
                { comboBox1, ptb2bF1C1 },
                { comboBox2, ptb2bF1C2 },
                { comboBox3, ptb2bF1C3 },
                { comboBox4, ptb2bF1C4 },
                { comboBox5, ptb2bF2C1 },
                { comboBox6, ptb2bF2C2 },
                { comboBox7, ptb2bF2C3 },
                { comboBox8, ptb2bF2C4 }
            };

            helper = new AulaBaseHelper
            {
                idAula = this.idAula,
                NombreProfesor = NombreProfesor,
                ApellidosProfesor = ApellidosProfesor,
                NombreAsignatura = NombreAsignatura,
                ComboBoxPictureBoxMap = comboBoxPictureBoxMap
            };

            foreach (var comboBox in comboBoxPictureBoxMap.Keys)
            {
                comboBox.SelectedIndexChanged += helper.ComboBox_SelectedIndexChanged;
            }

            helper.LlenarComboBox();

            txNombreApellidoProfesor.Text = $"{NombreProfesor} {ApellidosProfesor}";
            txNombreAsignatura.Text = $"Asignatura: {NombreAsignatura}";
        }

        private void txNombreAsignatura_TextChanged(object sender, EventArgs e)
        {
        }


        private void btGuardarAula_Click(object sender, EventArgs e)
        {
            // Obtener el horario seleccionado
            string horario = cbHorario.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(horario))
            {
                MessageBox.Show("Por favor, selecciona un horario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var alumnosSeleccionados = new List<(string Alumno, string Mesa)>();

            foreach (var entry in comboBoxPictureBoxMap)
            {
                ComboBox comboBox = entry.Key;
                PictureBox pictureBox = entry.Value;

                if (comboBox.SelectedItem != null) // Verifica si hay un alumno seleccionado
                {
                    string alumno = comboBox.SelectedItem.ToString(); // Nombre del alumno seleccionado
                    string mesa = pictureBox.Name; // Nombre de la mesa asociada al PictureBox
                    alumnosSeleccionados.Add((alumno, mesa)); // Agrega el alumno y la mesa a la lista
                }
            }
            foreach (var (alumno, mesa) in alumnosSeleccionados)
            {
                string pabellon = ObtenerDato("pabellon", "Aulas", $"Id = {idAula}");
                string planta = ObtenerDato("planta", "Aulas", $"Id = {idAula}");
                string aula = ObtenerDato("nombre", "Aulas", $"Id = {idAula}");
                string profesor = $"{NombreProfesor} {ApellidosProfesor}";
                string asignatura = $"{NombreAsignatura}";
                string periferico = "";
                string material = "";

                if (materialesPorMesa.ContainsKey(mesa))
                {
                    var listaMateriales = materialesPorMesa[mesa];
                    // Junta los periféricos (tipo y descripción) en un solo string
                    periferico = string.Join(", ", listaMateriales.Select(m => $"{m.TipoMaterial}: {m.DescripcionMaterial}"));
                    // Si quieres solo las descripciones:
                    material = string.Join(", ", listaMateriales.Select(m => m.DescripcionMaterial));
                }
                else
                {
                    periferico = "Sin periféricos asignados";
                    material = "";
                }

                GuardadoBD guardadoBD = new GuardadoBD
                {
                    NombreProfesor = this.NombreProfesor,
                    ApellidosProfesor = this.ApellidosProfesor,
                    NombreAsignatura = this.NombreAsignatura,
                    IdAula = this.idAula,
                    Rol = this.Rol,
                    GuardarAulaAccion = () =>
                    {
                        helper.GuardarAula_Click(idAula, horario);
                        helper.InsertarEnRegistro(
                                                horario,
                                                DateTime.Now,
                                                pabellon,
                                                planta,
                                                aula,
                                                profesor,
                                                asignatura,
                                                alumno,
                                                mesa,
                                                periferico,
                                                material
                                                );
                    }
                };

                guardadoBD.Show();
                this.Hide();

            }
        }

        public string ObtenerDato(string columna, string tabla, string condicion)
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = $"SELECT {columna} FROM {tabla} WHERE {condicion};";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener {columna}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void ptbF1C1_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptb2bF1C1";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                materialesPorMesa[nombreMesa] = new List<MaterialAlumno>(materialesSeleccionados);
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF1C2_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptb2bF1C2";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                materialesPorMesa[nombreMesa] = new List<MaterialAlumno>(materialesSeleccionados);
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF1C3_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptb2bF1C3";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                materialesPorMesa[nombreMesa] = new List<MaterialAlumno>(materialesSeleccionados);
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF1C4_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptb2bF1C4";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                materialesPorMesa[nombreMesa] = new List<MaterialAlumno>(materialesSeleccionados);
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF2C1_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptb2bF2C1";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                materialesPorMesa[nombreMesa] = new List<MaterialAlumno>(materialesSeleccionados);
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF2C2_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptb2bF2C2";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                materialesPorMesa[nombreMesa] = new List<MaterialAlumno>(materialesSeleccionados);
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF2C3_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptb2bF2C3";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                materialesPorMesa[nombreMesa] = new List<MaterialAlumno>(materialesSeleccionados);
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void ptbF2C4_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptb2bF2C4";
            FormularioMaterial formularioMaterial = new FormularioMaterial(nombreMesa);
            formularioMaterial.ShowDialog();
            materialesSeleccionados = formularioMaterial.MaterialesSeleccionados;
            if (materialesSeleccionados != null && materialesSeleccionados.Count > 0)
            {
                foreach (var material in formularioMaterial.MaterialesSeleccionados)
                {
                    material.NombreM = nombreMesa; // Asocia el material con el nombre de la mesa
                }
                if (helper.materialesSeleccionados == null)
                {
                    helper.materialesSeleccionados = new List<MaterialAlumno>();
                }
                helper.materialesSeleccionados.AddRange(materialesSeleccionados);
            }
        }

        private void btSalida_Click(object sender, EventArgs e)
        {
            PlanosPorPlantas planosPorPlantas = new PlanosPorPlantas
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura
            };

            planosPorPlantas.Show();

            this.Close();
        }
    }
}
