using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab6.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
        public class Tetrahedron
        {
            public Point3D[] Vertices { get; set; }
            public List<Edge> Edges { get; set; }

            public Tetrahedron()
            {
                // Задайте координаты вершин тетраэдра
                Vertices = new Point3D[4];
                Vertices[0] = new Point3D(0, 0, 0);
                Vertices[1] = new Point3D(1, 0, 0);
                Vertices[2] = new Point3D(0.5, Math.Sqrt(3) / 2, 0);
                Vertices[3] = new Point3D(0.5, Math.Sqrt(3) / 6, Math.Sqrt(6) / 3);

                // Создайте рёбра тетраэдра
                Edges = new List<Edge>();
                Edges.Add(new Edge(Vertices[0], Vertices[1]));
                Edges.Add(new Edge(Vertices[0], Vertices[2]));
                Edges.Add(new Edge(Vertices[0], Vertices[3]));
                Edges.Add(new Edge(Vertices[1], Vertices[2]));
                Edges.Add(new Edge(Vertices[1], Vertices[3]));
                Edges.Add(new Edge(Vertices[2], Vertices[3]));
            }
        }
        public class Hexahedron
        {
            public Point3D[] Vertices { get; set; }
            public List<Edge> Edges { get; set; }

            public Hexahedron()
            {
                Vertices = new Point3D[8];

                // Задайте координаты вершин гексаэдра
                Vertices[0] = new Point3D(0, 0, 0);
                Vertices[1] = new Point3D(1, 0, 0);
                Vertices[2] = new Point3D(1, 1, 0);
                Vertices[3] = new Point3D(0, 1, 0);
                Vertices[4] = new Point3D(0, 0, 1);
                Vertices[5] = new Point3D(1, 0, 1);
                Vertices[6] = new Point3D(1, 1, 1);
                Vertices[7] = new Point3D(0, 1, 1);

                Edges = new List<Edge>();

                // Создайте рёбра гексаэдра, соединяющие вершины
                Edges.Add(new Edge(Vertices[0], Vertices[1]));
                Edges.Add(new Edge(Vertices[1], Vertices[2]));
                Edges.Add(new Edge(Vertices[2], Vertices[3]));
                Edges.Add(new Edge(Vertices[3], Vertices[0]));

                Edges.Add(new Edge(Vertices[4], Vertices[5]));
                Edges.Add(new Edge(Vertices[5], Vertices[6]));
                Edges.Add(new Edge(Vertices[6], Vertices[7]));
                Edges.Add(new Edge(Vertices[7], Vertices[4]));

                Edges.Add(new Edge(Vertices[0], Vertices[4]));
                Edges.Add(new Edge(Vertices[1], Vertices[5]));
                Edges.Add(new Edge(Vertices[2], Vertices[6]));
                Edges.Add(new Edge(Vertices[3], Vertices[7]));
            }
        }
        private Tetrahedron tetrahedron;
        private bool drawTetrahedron = false;
        private Hexahedron hexahedron;
        private bool drawHexahedron = false;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (drawTetrahedron)
            {
                DrawTetrahedron(e.Graphics, tetrahedron);
            }
            if (checkBox2.Checked)
            {
                DrawHexahedron(e.Graphics, hexahedron);
            }
        }

        private void DrawTetrahedron(Graphics g, Tetrahedron tetrahedron)
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black);

            // Масштабирование и смещение для отображения на форме
            float scale = 100;
            float offsetX = pictureBox1.Width / 2;
            float offsetY = pictureBox1.Height / 2;
            float perspective = 100.0f; // Расстояние от камеры до экрана
            foreach (Edge edge in tetrahedron.Edges)
            {
                // Применение перспективной проекции к каждой вершине
                Point3D start = PerspectiveProjection(edge.Start, perspective);
                Point3D end = PerspectiveProjection(edge.End, perspective);
                Point startPoint = new Point((int)(edge.Start.X * scale + offsetX), (int)(edge.Start.Y * scale + offsetY));
                Point endPoint = new Point((int)(edge.End.X * scale + offsetX), (int)(edge.End.Y * scale + offsetY));
                g.DrawLine(pen, startPoint, endPoint);
            }
        }
        private void DrawHexahedron(Graphics g, Hexahedron hexahedronm)
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black);

            // Масштабирование и смещение для отображения на форме
            float scale = 100;
            float offsetX = pictureBox1.Width / 2;
            float offsetY = pictureBox1.Height / 2;
            float perspective = 100.0f; // Расстояние от камеры до экрана
            foreach (Edge edge in hexahedron.Edges)
            {
                // Применение аксонометрической проекции к каждой вершине
                Point3D start = axonometricProjection.Project(edge.Start);
                Point3D end = axonometricProjection.Project(edge.End);
                pictureBox1.Invalidate();
                Point startPoint = new Point((int)(edge.Start.X * scale + offsetX), (int)(edge.Start.Y * scale + offsetY));
                Point endPoint = new Point((int)(edge.End.X * scale + offsetX), (int)(edge.End.Y * scale + offsetY));
                g.DrawLine(pen, startPoint, endPoint);
            }
        }
        private void CheckBoxInGroup_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox clickedCheckBox = sender as System.Windows.Forms.CheckBox;

            // Отключите все остальные чекбоксы в группе
            foreach (Control control in groupBox1.Controls)
            {
                if (control is System.Windows.Forms.CheckBox && control != clickedCheckBox)
                {
                    System.Windows.Forms.CheckBox otherCheckBox = control as System.Windows.Forms.CheckBox;
                    otherCheckBox.Checked = false;
                }
            }

            // В зависимости от выбранного чекбокса, выполните соответствующие действия
            if (clickedCheckBox.Checked)
            {
                if (clickedCheckBox == checkBox1)
                {
                    drawTetrahedron = true;
                    drawHexahedron = false;
                }
                else if (clickedCheckBox == checkBox2)
                {
                    drawHexahedron = true;
                    drawTetrahedron = false;
                }
                pictureBox1.Invalidate();
            }
        }

        private AxonometricProjection axonometricProjection;


        public Form1()
        {
            InitializeComponent();
            tetrahedron = new Tetrahedron();
            hexahedron = new Hexahedron();
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
             foreach (Control control in groupBox1.Controls)
            {
                if (control is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox checkBox = control as System.Windows.Forms.CheckBox;
                    checkBox.CheckedChanged += CheckBoxInGroup_CheckedChanged;
                }
            }
            axonometricProjection = new AxonometricProjection(Math.PI / 8, Math.PI / 4); // Пример углов
      

        }

        private Point3D PerspectiveProjection(Point3D point, float perspective)
        {
            // Применение перспективной проекции к точке
            double projectedX = point.X / (1 + point.Z / perspective);
            double projectedY = point.Y / (1 + point.Z / perspective);

            return new Point3D(projectedX, projectedY, point.Z);
        }
        public class AxonometricProjection
        {
            // Углы аксонометрической проекции (в радианах)
            private double alpha; // Угол наклона к оси X
            private double beta;  // Угол наклона к оси Y

            // Матрица проекции
            private double[,] projectionMatrix;

            public AxonometricProjection(double alpha, double beta)
            {
                this.alpha = alpha;
                this.beta = beta;

                // Создаем матрицу проекции
                projectionMatrix = new double[3, 3];
                projectionMatrix[0, 0] = Math.Cos(beta);
                projectionMatrix[0, 1] = -Math.Sin(alpha) * Math.Sin(beta);
                projectionMatrix[0, 2] = 0;
                projectionMatrix[1, 0] = 0;
                projectionMatrix[1, 1] = Math.Cos(alpha);
                projectionMatrix[1, 2] = 0;
                projectionMatrix[2, 0] = Math.Sin(beta);
                projectionMatrix[2, 1] = Math.Sin(alpha) * Math.Cos(beta);
                projectionMatrix[2, 2] = 1;
            }

            public Point3D Project(Point3D point)
            {
                // Применяем матрицу проекции к точке
                double x = point.X * projectionMatrix[0, 0] + point.Y * projectionMatrix[0, 1] + point.Z * projectionMatrix[0, 2];
                double y = point.X * projectionMatrix[1, 0] + point.Y * projectionMatrix[1, 1] + point.Z * projectionMatrix[1, 2];
                double z = point.X * projectionMatrix[2, 0] + point.Y * projectionMatrix[2, 1] + point.Z * projectionMatrix[2, 2];

                return new Point3D(x, y, z);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
