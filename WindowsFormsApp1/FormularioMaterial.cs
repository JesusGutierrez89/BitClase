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
    public partial class FormularioMaterial : Form
    {
        public List<MaterialAlumno> MaterialesSeleccionados { get; private set; } //cambio aqui para probar
        private string nombreMesa;
        public FormularioMaterial(string nombreMesa)
        {
            InitializeComponent();
            MaterialesSeleccionados = new List<MaterialAlumno>();
            if (string.IsNullOrEmpty(nombreMesa))
            {
                MessageBox.Show("El nombre de la mesa no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Cerrar el formulario si el valor es inválido
                return;
            }
            this.nombreMesa = nombreMesa;
            this.ClientSize = new System.Drawing.Size(550, 450);

            // Crear los paneles
            Panel panel1 = new Panel();
            Panel panel2 = new Panel();
            Panel panel3 = new Panel();

            // Configurar los paneles
            panel1.Location = new Point(50, 100);
            panel1.Size = new Size(550, 100); // Ajustar el tamaño del panel para que los RadioButton sean visibles

            panel2.Location = new Point(50, 200);
            panel2.Size = new Size(550, 100);

            panel3.Location = new Point(50, 300);
            panel3.Size = new Size(550, 100);

            // Agregar los RadioButton a los paneles y ajustar sus posiciones
            rbPantallaCasa.Location = new Point(10, 12); // Posición relativa dentro del panel
            rbPantallaAula.Location = new Point(400,12);
            panel1.Controls.Add(rbPantallaCasa);
            panel1.Controls.Add(rbPantallaAula);

            rbRatonCasa.Location = new Point(10, 12);
            rbRatonAula.Location = new Point(400, 12);
            panel2.Controls.Add(rbRatonCasa);
            panel2.Controls.Add(rbRatonAula);

            rbTecladoCasa.Location = new Point(10, 12);
            rbTecladoAula.Location = new Point(400, 12);
            panel3.Controls.Add(rbTecladoCasa);
            panel3.Controls.Add(rbTecladoAula);

            // Agregar los paneles al formulario
            this.Controls.Add(panel1);
            this.Controls.Add(panel2);
            this.Controls.Add(panel3);
        }

        private void FormularioMaterial_Load(object sender, EventArgs e)
        {
            // Activar los RadioButton por defecto
            rbPantallaAula.Checked = true;
            rbRatonAula.Checked = true;
            rbTecladoAula.Checked = true;
        }

        private void btGuardarMaterial_Click(object sender, EventArgs e)
        {
            if (MaterialesSeleccionados == null)
            {
                MaterialesSeleccionados = new List<MaterialAlumno>();
            }
            // 1. Determinar el valor de retorno según los RadioButton seleccionados
            bool pantallaResul = !rbPantallaCasa.Checked;
            bool ratonResul = !rbRatonCasa.Checked;
            bool tecladoResul = !rbTecladoCasa.Checked;

            MessageBox.Show(nombreMesa);

            // Limpiar la lista antes de agregar nuevos materiales
            MaterialesSeleccionados.Clear();

            // 2. Realizar la consulta a la tabla de materiales
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=master;Integrated Security=SSPI;";
            string query = @"
        SELECT 
            mat.tipo AS TipoMaterial,
            mat.descripcion AS DescripcionMaterial,
            mes.nombre AS NombreM
        FROM 
            Material mat
        INNER JOIN
            Mesas mes ON mat.mesa_id = mes.Id
        WHERE 
            mes.nombre = @NombreMesa;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreMesa", nombreMesa);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string NombreM = reader["NombreM"].ToString(); 
                            string tipoMaterial = reader["TipoMaterial"].ToString();
                            string descripcionMaterial = reader["DescripcionMaterial"].ToString();

                            // Crear el objeto MaterialAlumno según el tipo
                            if (tipoMaterial == "Pantalla")
                            {
                                MaterialesSeleccionados.Add(new MaterialAlumno
                                {
                                    NombreM = NombreM,
                                    TipoMaterial = tipoMaterial,
                                    DescripcionMaterial = pantallaResul ? descripcionMaterial : "Pantalla Casa"
                                });
                            }
                            else if (tipoMaterial == "Raton")
                            {
                                MaterialesSeleccionados.Add(new MaterialAlumno
                                {
                                    NombreM = NombreM,
                                    TipoMaterial = tipoMaterial,
                                    DescripcionMaterial = ratonResul ? descripcionMaterial : "Raton Casa"
                                });
                            }
                            else if (tipoMaterial == "Teclado")
                            {
                                MaterialesSeleccionados.Add(new MaterialAlumno
                                {
                                    NombreM = NombreM,
                                    TipoMaterial = tipoMaterial,
                                    DescripcionMaterial = tecladoResul ? descripcionMaterial : "Teclado Casa"
                                });
                            }
                        }
                    }
                }

                // (Opcional) Mostrar confirmación
                MessageBox.Show("Materiales guardados en la lista.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar los materiales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close(); 
        }
    }
}