using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Task1bc : Form
    {
        private Bitmap image; 
        private List<Point> drawingPoints; // Точки для рисования
    
        private bool isDrawing = false;
        private Pen drawingPen = new Pen(Color.Black, 3.0f);
        private Bitmap replacementImage;
        private Color replacementColor = Color.Yellow;
        private Color boundColor = Color.Black;
        private Color targetColor;
        private LinkedList<Point> borderPixels;
        public Task1bc()
        {
            InitializeComponent();
            InitializeImage();
            drawingPoints = new List<Point>();
           panel1.BackColor = drawingPen.Color;
            panel2.BackColor = replacementColor;
            panel3.BackColor = boundColor;
            button1.Hide();
            label2.Hide();
            panel2.Hide();
            panel3.Hide();
            label3.Hide();
            panel1.Hide();
            label1.Hide();
        
        }

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
            if (isDrawing && !isBoundaryAlgorithmSelected)
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

        private void FloodFill(int x, int y, Color targetColor, Bitmap replacementImage)
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

            int targetImageWidth = replacementImage.Width;
            int targetImageHeight = replacementImage.Height;

            for (int i = left_x; i <= right_x; i++)
            {
                int replacementX = i % targetImageWidth;
                int replacementY = y % targetImageHeight;
                image.SetPixel(i, y, replacementImage.GetPixel(replacementX, replacementY));
            }

            for (int i = left_x; i <= right_x; i++)
            {
                FloodFill(i, y - 1, targetColor, replacementImage);
            }

            for (int i = left_x; i <= right_x; i++)
            {
                FloodFill(i, y + 1, targetColor, replacementImage);
            }
        }
        private void FloodFillColor(int x, int y, Color targetColor, Color replacementColor)
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
                FloodFillColor(i, y - 1, targetColor, replacementColor);
            }

            for (int i = left_x; i <= right_x; i++)
            {
                FloodFillColor(i, y + 1, targetColor, replacementColor);
            }
        }
   
        private Point GetNextPixel(int x, int y, int step)
        {
            switch (step)
            {
                case 0:
                    return new Point(x + 1, y);
                case 1:
                    return new Point(x + 1, y - 1);
                case 2:
                    return new Point(x, y - 1);
                case 3:
                    return new Point(x - 1, y - 1);
                case 4:
                    return new Point(x - 1, y);
                case 5:
                    return new Point(x - 1, y + 1);
                case 6:
                    return new Point(x, y + 1);
                case 7:
                    return new Point(x + 1, y + 1);
                default:
                    return new Point(x, y);
            }
        }

        private Point startPoint; // Начальная точка для поиска границы
        private void HighlightBound(int x, int y)
        {
            Color targetBorderColor; // Цвет границы, который мы ищем
            Point currentPixel; // Текущий пиксель
            int count = 0; // Счетчик для проверки выхода из алгоритма
            int stepDirection = 6; // Направление для поиска нужного пикселя

            // Инициализируем начальную точку и добавляем ее в список границы
            startPoint = new Point(x, y);
            borderPixels = new LinkedList<Point>();
            borderPixels.AddLast(startPoint);

            // Устанавливаем цвет границы для поиска
            targetBorderColor = targetColor;

            // Начинаем обход изображения
            currentPixel = GetNextPixel(x, y, stepDirection);

            // Проверяем, является ли первый пиксель внизу границей
            if (image.GetPixel(currentPixel.X, currentPixel.Y) == targetBorderColor)
            {
                y += 1;
                stepDirection = 4;
                borderPixels.AddLast(new Point(x, y));
            }
            else
            {
                // Поиск границы в противочасовом направлении
                currentPixel = GetNextPixel(x, y, stepDirection);
                while (image.GetPixel(currentPixel.X, currentPixel.Y) != targetBorderColor)
                {
                    stepDirection = (stepDirection + 1) % 8; // Движение против часовой
                    currentPixel = GetNextPixel(x, y, stepDirection);
                }

                // Обновляем координаты
                x = currentPixel.X;
                y = currentPixel.Y;
                borderPixels.AddLast(new Point(x, y));

                // Переходим на 90 градусов по часовой стрелке от того направления, по которому пришли
                stepDirection = (stepDirection + 6) % 8;
            }

            // Добавляем пиксели границы в список
            while ((x != startPoint.X || y != startPoint.Y || stepDirection != 6) && count != image.Width * image.Height)
            {
                currentPixel = GetNextPixel(x, y, stepDirection);
                if (image.GetPixel(currentPixel.X, currentPixel.Y) == targetBorderColor)
                {
                    x = currentPixel.X;
                    y = currentPixel.Y;
                    borderPixels.AddLast(new Point(x, y));

                    stepDirection = (stepDirection + 6) % 8; // Переходим на 90 градусов по часовой стрелке от того направления, по которому пришли
                }
                else
                {
                    currentPixel = GetNextPixel(x, y, stepDirection);
                    while (image.GetPixel(currentPixel.X, currentPixel.Y) != targetBorderColor)
                    {
                        stepDirection = (stepDirection + 1) % 8; // Движение против часовой
                        currentPixel = GetNextPixel(x, y, stepDirection);
                    }

                    x = currentPixel.X;
                    y = currentPixel.Y;
                    borderPixels.AddLast(new Point(x, y));

                    stepDirection = (stepDirection + 6) % 8; // Переходим на 90 градусов по часовой стрелке от того направления, по которому пришли
                }

                count++;
            }
        }


        // рисование границы по полученным с помощью GetBorder пикселям из borderPixels
        private void DrawBorder()
        {
            
                foreach (Point pixel in borderPixels)
                    image.SetPixel(pixel.X, pixel.Y, boundColor);
            
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
                if (replacementImage != null)
                {
                     replacementImage = null;
                }
                // Попробуйте загрузить новое изображение
                replacementImage = new Bitmap(openFileDialog.FileName);     
            }
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
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null && e.Button == MouseButtons.Left)
            { 
                Point imageMouseCoordinates = ScaleMouseCoordinates(e.Location);

               targetColor = image.GetPixel(imageMouseCoordinates.X, imageMouseCoordinates.Y);
                switch (listBox1.SelectedIndex)
                {
                    case 0:
                        FloodFillColor(imageMouseCoordinates.X, imageMouseCoordinates.Y, targetColor, replacementColor);
                        break;
                    case 1:
                        FloodFill(imageMouseCoordinates.X, imageMouseCoordinates.Y, targetColor, replacementImage);
                    break;
                    case 2:
                        //startPoint.X = imageMouseCoordinates.X;
                        //startPoint.Y = imageMouseCoordinates.Y;
                        HighlightBound(imageMouseCoordinates.X, imageMouseCoordinates.Y);
                        DrawBorder();
                        break;
                    default:
                        MessageBox.Show("Выберите задание");
                       
                        break;
                }              
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
        private void ColorPanel_Click(object sender, EventArgs e)
        {
            // При клике на панель цветов открываем диалог выбора цвета
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                drawingPen.Color = colorDialog.Color;
                ((Panel)sender).BackColor = drawingPen.Color; // Обновляем цвет панели
            }
        }
        private void ColorPanel2_Click(object sender, EventArgs e)
        {
            // При клике на панель цветов открываем диалог выбора цвета
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                replacementColor = colorDialog.Color;
                ((Panel)sender).BackColor = replacementColor; // Обновляем цвет панели
            }
        }
        private void ColorPanel3_Click(object sender, EventArgs e)
        {
            // При клике на панель цветов открываем диалог выбора цвета
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (colorDialog.Color != targetColor)
                    {
                        boundColor = colorDialog.Color;
                        ((Panel)sender).BackColor = boundColor;     // Обновляем цвет панели
                    }
                }
                catch
                {
                    MessageBox.Show("Цвет границы не долден совпадать с цветом области");
               
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
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
        private bool isBoundaryAlgorithmSelected = false;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch(listBox1.SelectedIndex)
            {
                case 0:
               button1.Hide();
                    label2.Show();
                    panel2.Show();
                    panel3.Hide();
                    panel1.Show();
                    label3.Hide();
                    label1.Show();
                    isBoundaryAlgorithmSelected = false;
                    break;
                case 1:
                    panel1.Show();
                    panel2.Show();
                    button1.Show();
                    label2.Hide();
                    panel2.Hide();
                    panel3.Hide();
                    label3.Hide();
                    label1.Show();
                    isBoundaryAlgorithmSelected = false;
                    break;
                case 2:
                    panel2.Hide();
                    button1.Hide();
                    label2.Hide();
                    panel2.Hide();
                    panel3.Show();
                    label3.Show();
                    panel1.Hide();
                    label1.Hide();
                    isBoundaryAlgorithmSelected = true;
                    break;
                default:
                    panel1.Show();
                    button1.Hide();
                    label2.Hide();
                    panel2.Hide();
                    panel3.Hide();
                    label3.Hide();
                    panel1.Hide();
                    label1.Hide();
                    isBoundaryAlgorithmSelected = false;
                    break;

            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
