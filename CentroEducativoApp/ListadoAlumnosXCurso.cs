using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            traerListadoCursoXComboBox();

        }

        private void traerListadoCursoXComboBox()
        {
            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            string consulta = "SELECT id,nombreAula FROM `aula`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(consulta, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Llena el ComboBox con los valores
                        while (reader.Read())
                        {
                            cboxListadoCurso.Items.Add(reader["id"].ToString() + " - "+reader["nombreAula"].ToString());
                            
                        }
                    }
                }
            }


        }


        private void ListadoAlumnosXCurso_Load(object sender, EventArgs e)
        {
            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            //LISTADO DE ALUMNOS X CURSO**********************************************************************

            string query = "SELECT e.id,e.nombre,e.apellido,e.legajo,a.nombreAula FROM estudiante e JOIN estudiante_materia em ON e.id = em.estudiante_id JOIN curso c ON em.materia_id = c.id JOIN aula a ON c.aula_id = a.id;";

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


            string consulta = "SELECT SUM(cantidad_estudiantes) AS \"Total estudiantes\" FROM ( SELECT a.nombreAula AS nombre_aula, COUNT(DISTINCT e.id) AS cantidad_estudiantes FROM aula a JOIN curso c ON a.id = c.aula_id JOIN estudiante_materia em ON c.id = em.materia_id JOIN estudiante e ON em.estudiante_id = e.id GROUP BY a.nombreAula ) AS subconsulta;";

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


            string query2 = "SELECT a.nombreAula AS Aula, COUNT(e.id) AS cantidad_estudiantes FROM aula a JOIN curso c ON a.id = c.aula_id JOIN estudiante_materia em ON c.id = em.materia_id JOIN estudiante e ON em.estudiante_id = e.id GROUP BY a.nombreAula;";

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string opcSeleccionada = cboxListadoCurso.SelectedItem.ToString();

        string valor = opcSeleccionada.Substring(0,1);

            

            string query = "SELECT e.id,e.nombre,e.apellido,e.legajo,a.nombreAula as Aula FROM estudiante e JOIN estudiante_materia em ON e.id = em.estudiante_id JOIN curso c ON em.materia_id = c.id JOIN aula a ON c.aula_id = a.id where a.id=" + valor + ";";

            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            //LISTADO DE ALUMNOS X CURSO**********************************************************************

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);                ///ACA ESTA EL ERROR

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

            //cantidad alumnos

            string consulta = "SELECT COUNT(e.id) AS cantidad_estudiantes FROM aula a JOIN curso c ON a.id = c.aula_id JOIN estudiante_materia em ON c.id = em.materia_id JOIN estudiante e ON em.estudiante_id = e.id where a.id=" + valor + " GROUP BY a.nombreAula;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(consulta, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            string valor2 = reader.GetString(0);

                            labelValor.Text = valor2;
                        }
                    }
                }
            }

        }
    }
    }
