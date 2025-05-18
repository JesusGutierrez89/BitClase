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
    public partial class FormularioEquipoOrdenador : Form
    {
        private string nuevaDescripcion = "";
        private string nuevoNombre = "";
        public FormularioEquipoOrdenador()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(550, 380);
            CargarAulas();
        }

        private void cbAula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAula.SelectedItem != null)
            {
                var row = cbAula.SelectedItem as DataRowView;
                if (row != null)
                {
                    int idAula = Convert.ToInt32(row["IdAula"]);
                    CargarMesasPorAula(idAula);
                    CargarTiposEquipo();
                }
            }
        }

        private void CbMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMesa.SelectedItem != null)
            {
                var row = cbMesa.SelectedItem as DataRowView;
                if (row != null)
                {
                    int idMesa = Convert.ToInt32(row["IdMesa"]);
                    CargarEquiposPorMesa(idMesa);
                }
            }
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbTipo.SelectedItem != null)
            {
                string tipoSeleccionado = cbTipo.SelectedItem.ToString();
              
            }
        }

        private void txNombre_TextChanged(object sender, EventArgs e)
        {
            nuevoNombre = txNombre.Text;
        }

        private void txDescripcion_TextChanged(object sender, EventArgs e)
        {
            nuevaDescripcion = txDescripcion.Text;
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            if (cbAula.SelectedItem == null || cbMesa.SelectedItem == null || cbTipo.SelectedItem == null || string.IsNullOrWhiteSpace(nuevaDescripcion))
            {
                MessageBox.Show("Debes seleccionar un aula, una mesa, un equipo y escribir la nueva descripción.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rowEquipo = cbTipo.SelectedItem as DataRowView;
            if (rowEquipo == null)
            {
                MessageBox.Show("Error al obtener el equipo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idEquipo = Convert.ToInt32(rowEquipo["IdEquipo"]);

            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = "UPDATE Equipo_Ordenador SET nombre = @nombre, descripcion = @descripcion WHERE id = @idEquipo";


            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nuevoNombre);
                    command.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                    command.Parameters.AddWithValue("@idEquipo", idEquipo);
                    connection.Open();
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Descripción actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var rowMesa = cbMesa.SelectedItem as DataRowView;
                        if (rowMesa != null)
                        {
                            int idMesa = Convert.ToInt32(rowMesa["IdMesa"]);
                            CargarEquiposPorMesa(idMesa);
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la descripción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormularioEquipoOrdenador_Load(object sender, EventArgs e)
        {

        }
        private void CargarAulas()
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = "SELECT Id AS IdAula, nombre AS NombreAula, planta AS Planta, pabellon AS Pabellon FROM Aulas";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);

                        dt.Columns.Add("DescripcionAula", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["DescripcionAula"] = $"{row["NombreAula"]} - Planta {row["Planta"]} - Pabellón {row["Pabellon"]}";
                        }

                        cbAula.DataSource = dt;
                        cbAula.DisplayMember = "DescripcionAula";
                        cbAula.ValueMember = "IdAula";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las aulas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarMesasPorAula(int idAula)
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = "SELECT Id AS IdMesa, nombre AS NombreMesa, aula_id AS AulaId FROM Mesas WHERE aula_id = @aulaId";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@aulaId", idAula);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);

                        dt.Columns.Add("DescripcionMesa", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["DescripcionMesa"] = $"Mesa {row["NombreMesa"]}";
                        }

                        cbMesa.DataSource = dt;
                        cbMesa.DisplayMember = "DescripcionMesa";
                        cbMesa.ValueMember = "IdMesa";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las mesas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarEquiposPorMesa(int idMesa)
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = "SELECT id AS IdEquipo, tipo AS Tipo, descripcion AS Descripcion, nombre AS NombreEquipo, mesa_id AS MesaId FROM Equipo_Ordenador WHERE mesa_id = @mesaId";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mesaId", idMesa);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);

                        dt.Columns.Add("DescripcionEquipo", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["DescripcionEquipo"] = $"{row["Tipo"]}";
                        }

                        cbTipo.DataSource = dt;
                        cbTipo.DisplayMember = "DescripcionEquipo";
                        cbTipo.ValueMember = "IdEquipo";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los equipos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarTiposEquipo()
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT DISTINCT tipo 
        FROM Equipo_Ordenador
        WHERE tipo IN ('Fuente Alimentacion', 'Procesador', 'Tarjeta grafica', 'Memoria ram')";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var tipos = new List<string>();
                        while (reader.Read())
                        {
                            tipos.Add(reader["tipo"].ToString());
                        }
                        cbTipo.DataSource = tipos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
