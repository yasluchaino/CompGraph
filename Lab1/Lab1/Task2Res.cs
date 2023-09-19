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
    public partial class Task2Res : Form
    {    
        public Task2Res()
        {
            InitializeComponent();
        }

        private void CreateHist(int[] ii, Chart chart)
        {
            chart.Series.Clear();
            Series series = new Series(); 
            for (int i = 0; i < 256; i++)
            {
                if (chart.Name == "chartRed")
                {
                    series.Color = Color.Red;
                    series.Points.AddXY(i, ii[i]);
                }
                else if (chart.Name == "chartGreen")
                {
                    series.Color = Color.Green;
                    series.Points.AddXY(i, ii[i]);
                }
                else if (chart.Name =="chartBlue")
                {
                    series.Color = Color.Blue;
                    series.Points.AddXY(i, ii[i]);
                }
            }
              
                                 
            chart.Series.Add(series);
          
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 255;
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 25000;
            chart.ChartAreas[0].AxisX.Title = "Color Value";
            chart.ChartAreas[0].AxisY.Title = "Frequency";
        }
        private void SelectColor()
        {

            int[] redHist1 = new int[256];
            int[] greenHist1 = new int[256];
            int[] blueHist1 = new int[256];

            //int[] redHist2 = new int[256];
            //int[] greenHist2 = new int[256];
            //int[] blueHist2 = new int[256];

            //int[] redHist3 = new int[256];
            //int[] greenHist3 = new int[256];
            //int[] blueHist3 = new int[256];

            try
            { 
                Bitmap img1 = new Bitmap(pictureBox2.Image);
                Bitmap img2 = new Bitmap(pictureBox2.Image);
                Bitmap img3 = new Bitmap(pictureBox2.Image);
                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        Color c = img1.GetPixel(i, j);
                        Color nc = Color.FromArgb(c.A, c.R, 0, 0);
                        img1.SetPixel(i, j, nc); 
                        nc = Color.FromArgb(c.A, 0, c.G, 0);
                        img2.SetPixel(i, j, nc);
                        nc = Color.FromArgb(c.A, 0, 0, c.B);
                        img3.SetPixel(i, j, nc);

                        redHist1[img1.GetPixel(i,j).R]++;
                        greenHist1[img2.GetPixel(i, j).G]++;
                        blueHist1[img3.GetPixel(i, j).B]++;
                    }
                }
                pixelRed.Image = img1;  
                pixelGreen.Image = img2;
                pixelBlue.Image = img3;
                CreateHist(redHist1, chartRed);
                CreateHist(greenHist1, chartGreen);
                CreateHist(blueHist1, chartBlue);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }


        private void Task2Res_Load(object sender, EventArgs e)
        {

        }

        private void pixelBlue_Click(object sender, EventArgs e)
        {

        }

        private void chartRed_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectColor();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Настройте фильтр файлов, чтобы пользователь мог выбирать только изображения
            openFileDialog.Filter = "Изображения (*.jpg;*.png;*.gif;*.bmp)|*.jpg;*.png;*.gif;*.bmp|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Если в pictureBox1 уже есть изображение, удалите его
                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                    pictureBox2.Image = null;
                }

                // Получите путь к выбранному файлу
                string selectedImagePath = openFileDialog.FileName;

                try
                {
                    // Попробуйте загрузить новое изображение
                    pictureBox2.Image = new Bitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    // Обработайте ошибку, если файл не является изображением
                    MessageBox.Show("Выбранный файл не является изображением.\nОшибка: " + ex.Message);
                }
            }
      
    }
    }
}
