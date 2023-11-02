using CentroEducativoApp.DAO;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CentroEducativoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string servidor = "localhost";
            string usuario = "root";
            string passw = "";
            string baseDatos = "login";

            string cadenaConexion = "Server=" + servidor + ";Database=" + baseDatos + ";Uid=" + usuario + ";Pwd=" + passw + ";";


            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "SELECT * FROM autoridad WHERE usuario = @usuario AND contraseña = @contrasena";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", tbUsuario.Text);
                    comando.Parameters.AddWithValue("@contrasena", tbContraseña.Text);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.HasRows)
                        {
                            //MessageBox.Show("Inicio de sesión exitoso.");
                            
                            MessageBox.Show("Inicio de sesión exitoso.","Bienvenido",MessageBoxButtons.OK);

                            //this.Hide();  --> dps no se puede detener el programa

                            VentanaAutoridad nuevaVentana = new VentanaAutoridad();
                            nuevaVentana.ShowDialog();
                            


                        }
                        else
                        {
                            MessageBox.Show("Credenciales Incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                }
            }

        }

        
        



    }
}
