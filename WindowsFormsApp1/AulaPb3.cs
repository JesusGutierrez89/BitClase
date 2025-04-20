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
    public partial class AulaPb3 : Form
    {
        public AulaPb3()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(750, 580);
        }

        private void AulaPb3_Load(object sender, EventArgs e)
        {
            LlenarComboBox();
        }
        private void LlenarComboBox()
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
        string query = @"SELECT * FROM Alumnos;";
            //    string query = @"
            //SELECT 
            //    al.nombre AS NombreAlumno,
            //    al.apellidos AS ApellidosAlumno,
            //    asig.Nombre AS Asignatura,
            //    asi.fecha AS FechaAsistencia,
            //    au.nombre AS NombreAula,
            //    au.planta AS Planta,
            //    au.pabellon AS Pabellon,
            //    me.fila AS FilaMesa,
            //    me.columna AS ColumnaMesa,
            //    mat.tipo AS TipoMaterial,
            //    mat.descripcion AS DescripcionMaterial,
            //    eq.tipo AS TipoEquipo,
            //    eq.nombre AS NombreEquipo,
            //    eq.descripcion AS DescripcionEquipo
            //FROM 
            //    Profesores p
            //INNER JOIN Asignatura asig 
            //    ON p.id = asig.id_profesor
            //INNER JOIN Alumnos al 
            //    ON asig.id_alumno = al.id
            //INNER JOIN Asistencias asi 
            //    ON asi.alumno_id = al.Id
            //INNER JOIN Aulas au 
            //    ON asi.aula_id = au.Id
            //INNER JOIN Mesas me 
            //    ON asi.mesa_id = me.Id
            //LEFT JOIN Material mat 
            //    ON mat.mesa_id = me.Id
            //LEFT JOIN Equipo_Ordenador eq 
            //    ON eq.mesa_id = me.Id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Crear un DataTable para almacenar los datos
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

                            // Llenar el DataGridView con los datos
                            dataGridView1.DataSource = dataTable;

                            // Llenar el ComboBox con los nombres y apellidos
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string nombreCompleto = $"{row["nombre"]} {row["apellidos"]}";//Cambiar por la consulta larga
                                comboBox1.Items.Add(nombreCompleto);
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

        private void ptbF1C1_Click(object sender, EventArgs e)
        {
            FormularioMaterial formularioMaterial = new FormularioMaterial();
            formularioMaterial.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
