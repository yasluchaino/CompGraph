using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
{
    public partial class Task1Res : Form
    {
        public Task1Res()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.jpg;*.png;*.gif;*.bmp)|*.jpg;*.png;*.gif;*.bmp|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                string selectedImagePath = openFileDialog.FileName;

                try
                {
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Выбранный файл не является изображением.\nОшибка: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(pictureBox1.Image);
            Bitmap img0 = new Bitmap(img);
            Bitmap img1 = new Bitmap(img);
            Bitmap img2 = new Bitmap(img);
            Bitmap img3 = new Bitmap(img);

            int[] intensity1 = new int[256];
            int[] intensity2 = new int[256];

            int width = img.Width;
            int height = img.Height;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color c = img.GetPixel(i, j);

                    var grey0 = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    Color nc0 = Color.FromArgb(grey0, grey0, grey0);
                    img0.SetPixel(i, j, nc0);

                    var grey1 = (int)(0.3 * c.R + 0.59 * c.G);
                    Color nc1 = Color.FromArgb(grey1, grey1, grey1);
                    img1.SetPixel(i, j, nc1);
                    intensity1[grey1]++;

                    var grey2 = (int)(0.11 * c.B);
                    Color nc2 = Color.FromArgb(grey2, grey2, grey2);
                    img2.SetPixel(i, j, nc2);
                    intensity2[grey2]++;

                    var grey3 = Math.Abs(grey1 - grey2);
                    Color nc3 = Color.FromArgb(grey3, grey3, grey3);
                    img3.SetPixel(i, j, nc3);
                }
            }
            pictureBox2.Image = img0;
            pictureBox3.Image = img1;
            pictureBox4.Image = img2;
            pictureBox5.Image = img3;

            chart1.Series.Clear();
            chart2.Series.Clear();

            Series intSeries1 = new Series("Intensity");
            Series intSeries2 = new Series("Intensity");

            for (int i = 0; i < 256; i++) 
            {
                intSeries1.Points.AddXY(i, intensity1[i]);
                intSeries2.Points.AddXY(i, intensity2[i]);
            }

            chart1.Series.Add(intSeries1);
            chart2.Series.Add(intSeries2);

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 255;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 25000;


            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 255;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 25000;
        }
    }
}
