using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Lab4
{
    public partial class Form1 : Form
    {

        List<PointF> points = new List<PointF>();
        SolidBrush brush = new SolidBrush(Color.Red);
        private Graphics g;
        public Form1()
        {
            InitializeComponent();

            pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);
            g = pictureBox1.CreateGraphics();

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //   точка
            if (checkBox1.Checked)
            {
                drawPoint(e.Location);
          
            }
            // ребро
            else if ( checkBox2.Checked)
            {

                
            }
            // полигон
            else if (checkBox3.Checked)
            {
               
                

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
