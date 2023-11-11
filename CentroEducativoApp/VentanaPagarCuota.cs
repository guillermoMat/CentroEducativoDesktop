using MySql.Data.MySqlClient;
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

namespace CentroEducativoApp
{
    public partial class VentanaPagarCuota : Form
    {
        public VentanaPagarCuota()
        {
            InitializeComponent();
            comboBox1.Items.Add("Enero");
            comboBox1.Items.Add("Febrero");
            comboBox1.Items.Add("Marzo");
            comboBox1.Items.Add("Abril");
            comboBox1.Items.Add("Mayo");
            comboBox1.Items.Add("Junio");
            comboBox1.Items.Add("Julio");
            comboBox1.Items.Add("Agosto");
            comboBox1.Items.Add("Septiembre");
            comboBox1.Items.Add("Octubre");
            comboBox1.Items.Add("Noviembre");
            comboBox1.Items.Add("Diciembre");
        }

        private void VentanaPagarCuota_Load(object sender, EventArgs e)
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
            string legajoEstudiante = textBox1.Text;
            

            // Construye la consulta SQL
            string consulta = "SELECT id FROM Estudiante WHERE legajo =@Legajo";

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarCamposCompletos(this))
            {
                int mes = mesSeleccionado();
                int idAlumno = obtenerIdEstudiante();
                DateTime fecha = dateTimePicker1.Value;
                double monto = double.Parse(textBox2.Text);


                string bd = "login";
                string servidor = "localhost";
                string usuarioConexion = "root";
                string password = "";

                //yyyy/MM/dd

                string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";


                string query = "INSERT INTO `pagos` (`id`, `cuota_id`, `alumno_id`, `fechaPago`, `montoPagado`) VALUES (NULL, '" + mes + "', '" + idAlumno + "', '" + fecha.ToString("yyyy/MM/dd") + "', '" + monto + "');";

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

                            MessageBox.Show("Pago de cuota realizado.", "Transacción Exitosa");
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al realizar el pago:\n" + ex.Message, "Falló el sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Falta rellenar datos", "Error en el programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //verificacion de que el campo sea numerico
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


        private int mesSeleccionado()
        {
            int idMes = 0;
            if (comboBox1.SelectedItem.ToString() == "Enero")
            {
                idMes = 1;
            }
            else if (comboBox1.SelectedItem.ToString() == "Febrero")
            {
                idMes = 4;
            }
            else if (comboBox1.SelectedItem.ToString() == "Marzo")
            {
                idMes = 5;
            }
            else if (comboBox1.SelectedItem.ToString() == "Abril")
            {
                idMes = 6;
            }
            else if (comboBox1.SelectedItem.ToString() == "Mayo")
            {
                idMes = 7;
            }
            else if (comboBox1.SelectedItem.ToString() == "Junio")
            {
                idMes = 8;
            }
            else if (comboBox1.SelectedItem.ToString() == "Julio")
            {
                idMes = 9;
            }
            else if (comboBox1.SelectedItem.ToString() == "Agosto")
            {
                idMes = 10;
            }
            else if (comboBox1.SelectedItem.ToString() == "Septiembre")
            {
                idMes = 11;
            }
            else if (comboBox1.SelectedItem.ToString() == "Octubre")
            {
                idMes = 12;
            }
            else if (comboBox1.SelectedItem.ToString() == "Noviembre")
            {
                idMes = 13;
            }
            else if (comboBox1.SelectedItem.ToString() == "Diciembre")
            {
                idMes = 14;
            }

            return idMes;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validarCampoNumerico(textBox2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validarCampoNumerico(textBox1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
