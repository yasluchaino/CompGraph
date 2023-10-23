using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace lab5
{
    public partial class Task2 : Form
    {
        public int count = 0;
        public bool Auto_Update = false;
        public double Cur_Rough_Value = 0;
        public Graphics g;
        public int Cur_Point_Count = 2;
        public int Cur_Line_Count = 1;

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
                Color = Color.Black;
            }
        }

        public List<Line> lines = new List<Line>();
        public List<PointF> mountPoints = new List<PointF>();

        public PointF startPoint;
        public PointF endPoint;


        public Task2()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 40;
            trackBar1.TickFrequency = 1;

            startPoint = new PointF(0, 700);
            endPoint = new PointF(1241, 700);
            mountPoints.Add(startPoint);
            mountPoints.Add(endPoint);

            Line line = new Line(startPoint,endPoint);
            lines.Add(line);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count = 0;
            Cur_Point_Count = 2;
            Cur_Line_Count = 1;
            lines.Clear();
            mountPoints.Clear();
            startPoint = new PointF(0, 700);
            endPoint = new PointF(1241, 700);
            mountPoints.Add(startPoint);
            mountPoints.Add(endPoint);
            Line line = new Line(startPoint, endPoint);
            lines.Add(line);
            g.Clear(Color.White);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Auto_Update = !Auto_Update;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Cur_Rough_Value = trackBar1.Value * 0.1;
            Recalculate_Lines();
        }

        void Recalculate_Lines() 
        {
            var rand = new Random();
            int cnt = 0;
            List<PointF> nmountPoints = new List<PointF>();
            List<PointF> emountPoints = new List<PointF>();
            List<Line> eLines = new List<Line>();

            emountPoints.Add(startPoint);
            emountPoints.Add(endPoint);

            int point_count = 2;
            int line_count = 1;

            while (cnt != count)
            {
                point_count = (point_count - 2) * 2 + 1 + 2;
                line_count *= 2;
                nmountPoints = new List<PointF>(point_count);

                int j = 0;
                for (int i = 0; i < point_count; i++) 
                {
                    if (i % 2 == 0)
                    {
                        nmountPoints.Add(emountPoints[j]);
                        j++;
                    }
                    else 
                    {
                        PointF tpf = new PointF((nmountPoints[i-1].X + emountPoints[j].X) / 2, (nmountPoints[i - 1].Y + emountPoints[j].Y) / 2);
                        float l = (float)(Math.Sqrt(Math.Pow(emountPoints[j].X - nmountPoints[i - 1].X, 2) + Math.Pow(emountPoints[j].Y - nmountPoints[i - 1].Y, 2)));
                        tpf.Y -= (float)(rand.NextDouble() * ((Cur_Rough_Value * l - (-1 * Cur_Rough_Value * l)) + -1 * Cur_Rough_Value * l));
                        nmountPoints.Add(tpf);
                    }
                }
                emountPoints = nmountPoints;
                cnt++;
            }

            for (int i = 1; i < emountPoints.Count; i++)
            {
                eLines.Add(new Line(emountPoints[i-1], emountPoints[i]));
            }

            mountPoints = emountPoints;
            lines = eLines;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count++;
            Cur_Point_Count = (Cur_Point_Count - 2) * 2 + 1 + 2;
            Cur_Line_Count *= 2;
            Recalculate_Lines();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            for (int i = 0; i < lines.Count; i++) 
            {
                g.DrawLine(new Pen(lines[i].Color), lines[i].StartPoint, lines[i].EndPoint);
            }
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (count >= 1)
            {
                count--;
                Cur_Point_Count = (Cur_Point_Count - 2 - 1) / 2 + 2; //(Cur_Point_Count - 2) * 2 + 1 + 2;
                Cur_Line_Count /= 2;
                Recalculate_Lines();
            }
        }
    }
}
