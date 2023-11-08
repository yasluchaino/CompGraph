using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab6
{
    public partial class Form1 : Form
    {
        List<PointD> list_points;
        List<Line> list_lines;
        List<Polygon> list_pols;

        public Form1()
        {
            InitializeComponent();
            list_points = new List<PointD>();
            list_lines = new List<Line>();
            list_pols = new List<Polygon>();
            
            InitializeMatrices();
            axonometric_button.Checked = true;
            redraw();
           
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
        }


        public class Line
        {

            public int a;
            public int b;

            public Line(int aa, int bb)
            {
                a = aa;
                b = bb;
            }
        }
        
        public class Polygon
        {

            public List<Line> lines;

            public Polygon(List<Line> l)
            {
                lines = l;
            }
        }

        public class Polyhedra
        {

            public List<Polygon> polygons;

            public Polyhedra(List<Polygon> l)
            {
                polygons = l;
            }
        }

                                                                                      
        double[,] matrixTranslation;
        double[,] matrixScale ;
        double[,] matrixRotateX;
        double[,] matrixRotateZ;
        double[,] matrixRotateY ;
        double[,] currentRotate;
        double[,] matrixResult;
        double[,] matrixAxonometric;
        double[,] matrixPerspective;
        double[,] matrixMirror;
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

            // Инициализация матрицы текущего поворота (по умолчанию это матрица единичная)
            currentRotate = new double[4, 4]
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
    { 0, 0, 0, 0 },
    { 0, 0, 0, 0 },
    { 0, 0, 0,0 },
    { 0, 0, 0, 0 }
            };


            // Инициализация матрицы отражения (зеркальной проекции)
            matrixMirror = new double[4, 4]
            {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
            };
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
                Point a = new Point(pictureBox1.Width/2+(int)(points[lines[i].a].x), pictureBox1.Height / 2 + (int)(points[lines[i].a].y));
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
        new PointD(1, 1, 1),
        new PointD(1, 1, -1),
        new PointD(1, -1, 1),
        new PointD(1, -1, -1),
        new PointD(-1, 1, 1),
        new PointD(-1, 1, -1),
        new PointD(-1, -1, 1),
        new PointD(-1, -1, -1)
    });

            list_points = cubePoints; // Сохранение вершин куба

            List<Line> cubeLines = new List<Line>()
    {
        new Line(0, 1),
        new Line(0, 2),
        new Line(0, 4),
        new Line(1, 3),
        new Line(1, 5),
        new Line(2, 3),
        new Line(2, 6),
        new Line(3, 7),
        new Line(4, 5),
        new Line(4, 6),
        new Line(5, 7),
        new Line(6, 7)
    };

            list_lines.Clear();
            list_lines = cubeLines; // Сохранение рёбер куба

            list_pols.Clear(); // Очистка списка полигонов

            // Определение граней куба (полигонов)
            Polygon cubePolygon = new Polygon(new List<Line>() { cubeLines[0], cubeLines[1], cubeLines[2], cubeLines[3] });
            list_pols.Add(cubePolygon);

            cubePolygon = new Polygon(new List<Line>() { cubeLines[4], cubeLines[5], cubeLines[6], cubeLines[7] });
            list_pols.Add(cubePolygon);

            cubePolygon = new Polygon(new List<Line>() { cubeLines[8], cubeLines[9], cubeLines[10], cubeLines[11] });
            list_pols.Add(cubePolygon);

            var g = Graphics.FromHwnd(pictureBox1.Handle);

            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x *= 50; // Масштабирование координат
                list_points[i].y *= 50;
                list_points[i].z *= 50;
            }

            DrawLines(list_lines, list_points, g); // Отрисовка куба

        }
        void Tetrahedron()
        {
            pictureBox1.Refresh(); // Очистка рисунка

            List<PointD> tetraPoints = new List<PointD>();
            tetraPoints.AddRange(new List<PointD>()
    {
        new PointD(1, 1, 1),
        new PointD(1, -1, -1),
        new PointD(-1, 1, -1),
        new PointD(-1, -2, 1)
    });

            list_points = tetraPoints; // Сохранение вершин тетраэдра

            List<Line> tetraLines = new List<Line>()
    {
        new Line(0, 1),
        new Line(0, 2),
        new Line(0, 3),
        new Line(1, 2),
        new Line(1, 3),
        new Line(2, 3)
    };

            list_lines.Clear();
            list_lines = tetraLines; // Сохранение рёбер тетраэдра

            list_pols.Clear(); // Очистка списка полигонов

            // Определение граней тетраэдра (полигонов)
            Polygon tetraPolygon = new Polygon(new List<Line>() { tetraLines[0], tetraLines[1], tetraLines[2] });
            list_pols.Add(tetraPolygon);

            tetraPolygon = new Polygon(new List<Line>() { tetraLines[0], tetraLines[3], tetraLines[4] });
            list_pols.Add(tetraPolygon);

            tetraPolygon = new Polygon(new List<Line>() { tetraLines[1], tetraLines[3], tetraLines[5] });
            list_pols.Add(tetraPolygon);

            tetraPolygon = new Polygon(new List<Line>() { tetraLines[2], tetraLines[4], tetraLines[5] });
            list_pols.Add(tetraPolygon);

            var g = Graphics.FromHwnd(pictureBox1.Handle);

            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x *= 50; // Масштабирование координат
                list_points[i].y *= 50;
                list_points[i].z *= 50;
            }

            DrawLines(list_lines, list_points, g); // Отрисовка тетраэдра
        }


        void Octahedron()
        {
            pictureBox1.Refresh(); // Очистка рисунка

            List<PointD> octaPoints = new List<PointD>();
            octaPoints.AddRange(new List<PointD>()
    {
        new PointD(1, 0, 0),
        new PointD(-1, 0, 0),
        new PointD(0, 1, 0),
        new PointD(0, -1, 0),
        new PointD(0, 0, 1),
        new PointD(0, 0, -1)
    });

            list_points = octaPoints; // Сохранение вершин октаэдра

            List<Line> octaLines = new List<Line>()
    {
        new Line(0, 2),
        new Line(2, 1),
        new Line(1, 3),
        new Line(3, 0),
        new Line(0, 4),
        new Line(2, 4),
        new Line(1, 4),
        new Line(3, 4),
        new Line(0, 5),
        new Line(2, 5),
        new Line(1, 5),
        new Line(3, 5)
    };

            list_lines.Clear();
            list_lines = octaLines; // Сохранение рёбер октаэдра

            list_pols.Clear(); // Очистка списка полигонов

            // Определение граней октаэдра (полигонов)
            Polygon octaPolygon = new Polygon(new List<Line>() { octaLines[0], octaLines[1], octaLines[2], octaLines[3] });
            list_pols.Add(octaPolygon);

            octaPolygon = new Polygon(new List<Line>() { octaLines[4], octaLines[5], octaLines[6], octaLines[7] });
            list_pols.Add(octaPolygon);

            octaPolygon = new Polygon(new List<Line>() { octaLines[8], octaLines[9], octaLines[10], octaLines[11] });
            list_pols.Add(octaPolygon);

            var g = Graphics.FromHwnd(pictureBox1.Handle);

            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x *= 100; // Масштабирование координат
                list_points[i].y *= 100;
                list_points[i].z *= 100;
            }

            DrawLines(list_lines, list_points, g); // Отрисовка октаэдра
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
            Point xyz = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            Point x = new Point(pictureBox1.Width, pictureBox1.Height / 2 + cathet);
            Point y = new Point(pictureBox1.Width / 2, 0);
            Point z = new Point(0, pictureBox1.Height / 2 + cathet);

            var g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(new Pen(Color.Red, 1), xyz, x);
            g.DrawLine(new Pen(Color.Green, 1), xyz, y);
            g.DrawLine(new Pen(Color.Blue, 1), xyz, z);

            ApplyTransformationAndDrawLines(matrixAxonometric);
        }   
        public void parallperpective()
        {
    
            matrixPerspective[0, 0] = 1;
            matrixPerspective[1, 1] = 1;
            matrixPerspective[3, 2] = 1/-2000;
            matrixPerspective[3, 3] = 1;

            Point xy = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            Point x = new Point(pictureBox1.Width, pictureBox1.Height / 2);
            Point y = new Point(pictureBox1.Width / 2, 0);
            Pen axes = new Pen(Color.Black, 1);
            var g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(axes, xy, x);
            g.DrawLine(axes, xy, y);
           
            ApplyTransformationAndDrawLines(matrixPerspective);
        }

        private void ApplyTransformationAndDrawLines(double[,] transformationMatrix)
        {
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
           
            switch(comboBoxAxis.SelectedIndex){
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
        private void button1_Click(object sender, EventArgs e)
        {           
            if (angleRotate.Text.Length < 1)
                return;
            double teta = Convert.ToDouble(angleRotate.Text);
            if (xRotate.Checked)
            {
                currentRotate = matrixRotateX;
                currentRotate[1, 1] = Math.Cos(teta * Math.PI / 180.0);
                currentRotate[1, 2] = Math.Sin(teta * Math.PI / 180.0);
                currentRotate[2, 1] = -Math.Sin(teta * Math.PI / 180.0);
                currentRotate[2, 2] = Math.Cos(teta * Math.PI / 180.0);
            }
             if(yRotate.Checked) { 
                    currentRotate = matrixRotateY;
                    currentRotate[0, 0] = Math.Cos(teta * Math.PI / 180.0);
                    currentRotate[0, 2] = -Math.Sin(teta * Math.PI / 180.0);
                    currentRotate[2, 0] = Math.Sin(teta * Math.PI / 180.0);
                    currentRotate[2, 2] = Math.Cos(teta * Math.PI / 180.0);
                   }
             if(zRotate.Checked) { 
                    currentRotate = matrixRotateZ;
                    currentRotate[0, 0] = Math.Cos(teta * Math.PI / 180.0);
                    currentRotate[0, 1] = Math.Sin(teta * Math.PI / 180.0);
                    currentRotate[1, 0] = -Math.Sin(teta * Math.PI / 180.0);
                    currentRotate[1, 1] = Math.Cos(teta * Math.PI / 180.0);
                
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
    }
}
