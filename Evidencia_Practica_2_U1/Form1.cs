using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidencia_Practica_2_U1
{
    public partial class Form1 : Form
    {

        Graphics hoja;

        public Form1()
        {
            InitializeComponent();
            hoja = pnlFondo.CreateGraphics();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            Dibujar_Fondo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void Dibujar_Fondo() 
        {
            Fondo fondo = new Fondo(Color.Black, Color.Orange);
            fondo.DibujarFondo(ref hoja);
            Mesa mesa = new Mesa(Color.AntiqueWhite,400,120);
            mesa.DibujarMesa(ref hoja);
        }
    }
}
