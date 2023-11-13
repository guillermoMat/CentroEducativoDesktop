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
    public partial class horarioTragajoDocente : Form
    {
        public horarioTragajoDocente()
        {
            InitializeComponent();
        }

        public void recibirUsuario(string dato)
        {
            label1.Text = dato;
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
            
            string usuario = label1.Text;

            string consulta = "";
            // Construye la consulta SQL

            if (usuario.Contains("@"))
            {
                consulta = "SELECT id FROM docente WHERE correo =@Usuario";
            }

            else
            {
                consulta = "SELECT id FROM docente WHERE usuario =@Usuario";
            }
            

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    // Añade parámetro para evitar SQL Injection
                    comando.Parameters.AddWithValue("@Usuario", usuario);

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

        private void ListadoAlumnosParaDocente_Load(object sender, EventArgs e)
        {
            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            

            int idDocente = obtenerIdEstudiante();

            //LISTADO DE ALUMNOS X CURSO**********************************************************************

            string query = "SELECT curso.nombreCurso AS Curso, horarios.diaDeLaSemana as Fecha,time( Horarios.horaInicio) as 'Hora de entrada',time(Horarios.horaFinalizacion) as 'Hora de salida', aula.nombreAula AS Aula FROM estudiante JOIN Alumnos_Cursos ON estudiante.id = Alumnos_Cursos.alumno_id JOIN Curso ON Alumnos_Cursos.curso_id = Curso.ID JOIN horarios ON curso.id = horarios.curso_id JOIN Aula ON Curso.aula_id = aula.ID where curso.profesor_id="+idDocente+";";

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
    }
}
