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
    public partial class Task3 : Form
    {
        static Bitmap bmp = new Bitmap(784, 381);
        public Graphics gr = Graphics.FromImage(bmp);
        int[] arrx = new int[3];
        int[] arry = new int[3];


        public Task3()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (arrx[0] == 0)
            {
                arrx[0] = (int)e.X;
                arry[0] = (int)e.Y;
            }
            else if (arrx[1] == 0)
            {
                arrx[1] = (int)e.X;
                arry[1] = (int)e.Y;
            }
            else if (arrx[2] == 0) 
            {
                arrx[2] = (int)e.X;
                arry[2] = (int)e.Y;
                Make_Triangle(arrx, arry);
                arrx[0] = 226;
                arry[0] = 129;
                arrx[1] = 438;
                arry[1] = 129;
                arrx[2] = 274;
                arry[2] = 250;
                Make_Triangle(arrx, arry);
                for (int i = 0; i < arrx.Length; i++) 
                {
                    arrx[i] = 0;
                    arry[i] = 0;
                }
            }
            //Console.WriteLine(e.X);
            //Console.WriteLine(e.Y);
        }

        private void Make_Triangle(int[] x, int[] y) 
        {
            Random random = new Random();
            Color c1 = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
            Color c2 = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
            Color c3 = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
            Dictionary<int, Tuple<int, Color>> ld = new Dictionary<int, Tuple<int, Color>>();
            Dictionary<int, Tuple<int, Color>> md1 = new Dictionary<int, Tuple<int, Color>>();
            Dictionary<int, Tuple<int, Color>> md2 = new Dictionary<int, Tuple<int, Color>>();

            if (y[0] == y[1] || y[1] == y[2] || y[0] == y[2])
            {
                int ind1 = 0;
                int ind2 = 0;
                int ind3 = 0;
                for (int i = 1; i < y.Length; i++) 
                {
                    if (y[i - 1] == y[i]) 
                    {
                        ind1 = i - 1;
                        ind2 = i;
                    }
                }

                for (int i = 1; i < y.Length; i++) 
                {
                    if (i != ind1 && i != ind2) 
                    {
                        ind3 = i;
                    }
                }

                DrawForwardLine(x[ind1], y[ind1], x[ind2], y[ind2], c1, c2);

                if (y[ind1] > y[ind3])
                {
                    Make_Line(x[ind1], y[ind1], x[ind3], y[ind3], c1, c3, ref md1);
                    Make_Line(x[ind2], y[ind2], x[ind3], y[ind3], c2, c3, ref md2);
                }
                else 
                {
                    Make_Line(x[ind3], y[ind3], x[ind1], y[ind1], c3, c1, ref md1);
                    Make_Line(x[ind3], y[ind3], x[ind2], y[ind2], c3, c2, ref md2);
                }
                Fill_Forward_Triangle(y[ind1], y[ind3], md1, md2);
            }
            else if (!(y[0] == y[1] || y[1] == y[2] || y[0] == y[2]))
            {
                int ind0 = 0;
                int ind1 = 10;
                int ind2 = 10;
                int max = int.MinValue;
                for (int i = 0; i < y.Length; i++) 
                {
                    if (y[i] > max) 
                    {
                        max = y[i];
                        ind0 = i;
                    }
                }
                max = int.MinValue;
                for (int i = 0; i < y.Length; i++)
                {
                    if (y[i] > max && i != ind0) 
                    {
                        ind1 = i;
                        max = y[i];
                    }
                }

                for (int i = 0; i < y.Length; i++) 
                {
                    if (i != ind0 && i != ind1)
                        ind2 = i;
                }

                Make_Line(x[ind0], y[ind0], x[ind1], y[ind1], c1, c2, ref md1);
                Make_Line(x[ind0], y[ind0], x[ind2], y[ind2], c1, c3, ref ld);
                Make_Line(x[ind1], y[ind1], x[ind2], y[ind2], c2, c3, ref md2);

                Fill_Triangle(y[ind0], y[ind2], ld, md1, md2);
            }

        }

        private void Make_Line(int ax, int ay, int bx, int by, Color ac, Color bc, ref Dictionary<int, Tuple<int, Color>> dict) 
        {
            int ty = ay;
            while (ty != by) 
            {
                ty--;
                int tx = ((ty - ay) * (bx - ax) / (by - ay)) + ax;
                int tr = ((ty - ay) * (bc.R - ac.R) / (by - ay)) + ac.R;
                int tg = ((ty - ay) * (bc.G - ac.G) / (by - ay)) + ac.G;
                int tb = ((ty - ay) * (bc.B - ac.B) / (by - ay)) + ac.B;
                var tuple = new Tuple<int, Color>(tx,Color.FromArgb(tr, tg, tb));
                dict.Add(ty, tuple);
                bmp.SetPixel(tx,ty,Color.FromArgb(tr, tg, tb));
                //Console.WriteLine(tx);
            }
            pictureBox1.Image = bmp;
        }

        private void DrawForwardLine(int ax, int ay, int bx, int by, Color ac, Color bc) 
        {
            if (ax < bx)
            {
                int tx = ax;
                while (tx != bx)
                {
                    tx++;
                    int tr = ((tx - ax) * (bc.R - ac.R) / (bx - ax)) + ac.R;
                    int tg = ((tx - ax) * (bc.G - ac.G) / (bx - ax)) + ac.G;
                    int tb = ((tx - ax) * (bc.B - ac.B) / (bx - ax)) + ac.B;
                    bmp.SetPixel(tx, ay, Color.FromArgb(tr, tg, tb));
                }
            }
            else 
            {
                int tx = bx;
                while (tx != ax)
                {
                    tx++;
                    int tr = ((tx - bx) * (ac.R - bc.R) / (ax - bx)) + bc.R;
                    int tg = ((tx - bx) * (ac.G - bc.G) / (ax - bx)) + bc.G;
                    int tb = ((tx - bx) * (ac.B - bc.B) / (ax - bx)) + bc.B;
                    bmp.SetPixel(tx, ay, Color.FromArgb(tr, tg, tb));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void Fill_Triangle(int y0, int y1, Dictionary<int, Tuple<int, Color>> ld, Dictionary<int, Tuple<int, Color>> md1, Dictionary<int, Tuple<int, Color>> md2) 
        {
            if (ld[y0-3].Item1 < md1[y0-3].Item1)
            {
                
                while (y0 != y1 && md1.ContainsKey(y0-1)) 
                {
                    y0--;
                    var tx = ld[y0].Item1;
                    var tx1 = md1[y0].Item1;
                    while (tx != tx1) 
                    {
                        tx++;
                        int tr = ((tx - ld[y0].Item1) * (md1[y0].Item2.R - ld[y0].Item2.R) / (md1[y0].Item1 - ld[y0].Item1)) + ld[y0].Item2.R;
                        int tg = ((tx - ld[y0].Item1) * (md1[y0].Item2.G - ld[y0].Item2.G) / (md1[y0].Item1 - ld[y0].Item1)) + ld[y0].Item2.G;
                        int tb = ((tx - ld[y0].Item1) * (md1[y0].Item2.B - ld[y0].Item2.B) / (md1[y0].Item1 - ld[y0].Item1)) + ld[y0].Item2.B;
                        if (tr > 255)
                            tr = 255;
                        if (tg > 255) 
                            tg = 255;
                        if (tb > 255) 
                            tb = 255;
                        if (tr < 0)
                            tr = 0;
                        if (tg < 0) 
                            tg = 0;
                        if (tb < 0)
                            tb = 0;
                        bmp.SetPixel(tx, y0, Color.FromArgb(tr, tg, tb));
                    }
                }
                while (y0 != y1 && md2.ContainsKey(y0-1))
                {
                    y0--;
                    var tx = ld[y0].Item1;
                    var tx1 = md2[y0].Item1;
                    while (tx != tx1)
                    {
                        tx++;
                        int tr = ((tx - ld[y0].Item1) * (md2[y0].Item2.R - ld[y0].Item2.R) / (md2[y0].Item1 - ld[y0].Item1)) + ld[y0].Item2.R;
                        int tg = ((tx - ld[y0].Item1) * (md2[y0].Item2.G - ld[y0].Item2.G) / (md2[y0].Item1 - ld[y0].Item1)) + ld[y0].Item2.G;
                        int tb = ((tx - ld[y0].Item1) * (md2[y0].Item2.B - ld[y0].Item2.B) / (md2[y0].Item1 - ld[y0].Item1)) + ld[y0].Item2.B;
                        if (tr > 255)
                            tr = 255;
                        if (tg > 255)
                            tg = 255;
                        if (tb > 255)
                            tb = 255;
                        if (tr < 0)
                            tr = 0;
                        if (tg < 0)
                            tg = 0;
                        if (tb < 0)
                            tb = 0;
                        bmp.SetPixel(tx, y0, Color.FromArgb(tr, tg, tb));
                    }
                }
            }
            else if (ld[y0 - 3].Item1 > md1[y0 - 3].Item1)
            {
                while (y0 != y1 && md1.ContainsKey(y0 - 1)) 
                {
                    y0--;
                    var tx = md1[y0].Item1;
                    var tx1 = ld[y0].Item1;
                    while (tx != tx1) 
                    {
                        tx++;
                        int tr = (tx - md1[y0].Item1) * (ld[y0].Item2.R - md1[y0].Item2.R) / (ld[y0].Item1 - md1[y0].Item1) + md1[y0].Item2.R;
                        int tg = (tx - md1[y0].Item1) * (ld[y0].Item2.G - md1[y0].Item2.G) / (ld[y0].Item1 - md1[y0].Item1) + md1[y0].Item2.G;
                        int tb = (tx - md1[y0].Item1) * (ld[y0].Item2.B - md1[y0].Item2.B) / (ld[y0].Item1 - md1[y0].Item1) + md1[y0].Item2.B;
                        if (tr > 255)
                            tr = 255;
                        if (tg > 255)
                            tg = 255;
                        if (tb > 255)
                            tb = 255;
                        if (tr < 0)
                            tr = 0;
                        if (tg < 0)
                            tg = 0;
                        if (tb < 0)
                            tb = 0;
                        bmp.SetPixel(tx, y0, Color.FromArgb(tr, tg, tb));
                    }
                }
                while (y0 != y1 && md2.ContainsKey(y0 - 1))
                {
                    y0--;
                    var tx = md2[y0].Item1;
                    var tx1 = ld[y0].Item1;
                    while (tx != tx1)
                    {
                        tx++;
                        int tr = (tx - md2[y0].Item1) * (ld[y0].Item2.R - md2[y0].Item2.R) / (ld[y0].Item1 - md2[y0].Item1) + md2[y0].Item2.R;
                        int tg = (tx - md2[y0].Item1) * (ld[y0].Item2.G - md2[y0].Item2.G) / (ld[y0].Item1 - md2[y0].Item1) + md2[y0].Item2.G;
                        int tb = (tx - md2[y0].Item1) * (ld[y0].Item2.B - md2[y0].Item2.B) / (ld[y0].Item1 - md2[y0].Item1) + md2[y0].Item2.B;
                        if (tr > 255)
                            tr = 255;
                        if (tg > 255)
                            tg = 255;
                        if (tb > 255)
                            tb = 255;
                        if (tr < 0)
                            tr = 0;
                        if (tg < 0)
                            tg = 0;
                        if (tb < 0)
                            tb = 0;
                        bmp.SetPixel(tx, y0, Color.FromArgb(tr, tg, tb));
                    }
                }
            }
            pictureBox1.Image = bmp;
        }

        private void Fill_Forward_Triangle(int y0, int y1, Dictionary<int, Tuple<int, Color>> md1, Dictionary<int, Tuple<int, Color>> md2) 
        {
            if (y0 > y1)
            {
                
                while (y0 != y1 && md1.ContainsKey(y0 - 1))
                {
                    Console.WriteLine("Efe");
                    y0--;
                    var tx = md1[y0].Item1;
                    var tx1 = md2[y0].Item1;
                    while (tx != tx1)
                    {
                        tx++;
                        int tr = ((tx - md1[y0].Item1) * (md2[y0].Item2.R - md1[y0].Item2.R) / (md2[y0].Item1 - md1[y0].Item1)) + md1[y0].Item2.R;
                        int tg = ((tx - md1[y0].Item1) * (md2[y0].Item2.G - md1[y0].Item2.G) / (md2[y0].Item1 - md1[y0].Item1)) + md1[y0].Item2.G;
                        int tb = ((tx - md1[y0].Item1) * (md2[y0].Item2.B - md1[y0].Item2.B) / (md2[y0].Item1 - md1[y0].Item1)) + md1[y0].Item2.B;
                        if (tr > 255)
                            tr = 255;
                        if (tg > 255)
                            tg = 255;
                        if (tb > 255)
                            tb = 255;
                        if (tr < 0)
                            tr = 0;
                        if (tg < 0)
                            tg = 0;
                        if (tb < 0)
                            tb = 0;
                        bmp.SetPixel(tx, y0, Color.FromArgb(tr, tg, tb));
                    }
                }
            }
            else
            {
                Console.WriteLine(y0 < y1);
                while (y0 != y1 && md1.ContainsKey(y0 + 1))
                {
                    Console.WriteLine("Ewse");
                    y0++;
                    var tx = md1[y0].Item1;
                    var tx1 = md2[y0].Item1;
                    while (tx != tx1)
                    {
                        tx++;
                        int tr = ((tx - md1[y0].Item1) * (md2[y0].Item2.R - md1[y0].Item2.R) / (md2[y0].Item1 - md1[y0].Item1)) + md1[y0].Item2.R;
                        int tg = ((tx - md1[y0].Item1) * (md2[y0].Item2.G - md1[y0].Item2.G) / (md2[y0].Item1 - md1[y0].Item1)) + md1[y0].Item2.G;
                        int tb = ((tx - md1[y0].Item1) * (md2[y0].Item2.B - md1[y0].Item2.B) / (md2[y0].Item1 - md1[y0].Item1)) + md1[y0].Item2.B;
                        if (tr > 255)
                            tr = 255;
                        if (tg > 255)
                            tg = 255;
                        if (tb > 255)
                            tb = 255;
                        if (tr < 0)
                            tr = 0;
                        if (tg < 0)
                            tg = 0;
                        if (tb < 0)
                            tb = 0;
                        bmp.SetPixel(tx, y0, Color.FromArgb(tr, tg, tb));
                    }
                }
            }
            pictureBox1.Image = bmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            pictureBox1.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
