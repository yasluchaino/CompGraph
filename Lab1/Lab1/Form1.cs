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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void task2_Click(object sender, EventArgs e)
        {
 Task2 task2 = new Task2();
            // Show the settings form
            task2.Show();
        }

        private void task3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
