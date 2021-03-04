using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencia_Practica_2_U1
{
    class Fondo
    {
        Color Xtiles;
        Color Ytiles;
        int tileSize;

        /// <summary>
        /// 
        /// </summary>
        public Fondo(int size=20) 
        {
            this.tileSize = size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colors"></param>
        public Fondo(Color[] colors, int size=20) 
        {
            this.Xtiles = colors[0];
            this.Ytiles = colors[1];
            this.tileSize = size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public Fondo(Color color1, Color color2, int size = 20) 
        {
            this.Xtiles = color1;
            this.Ytiles = color2;
            this.tileSize = size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void CambiarColores(Color color1, Color color2, int size = 20) 
        {
            this.Xtiles = color1;
            this.Ytiles = color2;
            this.tileSize = size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lienzo"></param>
        public void DibujarFondo(ref Graphics lienzo, int width=600, int height=400) 
        {
            SolidBrush solidBrush = new SolidBrush(Xtiles);
            SolidBrush solidBrush2 = new SolidBrush(Ytiles);

            lienzo.FillRectangle(solidBrush2, 0, 0, width, height);

            int i = 0, j=0;
            while (i<height)
            {
                while (j<width)
                {
                    lienzo.FillRectangle(solidBrush, j, i, tileSize, tileSize);

                    j += 2 * tileSize;

                    if (j == width)
                    {
                        i += tileSize;
                        j = tileSize;
                    }

                    if (j == width + tileSize)
                    {
                        j = 0;
                        i += tileSize;
                    }

                    if (i == height)
                        break;
                }
            }

            MessageBox.Show("Done");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tilesize"></param>
        public void CambiarCuadrados(int tilesize) 
        {
            this.tileSize = tilesize;
        }

    }
}
