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

namespace CentroEducativoApp
{
    public partial class ListadoAlumnosXCurso : Form
    {
        public ListadoAlumnosXCurso()
        {
            InitializeComponent();
        }



        private void ListadoAlumnosXCurso_Load(object sender, EventArgs e)
        {
            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            //LISTADO DE ALUMNOS X CURSO**********************************************************************

            string query = "select curso.nombre as Curso,curso.division as División,estudiante.nombre as Nombre,estudiante.apellido as Apellido,estudiante.legajo as Legajo from curso inner join estudiante on curso.id = estudiante.id_curso;";

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

            //cantidad total


            string consulta = "SELECT SUM(subquery.`Cantidad de Alumnos`) AS 'Total de Alumnos' FROM ( SELECT COUNT(*) AS 'Cantidad de Alumnos' FROM curso INNER JOIN estudiante ON curso.id = estudiante.id_curso GROUP BY estudiante.id_curso ) AS subquery;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(consulta, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            string valor = reader.GetString(0);

                            labelValor.Text = valor;
                        }
                    }
                }
            }
                //CANTIDAD DE ALUMNOS X CURSO******************************************************************

                string query2 = "select curso.nombre as Curso,curso.division as División,COUNT(*) AS 'Cantidad de Alumnos' from curso inner join estudiante on curso.id = estudiante.id_curso GROUP by curso.nombre;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query2, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Asignar los datos al DataGridView
                            dataGridView2.DataSource = dataTable;
                        }
                    }
                }
                //ajustamos la tabla al datagridview
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }


            }
        }
    }
