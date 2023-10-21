using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace lab5
{
    public partial class Task3 : Form
    {


        private Graphics g;
        private List<Point> points;
        private Point p;
        private bool isDrawing = false;


        public Task3()
        {
            InitializeComponent();



        


            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);

            g.Clear(Color.White);
            points = new List<Point>();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void Redraw()
        {
            g.Clear(Color.White);
            for (int i = 0; i < points.Count; ++i)
                g.FillEllipse(Brushes.LightSeaGreen, points[i].X - 2, points[i].Y - 2, 7, 7);
            pictureBox1.Invalidate();
        }

        private void AddPoint(Point p, int ind)
        {
            if (ind == -1)
                points.Add(p);
            else
                points.Insert(ind, p);

            g.FillEllipse(Brushes.LightSeaGreen, p.X - 2, p.Y - 2, 7, 7);
            pictureBox1.Invalidate();
        }

        private int RemovePoint(Point p)
        {

            int ind = points.FindIndex(point =>
                Math.Abs(point.X - p.X) < 7 && Math.Abs(point.Y - p.Y) < 7);

            if (ind != -1)
            {
                points.RemoveAt(ind);
                Redraw();
                return ind;
            }
            else
            {
                return -1;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                AddPoint(e.Location, -1);
            }
            else if (checkBox2.Checked)
            {
                RemovePoint(e.Location);
            }

            if (isDrawing)
            {
                Redraw();
                Composite_Bezier_Curve();
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBox3.Checked)
                p = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!checkBox3.Checked || e.Location == p)
                return;

            int ind = RemovePoint(p);
            if (ind != -1)
            {
                AddPoint(e.Location, ind);

                if (isDrawing)
                {
                    Redraw();
                    Composite_Bezier_Curve();
                }
            }
        }


        private void Bezier_Сurve(Point p0, Point p1, Point p2, Point p3)
        {
            List<Point> V = new List<Point> { p0, p1, p2, p3 };
            List<List<int>> M = new List<List<int>>{
                            new List<int> { 1, -3, 3, -1 },
                            new List<int> { 0, 3, -6, 3 },
                            new List<int> { 0, 0, 3, -3 },
                            new List<int> { 0, 0, 0, 1 }};
            List<float> T = new List<float> { 1.0f, 0.0f, 0.0f, 0.0f };
            List<PointF> VM = new List<PointF>();
            for (int i = 0; i < 4; ++i)
            {
                float x = 0;
                float y = 0;
                for (int j = 0; j < 4; ++j)
                {
                    x += V[j].X * M[j][i];
                    y += V[j].Y * M[j][i];
                }
                VM.Add(new PointF(x, y));
            }

            for (float t = 0; t <= 1; t += 0.001f)
            {
                T[1] = t;
                T[2] = t * t;
                T[3] = T[2] * t;
                PointF res = new PointF(0, 0);
                for (int i = 0; i < 4; ++i)
                {
                    res.X += VM[i].X * T[i];
                    res.Y += VM[i].Y * T[i];
                }
                (pictureBox1.Image as Bitmap).SetPixel((int)res.X, (int)res.Y, Color.MediumVioletRed);
            }
            pictureBox1.Invalidate();
        }

        private void Composite_Bezier_Curve()
        {

            if (points.Count == 1) { 

                MessageBox.Show("Добавьте точку");
                return;
            }
            if (points.Count == 2)
            {
                g.DrawLine(Pens.MediumVioletRed, points[0], points[1]);
            }
            else
            {
                Point prev = points[0];
                for (int i = 0; i < points.Count - 4; i += 2)
                {
                    Point next = new Point((points[i + 2].X + points[i + 3].X) / 2, (points[i + 2].Y + points[i + 3].Y) / 2);
                    Bezier_Сurve(prev, points[i + 1], points[i + 2], next);
                    prev = next;
                }

                if (points.Count % 2 == 0)
                {
                    Bezier_Сurve(prev, points[points.Count - 3], points[points.Count - 2], points[points.Count - 1]);
                }
                else
                {
                    Point p1 = new Point(prev.X + 2 * (points[points.Count - 2].X - prev.X) / 3,
                                           prev.Y + 2 * (points[points.Count - 2].Y - prev.Y) / 3);

                    Point p2 = new Point(points[points.Count - 2].X + (points[points.Count - 1].X - points[points.Count - 2].X) / 3,
                                           points[points.Count - 2].Y + (points[points.Count - 1].Y - points[points.Count - 2].Y) / 3);
                    Bezier_Сurve(prev, p1, p2, points[points.Count - 1]);
                }
            }

            pictureBox1.Invalidate();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Redraw();
            Composite_Bezier_Curve();
            isDrawing = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            isDrawing = false;
            points.Clear();
            g.Clear(Color.White);
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            pictureBox1.Invalidate();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
 
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }  
        
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {

                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }


    }
}

