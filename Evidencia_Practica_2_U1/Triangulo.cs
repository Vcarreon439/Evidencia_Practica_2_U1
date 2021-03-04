using System;
using System.Drawing;

namespace Evidencia_Practica_2_U1
{
    class Triangulo
    {
        Pen margen;
        SolidBrush relleno;

        Point vertice_X;
        Point vertice_Y;
        Point vertice_Z;

        public Point Vertice_Z { get => vertice_Z; set => vertice_Z = value; }
        public Point Vertice_Y { get => vertice_Y; set => vertice_Y = value; }
        public Point Vertice_X { get => vertice_X; set => vertice_X = value; }
        public SolidBrush Relleno { get => relleno; set => relleno = value; }
        public Pen Margen { get => margen; set => margen = value; }


        public Triangulo() { }

        public Triangulo(Point vertice_1, Point vertice_2, Point vertice_3)
        {
            Vertice_X = vertice_1;
            Vertice_Y = vertice_2;
            Vertice_Z = vertice_3;
        }

        public Triangulo(Point vertice_1, Point vertice_2, Point vertice_3, Color margen, Color relleno)
        {
            Vertice_X = vertice_1;
            Vertice_Y = vertice_2;
            Vertice_Z = vertice_3;

            this.Margen = new Pen(margen);
            this.Relleno = new SolidBrush(relleno);
        }

        public Triangulo(Point[] vertices, Color margen, Color relleno)
        {
            Vertice_X = vertices[0];
            Vertice_Y = vertices[1];
            Vertice_Z = vertices[2];

            this.Margen = new Pen(margen);
            this.Relleno = new SolidBrush(relleno);
        }

        public Triangulo(Point[] vertices)
        {
            Vertice_X = vertices[0];
            Vertice_Y = vertices[1];
            Vertice_Z = vertices[2];
        }

        public void CambiarMargen(Color color_Margen)
        {
            this.Margen = new Pen(color_Margen);
        }

        public void CambiarRelleno(Color color_Relleno)
        {
            this.Relleno = new SolidBrush(color_Relleno);
        }

        public Point[] ObtenerVertices()
        {
            Point[] triangulo = { Vertice_X, Vertice_Y, Vertice_Z };
            return triangulo;
        }

        static public Point CambiarVertice(int x, int y)
        {
            Point punto = new Point();
            punto.X = x;
            punto.Y = y;

            return punto;
        }

        static public void Dibujar(ref Graphics Papel, Triangulo triangulo) 
        {
            if (triangulo.Vertice_X == null | triangulo.Vertice_Y == null | triangulo.Vertice_Z == null)
                throw new NullReferenceException("Porfavor ingrese los valores del triangulo");
            if (triangulo.Relleno == null)
                throw new NullReferenceException($"Porfavor ingrese los valoes del triangulo Color:{triangulo.Relleno.ToString()}");
            if (triangulo.Margen == null)
                throw new NullReferenceException($"Porfavor ingrese los valoes del triangulo Color:{triangulo.Margen.ToString()}");

            Point[] vertices = { triangulo.Vertice_X, triangulo.Vertice_Y, triangulo.Vertice_Z };
            Papel.FillPolygon(triangulo.Relleno, vertices);
            Papel.DrawPolygon(triangulo.Margen, vertices);
        }
    }
}


