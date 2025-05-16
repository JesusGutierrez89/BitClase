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
    public partial class FormularioCambioPerifericos : Form
    {
        private string nuevaDescripcion = "";
        public FormularioCambioPerifericos()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(550, 350);
            CargarAulas();
        }

        private void cbAulas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbAulas.SelectedItem != null)
            {
                var row = cbAulas.SelectedItem as DataRowView;
                if (row != null)
                {
                    string nombreAula = row["NombreAula"].ToString();
                    string planta = row["Planta"].ToString();
                    string pabellon = row["Pabellon"].ToString();
                    int idAula = Convert.ToInt32(row["IdAula"]);

                    CargarMesasPorAula(idAula);
                }
            }
        }

        private void cbMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMesas.SelectedItem != null)
            {
                var row = cbMesas.SelectedItem as DataRowView;
                if (row != null)
                {
                   
                    string nombreMesa = row["NombreMesa"].ToString();
                    int aulaId = Convert.ToInt32(row["AulaId"]);
                    int idMesa = Convert.ToInt32(row["IdMesa"]);
                    CargarPerifericosPorMesa(idMesa);

                }
            }
        }

        private void cbPerifericos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbPerifericos.SelectedItem != null)
            {
                var row = cbPerifericos.SelectedItem as DataRowView;
                if (row != null)
                {
                    int idMaterial = Convert.ToInt32(row["IdMaterial"]);
                    string tipo = row["Tipo"].ToString();
                    string descripcion = row["Descripcion"].ToString();
                    int mesaId = Convert.ToInt32(row["MesaId"]);
                   
                }
            }
        }

        private void txNombreComponente_TextChanged(object sender, EventArgs e)
        {
            nuevaDescripcion = txNombreComponente.Text;
        }

        private void btModificacion_Click(object sender, EventArgs e)
        {
            
            if (cbAulas.SelectedItem == null || cbMesas.SelectedItem == null || cbPerifericos.SelectedItem == null || string.IsNullOrWhiteSpace(nuevaDescripcion))
            {
                MessageBox.Show("Debes seleccionar un aula, una mesa, un periférico y escribir la nueva descripción.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            var rowMaterial = cbPerifericos.SelectedItem as DataRowView;
            if (rowMaterial == null)
            {
                MessageBox.Show("Error al obtener el periférico seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idMaterial = Convert.ToInt32(rowMaterial["IdMaterial"]);

           
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = "UPDATE Material SET descripcion = @descripcion WHERE id = @idMaterial";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                    command.Parameters.AddWithValue("@idMaterial", idMaterial);
                    connection.Open();
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Descripción actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        var rowMesa = cbMesas.SelectedItem as DataRowView;
                        if (rowMesa != null)
                        {
                            int idMesa = Convert.ToInt32(rowMesa["IdMesa"]);
                            CargarPerifericosPorMesa(idMesa);
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

                        // Crear columna combinada para mostrar en el ComboBox
                        dt.Columns.Add("DescripcionAula", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["DescripcionAula"] = $"{row["NombreAula"]} - Planta {row["Planta"]} - Pabellón {row["Pabellon"]}";
                        }

                        cbAulas.DataSource = dt;
                        cbAulas.DisplayMember = "DescripcionAula";
                        cbAulas.ValueMember = "IdAula";
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

                        cbMesas.DataSource = dt;
                        cbMesas.DisplayMember = "DescripcionMesa";
                        cbMesas.ValueMember = "IdMesa";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las mesas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CargarPerifericosPorMesa(int idMesa)
        {
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = "SELECT Id AS IdMaterial, tipo AS Tipo, descripcion AS Descripcion, mesa_id AS MesaId FROM Material WHERE mesa_id = @mesaId";

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

                        dt.Columns.Add("DescripcionPeriferico", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["DescripcionPeriferico"] = $"{row["Tipo"]} - {row["Descripcion"]}";
                        }

                        cbPerifericos.DataSource = dt;
                        cbPerifericos.DisplayMember = "DescripcionPeriferico";
                        cbPerifericos.ValueMember = "IdMaterial";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los periféricos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            ActualizacionMaterial actualizacionMaterial = new ActualizacionMaterial();
            actualizacionMaterial.Show();
            this.Close();
        }
    }
}
