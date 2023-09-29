using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
                    WU(startX, startY, e.X, e.Y);
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
                    g.FillRectangle(Brushes.DarkOliveGreen, x, y, 1, 1);
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
                    g.FillRectangle(Brushes.DarkOliveGreen, x, y, 1, 1);
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

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static int IPart(float x)
        {
            return (int)Math.Floor(x);
        }

        public static int Round(float x)
        {
            return IPart(x + 0.5f);
        }

        public static float FPart(float x)
        {
            return x - IPart(x);
        }

        public static float RFPart(float x)
        {
            return 1 - FPart(x);
        }

        private void Plot(int x, int y, float brightness)
        {
            int c = (int)(255 * brightness);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(c, c, c));
               g.FillRectangle(brush, x, y, 1, 1);
            }
        }

        public void WU(int x0, int y0, int x1, int y1)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }

            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = dx != 0.0f ? dy / dx : 1;

            int xpxl1 = x0;
            int xpxl2 = x1;
            float intersectY = y0;



            if (steep)
            {
                for (int x = xpxl1; x <= xpxl2; x++)
                {
                    Plot(IPart(intersectY), x, RFPart(intersectY));
                    Plot(IPart(intersectY) - 1, x, FPart(intersectY));
                    intersectY += gradient;
                }
            }
            else
            {
                for (int x = xpxl1; x <= xpxl2; x++)
                {
                    Plot(x, IPart(intersectY), RFPart(intersectY));
                    Plot(x, IPart(intersectY) - 1, FPart(intersectY));
                    intersectY += gradient;
                }
            }

            pictureBox1.Image = bitmap;
        }

    }
}



//для последних точек в алгоритме ву
//int xend = Round(x0);
//float yend = y0 + gradient * (xend - x0);
//float xgap = RFPart(x0 + 0.5f);
//int xpxl1 = xend; // this will be used in the main loop
//int ypxl1 = IPart(yend);
//if (steep)
//{
//    Plot(ypxl1, xpxl1, RFPart(yend) * xgap);
//    Plot(ypxl1 + 1, xpxl1, FPart(yend) * xgap);
//}
//else
//{
//    Plot(xpxl1, ypxl1, RFPart(yend) * xgap);
//    Plot(xpxl1, ypxl1 + 1, FPart(yend) * xgap);
//}

//float intersectY = yend + gradient; // first y-intersection for the main loop


//xend = Round(x1);
//yend = y1 + gradient * (xend - x1);
//xgap = FPart(x1 + 0.5f);
//int xpxl2 = xend; //this will be used in the main loop
//int ypxl2 = IPart(yend);
//if (steep)
//{
//    Plot(ypxl2, xpxl2, RFPart(yend) * xgap);
//    Plot(ypxl2 + 1, xpxl2, FPart(yend) * xgap);
//}
//else
//{
//    Plot(xpxl2, ypxl2, RFPart(yend) * xgap);
//    Plot(xpxl2, ypxl2 + 1, FPart(yend) * xgap);
//}