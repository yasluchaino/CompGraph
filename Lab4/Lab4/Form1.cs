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
using System.Windows.Forms.VisualStyles;

namespace Lab4
{
    public class Line
    {
        public PointF StartPoint { get; set; }
        public PointF EndPoint { get; set; }
        public Color Color { get; set; }
    }


    public partial class Form1 : Form
    {

        private List<Line> lines = new List<Line>();
        private List<PointF> points = new List<PointF>();
        private SolidBrush brush = new SolidBrush(Color.Red);
        private Graphics g;
        private bool isDrawing = false;
        private PointF startPoint;
        private PointF endPoint;


        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();

        }

     
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
             
                drawPoint(e.Location);
            }
            else if (checkBox2.Checked)
            {

                isDrawing = true;
                startPoint = e.Location;
                endPoint = e.Location;
            }
            else if (checkBox3.Checked)
            {

            }
        } 
        
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && checkBox2.Checked)
            {

                endPoint = e.Location;


                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && checkBox2.Checked)
            {
                isDrawing = false;

                // Сохраняем текущий отрезок
                Line line = new Line { StartPoint = startPoint, EndPoint = endPoint, Color = Color.Black };
                lines.Add(line);


                pictureBox1.Invalidate();
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            foreach (var line in lines)
            {
                e.Graphics.DrawLine(new Pen(line.Color), line.StartPoint, line.EndPoint);
            }
            
            if (isDrawing && checkBox2.Checked)
            {
                e.Graphics.DrawLine(Pens.Black, startPoint, endPoint);
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
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                }
                else if (checkBox == checkBox2)
                {
                    line_box.Visible = true;
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                }
                else if (checkBox == checkBox3)
                {
                    line_box.Visible = false;
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
            points.Clear();
            groupBox1.Visible = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            g.Clear(Color.White);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        void drawPoint(PointF location)
        {
            g.FillEllipse(brush, location.X - 3, location.Y - 3, 5, 5);
        }

        
    }
}
