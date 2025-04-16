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
                string password = tbPassword.Text;

                conection.Open();
                comando.Connection = conection;
                comando.CommandText = "SELECT password FROM Profesores WHERE nrp = @nrp";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nrp", nrp);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    string hashedPassword = reader.GetString(0);
                    reader.Close();

                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        MessageBox.Show("Inicio de sesión exitoso.");
                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("NRP o contraseña incorrectos.");
                    }
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
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
