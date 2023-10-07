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

        private void button2_Click(object sender, EventArgs e)
        {

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

        private void move_button_Click(object sender, EventArgs e)
        {
            int dx = (int)numericUpDown1.Value;
            int dy = (int)numericUpDown2.Value;

            translatePolygon(polygonPoints, dx, dy);
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
