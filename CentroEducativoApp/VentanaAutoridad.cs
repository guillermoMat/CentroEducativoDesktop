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
    public partial class VentanaAutoridad : Form
    {
        public VentanaAutoridad()
        {
            InitializeComponent();

            panel1.Width = 200;
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

        private void btnRegistarDocente_Click(object sender, EventArgs e)
        {
            using (RegistroDocente obj = new RegistroDocente())
            {
                obj.ShowDialog();
            }
        }

        private void btnRegistrarCurso_Click(object sender, EventArgs e)
        {
            using (RegistroCurso obj = new RegistroCurso())
            {
                obj.ShowDialog();
            }
        }

        private void btnRegistrarAlumno_Click(object sender, EventArgs e)
        {
            using (RegistroAlumno obj=new RegistroAlumno())
            {
                obj.ShowDialog();
            }
        }

        private void btnListadoAlumXCurso_Click(object sender, EventArgs e)
        {
            using (ListadoAlumnosXCurso obj=new ListadoAlumnosXCurso())
            {
                obj.ShowDialog();
            }
        }

        private void btnDeudores_Click(object sender, EventArgs e)
        {
            using (ListadoDeudores obj=new ListadoDeudores())
            {
                obj.ShowDialog();
            }
        }

        private void btnPagarCuota_Click(object sender, EventArgs e)
        {
            using (VentanaPagarCuota obj = new VentanaPagarCuota())
            {
                obj.ShowDialog();
            }

        }
    }
}
