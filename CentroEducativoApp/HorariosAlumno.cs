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
    public partial class HorariosAlumno : Form
    {
        public HorariosAlumno()
        {
            InitializeComponent();
            CargarDatosComboBoxMateria();
        }

        private void HorariosAlumno_Load(object sender, EventArgs e)
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
        //private void btnBuscar_Click(object sender, EventArgs e)
        //{

        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    validarCampoNumerico(textBox1);
        //}
        private void CargarDatosComboBoxMateria()
        {

            string bd = "login";
            string servidor = "localhost";
            string usuarioConexion = "root";
            string password = "";

            string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";
            // Crear la conexión a la base de datos
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Crear el comando SQL
                    string consulta = "SELECT id,nombreCurso  FROM curso"; // Ajusta la consulta
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);

                    // Crear un adaptador de datos
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                    // Crear un conjunto de datos para almacenar los resultados
                    DataSet dataSet = new DataSet();

                    // Llenar el conjunto de datos con los resultados de la consulta
                    adaptador.Fill(dataSet, "Datos");

                    // Enlazar el conjunto de datos al ComboBox
                    comboBox1.DataSource = dataSet.Tables["Datos"];
                    comboBox1.DisplayMember = "nombreCurso"; // Ajusta según la estructura de tu tabla
                    comboBox1.ValueMember = "id"; // Ajusta según la estructura de tu tabla
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (ValidarCamposCompletos(this))
            {

                string bd = "login";
                string servidor = "localhost";
                string usuarioConexion = "root";
                string password = "";

                string connectionString = "Server=" + servidor + ";Database=" + bd + ";User ID=" + usuarioConexion + ";Password=" + password + ";";

                int idMateria = Convert.ToInt32(comboBox1.SelectedValue);

                //LISTADO DE ALUMNOS X CURSO**********************************************************************

                string query = "SELECT Curso.nombreCurso AS Curso, Horarios.diaDeLaSemana as Dia, Horarios.horaInicio as 'Hora de inicio', Horarios.horaFinalizacion as 'Hora de fin', Aula.nombreAula AS Aula FROM Curso JOIN Horarios ON Curso.ID = Horarios.curso_id JOIN Aula ON Curso.aula_id = Aula.ID WHERE Curso.ID = "+idMateria+";";

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
                MessageBox.Show("Falta rellenar datos", "Error en el programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
