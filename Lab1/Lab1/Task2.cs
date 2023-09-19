using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task2Res task2Res = new Task2Res();
            task2Res.Show();
        }
        public PictureBox GetPictureBox()
        {
            return pictureBox2;
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
