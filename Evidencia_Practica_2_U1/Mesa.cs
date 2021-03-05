using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencia_Practica_2_U1
{
    class Mesa
    {
        int cordX, cordY;
        Color mesa, sombra_Mesa;

        public Mesa(int xord = 300, int yord = 100) 
        {
            mesa = Color.Brown;
            sombra_Mesa = CambiarBrillo(mesa, -35);
            this.cordX = xord;
            this.cordY = yord;
        }

        public Mesa(Color color_Mesa, int ancho = 300, int alto = 100) 
        {
            mesa = color_Mesa;
            sombra_Mesa = CambiarBrillo(mesa, -35);
            this.cordX = ancho;
            this.cordY = alto;
        }

        public void DibujarMesa(ref Graphics gp, int width = 600, int heigth = 400)
        {
            int cenX = width / 2, cenY = heigth / 2;
            int posX = cenX - cordX / 2, posY = cenY - cordY / 2;

            SolidBrush relleno = new SolidBrush(mesa);
            SolidBrush sombra = new SolidBrush(sombra_Mesa);

            //
            SolidBrush fondo = new SolidBrush(Color.Bisque);
            gp.FillRectangle(fondo, 0, (heigth / 2)+20, width, heigth);

            //Patas izquierdas
            gp.FillRectangle(relleno, posX, posY+100, 25,110);
            // Sombra pata 1
            Point[] sombra1 = new Point[]{
                new Point(posX+35, posY+100),
                new Point(posX+25, posY+100),
                new Point(posX+25,posY+210),
                new Point(posX+35,posY+200)
            };
            gp.FillPolygon(sombra, sombra1);
            
            gp.FillRectangle(relleno, posX+50, posY + 80, 25, 80);
            
            // Sombra pata 2
            Point[] sombra2 = new Point[]{
                new Point(posX+50+25,posY+80),
                new Point(posX+50+25+5,posY+80),
                new Point(posX+50+25+5,posY+80+70),
                new Point(posX+50+25,posY+80+80)
            };
            
            gp.FillPolygon(sombra, sombra2);

            //Patas derechas
            gp.FillRectangle(relleno, posX+cordX-80, posY+100, 25, 110);
            // Sombra pata 3
            Point[] sombra3 = new Point[]{
                new Point(posX+cordX-80+25,posY+100),
                new Point(posX+cordX-80+10+25,posY+100),
                new Point(posX+cordX-80+35,posY+100+110-10),
                new Point(posX+cordX-80+25,posY+100+110),
            };
            gp.FillPolygon(sombra, sombra3);

            gp.FillRectangle(relleno, posX + cordX - 30, posY + 80, 25, 80);
            //// Sombra pata 4
            Point[] sombra4 = new Point[]{
                new Point(posX+cordX-30+25,posY+80),
                new Point(posX+cordX-30+25+5,posY+80),
                new Point(posX+cordX-30+25+5,posY+80+70),
                new Point(posX+cordX-30+25,posY+80+80)
            };
            gp.FillPolygon(sombra, sombra4);
            //A partir de aqui se empieza a dibujar la mesa
            gp.FillRectangle(relleno, posX, posY, cordX, cordY);

            Triangulo izq = new Triangulo
            (
                new Point(posX, posY),
                new Point(posX, posY + cordY),
                new Point(posX - 40, posY + cordY),
                mesa, mesa
            );

            Triangulo.Dibujar(ref gp, izq);

            Triangulo der = new Triangulo
            (
                new Point(posX + cordX, posY),
                new Point(posX + cordX + 40, posY),
                new Point(posX + cordX, posY + cordY),
                mesa, mesa
            );

            Triangulo.Dibujar(ref gp, der);

            gp.FillRectangle(sombra, posX - 40, posY + cordY, cordX + 40, 10);

            Point[] paralelogramo = new Point[]{
                new Point(posX + cordX + 40, posY),
                new Point(posX + cordX + 40, posY + 10),
                new Point(posX + cordX, posY + cordY + 10),
                new Point(posX + cordX, posY + cordY)
            };

            gp.FillPolygon(sombra, paralelogramo);
            //Aqui se termina de dibujar la mesa


            //aqui se empieza a dibujar la sandia triangular
            SolidBrush sandiaFV = new SolidBrush(Color.Green);
            SolidBrush sandiaFR = new SolidBrush(Color.Red);
            SolidBrush sandiaFFR = new SolidBrush(Color.DarkRed);
            SolidBrush sandiaSemillas = new SolidBrush(Color.Black);
            SolidBrush sandiaMordidas = new SolidBrush(Color.White);

            

            Point[] TrianguloSandia = new Point[]
            {
                new Point(115,cenY+15),
                new Point(225,cenY+ 15),
                new Point(175,cenY-60),
            };
            

            Point[] CurvaSombraTriangular = new Point[]
            {
                new Point(225-10,cenY+ 20),
                new Point(225+20+20-10,cenY+ 15-20),
                new Point(225+20+5-5,cenY+ 15),
            };
            
            Point[] TrianguloSandiaSombra = new Point[]
            {
                new Point(225,cenY+ 15),
                new Point(175,cenY-60),
                new Point(230,cenY+ 10),

            };
            gp.FillClosedCurve(sombra, CurvaSombraTriangular);
            gp.FillEllipse(sandiaFV, 115, cenY, 118, 30);
            gp.FillEllipse(sandiaFR, 115, cenY + 5, 110, 15);
            gp.FillPolygon(sandiaFFR, TrianguloSandiaSombra);
            gp.FillPolygon(sandiaFR, TrianguloSandia);
            // se dibujan las semillas
            gp.FillEllipse(sandiaSemillas, 170, cenY - 40, 5, 10);
            gp.FillEllipse(sandiaSemillas, 170, cenY - 20, 5, 10);
            gp.FillEllipse(sandiaSemillas, 155, cenY - 20, 5, 10);
            gp.FillEllipse(sandiaSemillas, 185, cenY - 20, 5, 10);
            gp.FillEllipse(sandiaSemillas, 145, cenY, 5, 10);
            gp.FillEllipse(sandiaSemillas, 162, cenY, 5, 10);
            gp.FillEllipse(sandiaSemillas, 179, cenY, 5, 10);
            gp.FillEllipse(sandiaSemillas, 196, cenY, 5, 10);

            //simulacion de mordidas
            gp.FillEllipse(relleno, 200, cenY - 30, 20, 20);
            gp.FillEllipse(relleno, 190, cenY - 40, 25, 25);
            gp.FillEllipse(relleno, 170, cenY - 50, 25, 25);
            gp.FillEllipse(relleno, 165, cenY - 61, 25, 25);
            //aqui se termina de dibijar la sandia triangular


            //Aqui Se dibuja la Sandia Circular
            SolidBrush SandiaCrV = new SolidBrush(Color.Green);
            SolidBrush SandiaCrB = new SolidBrush(Color.White);
            SolidBrush SandiaCrR = new SolidBrush(Color.Red);
            //Dibujo de Semillas
            SolidBrush Semilla = new SolidBrush(Color.Black);
            
            gp.FillEllipse(sombra, cenX+25, cenY - 120+45, 150, 150-45);

            gp.FillEllipse(SandiaCrV, cenX, cenY - 120, 150, 150);
            gp.FillEllipse(SandiaCrB, cenX + 10, cenY - 110, 130, 130);
            gp.FillEllipse(SandiaCrR, cenX + 15, cenY - 105, 120, 120);

            //Semillas
            gp.FillEllipse(Semilla, cenX + 60, cenY - 80, 10, 6);
            gp.FillEllipse(Semilla, cenX + 35, cenY - 50, 10, 6);
            gp.FillEllipse(Semilla, cenX + 90, cenY - 15, 10, 6);
            gp.FillEllipse(Semilla, cenX + 42, cenY - 10, 10, 6);
            gp.FillEllipse(Semilla, cenX + 105, cenY - 50, 6, 10);
            gp.FillEllipse(Semilla, cenX + 100, cenY - 85, 10, 6);
            gp.FillEllipse(Semilla, cenX + 65, cenY - 40, 6, 10);
            gp.FillEllipse(Semilla, cenX + 70, cenY - 65, 10, 6);
        }

        public Color CambiarBrillo(Color color, int factor) 
        {
            int R = (color.R + factor > 255) ? 255 : color.R + factor;
            int G = (color.G + factor > 255) ? 255 : color.G + factor;
            int B = (color.B + factor > 255) ? 255 : color.B + factor;
            
            return Color.FromArgb(R, G, B);
        }
    }
}

