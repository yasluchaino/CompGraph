using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    public partial class Task3 : Form
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void h_Scroll(object sender, EventArgs e)
        {
            // Получите текущее значение трекбара
            int value = h.Value;

            // Обновите текст в Label, чтобы отобразить текущее значение
            label_HUE.Text = $"{value}";
        }

        private void s_Scroll(object sender, EventArgs e)
        {
            // Получите текущее значение трекбара
            int value = s.Value;

            // Обновите текст в Label, чтобы отобразить текущее значение
            label_SAT.Text = $"{value}";
        }

        private void v_Scroll(object sender, EventArgs e)
        {
            // Получите текущее значение трекбара
            int value = v.Value;

            // Обновите текст в Label, чтобы отобразить текущее значение
            label_V.Text = $"{value}";
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Настройте фильтр файлов, чтобы пользователь мог выбирать только изображения
            openFileDialog.Filter = "Изображения (*.jpg;*.png;*.gif;*.bmp)|*.jpg;*.png;*.gif;*.bmp|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {


                // Если в pictureBox1 уже есть изображение, удалите его
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                // Получите путь к выбранному файлу
                string selectedImagePath = openFileDialog.FileName;

                try
                {
                    // Попробуйте загрузить новое изображение
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    // Обработайте ошибку, если файл не является изображением
                    MessageBox.Show("Выбранный файл не является изображением.\nОшибка: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Не удалось получить картинку", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap input = new Bitmap(pictureBox1.Image);

            Bitmap output = new Bitmap(input.Width, input.Height);

            int h_change = h.Value;
            int s_vhange = s.Value;
            int v_change = v.Value;

            for (int j = 0; j < input.Height; j++)
                for (int i = 0; i < input.Width; i++)
                {

                    Color c = input.GetPixel(i, j);
                    double R = (double)c.R;
                    double G = (double)c.G;
                    double B = (double)c.B;


                    //RGB to HSV
                    double R1 = R / 255;
                    double G1 = G / 255;
                    double B1 = B / 255;

                    double max = Math.Max(Math.Max(R1, G1), B1);
                    double min = Math.Min(Math.Min(R1, G1), B1);

                    double H = 0;
                    double S = 0;
                    double V = max;

                    // Считаем H
                    if (max == R1 && G1 >= B1)
                    {
                        H = 60 * (G1 - B1) / (max - min);
                    }
                    else if (max == R1 && G1 < B1)
                    {
                        H = 60 * (G1 - B1) / (max - min) + 360;
                    }
                    else if (max == G1)
                    {
                        H = 60 * (B1 - R1) / (max - min) + 120;
                    }
                    else if (max == B1)
                    {
                        H = 60 * (R1 - G1) / (max - min) + 240;
                    }
                    //string message = $"Hue: {H}, Sat: {S}, Val: {V}";
                    //MessageBox.Show(message, "Значения h s v ");
                    if (max != 0)
                    {
                        S = 1 - (min / max);
                    }

                    // Добавляем значения полей

                    H = (int)(H + h_change) % 360;

                    S = S + (double)s_vhange / 100;
                    if (S > 1)
                    {
                        S = 1;
                    }
                    else if (S < 0)
                    {
                        S = 0;
                    }

                    V = V + (double)v_change / 100;
                    if (V > 1)
                        V = 1;
                    else if (V < 0)
                        V = 0;


                    //HSV to RGB

                    Color c1 = from_hsv_to_rgb(H, S, V);

                    output.SetPixel(i, j, c1);
                }
            pictureBox2.Image = output;


        }
        private Color from_hsv_to_rgb(double H, double S, double V)
        {
            //string message = $"Hue: {H}, Sat: {S}, Val: {V}";
            //MessageBox.Show(message, "Значения h s v ");
            int R = 0; int G = 0; int B = 0;

            int hi = Convert.ToInt32(Math.Floor(H / 60)) % 6;
            double f = (H / 60) - Math.Floor(H / 60);
            double p = V * (1 - S);
            double q = V * (1 - f * S);
            double t = V * (1 - (1 - f) * S);

            if (hi == 0) {
                R = Convert.ToInt32(V * 255);
                G = Convert.ToInt32(t * 255);
                B = Convert.ToInt32(p * 255);
            }
            else if (hi == 1) {
                R = Convert.ToInt32(q * 255);
                G = Convert.ToInt32(V * 255);
                B = Convert.ToInt32(p * 255);
            }
            else if (hi == 2) {
                R = Convert.ToInt32(p * 255);
                G = Convert.ToInt32(V * 255);
                B = Convert.ToInt32(t * 255);
            }
            else if (hi == 3) {
                R = Convert.ToInt32(p * 255);
                G = Convert.ToInt32(q * 255);
                B = Convert.ToInt32(V * 255);
            }
            else if (hi == 4) {
                R = Convert.ToInt32(t * 255);
                G = Convert.ToInt32(p * 255);
                B = Convert.ToInt32(V * 255);
            }
            else {
                R = Convert.ToInt32(V * 255);
                G = Convert.ToInt32(p * 255);
                B = Convert.ToInt32(q * 255);
            }
            

            return Color.FromArgb(R, G, B);
        }

        private void save_buttom_Click(object sender, EventArgs e)
        {
            System.Drawing.Image image = pictureBox2.Image;
            if (pictureBox2.Image != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
