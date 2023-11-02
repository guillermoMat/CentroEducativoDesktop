using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentroEducativoApp
{
    public partial class RegistroDocente : Form
    {
        public RegistroDocente()
        {
            InitializeComponent();

            //if (ValidarCamposCompletos(this))//este desabilita el boton
            //{
            //    btnRegistrar.Enabled = true;
            //}
            //else
            //{
            //    btnRegistrar.Enabled = false;
            //}
            
        }

        
        //verificacion para nombre/apellido que lo ingresado sea solo texto y no este vacio
        private void controlTodoTexto(TextBox tb,string texto)
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

        //verificacion de que el campo no este vacio para mostrar mensaje de error
        private void validadTextoVacio(TextBox tb,string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                //btnRegistrar.Enabled = false;
                errorProvider1.SetError(tb,"Debe rellenar este campo");
            }
            else
            {
                //btnRegistrar.Enabled = true;
                errorProvider1.SetError(tb, "");
            }
        }
        //validar que todos los campos tengan texto, no te deja procesar la transaccion en un cond IF
        private bool ValidarCamposCompletos(Control control)
        {
            bool camposCompletos = true;

            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrWhiteSpace((c as TextBox).Text))
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            

            if (ValidarCamposCompletos(this))
            {

                string nombre, apellido, usuario, contraseña, correo;

                nombre = tbNombre.Text;
                apellido = tbApellido.Text;
                correo = tbCorreo.Text;
                usuario = tbUsuario.Text;
                contraseña = tbContra.Text;
                DateTime fecha = dateTimePicker1.Value;


                string bd = "login";
                string servidor = "localhost";
                string usuarioConexion = "root";
                string password = "";

                //yyyy/MM/dd

                string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";


                string query = "INSERT INTO `docente` (`id`, `nombre`, `apellido`, `fechaNacimiento`, `correo`, `usuario`, `contraseña`) VALUES (NULL, '" + @nombre + "', '" + apellido + "', '" + fecha.ToString("yyyy/MM/dd") + "', '" + correo + "','" + usuario +
                    "','" + contraseña + "');";

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

                            MessageBox.Show("Los datos se han guardado correctamente.","Transacción Exitosa");
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
                MessageBox.Show("Uno o más campos están vacíos. Complete los datos e intente de nuevo","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            controlTodoTexto(tbNombre,tbNombre.Text);
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
                errorProvider1.SetError(tbCorreo,"");
            }
            else
            {
                //btnRegistrar.Enabled = false;
                errorProvider1.SetError(tbCorreo, "Correo no valido");
            }
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {
            validadTextoVacio(tbUsuario,tbUsuario.Text);//este muestra error
        }

        private void tbContra_TextChanged(object sender, EventArgs e)
        {
            validadTextoVacio(tbContra,tbContra.Text);
        }

        private void RegistroDocente_Load(object sender, EventArgs e)
        {

        }
    }
}
