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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void task_2_click_Click(object sender, EventArgs e)
        {
            Task2 task2 = new Task2();
            task2.Show();

        }

        private void task_3_click_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task1bc task1 = new Task1bc();
            task1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
