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
    public partial class ListadoAlumnosXDocente : Form
    {
        public ListadoAlumnosXDocente()
        {
            InitializeComponent();
        }

        private void ListadoAlumnosXDocente_Load(object sender, EventArgs e)
        {

        }
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

        private int obtenerIdProfesor()
        {
            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            //yyyy/MM/dd

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            int final = 0;
            string nombre = tbNombre.Text;
            string apellido = tbApellido.Text;


            // Construye la consulta SQL

            //string consulta = "select id from docente where nombre='"+nombre+ "' and apellido='"+apellido+"';";
            string consulta = "select id from docente where nombre=@Nombre and apellido=@Apellido;";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    // Añade parámetro para evitar SQL Injection
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Apellido", apellido);

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

        private int comprobarConsulta()
        {
            int resultado = 0;
            int idProfesor = obtenerIdProfesor();

            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            //LISTADO DE ALUMNOS X CURSO**********************************************************************

                string query = "SELECT estudiante.nombre Nombre, estudiante.apellido AS Apellido,estudiante.legajo as Legajo,curso.nombreCurso as Materia FROM estudiante JOIN alumnos_cursos ON estudiante.id = alumnos_cursos.alumno_id JOIN Curso ON alumnos_cursos.curso_id = curso.id WHERE curso.profesor_id = '" + idProfesor + "';";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            resultado = 1;

                        }
                        
                    }
                }
            }
            return resultado;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idProfesor = obtenerIdProfesor();

            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            //LISTADO DE ALUMNOS X CURSO**********************************************************************

            string query = "SELECT estudiante.nombre Nombre, estudiante.apellido AS Apellido,estudiante.legajo as Legajo,curso.nombreCurso as Materia FROM estudiante JOIN alumnos_cursos ON estudiante.id = alumnos_cursos.alumno_id JOIN Curso ON alumnos_cursos.curso_id = curso.id WHERE curso.profesor_id = '"+idProfesor+"';";

            if (ValidarCamposCompletos(this))
            {
                if (comprobarConsulta()>0)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                // Asignar los datos al DataGridView
                                dataGridView1.DataSource = dataTable;
                            }

                        }
                    }
                    //ajustamos la tabla al datagridview
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                else
                {
                    MessageBox.Show("Profesor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tbApellido_TextChanged(object sender, EventArgs e)
        {
            controlTodoTexto(tbApellido, tbApellido.Text);
        }
    }
}
