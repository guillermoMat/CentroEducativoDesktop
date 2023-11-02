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
            cbDivision.Items.Add("A");
            cbDivision.Items.Add("B");

            cbCurso.Items.Add(1.1);
            cbCurso.Items.Add(1.2);
            cbCurso.Items.Add(1.3);
            cbCurso.Items.Add(1.4);
            cbCurso.Items.Add(2.1);
            cbCurso.Items.Add(2.2);
            cbCurso.Items.Add(2.3);

        }

        private void RegistroCurso_Load(object sender, EventArgs e)
        {

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposCompletos(this))
            {
                if (cbCurso.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbCurso, "Seleccione alguna opción");

                }else if (cbDivision.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbDivision, "Seleccione alguna opción");
                }
                else
                {
                    errorProvider1.SetError(cbCurso, "");
                    errorProvider1.SetError(cbDivision, "");


                    string curso, año;
                    char division;
                    int maxCant;


                    curso = cbCurso.SelectedItem.ToString();
                    division = Convert.ToChar(cbDivision.SelectedItem.ToString());
                    año = tbAño.Text;
                    maxCant = Int32.Parse(tbCantAlumn.Text);




                    string bd = "login";
                    string servidor = "localhost";
                    string usuarioConexion = "root";
                    string password = "";

                    //yyyy/MM/dd

                    string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";


                    string query = "INSERT INTO `curso` (`id`, `nombre`, `division`, `año_academico`, `maxCantAlumn`) VALUES (NULL, '" + curso + "', '" + division + "','" + año + "/01/01  ','" + maxCant + "');";

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            validarCampoNumerico(tbAño);
        }

        private void tbCantAlumn_TextChanged(object sender, EventArgs e)
        {
            validarCampoNumerico(tbCantAlumn);
        }

        private void cbCurso_TextChanged(object sender, EventArgs e)
        {
            validarComboBox(cbCurso);
        }

        private void cbDivision_TextChanged(object sender, EventArgs e)
        {
            validarComboBox(cbDivision);
        }
    }
}
