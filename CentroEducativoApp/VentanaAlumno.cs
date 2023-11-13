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
    public partial class VentanaAlumno : Form
    {
        public VentanaAlumno()
        {
            InitializeComponent();
        }

        public void recibirDato(string dato1)
        {
            label1.Text = "Bienvenido \n" + dato1;
        }

        private void VentanaAlumno_Load(object sender, EventArgs e)
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


        private void btnHorarios_Click(object sender, EventArgs e)
        {
            using (HorariosAlumno obj=new HorariosAlumno())
            {
                obj.ShowDialog();
            }
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            using (NotasHijos obj=new NotasHijos())
            {
                obj.ShowDialog();
            }
        }

        //private void btnPagarCuota_Click(object sender, EventArgs e)
        //{
        //    using (VentanaPagarCuota obj =new VentanaPagarCuota())
        //    {
        //        obj.ShowDialog();
        //    }
        //}
    }
}
