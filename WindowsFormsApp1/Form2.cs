using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        SqlConnection conection = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;Integrated Security = SSPI;");
        SqlCommand comando = new SqlCommand();

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                string nrp = txtNRP.Text;
                string nombre = txtNombre.Text;
                string apellidos = txtApellidos.Text;
                string email = txtEmail.Text;
                string departamento = txtDepartamento.Text;
                string password = EncriptarPassword(txtpassword.Text);

                conection.Open();
                comando.Connection = conection;

                // Verificar si el NRP existe en la base de datos
                comando.CommandText = "SELECT * FROM Profesores WHERE nrp = @nrp";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nrp", nrp);
                SqlDataReader reader = comando.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("El NRP no existe en la base de datos.");
                }
                else
                {
                    reader.Close();
                    // Verificar si el NRP ya está asociado a otro usuario con datos no vacíos
                    comando.CommandText = "SELECT * FROM Profesores WHERE nrp = @nrp AND (nombre != '' OR apellidos != '' OR email != '' OR departamento != '' OR password != '')";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@nrp", nrp);
                    SqlDataReader readerDentro = comando.ExecuteReader();

                    if (readerDentro.Read())
                    {
                        MessageBox.Show("El NRP ya está asociado a otro usuario.");
                    }
                    else
                    {
                        readerDentro.Close();
                        // Actualizar el usuario existente con los nuevos datos
                        comando.CommandText = "UPDATE Profesores SET nombre = @nombre, apellidos = @apellidos, email = @email, departamento = @departamento, password = @password WHERE nrp = @nrp";
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@apellidos", apellidos);
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@departamento", departamento);
                        comando.Parameters.AddWithValue("@password", password);
                        comando.Parameters.AddWithValue("@nrp", nrp);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Usuario actualizado exitosamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar registrar o actualizar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conection.State == ConnectionState.Open)
                {
                    conection.Close();
                }
            }
        }
        public static string EncriptarPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la cadena de texto en un array de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir el array de bytes en una cadena de texto
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
