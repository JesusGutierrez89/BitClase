using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AulaPb1 : Form
    {
        private Dictionary<ComboBox, PictureBox> comboBoxPictureBoxMap;
        public List<MaterialAlumno> materialesSeleccionados;
        private AulaBaseHelper helper;
        private Dictionary<string, List<MaterialAlumno>> materialesPorMesa = new Dictionary<string, List<MaterialAlumno>>();
        private int idAula = 3;
        private string nombreMesa = "";

        private bool volverAlMenu = false;

        public string horario { get; set; }
        public string NombreProfesor { get; set; }
        public string ApellidosProfesor { get; set; }
        public string NombreAsignatura { get; set; }
        public string Rol { get; set; }

        public AulaPb1()
        {
            InitializeComponent();
            this.FormClosing += Presentacion_FormClosing;
            this.ClientSize = new Size(750, 580);
        }

        private void AulaPb1_Load(object sender, EventArgs e)
        {
            comboBoxPictureBoxMap = new Dictionary<ComboBox, PictureBox>
            {
                { comboBox1, ptb1bF1C1 },
                { comboBox2, ptb1bF1C2 },
                { comboBox3, ptb1bF1C3 },
                { comboBox4, ptb1bF1C4 },
                { comboBox5, ptb1bF2C1 },
                { comboBox6, ptb1bF2C2 },
                { comboBox7, ptb1bF2C3 },
                { comboBox8, ptb1bF2C4 }
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

       
        private void txNombreApellidoProfesor_TextChanged(object sender, EventArgs e)
        {
        }

        private void btGuardarAula_Click(object sender, EventArgs e)
        {
            string horario = cbHorario.SelectedItem?.ToString();
            this.horario = horario;
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

                if (comboBox.SelectedItem != null)
                {
                    string alumno = comboBox.SelectedItem.ToString();
                    string mesa = pictureBox.Name;
                    alumnosSeleccionados.Add((alumno, mesa));
                }
            }

            var datosARegistrar = new List<(string Alumno, string Mesa, string Periferico, string Material)>();
            foreach (var (alumno, mesa) in alumnosSeleccionados)
            {
                var equipos = helper.ObtenerEquiposPorMesa(mesa);
                string periferico = equipos.Count > 0 ? string.Join(", ", equipos) : "Sin equipos asignados";

                string material = "";
                if (materialesPorMesa.ContainsKey(mesa))
                {
                    var listaMateriales = materialesPorMesa[mesa];
                    material = string.Join(", ", listaMateriales.Select(m => m.DescripcionMaterial));
                }

                datosARegistrar.Add((alumno, mesa, periferico, material));
            }

            string pabellon = ObtenerDato("pabellon", "Aulas", $"Id = {idAula}");
            string planta = ObtenerDato("planta", "Aulas", $"Id = {idAula}");
            string aula = ObtenerDato("nombre", "Aulas", $"Id = {idAula}");
            string profesor = $"{NombreProfesor} {ApellidosProfesor}";
            string asignatura = NombreAsignatura;

            foreach (var dato in datosARegistrar)
            {
                helper.InsertarEnRegistro(
                    horario,
                    DateTime.Now,
                    pabellon,
                    planta,
                    aula,
                    profesor,
                    asignatura,
                    dato.Alumno,
                    dato.Mesa,
                    dato.Material,
                    dato.Periferico
                );
            }

            //helper.GuardarAula_Click(idAula, horario);
            GuardadoBD guardadoBD = new GuardadoBD
            {

                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura,
                IdAula = this.idAula,
                Rol = this.Rol,
                Horario = this.horario,
                Helper = this.helper



            };

            guardadoBD.Show();
            this.Hide();
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

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ptbF1C1_Click(object sender, EventArgs e)
        {
            nombreMesa = "ptb1bF1C1";
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
            nombreMesa = "ptb1bF1C2";
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
            nombreMesa = "ptb1bF1C3";
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
            nombreMesa = "ptb1bF1C4";
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
            nombreMesa = "ptb1bF2C1";
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
            nombreMesa = "ptb1bF2C2";
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
            nombreMesa = "ptb1bF2C3";
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
            nombreMesa = "ptb1bF2C4";
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

        private void pbSalida_Click(object sender, EventArgs e)
        {
            volverAlMenu = true;
            PlanosPorPlantas planosPorPlantas = new PlanosPorPlantas
            {
                NombreProfesor = this.NombreProfesor,
                ApellidosProfesor = this.ApellidosProfesor,
                NombreAsignatura = this.NombreAsignatura
            };

            planosPorPlantas.Show();

            this.Close();
        }

        private void cbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Presentacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!volverAlMenu)
            {
                Application.Exit();
            }
        }
    }
}
