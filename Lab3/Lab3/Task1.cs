using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Lab3
{
    public partial class Task1 : Form
    {
        //private List<Bitmap> filledImages = new List<Bitmap>();
        private Bitmap image;
        private Color replacementColor;
        private Color targetColor;
        public Task1()
        {
            InitializeComponent();
            InitializeImage();
            drawingPoints = new List<Point>();
        }
        private void FloodFill(int x, int y, Color targetColor, Color replacementColor)
        {
            int width = image.Width;
            int height = image.Height;

            if (x < 0 || x >= width || y < 0 || y >= height)
                return;

            if (image.GetPixel(x, y) != targetColor)
                return;

            int left_x = x;
            while (left_x > 0 && image.GetPixel(left_x - 1, y) == targetColor)
                left_x--;

            int right_x = x;
            while (right_x < width - 1 && image.GetPixel(right_x + 1, y) == targetColor)
                right_x++;

            for (int i = left_x; i <= right_x; i++)
            {
                image.SetPixel(i, y, replacementColor);
            }

            for (int i = left_x; i <= right_x; i++)
            {
                FloodFill(i, y - 1, targetColor, replacementColor);
            }

            for (int i = left_x; i <= right_x; i++)
            {
                FloodFill(i, y + 1, targetColor, replacementColor);
            }
        }
        private List<Point> drawingPoints; // Точки для рисования
        private bool isDrawing = false;
        private Pen drawingPen = new Pen(Color.Black, 3.0f);
        private void InitializeImage()
        {
            // Создаем изображение с белым фоном
            image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.White);
            }

            pictureBox1.Image = image;
        }
        private Point ScaleMouseCoordinates(Point mouseCoordinates)
        {
            int pictureBoxWidth = pictureBox1.Width;
            int pictureBoxHeight = pictureBox1.Height;

            int imageWidth = image.Width;
            int imageHeight = image.Height;

            float scaleX = (float)imageWidth / pictureBoxWidth;
            float scaleY = (float)imageHeight / pictureBoxHeight;

            int imageX = (int)(mouseCoordinates.X * scaleX);
            int imageY = (int)(mouseCoordinates.Y * scaleY);

            return new Point(imageX, imageY);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (image != null)
            {
                isDrawing = true;
                drawingPoints.Clear();

                Point imageMouseCoordinates = ScaleMouseCoordinates(e.Location);

                drawingPoints.Add(imageMouseCoordinates);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point imageMouseCoordinates = ScaleMouseCoordinates(e.Location);

                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawLine(drawingPen, drawingPoints[drawingPoints.Count - 1], imageMouseCoordinates);
                }

                drawingPoints.Add(imageMouseCoordinates);
                pictureBox1.Invalidate(); // Обновляем PictureBox
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            //  image.Save("image1.png", System.Drawing.Imaging.ImageFormat.Png);
            pictureBox1.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Настройте фильтр файлов, чтобы пользователь мог выбирать только изображения
                Filter = "Изображения (*.jpg;*.png;*.gif;*.bmp)|*.jpg;*.png;*.gif;*.bmp|Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Если в pictureBox1 уже есть изображение, удалите его
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                try
                {
                    // Попробуйте загрузить новое изображение
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                    image = new Bitmap(pictureBox1.Image);

                }
                catch (Exception ex)
                {
                    // Обработайте ошибку, если файл не является изображением
                    MessageBox.Show("Выбранный файл не является изображением.\nОшибка: " + ex.Message);
                }
            }
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null && e.Button == MouseButtons.Left)
            {
                Point imageMouseCoordinates = ScaleMouseCoordinates(e.Location);

                ColorDialog colorDialog = new ColorDialog
                {
                    Color = replacementColor
                };

                if (colorDialog.ShowDialog() == DialogResult.OK)
                    replacementColor = colorDialog.Color;
                          
                targetColor = image.GetPixel(imageMouseCoordinates.X, imageMouseCoordinates.Y);
                FloodFill(imageMouseCoordinates.X, imageMouseCoordinates.Y, targetColor, replacementColor);
                //image.Save("filled_image.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
              
            }
        }

       
            private void clear_button_Click(object sender, EventArgs e)
             {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.White);
            }
            pictureBox1.Image = image;

        }
        
    }

}
