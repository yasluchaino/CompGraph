using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{

    public partial class Task2 : Form
    {
        Bitmap bitmap;
        Graphics g;
        private int startX, startY;
        private bool isDrawing = false;

        public Task2()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);

            // Добавляем обработчики событий для PictureBox
            pictureBox1.MouseDown += PictureBox_MouseDown;
            pictureBox1.MouseMove += PictureBox_MouseMove;
            pictureBox1.MouseUp += PictureBox_MouseUp;
        }

 

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {

            isDrawing = true;
         
            startX = e.X;
            startY = e.Y;


        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        { 
            if (isDrawing)
            {
                g.Clear(Color.White);
                if (radioButton1.Checked)
                {       
                    Bresenham(startX, startY, e.X, e.Y);                
                }
                else
                {
                    MessageBox.Show("Please, select a method.");
                }
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;         
        }

        private void plotLineLow(int x0, int y0, int x1, int y1)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int yi = 1;
            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }
            int D = (2 * dy) - dx;
            int y = y0;

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for (int x = x0; x < x1; x++)
                {
                    g.FillRectangle(Brushes.Black,x, y, 1, 1);
                    if (D > 0)
                    {
                        y = y + yi;
                        D = D + (2 * (dy - dx));
                    }
                    else
                        D = D + 2 * dy;
                }
            }
        }



        private void plotLineHigh(int x0, int y0, int x1, int y1)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }
            int D = (2 * dx) - dy;
            int x = x0;

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for (int y = y0; y < y1; y++)
                {
                    g.FillRectangle(Brushes.Black, x, y, 1, 1);
                    if (D > 0)
                    {
                        x = x + xi;
                        D = D + (2 * (dx - dy));
                    }
                    else
                        D = D + 2 * dx;
                }
            }

        }



        void Bresenham(int x0, int y0, int x1, int y1)
        {
            if( Math.Abs(y1-y0) < Math.Abs(x1 - x0))
            {
                if (x0 > x1)
                {
                    plotLineLow(x1,y1,x0,y0);
                }
                else
                {
                    plotLineLow(x0,y0,x1,y1);
                }
            }
            else
            {
                if (y0 > y1) {
                    plotLineHigh(x1,y1,x0,y0);
                }
                else
                {
                    plotLineHigh(x0,y0,x1,y1);
                }
            }

            pictureBox1.Image = bitmap; 

        }


    }
}
