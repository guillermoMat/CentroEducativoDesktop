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
    public partial class ListaDeudasHijos : Form
    {
        public ListaDeudasHijos()
        {
            InitializeComponent();
        }

        private void ListaDeudasHijos_Load(object sender, EventArgs e)
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
            string legajoEstudiante = tbBuscarCuotasImpagas.Text;


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

        private void btnBuscarCuotas_Click(object sender, EventArgs e)
        {
            int idAlumno = obtenerIdEstudiante();

            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            //LISTADO DE ALUMNOS X CURSO**********************************************************************
            //int idBuscar = Int32.Parse(tbBuscarCuotasImpagas.Text);

            string query = "SELECT Cuota.mes as Mes, Cuota.FechaVencimiento as 'Fecha Vencimiento' FROM Cuota LEFT JOIN pagos ON Cuota.id = pagos.id AND pagos.alumno_id = " + idAlumno + " WHERE pagos.id IS NULL;";


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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
