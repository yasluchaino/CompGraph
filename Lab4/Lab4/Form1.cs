using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Lab4
{


    public partial class Form1 : Form
    {

        private List<Line> lines = new List<Line>();
        private Point point = new Point(0,0);
        private List<PointF> polygonPoints = new List<PointF>();

        private SolidBrush brush = new SolidBrush(Color.BurlyWood);
        private Graphics g;

        private bool isDrawing = false;

        private PointF startPoint;
        private PointF endPoint;

        private PointF minPolyCoordinates;
        private PointF maxPolyCoordinates;

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();

        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                isDrawing = true;
            }
            else if (checkBox2.Checked)
            {

                isDrawing = true;
                startPoint = e.Location;
            }
            else if (checkBox3.Checked)
            {
                isDrawing = true;
                if (polygonPoints.Count == 0)
                {
                    startPoint = e.Location;
                    minPolyCoordinates = e.Location;
                    maxPolyCoordinates = e.Location;
                    polygonPoints.Add(startPoint);
                }

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && (checkBox2.Checked || checkBox3.Checked))
            {

                endPoint = e.Location;


                pictureBox1.Invalidate();
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (checkBox1.Checked)
            {
                isDrawing = false;
                point = e.Location;

            }

            else if (isDrawing && checkBox2.Checked)
            {
                isDrawing = false;

                // текущий отрезок
                Line line = new Line { StartPoint = startPoint, EndPoint = endPoint };
                lines.Add(line);  

            }

            else if (isDrawing && checkBox3.Checked)
            {
                isDrawing = false;
                polygonPoints.Add(endPoint);

                if (endPoint.X < minPolyCoordinates.X)
                    minPolyCoordinates.X = endPoint.X;
                if (endPoint.Y < minPolyCoordinates.Y)
                    minPolyCoordinates.Y = endPoint.Y;
                if (endPoint.X > maxPolyCoordinates.X)
                    maxPolyCoordinates.X = endPoint.X;
                if (endPoint.Y > maxPolyCoordinates.Y)
                    maxPolyCoordinates.Y = endPoint.Y;
                startPoint = endPoint;

                
            }

            pictureBox1.Invalidate();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillEllipse(brush, point.X - 3, point.Y - 3, 5, 5);

            foreach (var line in lines)
            {
                e.Graphics.DrawLine(new Pen(line.Color), line.StartPoint, line.EndPoint);
            }

            if (isDrawing && checkBox2.Checked)
            {
                e.Graphics.DrawLine(Pens.BlueViolet, startPoint, endPoint);
            }



            if (polygonPoints.Count >= 2)
            {


                for (int i = 0; i < polygonPoints.Count - 1; i++)
                    e.Graphics.DrawLine(Pens.DeepPink, polygonPoints[i], polygonPoints[i + 1]);

                // соединяем последнбб точку с первой
                if (polygonPoints.Count > 2)
                    e.Graphics.DrawLine(Pens.DeepPink, polygonPoints[polygonPoints.Count - 1], polygonPoints[0]);
            }

            if (isDrawing && checkBox3.Checked)
            {
                e.Graphics.DrawLine(Pens.DeepPink, startPoint, endPoint);
            }

        }


        private void PrimitiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                groupBox1.Visible = true;
                // сбрасываем остальные, если уже какой-то выбран
                if (checkBox == checkBox1)
                {
                    line_box.Visible = false;
                    rotate_box.Visible = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                }
                else if (checkBox == checkBox2)
                {
                    line_box.Visible = true;
                    rotate_box.Visible = true;
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                }
                else if (checkBox == checkBox3)
                {
                    line_box.Visible = false;
                    rotate_box.Visible = false;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            point = Point.Empty;
            polygonPoints.Clear();
            lines.Clear();
            groupBox1.Visible = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            g.Clear(Color.White);

        }

        private PointF intersect_point(PointF p0, PointF p1, PointF p2, PointF p3)
        {
            

            float a1 = p1.Y - p0.Y;
            float b1 = p0.X - p1.X;
            float c1 = a1 * p0.X + b1 * p0.Y;

            float a2 = p3.Y - p2.Y;
            float b2 = p2.X - p3.X;
            float c2 = a2 * p2.X + b2 * p2.Y;

            float d = a1 * b2 - a2 * b1;

            if (d== 0)//условие, что прямые параллельны
            {

                return Point.Empty;
            }

            float X = (b2 * c1 - b1 * c2) / d;
            float Y = (a1 * c2 - a2 * c1) / d;

            float minX1 = Math.Min(p0.X, p1.X);
            float maxX1 = Math.Max(p0.X, p1.X);
            float minY1 = Math.Min(p0.Y, p1.Y);
            float maxY1 = Math.Max(p0.Y, p1.Y);

            float minX2 = Math.Min(p2.X, p3.X);
            float maxX2 = Math.Max(p2.X, p3.X);
            float minY2 = Math.Min(p2.Y, p3.Y);
            float maxY2 = Math.Max(p2.Y, p3.Y);
          

            if (X >= minX1 && X <= maxX1 && Y >= minY1 && Y <= maxY1
                && X >= minX2 && X <= maxX2 && Y >= minY2 && Y <= maxY2)
            {
         
                return new PointF(X, Y);
            }

            return PointF.Empty;


        }


        //ищет пересеччение между только что нарисованным отрезком и предыдущим(главное не забыть какой был предыдущий)
        private void intersect_Click(object sender, EventArgs e)
        {
            PointF intersection = intersect_point(lines[lines.Count - 2].StartPoint, lines[lines.Count - 2].EndPoint, lines[lines.Count - 1].StartPoint, lines[lines.Count - 1].EndPoint);

            if (!intersection.IsEmpty)
            {
                g.FillEllipse(Brushes.YellowGreen, intersection.X - 3, intersection.Y - 3, 5, 5);
                //pictureBox1.Invalidate();
                pictureBox1.Update();
                textBox1.Text = intersection.Y.ToString();
                textBox2.Text = intersection.X.ToString();
                 
            }
            else
            {
                MessageBox.Show("Не пересекаются");
                textBox1.Text = "";
                textBox2.Text = "";
            }
           
        }
private void rotatePolygon(List<PointF> polygon, float angle, Point pivot)
            {
            PointF[] polygonArray = polygon.ToArray();
            Matrix rotationMatrix = new Matrix();
                rotationMatrix.RotateAt(angle, pivot);
                rotationMatrix.TransformPoints(polygonArray);

            polygon.Clear();
            polygon.AddRange(polygonArray);
            }
        private void translatePolygon(List<PointF> polygon, int dx, int dy)
        {
            PointF[] polygonArray = polygon.ToArray();  // Преобразуем List<Point> в массив Point[]

            Matrix translationMatrix = new Matrix();
            translationMatrix.Translate(dx, -dy);
            translationMatrix.TransformPoints(polygonArray);

            // Обновляем List<Point> с преобразованными значениями
            polygon.Clear();
            polygon.AddRange(polygonArray);
        }
        private void scalePolygon(List<PointF> polygon, float scaleX, float scaleY, Point pivot)
        {
            PointF[] polygonArray = polygon.ToArray();
            Matrix scalingMatrix = new Matrix();
            scalingMatrix.Scale(scaleX, scaleY);
            scalingMatrix.Translate(pivot.X * (1 - scaleX), pivot.Y * (1 - scaleY), MatrixOrder.Append);
            scalingMatrix.TransformPoints(polygonArray);

            polygon.Clear();
            polygon.AddRange(polygonArray);
        }

        private void move_button_Click(object sender, EventArgs e)
        {
            int dx = (int)numericUpDown1.Value;
            int dy = (int)numericUpDown2.Value;

            translatePolygon(polygonPoints, dx, dy);
            pictureBox1.Invalidate();
        }
  private void rotate_button_Click(object sender, EventArgs e)
        {
            float angle = (float)numericUpDown3.Value;

            rotatePolygon(polygonPoints, angle,point);
            pictureBox1.Invalidate();

        } 
        private void scale_button_Click(object sender, EventArgs e)
        {
            float scaleX = (float)numericUpDown4.Value;
            float scaleY = (float)numericUpDown5.Value;
            scalePolygon(polygonPoints, scaleX, scaleY, point);

            pictureBox1.Invalidate();
        }
        public class Line
        {
            public PointF StartPoint { get; set; }
            public PointF EndPoint { get; set; }
            public Color Color { get; set; } = Color.BlueViolet;

            public Line() { }

            public Line(PointF start, PointF end, Color color) 
            {
                StartPoint = start;
                EndPoint = end;
                Color = color;
            }
            public Line(PointF start, PointF end)
            {
                StartPoint = start;
                EndPoint = end;
                Color = Color.BlueViolet;
            }
        }

        private void rotate_edge_Click(object sender, EventArgs e)
        {
            double angle = 90;  

       
            for (int i = 0; i < lines.Count; i++)
            {
                PointF center = new PointF((lines[i].StartPoint.X + lines[i].EndPoint.X) / 2,
                                           (lines[i].StartPoint.Y + lines[i].EndPoint.Y) / 2);

                Matrix rotationMatrix = new Matrix();
                rotationMatrix.RotateAt((float)angle, center);

                PointF[] points = { lines[i].StartPoint, lines[i].EndPoint };
                rotationMatrix.TransformPoints(points);

                lines[i] = new Line(points[0], points[1], lines[i].Color);
            }

            pictureBox1.Invalidate();
        }

      
    }
}
