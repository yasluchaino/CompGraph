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
        public Form1()
        {
            InitializeComponent();

            pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //   точка
            if (checkBox1.Checked)
            {
                
          
            }
            // ребро
            else if ( checkBox2.Checked)
            {

                
            }
            // полигон
            else if (checkBox3.Checked)
            {
               
                

            }

            pictureBox1.Invalidate();
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
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                }
                else if (checkBox == checkBox2)
                {
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                }
                else if (checkBox == checkBox3)
                {
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

        }

    }
}
