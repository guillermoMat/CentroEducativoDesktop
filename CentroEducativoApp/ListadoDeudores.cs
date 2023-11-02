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
    public partial class ListadoDeudores : Form
    {
        public ListadoDeudores()
        {
            InitializeComponent();
        }

        private void ListadoDeudores_Load(object sender, EventArgs e)
        {
            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            //LISTADO DE ALUMNOS X CURSO**********************************************************************

            string query = "SELECT estudiante.Nombre, estudiante.Apellido,estudiante.id as ID,estudiante.legajo as Legajo FROM estudiante LEFT JOIN cuota ON estudiante.id = cuota.id LEFT JOIN pagos ON Cuota.id = pagos.id WHERE pagos.id IS NULL OR cuota.fechaVencimiento < NOW();";


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

        private void btnBuscarCuotas_Click(object sender, EventArgs e)
        {
            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

            //LISTADO DE ALUMNOS X CURSO**********************************************************************
            int idBuscar=Int32.Parse(tbBuscarCuotasImpagas.Text);

            string query = "SELECT Cuota.mes as Mes, Cuota.FechaVencimiento as 'Fecha Vencimiento' FROM Cuota LEFT JOIN pagos ON Cuota.id = pagos.id AND pagos.alumno_id = "+idBuscar+" WHERE pagos.id IS NULL;";


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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
