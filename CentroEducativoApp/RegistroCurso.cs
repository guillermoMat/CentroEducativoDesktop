using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CentroEducativoApp
{
    public partial class RegistroCurso : Form
    {
        public RegistroCurso()
        {
            InitializeComponent();

            CargarComboBoxAula();
            CargarComboBoxProfesor();


        }

        private void RegistroCurso_Load(object sender, EventArgs e)
        {

        }

        private void CargarComboBoxAula()
        {
            string query = "SELECT id,nombreAula FROM `aula`";

            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = Conexion();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int id = Int32.Parse(reader.GetString("id"));
                    string nombre = reader.GetString("nombreAula");
                    
                    // Agregar los datos al ComboBox
                    cbAula.Items.Add(id + " - Aula: " + nombre);
                }

                //Conexion().Close();
            }
            Conexion().Close();
        }

        private void CargarComboBoxProfesor()
        {
            string query = "SELECT id,nombre,apellido FROM `docente`";

            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = Conexion();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int id = Int32.Parse(reader.GetString("id"));
                    string nombre = reader.GetString("nombre");
                    string apellido = reader.GetString("Apellido");

                    // Agregar los datos al ComboBox
                    cbProfesor.Items.Add(id + " - Docente: " + nombre+" "+apellido);
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
                errorProvider1.SetError(cb,"Seleccione alguna opción");
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
        //private void validarCampoNumerico(System.Windows.Forms.TextBox tb)
        //{
        //    int numero;

        //    if (int.TryParse(tb.Text, out numero))
        //    {
        //        // El valor en el TextBox es un número entero.
        //        // Puedes utilizar la variable "numero" para trabajar con el valor numérico.
        //            errorProvider1.SetError(tb, "");
        //    }
        //    else
        //    {
        //        errorProvider1.SetError(tb, "Este campo debe ser numerico");
        //    }
        //}

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposCompletos(this))
            {
                if (cbAula.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbAula, "Seleccione alguna opción");

                }else if (cbProfesor.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbProfesor, "Seleccione alguna opción");
                }
                else
                {
                    errorProvider1.SetError(cbAula, "");
                    errorProvider1.SetError(cbProfesor, "");


                    string nombreMateria;
                    int aulaID, profesorID;


                    string cbSeleccionadoAula = cbAula.SelectedItem.ToString();
                    string cbSeleccionadoProfesor = cbProfesor.SelectedItem.ToString();

                    

                    aulaID = Int32.Parse(cbSeleccionadoAula[0].ToString());
                    profesorID = Int32.Parse(cbSeleccionadoProfesor[0].ToString());
                    nombreMateria = tbMateria.Text;


                    string bd = "login";
                    string servidor = "localhost";
                    string usuarioConexion = "root";
                    string password = "";

                    //yyyy/MM/dd

                    string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";


                    string query = "INSERT INTO `curso` (`id`, `nombreCurso`, `profesor_id`, `aula_id`) VALUES (NULL, '" + nombreMateria + "', '" + profesorID + "','" +  aulaID + "');";

                    try
                    {
                        using (MySqlConnection conexion = new MySqlConnection(connectionString))
                        {
                            conexion.Open();

                            // Crea y ejecuta el comando SQL
                            using (MySqlCommand comando = new MySqlCommand(query))
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

                        MessageBox.Show("Error al agregar un nuevo curso:\n" + ex.Message, "Falló el sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }


            }
            else
            {
                MessageBox.Show("Falta rellenar datos","Error en el programa",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

       

        private void cbCurso_TextChanged(object sender, EventArgs e)
        {
            validarComboBox(cbAula);
        }

        private void cbDivision_TextChanged(object sender, EventArgs e)
        {
            validarComboBox(cbProfesor);
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
        private void controlTodoTexto(System.Windows.Forms.TextBox tb, string texto)
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

        private void tbMateria_TextChanged(object sender, EventArgs e)
        {
            controlTodoTexto(tbMateria,tbMateria.Text);
        }
    }
}
