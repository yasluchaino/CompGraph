﻿using System;
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
 Task2Res task2 = new Task2Res();
            // Show the settings form
            task2.Show();
        }

        private void task3_Click(object sender, EventArgs e)
        {
            Task3 task3 = new Task3();
            task3.Show();
           
        }
        private void task1_Click_1(object sender, EventArgs e)
        {
            Task1Res task1 = new Task1Res();
            task1.Show();
        }

    }
}
