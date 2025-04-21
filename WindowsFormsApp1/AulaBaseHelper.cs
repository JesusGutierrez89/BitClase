using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

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
            foreach (var comboBox in ComboBoxPictureBoxMap.Keys)
            {
                if (comboBox.SelectedItem == null)
                {
                    ComboBoxPictureBoxMap[comboBox].Image = Image.FromFile("C:\\Users\\Guty\\Documents\\TFS\\Imagenes\\pcCasa.jpg");
                }
            }
            MessageBox.Show("Todos los alumnos han sido seleccionados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
