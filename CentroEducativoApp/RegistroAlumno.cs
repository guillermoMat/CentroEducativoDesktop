using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentroEducativoApp
{
    public partial class RegistroAlumno : Form
    {
        public RegistroAlumno()
        {
            InitializeComponent();
            CargarComboBoxConDatos();
        }

        private void RegistroAlumno_Load(object sender, EventArgs e)
        {

        }
        private MySqlConnection Conexion()
        {
            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            return connection;
        }

        private void CargarComboBoxConDatos()
        {
            string query = "SELECT id,nombre FROM `curso`";

            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = Conexion();
                MySqlDataReader reader = cmd.ExecuteReader();
                
                    while (reader.Read())
                    {
                    int id = Int32.Parse(reader.GetString("id"));
                        string nombre = reader.GetString("nombre");
                        // Agregar los datos al ComboBox
                        comboBox1.Items.Add(id +" - Curso: "+nombre);
                    }
                
                //Conexion().Close();
            }
            Conexion().Close();
        }

        //verificacion de que el bombobox no este vacio
        private void validarComboBox(System.Windows.Forms.ComboBox cb)
        {
            if (cb.SelectedIndex == -1)
            {
                errorProvider1.SetError(cb, "Seleccione alguna opción");
            }
            else
            {
                errorProvider1.SetError(cb, "");
            }
        }

        //validar que todos los campos tengan texto, no te deja procesar la transaccion
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
        //verificacion para nombre/apellido que lo ingresado sea solo texto y no este vacio
        private void controlTodoTexto(TextBox tb, string texto)
        {
            if (texto.Trim() != string.Empty && texto.All(Char.IsLetter))
            {
                //btnRegistrar.Enabled = true;
                errorProvider1.SetError(tb, "");
            }
            else
            {
                if (!(texto.All(Char.IsLetter)))
                {
                    errorProvider1.SetError(tb, "Solo debe contener letras");
                }
                else
                {
                    errorProvider1.SetError(tb, "Solo debe contener letras");
                }
            }
        }

        //verificacion de que el campo correo tenga la sintaxis correcta de un correo electronico
        public static bool EsCorreoValido(string correo)
        {
            // Expresión regular para validar una dirección de correo electrónico
            string patronCorreo = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            // Verificar si la dirección de correo coincide con el patrón
            return Regex.IsMatch(correo, patronCorreo);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposCompletos(this))
            {
                string nombre, apellido, usuario, contraseña, correo;
                string legajo;
                string cbSeleccionado = comboBox1.SelectedItem.ToString();
                int idCurso = Int32.Parse(cbSeleccionado[0].ToString());

                nombre = tbNombre.Text;
                apellido = tbApellido.Text;
                legajo = tbLegajo.Text;
                correo = tbCorreo.Text;
                usuario = tbUsuario.Text;
                contraseña = tbContraseña.Text;
                DateTime fecha = dateTimePicker1.Value;
                

                string bd = "login";
                string servidor = "localhost";
                string usuarioConexion = "root";
                string password = "";

                string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

                string consulta = "INSERT INTO `estudiante` (`id`, `nombre`, `apellido`, `fechaNacimiento`, `legajo`, `correo`, `usuario`, `contraseña`, `id_curso`) VALUES (NULL, '" + @nombre + "', '" + apellido + "', '" + fecha.ToString("yyyy/MM/dd") + 
                    "', '"+legajo+"', '"+correo+"', '"+usuario+"', '"+contraseña+"', '"+idCurso+"');";

                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(connectionString))
                    {
                        conexion.Open();

                        // Crea y ejecuta el comando SQL
                        using (MySqlCommand comando = new MySqlCommand(consulta))
                        {
                            //comando.Parameters.AddWithValue("@Nombre", nombre);
                            //comando.Parameters.AddWithValue("@Apellido", apellido);
                            //comando.Parameters.AddWithValue("@FechaNacimiento", fechaCorta);
                            comando.Connection = conexion;
                            comando.ExecuteNonQuery();

                            MessageBox.Show("Los datos se han guardado correctamente.", "Transacción Exitosa");
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al agregar un nuevo docente:\n" + ex.Message, "Fallo el sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Falta rellenar datos", "Error en el programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            controlTodoTexto(tbNombre,tbNombre.Text);
        }

        private void tbLegajo_TextChanged(object sender, EventArgs e)
        {
            validarCampoNumerico(tbLegajo);
        }

        private void tbApellido_TextChanged(object sender, EventArgs e)
        {
            controlTodoTexto(tbApellido,tbApellido.Text);
        }

        private void tbCorreo_TextChanged(object sender, EventArgs e)
        {
            if (EsCorreoValido(tbCorreo.Text))
            {
                //btnRegistrar.Enabled = true;
                errorProvider1.SetError(tbCorreo, "");
            }
            else
            {
                //btnRegistrar.Enabled = false;
                errorProvider1.SetError(tbCorreo, "Correo no valido");
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            validarComboBox(comboBox1);
        }
    }
}
