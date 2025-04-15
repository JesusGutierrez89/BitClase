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
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class Presentacion : Form
    {
        SqlConnection conection = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;Integrated Security = SSPI;");
        SqlCommand comando = new SqlCommand();
        public Presentacion()
        {
            InitializeComponent();
        }

        private void Presentacion_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btInicioSesion_Click(object sender, EventArgs e)
        {
           
            try
            {
                string nrp = tbUsuario.Text;
                string password = EncriptarPassword(tbPassword.Text);

                conection.Open();
                comando.Connection = conection;
                comando.CommandText = "SELECT * FROM Profesores WHERE nrp = @nrp AND password = @password";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nrp", nrp);
                comando.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = comando.ExecuteReader();
                
                if (reader.Read())
                {
                    MessageBox.Show("Inicio de sesión exitoso.");
                    // Aquí puedes redirigir al usuario a la siguiente pantalla o realizar otras acciones necesarias
                }
                else
                {
                    MessageBox.Show("NRP o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conection.State == ConnectionState.Open)
                {
                    conection.Close();
                }
            }
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btRegistro_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
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
