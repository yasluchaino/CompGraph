using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {

        // Класс для точки
        public class Point3D
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public Point3D(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }

        // Класс для прямой
        public class Edge
        {
            public Point3D Start { get; set; }
            public Point3D End { get; set; }

            public Edge(Point3D start, Point3D end)
            {
                Start = start;
                End = end;
            }
        }

        // Класс для многоугольника (грани)
        public class Polygon
        {
            public List<Point3D> Vertices { get; set; }

            public Polygon(List<Point3D> vertices)
            {
                Vertices = vertices;
            }
        }

        // Класс для многогранника
        public class Polyhedron
        {
            public List<Polygon> Faces { get; set; }

            public Polyhedron(List<Polygon> faces)
            {
                Faces = faces;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
