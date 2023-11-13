using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CentroEducativoApp
{
    public partial class CargarNotaEstudiante : Form
    {
        public CargarNotaEstudiante()
        {
            InitializeComponent();
            CargarDatosComboBoxMateria();
            cbTrimestre.Items.Add(1);
            cbTrimestre.Items.Add(2);
            cbTrimestre.Items.Add(3);
        }

        public void recibirUsuario(string dato)
        {
            lblUsuario.Text = dato;
            lblUsuario.Visible = false;
        }
        private void validarCampoNumerico(System.Windows.Forms.TextBox tb)
        {
            int numero;

            if (int.TryParse(tb.Text, out numero))
            {
                // El valor en el TextBox es un número entero.
                // Puedes utilizar la variable "numero" para trabajar con el valor numérico.
                errorProvider1.SetError(tb, "");
            }
            else
            {
                errorProvider1.SetError(tb, "Este campo debe ser numerico");
            }
        }
        private bool ValidarCamposCompletos(Control control)
        {
            bool camposCompletos = true;

            foreach (Control c in control.Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                {
                    if (string.IsNullOrWhiteSpace((c as System.Windows.Forms.TextBox).Text))
                    {
                        camposCompletos = false;
                        break; // Puedes detener la verificación en el primer campo vacío que encuentres
                    }
                }
                else if (c.HasChildren)
                {
                    // Si el control contiene otros controles, verifica esos controles recursivamente
                    camposCompletos = ValidarCamposCompletos(c);
                    if (!camposCompletos) break;
                }
            }

            return camposCompletos;
        }

        private void CargarNotaEstudiante_Load(object sender, EventArgs e)
        {

        }
        private int obtenerIdEstudiante()
        {
            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            //yyyy/MM/dd

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            int final = 0;
            int legajoEstudiante =Convert.ToInt32(tbLegajoEstudiante.Text);
            


            string consulta = "SELECT id FROM estudiante WHERE legajo =@Legajo";
            // Construye la consulta SQL
            
                

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    // Añade parámetro para evitar SQL Injection
                    comando.Parameters.AddWithValue("@Legajo", legajoEstudiante);

                    try
                    {
                        conexion.Open();

                        // Ejecuta la consulta y obtén el resultado
                        object resultado = comando.ExecuteScalar();
                        final = Convert.ToInt32(resultado);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error2: {ex.Message}");
                    }
                }
            }

            return final;
        }

        private int obtenerIdDocente()
        {
            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            //yyyy/MM/dd

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            int final = 0;
            string consulta = "";
            //int legajoEstudiante = Convert.ToInt32(tbLegajoEstudiante.Text);
            string usuariDocente = lblUsuario.Text;
            if (usuariDocente.Contains('@'))
            {
                consulta = "SELECT id FROM docente WHERE correo =@Docente";
            }
            else
            {
                consulta = "SELECT id FROM docente WHERE usuario =@Docente";
            }


            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    // Añade parámetro para evitar SQL Injection
                    comando.Parameters.AddWithValue("@Docente", usuariDocente);

                    try
                    {
                        conexion.Open();

                        // Ejecuta la consulta y obtén el resultado
                        object resultado = comando.ExecuteScalar();
                        final = Convert.ToInt32(resultado);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error2: {ex.Message}");
                    }
                }
            }

            return final;
        }
        private void CargarDatosComboBoxMateria()
        {

            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";
            // Crear la conexión a la base de datos
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Crear el comando SQL
                    string consulta = "SELECT id,nombreCurso  FROM curso"; // Ajusta la consulta
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);

                    // Crear un adaptador de datos
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                    // Crear un conjunto de datos para almacenar los resultados
                    DataSet dataSet = new DataSet();

                    // Llenar el conjunto de datos con los resultados de la consulta
                    adaptador.Fill(dataSet, "Datos");

                    // Enlazar el conjunto de datos al ComboBox
                    cbMateria.DataSource = dataSet.Tables["Datos"];
                    cbMateria.DisplayMember = "nombreCurso"; // Ajusta según la estructura de tu tabla
                    cbMateria.ValueMember = "id"; // Ajusta según la estructura de tu tabla
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarCamposCompletos(this))
            {
                int idEstudiante = obtenerIdEstudiante();
                int idMateria = Convert.ToInt32(cbMateria.SelectedValue);
                int idDocente = obtenerIdDocente();
                int nota = Convert.ToInt32(tbNota.Text);

                object tri = cbTrimestre.SelectedItem;
                int trimestre = Convert.ToInt32(tri);

                string bd = "login";
                string servidor = "localhost";
                string usuarioConexion = "root";
                string password = "";

                //yyyy/MM/dd

                string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";


                string query = "INSERT INTO `notas` (`id`, `estudiante_id`, `materia_id`, `docente_id`, `trimestre`, `nota`) VALUES (NULL, " + idEstudiante + ", " + idMateria + "," + idDocente + "," + trimestre + ", " + nota + ");";

                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(connectionString))
                    {
                        conexion.Open();

                        // Crea y ejecuta el comando SQL
                        using (MySqlCommand comando = new MySqlCommand(query))
                        {
                            comando.Connection = conexion;
                            comando.ExecuteNonQuery();

                            MessageBox.Show("Nota Cargada Correctamente.", "Transacción Exitosa");
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al cargar nota:\n" + ex.Message, "Falló el sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Falta rellenar datos", "Error en el programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbLegajoEstudiante_TextChanged(object sender, EventArgs e)
        {
            validarCampoNumerico(tbLegajoEstudiante);
        }

        private void tbNota_TextChanged(object sender, EventArgs e)
        {
            validarCampoNumerico(tbNota);
        }
    }
}
