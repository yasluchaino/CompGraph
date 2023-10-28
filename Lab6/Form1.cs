using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            public List<Polygon> Faces { get; set; }

            public Tetrahedron()
            {
                // Задайте координаты вершин тетраэдра
                Point3D vertexA = new Point3D(0, 0, 0);
                Point3D vertexB = new Point3D(1, 0, 0);
                Point3D vertexC = new Point3D(0.5, Math.Sqrt(3) / 2, 0);
                Point3D vertexD = new Point3D(0.5, Math.Sqrt(3) / 6, Math.Sqrt(6) / 3);

                // Создайте грани тетраэдра
                List<Polygon> faces = new List<Polygon>();
                faces.Add(new Polygon(new List<Point3D> { vertexA, vertexB, vertexC }));
                faces.Add(new Polygon(new List<Point3D> { vertexA, vertexC, vertexD }));
                faces.Add(new Polygon(new List<Point3D> { vertexA, vertexD, vertexB }));
                faces.Add(new Polygon(new List<Point3D> { vertexB, vertexC, vertexD }));

                Faces = faces;
            }
        }

        public class Hexahedron
        {
            public List<Polygon> Faces { get; set; }

            public Hexahedron()
            {
                // Задайте координаты вершин гексаэдра
                Point3D[] vertices = new Point3D[8];
                vertices[0] = new Point3D(0, 0, 0);
                vertices[1] = new Point3D(1, 0, 0);
                vertices[2] = new Point3D(1, 1, 0);
                vertices[3] = new Point3D(0, 1, 0);
                vertices[4] = new Point3D(0, 0, 1);
                vertices[5] = new Point3D(1, 0, 1);
                vertices[6] = new Point3D(1, 1, 1);
                vertices[7] = new Point3D(0, 1, 1);

                // Определите грани гексаэдра
                List<Polygon> faces = new List<Polygon>();

                // Основание
                List<Point3D> baseVertices = new List<Point3D> { vertices[0], vertices[1], vertices[2], vertices[3] };
                faces.Add(new Polygon(baseVertices));

                // Верхняя грань
                List<Point3D> topVertices = new List<Point3D> { vertices[4], vertices[5], vertices[6], vertices[7] };
                faces.Add(new Polygon(topVertices));

                // Боковые грани
                List<Point3D> side1Vertices = new List<Point3D> { vertices[0], vertices[4], vertices[7], vertices[3] };
                faces.Add(new Polygon(side1Vertices));

                List<Point3D> side2Vertices = new List<Point3D> { vertices[1], vertices[5], vertices[6], vertices[2] };
                faces.Add(new Polygon(side2Vertices));

                List<Point3D> side3Vertices = new List<Point3D> { vertices[0], vertices[1], vertices[5], vertices[4] };
                faces.Add(new Polygon(side3Vertices));

                List<Point3D> side4Vertices = new List<Point3D> { vertices[2], vertices[6], vertices[7], vertices[3] };
                faces.Add(new Polygon(side4Vertices));

                Faces = faces;
            }
        
        }
        public class Octahedron
        {
            public List<Polygon> Faces { get; set; }

            public Octahedron()
            {
                // Задайте координаты вершин октаэдра
                Point3D[] vertices = new Point3D[6];
                double a = 1.0; // Длина ребра октаэдра

                vertices[0] = new Point3D(0, 0, -a);
                vertices[1] = new Point3D(a, 0, 0);
                vertices[2] = new Point3D(0, 0, a);
                vertices[3] = new Point3D(-a, 0, 0);
                vertices[4] = new Point3D(0, -a, 0);
                vertices[5] = new Point3D(0, a, 0);

                // Определите грани октаэдра
                List<Polygon> faces = new List<Polygon>();

                // Грань 1 (нижний треугольник)
                List<Point3D> face1Vertices = new List<Point3D> { vertices[0], vertices[1], vertices[5] };
                faces.Add(new Polygon(face1Vertices));

                // Грань 2 (нижний треугольник)
                List<Point3D> face2Vertices = new List<Point3D> { vertices[1], vertices[2], vertices[5] };
                faces.Add(new Polygon(face2Vertices));

                // Грань 3 (нижний треугольник)
                List<Point3D> face3Vertices = new List<Point3D> { vertices[2], vertices[3], vertices[5] };
                faces.Add(new Polygon(face3Vertices));

                // Грань 4 (нижний треугольник)
                List<Point3D> face4Vertices = new List<Point3D> { vertices[3], vertices[0], vertices[5] };
                faces.Add(new Polygon(face4Vertices));

                // Грань 5 (верхний треугольник)
                List<Point3D> face5Vertices = new List<Point3D> { vertices[0], vertices[1], vertices[4] };
                faces.Add(new Polygon(face5Vertices));

                // Грань 6 (верхний треугольник)
                List<Point3D> face6Vertices = new List<Point3D> { vertices[1], vertices[2], vertices[4] };
                faces.Add(new Polygon(face6Vertices));

                // Грань 7 (верхний треугольник)
                List<Point3D> face7Vertices = new List<Point3D> { vertices[2], vertices[3], vertices[4] };
                faces.Add(new Polygon(face7Vertices));

                // Грань 8 (верхний треугольник)
                List<Point3D> face8Vertices = new List<Point3D> { vertices[3], vertices[0], vertices[4] };
                faces.Add(new Polygon(face8Vertices));

                Faces = faces;
            }
        }
            private Tetrahedron tetrahedron;
        private bool drawTetrahedron = false;
        private Hexahedron hexahedron;
        private bool drawHexahedron = false;
        private Octahedron octahedron;
        private bool drawOctahedron = false;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (drawTetrahedron)
            {
                DrawTetrahedron(e.Graphics, tetrahedron);
            }
            if (drawHexahedron)
            {
                DrawHexahedron(e.Graphics, hexahedron);
            }
            if (drawOctahedron)
            {
                DrawOctahedron(e.Graphics, octahedron);
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

            foreach (Polygon face in tetrahedron.Faces)
            {
                // Применение аксонометрической проекции к каждой вершине в грани
                List<Point> points = new List<Point>();
                foreach (Point3D vertex in face.Vertices)
                {
                    Point3D projectedVertex = PerspectiveProjection(vertex, perspective);
                    Point point = new Point((int)(projectedVertex.X * scale + offsetX), (int)(projectedVertex.Y * scale + offsetY));
                    points.Add(point);
                }

                g.DrawPolygon(pen, points.ToArray());
            }
        }

        private void DrawHexahedron(Graphics g, Hexahedron hexahedron)
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black);

            // Масштабирование и смещение для отображения на форме
            float scale = 100;
            float offsetX = pictureBox1.Width / 2;
            float offsetY = pictureBox1.Height / 2;

            foreach (Polygon face in hexahedron.Faces)
            {
                List<Point> points = new List<Point>();
                foreach (Point3D vertex in face.Vertices)
                {
                    // Примените перспективную проекцию (или аксонометрическую) к каждой вершине
                    Point3D projectedVertex = PerspectiveProjection(vertex, 100.0f);

                    // Отмасштабируйте и сместите вершину
                    int x = (int)(projectedVertex.X * scale + offsetX);
                    int y = (int)(projectedVertex.Y * scale + offsetY);
                    points.Add(new Point(x, y));
                }

                // Нарисуйте грань
                g.DrawPolygon(pen, points.ToArray());
            }
        }
        private void DrawOctahedron(Graphics g, Octahedron octahedron)
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black);

            // Масштабирование и смещение для отображения на форме
            float scale = 100;
            float offsetX = pictureBox1.Width / 2;
            float offsetY = pictureBox1.Height / 2;

            foreach (Polygon face in octahedron.Faces)
            {
                List<Point> points = new List<Point>();
                foreach (Point3D vertex in face.Vertices)
                {
                    // Примените аксонометрическую проекцию к каждой вершине
                    Point3D projectedVertex = axonometricProjection.Project(vertex);

                    // Отмасштабируйте и сместите вершину
                    int x = (int)(projectedVertex.X * scale + offsetX);
                    int y = (int)(projectedVertex.Y * scale + offsetY);
                    points.Add(new Point(x, y));
                }

                // Нарисуйте грань
                g.DrawPolygon(pen, points.ToArray());
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
                    drawOctahedron = false;
                }
                else if (clickedCheckBox == checkBox2)
                {
                    drawHexahedron = true;
                    drawTetrahedron = false;
                    drawOctahedron = false;
                }
                else if (clickedCheckBox == checkBox3)
                {
                    drawTetrahedron = false;
                    drawHexahedron = false;
                    drawOctahedron = true;

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
            octahedron = new Octahedron();
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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
