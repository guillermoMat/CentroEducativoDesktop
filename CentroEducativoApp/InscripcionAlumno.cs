using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentroEducativoApp
{
    public partial class InscripcionAlumno : Form
    {
        public InscripcionAlumno()
        {
            InitializeComponent();
        }

        private void InscripcionAlumno_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)//   BTN REGISTRAR
        {
            int result=0;
            if (validadRadioButton() == true)
            {
                if (ValidarCamposCompletos(this))
                {
                    try
                    {
                        string bd = "login";
                        string servidor = "localhost";
                        string usuarioConexion = "root";
                        string password = "";

                        string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

                        int idEstudiante = 0;
                        string queryObtenerID = "select id from estudiante where legajo=" + tbLegajo.Text + "; ";

                        using (MySqlConnection conexion = new MySqlConnection(connectionString))
                        {
                            conexion.Open();

                            using (MySqlCommand cmd = new MySqlCommand(queryObtenerID, conexion))
                            {
                                idEstudiante = Convert.ToInt32(cmd.ExecuteScalar());

                            }
                        }

                        string consulta = "INSERT INTO Estudiante_Materia (estudiante_id, materia_id) " +
                            "SELECT " + idEstudiante + " AS EstudianteID, ID AS MateriaID " +
                            "FROM curso";

                        using (MySqlConnection conexion = new MySqlConnection(connectionString))
                        {
                            conexion.Open();

                            // Crea y ejecuta el comando SQL
                            using (MySqlCommand comando = new MySqlCommand(consulta))
                            {
                                comando.Connection = conexion;
                                result=comando.ExecuteNonQuery();

                                if (result>0)
                                {
                                    MessageBox.Show("Alumno inscripto para el año academico.", "Transacción Exitosa");
                                    this.Close();
                                }
                                

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (result==0)
                        {
                            MessageBox.Show("Alumno no encontrado.", "Error");
                        }
                        else
                        {
                            MessageBox.Show("Error al inscribir alumno, tipo:\n" + ex.Message, "Fallo el sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }


                }
                else
                {
                    MessageBox.Show("Falta rellenar datos", "Error en el programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        

        private void tbLegajo_TextChanged(object sender, EventArgs e)
        {
            validarCampoNumerico(tbLegajo);
        }
        private bool validadRadioButton()
        {
            bool result = false;
            if (radioButton1.Checked)
            {
                result = true;
                errorProvider1.SetError(radioButton1, "");
            }
            else if (radioButton1.Checked == false)
            {
                errorProvider1.SetError(radioButton1, "Seleccione opcion");
            }
            return result;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            validadRadioButton();
        }

        //private void btnBuscar_Click(object sender, EventArgs e)// BTN BUSCAR
        //{

        //    try
        //    {
        //        string bd = "login";
        //        string servidor = "localhost";
        //        string usuarioConexion = "root";
        //        string password = "";

        //        string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

        //        string queryObtenerID = "select id from estudiante where legajo=" + tblegajo2.Text + "; ";
        //        string queryDatosAlumno = "select id,nombre,apellido,legajo from estudiante where legajo=" + tblegajo2.Text + "; ";
        //        object idEstudiante;
        //        using (MySqlConnection connection = new MySqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            using (MySqlCommand cmd = new MySqlCommand(queryObtenerID, connection))
        //            {
        //                idEstudiante = cmd.ExecuteScalar();

        //            }
        //        }
        //        if (idEstudiante == null)
        //        {
        //            MessageBox.Show("Alumno no existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        else
        //        {
        //            using (MySqlConnection connection = new MySqlConnection(connectionString))
        //            {
        //                connection.Open();

        //                using (MySqlCommand cmd = new MySqlCommand(queryDatosAlumno, connection))
        //                {
        //                    MySqlDataReader reader = cmd.ExecuteReader();

        //                    if (reader.Read())
        //                    {

        //                        // Obtener los valores de las columnas
        //                        string id = reader.GetString("id");
        //                        string nombre = reader.GetString("nombre");
        //                        string apellido = reader.GetString("apellido");
        //                        string legajo = reader.GetString("legajo");

        //                        // Mostrar los valores en el Label
        //                        lblNombreEstudiante.Text = $"ID: {id} -  {nombre} {apellido} - Legajo: {legajo}";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Error en el codigo: " + ex.Message);
        //    }
        //}

    
    }
}
