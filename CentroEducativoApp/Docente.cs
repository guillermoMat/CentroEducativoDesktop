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
    public partial class Docente : Form
    {
        public Docente()
        {
            InitializeComponent();
        }

        public void recibirDato(string dato1)
        {
            label1.Text =dato1;
        }

        private void Docente_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 200)
            {
                button4.Text = "Mostrar Menu";
                panel1.Width = 0; // Ancho deseado del menú
            }
            else
            {
                button4.Text = "Ocultar Menu";

                panel1.Width = 200;
            }
        }

        private void btnListaEstudiantes_Click(object sender, EventArgs e)
        {
            using (ListadoAlumnosXDocente obj=new ListadoAlumnosXDocente())
            {
                obj.ShowDialog();
            }
        }

        private void btnHorarioTrabajo_Click(object sender, EventArgs e)
        {
            using (horarioTragajoDocente obj =new horarioTragajoDocente())
            {
                string dato = label1.Text;
                obj.recibirUsuario(dato);
                obj.ShowDialog();
            }

        }

        private void btnCargarNota_Click(object sender, EventArgs e)
        {
            using (CargarNotaEstudiante obj=new CargarNotaEstudiante())
            {
                string dato = label1.Text;
                obj.recibirUsuario(dato);
                obj.ShowDialog();
            }
        }
    }
}
