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
            SolidBrush fondo = new SolidBrush(Color.Beige);
            gp.FillRectangle(fondo, 0, (heigth / 2)+20, width, heigth);

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

            Triangulo sandia = new Triangulo
            {

            };
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

