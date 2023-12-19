using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab6.Form1;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab6
{
    public partial class Form1 : Form
    {
        static List<PointD> list_points;
        List<Line> list_lines;
        List<Polygon> list_pols;
        Func<double, double, double> func;
        List<Line> figureLines;
        Polyhedra polyhedra;
        Vector view;

        public Form1()
        {
            InitializeComponent();
            ComboBoxInit();
            list_points = new List<PointD>();
            list_lines = new List<Line>();
            list_pols = new List<Polygon>();
            figureLines = new List<Line>();
            polyhedra = new Polyhedra();
            view = new Vector();

            InitializeMatrices();
            axonometric_button.Checked = true;
            redraw();

        }

        public class Vector 
        {
            public double x;
            public double y;
            public double z;

            public Vector() 
            {

            }

            public Vector(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public void Reverse()
            {
                x *= -1;
                y *= -1;
                z *= -1;
            }
        }
        
        
        public class PointD
        {
            public double x;
            public double y;
            public double z;

            public PointD(double xx, double yy, double zz)
            {
                x = xx;
                y = yy;
                z = zz;
            }
           
            public override string ToString()
            {
                return $"({x}, {y}, {z})"; 
            }
        }


        public class Line
        {

            public int a;
            public int b;
            public PointD pointD1;
            public PointD pointD2;
            public bool visible = true;

            public Line(int aa, int bb)
            {
                a = aa;
                b = bb;
            }

            public Line(PointD pointD1, PointD pointD2)
            {
                this.pointD1 = pointD1;
                this.pointD2 = pointD2;
            }
        }

        public class Polygon
        {

            public List<Line> lines;
            public List<PointD> points;
            public Vector normal;
            public Polygon(List<Line> l)
            {
                lines = l;
            }
            public Polygon(List<PointD> p)
            {

                points = p;
            }

            public void Calculate_Normal(PointD center) 
            {
                Vector t1 = new Vector(list_points[lines[0].b].x - list_points[lines[0].a].x, list_points[lines[0].b].y - list_points[lines[0].a].y, list_points[lines[0].b].z - list_points[lines[0].a].z);
                Vector t2 = new Vector(list_points[lines[1].b].x - list_points[lines[1].a].x, list_points[lines[1].b].y - list_points[lines[1].a].y, list_points[lines[1].b].z - list_points[lines[1].a].z);

                normal = new Vector(t1.y * t2.z - t1.z * t2.y, t1.z * t2.x - t1.x * t2.z, t1.x * t2.y - t1.y * t2.x);
                double dist = -1 * (list_points[lines[0].b].x * normal.x + list_points[lines[0].b].y * normal.y + list_points[lines[0].b].z * normal.z);
                
                if (OnSide(normal, dist, center, list_points[lines[0].b]))
                {
                    normal.Reverse();
                }
            }

        }

        static public bool OnSide(Vector normal, double dist, PointD center, PointD view)
        {
            double scal1 = (view.x + normal.x) * normal.x + (view.y + normal.y) * normal.y + (view.z + normal.z) * normal.z + dist;
            double scal2 = normal.x * center.x + normal.y * center.y + normal.z * center.z + dist;
            return scal1 * scal2 > 0;
        }

        public class Polyhedra
        {

            public List<Polygon> polygons;
            public PointD center;

            public Polyhedra() 
            {

            }

            public Polyhedra(List<Polygon> l)
            {
                polygons = l;
                Calculate_Center();
            }

            void Calculate_Center() 
            {
                double x = 0;
                double y = 0;
                double z = 0;
                int cnt = 0;
                foreach (var p in polygons) 
                {
                    foreach (var l in p.lines) 
                    {
                        cnt++;
                        x += list_points[l.a].x;
                        y += list_points[l.a].y;
                        z += list_points[l.a].z;
                    }
                }
                center = new PointD(x/cnt, y/cnt, z/cnt);
                foreach (var p in polygons) 
                {
                    p.Calculate_Normal(center);
                }
            }
        }


        double[,] matrixTranslation;
        double[,] matrixScale;
        double[,] matrixRotateX;
        double[,] matrixRotateZ;
        double[,] matrixRotateY;
        double[,] currentRotate;
        double[,] matrixResult;
        double[,] matrixAxonometric;
        double[,] matrixPerspective;
        double[,] matrixMirror;
        double[,] matrixRotateLine;
        private void InitializeMatrices()
        {
            // Инициализация матрицы смещения (переноса)
            matrixTranslation = new double[4, 4]
            {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
            };

            // Инициализация матрицы масштабирования
            matrixScale = new double[4, 4]
            {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
            };

            // Инициализация матрицы поворота вокруг оси X
            matrixRotateX = new double[4, 4]
            {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
            };

            // Инициализация матрицы поворота вокруг оси Z
            matrixRotateZ = new double[4, 4]
            {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
            };

            // Инициализация матрицы поворота вокруг оси Y
            matrixRotateY = new double[4, 4]
            {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
            };

            // Инициализация матрицы результата (по умолчанию это матрица единичная)
            matrixResult = new double[4, 4]
            {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
            };

            // Инициализация матрицы аксонометрической проекции
            matrixAxonometric = new double[4, 4]
            {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 0, 0 },
        { 0, 0, 0, 1 }
            };


            matrixPerspective = new double[4, 4]
            {
    { 1, 0, 0, 0 },
    { 0, 1, 0, 0 },
    { 0, 0, 0,-0.1},
    { 0, 0, 0, 1 }
            };


            // Инициализация матрицы отражения (зеркальной проекции)
            matrixMirror = new double[4, 4]
            {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
            };


            matrixRotateLine = new double[4, 4] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 } };
        }
        double[,] multipleMatrix(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

        private void DrawLines(List<Line> lines, List<PointD> points, Graphics g)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Point a = new Point(pictureBox1.Width / 2 + (int)(points[lines[i].a].x), pictureBox1.Height / 2 + (int)(points[lines[i].a].y));
                Point b = new Point(pictureBox1.Width / 2 + (int)(points[lines[i].b].x), pictureBox1.Height / 2 + (int)(points[lines[i].b].y));
                g.DrawLine(new Pen(Color.Black, 2.0f), a, b);
            }
        }

        void Hexahedron()
        {

            pictureBox1.Refresh(); // Очистка рисунка

            List<PointD> cubePoints = new List<PointD>();
            cubePoints.AddRange(new List<PointD>()
            {
                new PointD(0, 0, 0),
                new PointD(0, 0, 1),
                new PointD(0, 1, 0),
                new PointD(0, 1, 1),
                new PointD(1, 0, 0),
                new PointD(1, 0, 1),
                new PointD(1, 1, 0),
                new PointD(1, 1, 1)
            });

            list_points = cubePoints; // Сохранение вершин куба
            List<Line> cubeLines = new List<Line>()
            {
                new Line(0, 1), new Line(1, 3), new Line(3, 2), new Line(2, 0),
                new Line(6, 7), new Line(7, 3), new Line(3, 2), new Line(2, 6),
                new Line(3, 7), new Line(7, 5), new Line(5, 1), new Line(1, 3),
                new Line(5, 7), new Line(7, 6), new Line(6, 4), new Line(4, 5),
                new Line(5, 4), new Line(4, 0), new Line(0, 1), new Line(1, 5),
                new Line(0, 2), new Line(2, 6), new Line(6, 4), new Line(4, 0)
            };

            list_lines.Clear();
            list_lines.AddRange(cubeLines);

            list_pols.Clear();

            list_pols.Add(new Polygon(new List<Line>() { cubeLines[0], cubeLines[1], cubeLines[2], cubeLines[3] }));
            list_pols.Add(new Polygon(new List<Line>() { cubeLines[4], cubeLines[5], cubeLines[6], cubeLines[7] }));
            list_pols.Add(new Polygon(new List<Line>() { cubeLines[8], cubeLines[9], cubeLines[10], cubeLines[11] }));
            list_pols.Add(new Polygon(new List<Line>() { cubeLines[12], cubeLines[13], cubeLines[14], cubeLines[15] }));
            list_pols.Add(new Polygon(new List<Line>() { cubeLines[16], cubeLines[17], cubeLines[18], cubeLines[19] }));
            list_pols.Add(new Polygon(new List<Line>() { cubeLines[20], cubeLines[21], cubeLines[22], cubeLines[23] }));
            var g = Graphics.FromHwnd(pictureBox1.Handle);

            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x *= 100; // Масштабирование координат
                list_points[i].y *= 100;
                list_points[i].z *= 100;
            }

            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x -= 100;

            }

            polyhedra = new Polyhedra(list_pols);

            DrawLines(list_lines, list_points, g); // Отрисовка куба

        }
        void Tetrahedron()
        {
            pictureBox1.Refresh(); // Очистка рисунка

            List<PointD> tetraPoints = new List<PointD>()
            {
                new PointD(2, 2, 2),
                new PointD(2, 0, 0),
                new PointD(0, 2, 0),
                new PointD(0, 0, 2)
            };
            list_points = tetraPoints;
            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x *= 50; 
                list_points[i].y *= 50;
                list_points[i].z *= 50;
            }

            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x -= 100;

            }

            List<Line> tetraLines = new List<Line>()
            {
                new Line(0, 2), new Line(2, 1), new Line(1, 0),
                new Line(3, 0), new Line(0, 1), new Line(1, 3),
                new Line(3, 1), new Line(1, 2), new Line(2, 3),
                new Line(2, 0), new Line(0, 3), new Line(3, 2)
            };

            list_lines.Clear();
            list_lines = tetraLines;
            list_pols.Clear();

            Polygon tetraPolygon = new Polygon(new List<Line>() { tetraLines[0], tetraLines[1], tetraLines[2] });
            list_pols.Add(tetraPolygon);

            tetraPolygon = new Polygon(new List<Line>() { tetraLines[3], tetraLines[4], tetraLines[5] });
            list_pols.Add(tetraPolygon);

            tetraPolygon = new Polygon(new List<Line>() { tetraLines[6], tetraLines[7], tetraLines[8] });
            list_pols.Add(tetraPolygon);

            tetraPolygon = new Polygon(new List<Line>() { tetraLines[9], tetraLines[10], tetraLines[11] });
            list_pols.Add(tetraPolygon);

            var g = Graphics.FromHwnd(pictureBox1.Handle);

            polyhedra = new Polyhedra(list_pols);

            DrawLines(list_lines, list_points, g);
        }
        void Octahedron()
        {
            pictureBox1.Refresh();

            List<PointD> octaPoints = new List<PointD>()
            {
                new PointD(0, 1, 1),
                new PointD(1, 2, 1),
                new PointD(1, 1, 2),
                new PointD(2, 1, 1),
                new PointD(1, 0, 1),
                new PointD(1, 1, 0)
            };

            list_points = octaPoints;
            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x *= 75;
                list_points[i].y *= 75;
                list_points[i].z *= 75;
            }

            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x -= 150;

            }

            List<Line> octaLines = new List<Line>()
            {
                new Line(0,  2), new Line(2, 1), new Line(1, 0),
                new Line(1,  3), new Line(3, 2), new Line(2, 1),
                new Line(3,  4), new Line(4, 2), new Line(2, 3),
                new Line(4,  0), new Line(0, 2), new Line(2, 4),

                new Line(1,  5), new Line(5, 3), new Line(3, 1),
                new Line(3,  5), new Line(5, 4), new Line(4, 3),
                new Line(4,  5), new Line(5, 0), new Line(0, 4),
                new Line(0,  5), new Line(5, 1), new Line(1, 0)
            };

            list_lines.Clear();
            list_lines = octaLines;

            list_pols.Clear();

            List<Polygon> octaPolygons = new List<Polygon>()
            {
                new Polygon(new List<Line>() { octaLines[0], octaLines[1], octaLines[2] }),
                new Polygon(new List<Line>() { octaLines[3], octaLines[4], octaLines[5] }),
                new Polygon(new List<Line>() { octaLines[6], octaLines[7], octaLines[8] }),
                new Polygon(new List<Line>() { octaLines[9], octaLines[10], octaLines[11] }),
                new Polygon(new List<Line>() { octaLines[12], octaLines[13], octaLines[14] }),
                new Polygon(new List<Line>() { octaLines[15], octaLines[16], octaLines[17] }),
                new Polygon(new List<Line>() { octaLines[18], octaLines[19], octaLines[20] }),
                new Polygon(new List<Line>() { octaLines[21], octaLines[22], octaLines[23] })
            };

            list_pols = octaPolygons;
            var g = Graphics.FromHwnd(pictureBox1.Handle);

            polyhedra = new Polyhedra(list_pols);

            DrawLines(list_lines, list_points, g);

        }


        private void axonometric()
        {
            var sf = (float)Math.Sqrt(1.0 / 3.0);
            var cf = (float)Math.Sqrt(2.0 / 3.0);
            var sp = (float)Math.Sqrt(1.0 / 2.0);
            var cp = (float)Math.Sqrt(1.0 / 2.0);


            matrixAxonometric[0, 0] = cp;
            matrixAxonometric[0, 1] = sf * sp;
            matrixAxonometric[1, 1] = cf;
            matrixAxonometric[2, 0] = sp;
            matrixAxonometric[2, 1] = -sf * cp;
            matrixAxonometric[3, 3] = 1;


            int cathet = (int)Math.Sqrt(Math.Pow(pictureBox1.Width / 2, 2) / 3);
            /**/
            int shiftX = 0; // Смещение по оси X
            int shiftY = 0; // Смещение по оси Y

            Point xyz = new Point(pictureBox1.Width / 2 + shiftX, pictureBox1.Height / 2 + shiftY);
            Point x = new Point(pictureBox1.Width + shiftX, pictureBox1.Height / 2 + cathet + shiftY);
            Point y = new Point(0 + shiftX, pictureBox1.Height / 2 + cathet + shiftY);
            Point z = new Point(pictureBox1.Width / 2 + shiftX, 0 + shiftY);


            var g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(new Pen(Color.Red, 1), xyz, x);
            g.DrawLine(new Pen(Color.Green, 1), xyz, y);
            g.DrawLine(new Pen(Color.Blue, 1), xyz, z);

            ApplyTransformationAndDrawLines(matrixAxonometric);
        }
        public void parallperpective()
        {
            Point xy = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            Point x = new Point(pictureBox1.Width, pictureBox1.Height / 2);
            Point y = new Point(pictureBox1.Width / 2, 0);
            Pen axes = new Pen(Color.Black, 1);
            var g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(axes, xy, x);
            g.DrawLine(axes, xy, y);
            if (list_points.Count == 0)
                return;
            var newimage = new List<PointD>();
            double c = 20.0; // Параметр перспективы

            // Применение матрицы перспективной проекции к каждой точке
            for (int i = 0; i < list_points.Count; i++)
            {
                double[,] matrixPoint = new double[1, 4] { { list_points[i].x, list_points[i].y, list_points[i].z, 1.0 } };

                var res = multipleMatrix(matrixPoint, matrixPerspective);

                // Коррекция перспективы
                res[0, 0] /= 1.0 - res[0, 3] / c;
                res[0, 1] /= 1.0 - res[0, 3] / c;

                newimage.Add(new PointD(res[0, 0], res[0, 1], res[0, 2]));
            }

            g = Graphics.FromHwnd(pictureBox1.Handle);
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;
            for (int i = 0; i < list_lines.Count(); i++)
            {
                Point a = new Point((int)(newimage[list_lines[i].a].x) + centerX, (int)(newimage[list_lines[i].a].y) + centerY);
                Point b = new Point((int)(newimage[list_lines[i].b].x) + centerX, (int)(newimage[list_lines[i].b].y) + centerY);

                g.DrawLine(new Pen(Color.Black, 2.0f), a, b);
            }

        }

        private void ApplyTransformationAndDrawLines(double[,] transformationMatrix)
        {
            if (list_points.Count == 0)
                return;
            var newImage = new List<PointD>();
            for (int i = 0; i < list_points.Count; i++)
            {
                double[,] matrixPoint = new double[1, 4] { { list_points[i].x, list_points[i].y, list_points[i].z, 1.0 } };
                var result = multipleMatrix(matrixPoint, transformationMatrix);

                newImage.Add(new PointD(result[0, 0], result[0, 1], result[0, 2]));
            }

            var g = Graphics.FromHwnd(pictureBox1.Handle);
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            for (int i = 0; i < list_lines.Count(); i++)
            {
                if (!list_lines[i].visible)
                    continue;
                Point a = new Point((int)(newImage[list_lines[i].a].x) + centerX, (int)(newImage[list_lines[i].a].y) + centerY);
                Point b = new Point((int)(newImage[list_lines[i].b].x) + centerX, (int)(newImage[list_lines[i].b].y) + centerY);

                g.DrawLine(new Pen(Color.Black, 2.0f), a, b);
            }
        }

        private void buttonTranslite_Click(object sender, EventArgs e)
        {


            var g = Graphics.FromHwnd(pictureBox1.Handle);

            matrixTranslation[3, 0] = Convert.ToDouble(textBox1.Text);
            matrixTranslation[3, 1] = Convert.ToDouble(textBox2.Text);
            matrixTranslation[3, 2] = Convert.ToDouble(textBox3.Text);

            for (int i = 0; i < list_points.Count; i++)
            {
                double[,] matrixPoint = new double[1, 4] { { list_points[i].x, list_points[i].y, list_points[i].z, 1.0 } };

                var res = (multipleMatrix(matrixPoint, matrixTranslation));

                list_points[i] = new PointD(res[0, 0], res[0, 1], res[0, 2]);
            }

            redraw();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBoxAxis.SelectedIndex) {
                case 0://z

                    matrixMirror[0, 0] = 1;
                    matrixMirror[1, 1] = 1;
                    matrixMirror[2, 2] = -1;
                    break;
                case 1://y

                    matrixMirror[0, 0] = 1;
                    matrixMirror[1, 1] = -1;
                    matrixMirror[2, 2] = 1;
                    break;
                case 2://x
                    matrixMirror[0, 0] = -1;
                    matrixMirror[1, 1] = 1;
                    matrixMirror[2, 2] = 1;
                    break;
            }

        }

        private void buttonMirror_Click(object sender, EventArgs e)
        {
            if (comboBoxAxis.SelectedIndex == -1)
            {
                return;
            }

            for (int i = 0; i < list_points.Count; i++)
            {
                double[,] matrixPoint = new double[1, 4] { { list_points[i].x, list_points[i].y, list_points[i].z, 1.0 } };

                var res = (multipleMatrix(matrixPoint, matrixMirror));

                list_points[i] = new PointD(res[0, 0], res[0, 1], res[0, 2]);
            }

            redraw();
        }


        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            redraw();
        }

        private void redraw()
        {

            var g = Graphics.FromHwnd(pictureBox1.Handle);

            if (axonometric_button.Checked)
            {
                pictureBox1.Refresh();
                axonometric();
            }
            else if (perpective_button.Checked)
            {
                pictureBox1.Refresh();
                parallperpective();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                pictureBox1.Refresh();
                Hexahedron();
                redraw();
            }
            else if (radioButton2.Checked)
            {
                pictureBox1.Refresh();
                Tetrahedron();
                redraw();
            }
            else if (radioButton3.Checked)
            {
                pictureBox1.Refresh();
                Octahedron();
                redraw();
            }
           
        }

        public void  RotateX(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
               currentRotate = matrixRotateX;
                currentRotate[1, 1] = Math.Cos(angle * Math.PI / 180.0);
                currentRotate[1, 2] = Math.Sin(angle * Math.PI / 180.0);
                currentRotate[2, 1] = -Math.Sin(angle * Math.PI / 180.0);
                currentRotate[2, 2] = Math.Cos(angle * Math.PI / 180.0);
        }

        public void  RotateY(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            
                currentRotate = matrixRotateY;
                currentRotate[0, 0] = Math.Cos(angle * Math.PI / 180.0);
                currentRotate[0, 2] = -Math.Sin(angle * Math.PI / 180.0);
                currentRotate[2, 0] = Math.Sin(angle * Math.PI / 180.0);
                currentRotate[2, 2] = Math.Cos(angle * Math.PI / 180.0);
        }

        public void  RotateZ(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            currentRotate = matrixRotateZ;
                currentRotate[0, 0] = Math.Cos(angle * Math.PI / 180.0);
                currentRotate[0, 1] = Math.Sin(angle * Math.PI / 180.0);
                currentRotate[1, 0] = -Math.Sin(angle * Math.PI / 180.0);
                currentRotate[1, 1] = Math.Cos(angle * Math.PI / 180.0);
           
        }
        //поворот вокруг центра
        private void button1_Click(object sender, EventArgs e)
        {
            if (rotatex.Text.Length < 1 || rotatey.Text.Length < 1 || rotatez.Text.Length < 1)
                return;


            double xangle = Convert.ToDouble(rotatex.Text);
            double yangle = Convert.ToDouble(rotatey.Text);
            double zangle = Convert.ToDouble(rotatez.Text);

            if (xangle != 0)
            {
                RotateX(xangle);
            }
            else if (yangle != 0)
            {
                RotateY(yangle);
            }
            else if (zangle != 0)
            {
                RotateZ(zangle);        
            }
            for (int i = 0; i < list_points.Count; i++)
            {
                double[,] matrixPoint = new double[1, 4] { { list_points[i].x, list_points[i].y, list_points[i].z, 1.0 } };

                var res = (multipleMatrix(matrixPoint, currentRotate));

                list_points[i] = new PointD(res[0, 0], res[0, 1], res[0, 2]);
            }

            redraw();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rotate_around_line_Click(object sender, EventArgs e)
        {
            double angle = Convert.ToDouble(angle_text.Text) * Math.PI / 180;
            double x1 = Convert.ToDouble(x1_text.Text);
            double y1 = Convert.ToDouble(y1_text.Text);
            double z1 = Convert.ToDouble(z1_text.Text);
            double x2 = Convert.ToDouble(x2_text.Text);
            double y2 = Convert.ToDouble(y2_text.Text);
            double z2 = Convert.ToDouble(z2_text.Text);
            double Sin = Math.Sin(angle);
            double Cos = Math.Cos(angle);

            PointD vector = new PointD(x2 - x1, y2 - y1, z2 - z1);
            double length = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));

            double l = (double)(vector.x / length);
            double m = (double)(vector.y / length);
            double n = (double)(vector.z / length);

            matrixRotateLine[0, 0] = l * l + Cos * (1 - l * l);
            matrixRotateLine[0, 1] = l * (1 - Cos) * m + n * Sin;
            matrixRotateLine[0, 2] = l * (1 - Cos) * n - m * Sin;
            matrixRotateLine[0, 3] = 0;

            matrixRotateLine[1, 0] = l * (1 - Cos) * m - n * Sin;
            matrixRotateLine[1, 1] = m * m + Cos * (1 - m * m);
            matrixRotateLine[1, 2] = m * (1 - Cos) * n + l * Sin;
            matrixRotateLine[1, 3] = 0;

            matrixRotateLine[2, 0] = l * (1 - Cos) * n + m * Sin;
            matrixRotateLine[2, 1] = m * (1 - Cos) * n - l * Sin;
            matrixRotateLine[2, 2] = n * n + Cos * (1 - n * n);
            matrixRotateLine[2, 3] = 0;

            matrixRotateLine[3, 0] = 0;
            matrixRotateLine[3, 1] = 0;
            matrixRotateLine[3, 2] = 0;
            matrixRotateLine[3, 3] = 1;

            for (int i = 0; i < list_points.Count; i++)
            {
                double[,] matrixPoint = new double[1, 4] { { list_points[i].x, list_points[i].y, list_points[i].z, 1.0 } };

                var res = (multipleMatrix(matrixPoint, matrixRotateLine));

                list_points[i] = new PointD(res[0, 0], res[0, 1], res[0, 2]);
            }
            redraw();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double x_scale = Convert.ToDouble(xScale.Text);
            double y_scale = Convert.ToDouble(yScale.Text);
            double z_scale = Convert.ToDouble(zScale.Text);

            matrixScale[0, 0] = x_scale;
            matrixScale[1, 1] = y_scale;
            matrixScale[2, 2] = z_scale;

            for (int i = 0; i < list_points.Count; i++)
            {
                double[,] matrixPoint = new double[1, 4] { { list_points[i].x, list_points[i].y, list_points[i].z, 1.0 } };

                var res = (multipleMatrix(matrixPoint, matrixScale));

                list_points[i] = new PointD(res[0, 0], res[0, 1], res[0, 2]);
            }

            redraw();

        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|obj files (*.obj)|*.obj";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {

                        foreach (var point in list_points)
                        {
                            writer.WriteLine($"v {point.x / 50} {point.y / 50} {point.z / 50}");
                        }

                        foreach (var p in list_pols)
                        {
                            List<string> faceIndices = new List<string>();

                            foreach (var l in p.lines)
                            {
                                faceIndices.Add((l.a ).ToString()); 
                            }

                            string lineToWrite = $"f {string.Join(" ", faceIndices)}";
                            writer.WriteLine(lineToWrite);
                        }

                    }


                    MessageBox.Show("Файл успешно сохранен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении файла: " + ex.Message);
                }
            }
        }

        private void load_button_Click(object sender, EventArgs e)
        {
            list_lines.Clear();
            list_points.Clear();
            list_pols.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|obj files (*.obj)|*.obj";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string[] lines = File.ReadAllLines(filePath);


                    foreach (string line in lines)
                    {
                        string[] values = line.Split(' ');

                        if (values.Length > 0)
                        {
                            if (values[0] == "v" && values.Length >= 4)
                            {
                                double x, y, z;
                                if (double.TryParse(values[1], out x) && double.TryParse(values[2], out y) && double.TryParse(values[3], out z))
                                {
                                    list_points.Add(new PointD(x * 50, y * 50, z * 50));
                                }
                            }
                            else if (values[0] == "f" && values.Length >= 4)
                            {
                                List<Line> faceLines = new List<Line>();

                                for (int i = 1; i < values.Length - 1; i++)
                                {
                                    if (int.TryParse(values[i], out int a) && int.TryParse(values[i + 1], out int b))
                                    {
                                        faceLines.Add(new Line(a, b));
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ошибка в формате грани: " + line);
                                        break;
                                    }
                                }

                                faceLines.Add(new Line(int.Parse(values[values.Length - 1]), int.Parse(values[1])));
                                list_lines.AddRange(faceLines);
                                list_pols.Add(new Polygon(faceLines));
                            }
                        }
                    }

                    redraw();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int x) &&
                   int.TryParse(textBox8.Text, out int y) &&
                   int.TryParse(textBox9.Text, out int z))
            {
                listBox1.Items.Add(new PointD(x, y, z));
                textBox5.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения в поля координат.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            list_points.Clear();
            listBox1.Items.Clear();
            redraw();
            
        }
        
        private PointD RotatePoint(PointD point, int axis, double angle)
        {
            double newX = point.x, newY = point.y, newZ = point.z;

            switch (axis)
            {
                case 0: // X
                    newY = point.y * Math.Cos(angle) - point.z * Math.Sin(angle);
                    newZ = point.y * Math.Sin(angle) + point.z * Math.Cos(angle);
                    break;
                case 1: // Y
                    newX = point.x * Math.Cos(angle) + point.z * Math.Sin(angle);
                    newZ = -point.x * Math.Sin(angle) + point.z * Math.Cos(angle);
                    break;
                case 2: // Z
                    newX = point.x * Math.Cos(angle) - point.y * Math.Sin(angle);
                    newY = point.x * Math.Sin(angle) + point.y * Math.Cos(angle);
                    break;
                default:
                    throw new ArgumentException("Invalid axis");
            }

            return new PointD(newX, newY, newZ);
        }

     

        private void button3_Click(object sender, EventArgs e)
        {

            list_points.Clear();
            list_lines.Clear();
            list_pols.Clear();
            List<PointD> points = new List<PointD>();
            int count = int.Parse(textBox6.Text);
            foreach (var p in listBox1.Items)
            {
                PointD point = (PointD)p;
                point.x *= 50; 
                point.y *= 50; 
                point.z *= 50; 
                points.Add(point);
            }

            int axis = 0;
            switch (textBox7.Text)
            {
                case "OX":
                    axis = 0;
                    break;
                case "OY":
                    axis = 1;
                    break;
                case "OZ":
                    axis = 2;
                    break;
            }
            var g = Graphics.FromHwnd(pictureBox1.Handle);

            (list_points, list_lines) = CreateRotationFigurePointsAndLines(points, axis, count);

            DrawLines(list_lines, list_points, g);
        }

        private(List<PointD>, List<Line>) CreateRotationFigurePointsAndLines(List<PointD> basePoints, int axis, int partitions)
        {
            List<PointD> points = new List<PointD>(basePoints);
            List<PointD> rotatedPoints = new List<PointD>();
            for (int i = 1; i < partitions; ++i)
            {
                var angle = 2 * Math.PI * i / partitions;
                foreach (var point in basePoints)
                {
                    rotatedPoints.Add(RotatePoint(point, axis, angle));
                }
                points.AddRange(rotatedPoints);
                rotatedPoints.Clear();
            }

            var n = basePoints.Count;

            textBox4.Text = points.Count.ToString();
            for (int i = 0; i < partitions; ++i)
            {
                for (int j = 0; j < n - 1; ++j)
                {

                    int indexA = i * n + j;
                    int indexB = (i + 1) % partitions * n + j;
                    int indexC = (i + 1) % partitions * n + j + 1;
                    int indexD = i * n + j + 1;

                    figureLines.Add(new Line(indexA, indexB));
                    figureLines.Add(new Line(indexB, indexC));
                    figureLines.Add(new Line(indexC, indexD));
                    figureLines.Add(new Line(indexD, indexA));

                }
            }

            return (points, figureLines);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            FunctionDraw();
        }

        void FunctionDraw() 
        {
            list_lines.Clear();
            list_pols.Clear();
            list_points.Clear();
            double x0 = Convert.ToDouble(textBox10.Text);
            double x1 = Convert.ToDouble(textBox12.Text);
            double y0 = Convert.ToDouble(textBox11.Text);
            double y1 = Convert.ToDouble(textBox13.Text);
            int splits = int.Parse(textBox14.Text);
            double sdvx = (x1 - x0) / splits;
            double sdvy = (y1 - y0) / splits;
            for (int i = 0; i < splits; i++)
            {
                for (int j = 0; j < splits; j++)
                {
                    var tx = x0 + i * sdvx;
                    var ty = y0 + j * sdvy;
                    PointD p = new PointD(tx, ty, func(tx,ty));
                    list_points.Add(p);
                }
            }
            for (int i = 0; i < splits - 1; i++)
            {
                int it0 = (splits * i);
                int it1 = (splits * (i + 1));
                for (int j = 0; j < splits - 1; j++)
                {
                    Line l0 = new Line(it0 + j, it0 + j + 1);
                    Line l1 = new Line(it0 + j + 1, it1 + j + 1);
                    Line l2 = new Line(it1 + j + 1, it1 + j);
                    Line l3 = new Line(it1 + j, it0 + j);
                    List<Line> lines_buf = new List<Line>() { l0, l1, l2, l3 };
                    list_lines.AddRange(lines_buf);
                    list_pols.Add(new Polygon(lines_buf));
                }
            } 
            redraw();
        }

        void ComboBoxInit()
        {
            comboBox1.Items.Add("5*(cos(x^2+y^2+1)/(x^2+y^2+1)+0.1)");
            comboBox1.Items.Add("sin(x)+cos(y)");
            comboBox1.Items.Add("sin(x)*cos(y)");
            comboBox1.Items.Add("x^2 + y^2");
            comboBox1.Items.Add("cos(x*x+y*y)/(x*x+y*y+1)");
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    func = (double x, double y) => { return 5 * (Math.Cos(x * x + y * y + 1) / (x * x + y * y + 1) + 0.1); };
                    break;
                case 1:
                    func = (double x, double y) => { return Math.Sin(x) + Math.Cos(y); };
                    break;
                case 2:
                    func = (double x, double y) => { return Math.Sin(x) * Math.Cos(y); };
                    break;
                case 3:
                    func = (double x, double y) => { return x*x + y*y; };
                    break;
                case 4:
                    func = (double x, double y) => { return Math.Cos(x * x + y * y) / (x * x + y * y + 1); };
                    break;


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            

            polyhedra = new Polyhedra(list_pols);
            PointD center = polyhedra.center;
            view = new Vector(Convert.ToDouble(textBox15.Text) - center.x, Convert.ToDouble(textBox16.Text) - center.y, Convert.ToDouble(textBox17.Text) - center.z);
            int i = 0;
            foreach (var p in list_pols)
            {
                double angle = (p.normal.x * view.x + p.normal.y * view.y + p.normal.z * view.z) / (Math.Sqrt(Math.Pow(p.normal.x, 2) + Math.Pow(p.normal.y, 2) + Math.Pow(p.normal.z, 2)) * Math.Sqrt(Math.Pow(view.x, 2) + Math.Pow(view.y, 2) + Math.Pow(view.z, 2)));
                double arc = Math.Acos(angle);
                if (arc * 180 / Math.PI > 90)
                {
                    for (int j = 0; j < list_pols[i].lines.Count; j++)
                    {
                        list_lines[list_pols[i].lines.Count * i + j].visible = false;
                    }
                }
                i++;
            }
            redraw();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list_lines.Count; i++)
            {
                list_lines[i].visible = true;
            }
            redraw();
        }
    }
}
