using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6_a
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
            Hexahedron();
            InitializeMatrices();
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

            // Инициализация матрицы перспективной проекции
            matrixPerspective = new double[4, 4]
            {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 0, -0.1 },
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
        private void comboBoxTypePolyhedra_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTypePolyhedra.SelectedIndex)
            {
                case 0:
                    {
                        Hexahedron();
                        break;
                    }
                case 1:
                    {
                        Tetrahedron();
                        break;
                    }
                case 2:
                    {
                        Octahedron();
                        break;
                    }                    
            }

        }
        private void DrawLines(List<Line> lines, List<PointD> points, Graphics g)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Point a = new Point((int)(points[lines[i].a].x), (int)(points[lines[i].a].y));
                Point b = new Point((int)(points[lines[i].b].x), (int)(points[lines[i].b].y));
                g.DrawLine(new Pen(Color.Black, 2.0f), a, b);
            }
        }

        void Hexahedron()
        {
            pictureBox1.Refresh();
            List<PointD> curPoints = new List<PointD>();
            curPoints.AddRange(new List<PointD>()
    {
        new PointD(0, 0, 0), new PointD(0, 0, 1), new PointD(0, 1, 0),
        new PointD(0, 1, 1), new PointD(1, 0, 0), new PointD(1, 0, 1), new PointD(1, 1, 0), new PointD(1, 1, 1)
    });

            list_points = curPoints;

            List<Line> curLines = new List<Line>()
    {
        new Line(0, 1), new Line(0, 2), new Line(0, 4),
        new Line(6, 7), new Line(6, 4), new Line(6, 2),
        new Line(3, 1), new Line(3, 2), new Line(3, 7),
        new Line(5, 7), new Line(5, 1), new Line(5, 4)
    };

            list_lines.Clear();
            list_lines = curLines;

            list_pols.Clear();

            Polygon curPolygon = new Polygon(new List<Line>() { curLines[1], curLines[5], curLines[4], curLines[2] });
            list_pols.Add(curPolygon);

            curPolygon = new Polygon(new List<Line>() { curLines[6], curLines[8], curLines[9], curLines[10] });
            list_pols.Add(curPolygon);

            curPolygon = new Polygon(new List<Line>() { curLines[2], curLines[11], curLines[10], curLines[0] });
            list_pols.Add(curPolygon); 
            curPolygon = new Polygon(new List<Line>() { curLines[8], curLines[7], curLines[5], curLines[3] });
            list_pols.Add(curPolygon);

            curPolygon = new Polygon(new List<Line>() { curLines[11], curLines[9], curLines[3], curLines[4] });
            list_pols.Add(curPolygon);

            curPolygon = new Polygon(new List<Line>() { curLines[0], curLines[6], curLines[7], curLines[1] });
            list_pols.Add(curPolygon);

            var g = Graphics.FromHwnd(pictureBox1.Handle);

            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x *= 200;
                list_points[i].y *= 200;
                list_points[i].z *= 200;
            }

            DrawLines(list_lines, list_points, g);
        

        }
        void Tetrahedron()
        {
            pictureBox1.Refresh();

            var templist = new List<PointD> { list_points[4], list_points[1], list_points[2], list_points[7], };
            list_points.Clear();
            list_points = templist;

            var cur_lines = new List<Line>() {new Line(0,  1), new Line(0, 2), new Line(0, 3), 
                                          new Line(1,  2), new Line(2, 3), new Line(3, 1) };
            list_lines.Clear();
            list_lines = cur_lines;

            list_pols.Clear();

            Polygon cur_pol = new Polygon(new List<Line>() { cur_lines[0], cur_lines[5], cur_lines[2] });
            list_pols.Add(cur_pol); 
            cur_pol = new Polygon(new List<Line>() { cur_lines[2], cur_lines[4], cur_lines[1] });
            list_pols.Add(cur_pol); 
            cur_pol = new Polygon(new List<Line>() { cur_lines[0], cur_lines[1], cur_lines[3] });
            list_pols.Add(cur_pol); 
            cur_pol = new Polygon(new List<Line>() { cur_lines[4], cur_lines[5], cur_lines[3] });
            list_pols.Add(cur_pol); 

            var g = Graphics.FromHwnd(pictureBox1.Handle);

            DrawLines(list_lines, list_points, g);

        }
        void Octahedron()
        {
            pictureBox1.Refresh();

            List<PointD> new_points = new List<PointD>();

            for (int i = 0; i < 6; i++)
            {
                Polygon cur = list_pols[i];
                double sum_x = 0;
                double sum_y = 0;
                double sum_z = 0;

                for (int j = 0; j < cur.lines.Count(); j++)
                {
                    sum_x += list_points[cur.lines[j].a].x;
                    sum_y += list_points[cur.lines[j].a].y;
                    sum_z += list_points[cur.lines[j].a].z;
                    
                    sum_x += list_points[cur.lines[j].b].x;
                    sum_y += list_points[cur.lines[j].b].y;
                    sum_z += list_points[cur.lines[j].b].z;

                }

                PointD new_p = new PointD(sum_x / 16.0, sum_y / 16.0, sum_z / 16.0);
                new_points.Add(new_p);
            }

            list_points = new_points;

            List<Line> cur_lines = new List<Line>()
               {new Line(0,  2), new Line(0, 4), new Line(0, 3), new Line(0, 5), 
                new Line(1,  2), new Line(1, 4), new Line(1, 3), new Line(1, 5), 
                new Line(4,  2), new Line(2, 5), new Line(5, 3), new Line(3, 4), 
               };

            list_lines.Clear();
            list_lines = cur_lines;
            list_pols.Clear();
            Polygon cur_pol = new Polygon(new List<Line>() { cur_lines[0], cur_lines[1], cur_lines[8] });
            list_pols.Add(cur_pol); 
            cur_pol = new Polygon(new List<Line>() { cur_lines[11], cur_lines[2], cur_lines[1] });
            list_pols.Add(cur_pol); 
            cur_pol = new Polygon(new List<Line>() { cur_lines[10], cur_lines[3], cur_lines[2] });
            list_pols.Add(cur_pol); 
            cur_pol = new Polygon(new List<Line>() { cur_lines[9], cur_lines[0], cur_lines[3] });
            list_pols.Add(cur_pol); 

            cur_pol = new Polygon(new List<Line>() { cur_lines[4], cur_lines[5], cur_lines[8] });
            list_pols.Add(cur_pol); 
            cur_pol = new Polygon(new List<Line>() { cur_lines[5], cur_lines[6], cur_lines[11] });
            list_pols.Add(cur_pol); 
            cur_pol = new Polygon(new List<Line>() { cur_lines[6], cur_lines[7], cur_lines[10] });
            list_pols.Add(cur_pol); 
            cur_pol = new Polygon(new List<Line>() { cur_lines[7], cur_lines[4], cur_lines[9] });
            list_pols.Add(cur_pol); 

            var g = Graphics.FromHwnd(pictureBox1.Handle);
            for (int i = 0; i < list_points.Count(); i++)
            {
                list_points[i].x *= 2;
                list_points[i].y *= 2;
                list_points[i].z *= 2;
            }
            DrawLines(list_lines, list_points, g);

        }
        
        private void redraw()
        {
            if (comboBoxTypePolyhedra.SelectedIndex == -1)
                return;

            if (comboBoxTypeProection.SelectedIndex == -1)
                return;

            var g = Graphics.FromHwnd(pictureBox1.Handle);

            switch (comboBoxTypeProection.SelectedIndex)
            {
              
                case 0:
                    {
                        pictureBox1.Refresh();
                        for (int i = 0; i < list_lines.Count(); i++)
                        {
                            Point a = new Point((int)(list_points[list_lines[i].a].x), (int)(list_points[list_lines[i].a].y));
                            Point b = new Point((int)(list_points[list_lines[i].b].x), (int)(list_points[list_lines[i].b].y));

                            g.DrawLine(new Pen(Color.Black, 2.0f), a, b);

                        }

                        break; 
                    }
               
                case 1:
                    {
                        pictureBox1.Refresh();
                        axonometric();
                        break; 
                    }
                case 2:
                    {
                        pictureBox1.Refresh();
                        parallperpective();
                        break; 
                    }                     
           
            }
                     
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
            for (int i = 0; i < list_lines.Count(); i++)
            {
                Point a = new Point((int)(newImage[list_lines[i].a].x) + pictureBox1.Width / 3, (int)(newImage[list_lines[i].a].y) + pictureBox1.Height / 3);
                Point b = new Point((int)(newImage[list_lines[i].b].x) + pictureBox1.Width / 3, (int)(newImage[list_lines[i].b].y) + pictureBox1.Height / 3);

                g.DrawLine(new Pen(Color.Black, 2.0f), a, b);
            }
        }

        public void parallperpective()
        {
            double c = 10.0;
            matrixPerspective[0, 0] = 1.0;
            matrixPerspective[1, 1] = 1.0;
            matrixPerspective[2, 2] = 0.0;
            matrixPerspective[2, 3] = -1.0 / c;

            ApplyTransformationAndDrawLines(matrixPerspective);
        }

        private void axonometric()
        {
            double anglePhi = -45.0 * Math.PI / 180.0;
            double anglePsi = 35.26 * Math.PI / 180.0;
            matrixAxonometric[0, 0] = Math.Cos(anglePsi);
            matrixAxonometric[0, 1] = Math.Sin(anglePhi) * Math.Sin(anglePsi);
            matrixAxonometric[1, 1] = Math.Cos(anglePhi);
            matrixAxonometric[2, 0] = Math.Sin(anglePsi);
            matrixAxonometric[2, 1] = -Math.Cos(anglePsi) * Math.Sin(anglePhi);

            ApplyTransformationAndDrawLines(matrixAxonometric);
        }
        private void buttonTranslite_Click(object sender, EventArgs e)
        {
            if (comboBoxTypePolyhedra.SelectedIndex == -1)
                return;

            var g = Graphics.FromHwnd(pictureBox1.Handle);
            //                                                                                                   x  y  z
            //double[,] matrixTranslation = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 1, 1, 1, 1 } };
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

        private void comboBoxTypeProection_SelectedIndexChanged(object sender, EventArgs e)
        {
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

   
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
