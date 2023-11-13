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

        private int validarTipoDeRol()
        {
            int autoridad = 0, padre = 0, alumno = 0, docente = 0;
            if (rbAutoridad.Checked)
            {
                return autoridad = 1;
            }else if (rbPadre.Checked)
            {
                return padre = 2;
            }else if (rbAlumno.Checked)
            {
                return alumno = 3;
            }else if (rbDocente.Checked)
            {
                return docente = 4;
            }
            else
            {
                return 0;
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


        private void button1_Click(object sender, EventArgs e)
        {
            string tabla = "";
            if (validarTipoDeRol()==1)
            {
                tabla = "autoridad";
            }else if (validarTipoDeRol() == 2)
            {
                tabla = "padres";
            }else if (validarTipoDeRol() == 3)
            {
                tabla = "estudiante";
            }else if (validarTipoDeRol() == 4)
            {
                tabla = "docente";
            }


                if (ValidarCamposCompletos(this))
            {
                string servidor = "localhost";
                string usuario = "root";
                string passw = "";
                string baseDatos = "login";

                string cadenaConexion = "Server=" + servidor + ";Database=" + baseDatos + ";Uid=" + usuario + ";Pwd=" + passw + ";";


                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string texto = tbUsuario.Text;
                    string consulta = "";

                    if (texto.Contains("@"))
                    {
                        consulta = "SELECT * FROM "+tabla+" WHERE correo = @correo AND contraseña = @contrasena";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@correo", tbUsuario.Text);
                            comando.Parameters.AddWithValue("@contrasena", tbContraseña.Text);

                            using (MySqlDataReader lector = comando.ExecuteReader())
                            {
                                if (lector.HasRows)
                                {
                                    MessageBox.Show("Inicio de sesión exitoso.", "Bienvenido", MessageBoxButtons.OK);

                                    //this.Hide();  --> dps no se puede detener el programa
                                    if (tabla=="autoridad")
                                    {
                                        using (VentanaAutoridad nuevaVentana = new VentanaAutoridad())
                                        {
                                            nuevaVentana.ShowDialog();
                                        }
                                    }else if (tabla=="padres")
                                    {
                                        using (VentanaPadre_Madre obj=new VentanaPadre_Madre())
                                        {
                                            obj.ShowDialog();
                                        }
                                    }else if (tabla=="estudiante")
                                    {

                                        using (VentanaAlumno obj=new VentanaAlumno())
                                        {
                                            obj.ShowDialog();
                                        }
                                    }else if (tabla=="docente")
                                    {
                                        using (Docente obj= new Docente())
                                        {
                                            obj.ShowDialog();
                                        }
                                    }
                                    



                                }
                                else
                                {
                                    MessageBox.Show("Credenciales Incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }
                            }
                        }
                    }
                    else
                    {
                        consulta = "SELECT * FROM "+tabla+" WHERE usuario = @usuario AND contraseña = @contrasena";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@usuario", tbUsuario.Text);
                            comando.Parameters.AddWithValue("@contrasena", tbContraseña.Text);

                            using (MySqlDataReader lector = comando.ExecuteReader())
                            {
                                if (lector.HasRows)
                                {
                                    //MessageBox.Show("Inicio de sesión exitoso.");

                                    MessageBox.Show("Inicio de sesión exitoso.", "Bienvenido", MessageBoxButtons.OK);

                                    if (tabla == "autoridad")
                                    {
                                        using (VentanaAutoridad nuevaVentana = new VentanaAutoridad())
                                        {
                                            string dato1 = tbUsuario.Text;

                                            nuevaVentana.recibirDato(dato1);
                                            nuevaVentana.ShowDialog();
                                        }
                                    }
                                    else if (tabla == "padres")
                                    {
                                        using (VentanaPadre_Madre obj = new VentanaPadre_Madre())
                                        {
                                            string dato1 = tbUsuario.Text;

                                            obj.recibirDato(dato1);

                                            obj.ShowDialog();
                                        }
                                    }
                                    else if (tabla == "estudiante")
                                    {

                                        using (VentanaAlumno obj = new VentanaAlumno())
                                        {
                                            string dato1 = tbUsuario.Text;

                                            obj.recibirDato(dato1);
                                            obj.ShowDialog();
                                        }
                                    }
                                    else if (tabla == "docente")
                                    {
                                        using (Docente obj = new Docente())
                                        {
                                            string dato1 = tbUsuario.Text;

                                            obj.recibirDato(dato1);
                                            obj.ShowDialog();
                                        }
                                    }



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
            else
            {
                MessageBox.Show("Falta rellenar datos", "Error en el programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
