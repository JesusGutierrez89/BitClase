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
            txtNRP.TextChanged += txtNRP_TextChanged;
            txtNombre.TextChanged += txtNombre_TextChanged;
            txtApellidos.TextChanged += txtApellidos_TextChanged;
            txtEmail.TextChanged += txtEmail_TextChanged;
            txtpassword.TextChanged += txtpassword_TextChanged;

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
                string password = EncriptarPassword(txtpassword.Text);

                // Encriptar la contraseña con BCrypt
                string hashedPassword = EncriptarPassword(password);
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
                    comando.CommandText = "SELECT * FROM Profesores WHERE nrp = @nrp AND (nombre != '' OR apellidos != '' OR email != '' OR password != '')";
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
                        comando.CommandText = "UPDATE Profesores SET nombre = @nombre, apellidos = @apellidos, email = @email, password = @password WHERE nrp = @nrp";
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@apellidos", apellidos);
                        comando.Parameters.AddWithValue("@email", email);
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
            // Regresar al formulario Presentacion
            Presentacion presentacion = new Presentacion();
            presentacion.Show();
            this.Hide();
        }
        // Método para encriptar la contraseña con BCrypt
        public static string EncriptarPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        private void txtNRP_TextChanged(object sender, EventArgs e)
        {
            if (txtNRP.Text.Length != 11)
            {
                errorProvider1.SetError(txtNRP, "El NRP debe tener exactamente 11 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtNRP, string.Empty); // Elimina el error si es válido
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El campo Nombre no puede estar vacío.");
            }
            else
            {
                errorProvider1.SetError(txtNombre, string.Empty); // Elimina el error si es válido
            }
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                errorProvider1.SetError(txtApellidos, "El campo Apellidos no puede estar vacío.");
            }
            else
            {
                errorProvider1.SetError(txtApellidos, string.Empty); // Elimina el error si es válido
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!EsCorreoValido(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "El correo electrónico no es válido.");
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty); // Elimina el error si es válido
            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtpassword.Text.Length < 4)
            {
                errorProvider1.SetError(txtpassword, "La contraseña debe tener al menos 4 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtpassword, string.Empty); // Elimina el error si es válido
            }
        }
        private bool EsCorreoValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
