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
    public partial class VentanaPadre_Madre : Form
    {
        public VentanaPadre_Madre()
        {
            InitializeComponent();
        }

        private void VentanaPadre_Madre_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDeudores_Click(object sender, EventArgs e)
        {
            using (ListaDeudasHijos obj = new ListaDeudasHijos())
            {
                obj.ShowDialog();
            }
                
        }

        private void btnPagarCuota_Click(object sender, EventArgs e)
        {
            using (VentanaPagarCuota obj=new VentanaPagarCuota())
            {
                obj.ShowDialog();
            }
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

        public void recibirDato(string dato1)
        {
            label1.Text ="Bienvenido \n"+ dato1;
        }

        private void verNotasHijo_Click(object sender, EventArgs e)
        {
            using (NotasHijos obj=new NotasHijos())
            {
                obj.ShowDialog();
            }
        }
    }
}
