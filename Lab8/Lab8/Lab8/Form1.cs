using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public enum Axis { AXIS_X, AXIS_Y, AXIS_Z, LINE };
    public enum Projection { PERSPECTIVE = 0, AXONOMETRIC};
    public enum Clipping { clipping = 0, ZBuffer , Gouro};
    public partial class Form1 : Form
    {
        Graphics g;
        Projection projection = 0;
        Polyhedra figure = null; // наша текущая фигура
        Axis rotateLineMode = 0;
        Clipping clipping = 0;

        Camera camera;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            g.TranslateTransform(pictureBox1.ClientSize.Width / 2, pictureBox1.ClientSize.Height / 2);
            g.ScaleTransform(1, -1);
            camera = new Camera(new PointD(2, 2,2), 0, Math.PI / 4, -Math.PI / 4);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                //Hex
                g.Clear(Color.White);
                figure = new Polyhedra();
                figure.Hexahedron();

                if (clipping == 0)
                    figure.DrawLines(g, projection);
                else if (clipping == Clipping.ZBuffer)
                    show_z_buff();
                else if (clipping == Clipping.Gouro)
                    show_gouro();
                
            }
            else if (radioButton2.Checked)
            {//Tetr
                g.Clear(Color.White);
                figure = new Polyhedra();
                figure.Tetrahedron();

                if (clipping == 0)
                    figure.DrawLines(g, projection);
                else if (clipping == Clipping.ZBuffer)
                    show_z_buff();
                else if (clipping == Clipping.Gouro)
                    show_gouro();
            }
            else if (radioButton3.Checked)
            {
                //Okt
                g.Clear(Color.White);
                figure = new Polyhedra();
                figure.Octahedron();

                if (clipping == 0)
                    figure.DrawLines(g, projection);
                else if (clipping == Clipping.ZBuffer)
                    show_z_buff();
                else if (clipping == Clipping.Gouro)
                    show_gouro();
            }
            camera = new Camera(new PointD(10, 10, 10), 0, Math.PI / 4, -Math.PI / 4);

        }

        //----------------------------------------------LAB8/9-------------------------------------------------------\\
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0:
                    clipping = 0;
                    break;
                case 1:
                    clipping = Clipping.ZBuffer;
                    break;
                case 2:
                    clipping = Clipping.Gouro;
                    break;
                default:
                    clipping = 0;
                    break;
            }
        }
    
        private void show_z_buff()
        {
            int[] buff = new int[pictureBox1.Width * pictureBox1.Height];

            figure.calculateZBuffer(pictureBox1.Width, pictureBox1.Height, out buff);

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;

            g.Clear(Color.White);

            for (int i = 0; i < pictureBox1.Width; ++i)
                for (int j = 0; j < pictureBox1.Height; ++j)
                {
                    Color c = Color.FromArgb(buff[i * pictureBox1.Height + j], buff[i * pictureBox1.Height + j], buff[i * pictureBox1.Height + j]);
                    bmp.SetPixel(i, j, c);
                }

            pictureBox1.Refresh();
        }
        private void show_gouro()
        {
            float[] buff = new float[pictureBox1.Width * pictureBox1.Height];
            Color fill_color = Color.FromArgb(int.Parse(colorRed.Text), int.Parse(colorGreen.Text), int.Parse(colorBlue.Text)); 
            figure.calcGouro(camera.view, pictureBox1.Width, pictureBox1.Height, out buff, new PointD(int.Parse(light_x.Text), int.Parse(light_y.Text), int.Parse(light_z.Text)));
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var eps = 0.000001;
            pictureBox1.Image = bmp;
            
            g.Clear(Color.White);
            for (int i = 0; i < pictureBox1.Width; ++i)
                for (int j = 0; j < pictureBox1.Height; ++j)
                {
                    Color c;
                    if (buff[i * pictureBox1.Height + j] < eps)
                        c = Color.White;
                    else
                    {
                        float intsv = buff[i * pictureBox1.Height + j];
                        if (intsv > 1)
                            intsv = 1;
                        c = Color.FromArgb((int)(fill_color.R * intsv) % 256, (int)(fill_color.G * intsv) % 256, (int)(fill_color.B * intsv) % 256);
                    }
                    bmp.SetPixel(i, j, c);
                }

            pictureBox1.Refresh();
        }
  
       

        //------------------------------------------------------------\\   
        //фигура вращения
        private void button7_Click(object sender, EventArgs e)
        {
            List<PointD> points = new List<PointD>();
            var lines = textBox1.Text.Split('\n');

            foreach (var p in lines)
            {
                //берем точки из листбокса, добавляем в список который передадим затем в конструктор RotationFigure
                var arr = ((string)p).Split(';');
                points.Add(new PointD(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2])));
            }

            Axis axis;
            switch (textBox6.Text)
            {
                case "OX":
                    axis = 0;
                    break;
                case "OY":
                    axis = Axis.AXIS_Y;
                    break;
                case "OZ":
                    axis = Axis.AXIS_Z;
                    break;
                default:
                    axis = 0;
                    break;
            }

            RotationFigure rotateFigure = new RotationFigure(points, axis, int.Parse(textBox5.Text));

            figure = rotateFigure;

            g.Clear(Color.White);
            //теперь везде ресуем в зависимости от того, включен zbuf или нет

            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        //это перенос
        private void buttonTranslite_Click(object sender, EventArgs e)
        {

            int offsetX = int.Parse(textBox10.Text), offsetY = int.Parse(textBox7.Text), offsetZ = int.Parse(textBox8.Text);
            figure.Translate(offsetX, offsetY, offsetZ);
            g.Clear(Color.White);

            //теперь везде ресуем в зависимости от того, включен zbuf или нет
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else show_gouro();
        }

        //кнопка поворота вокруг графика какого-либо
        private void rotate_Click(object sender, EventArgs e)
        {
            int rotateAngleX = int.Parse(rotatex.Text);
            figure.Rotate(rotateAngleX, 0);

            int rotateAngleY = int.Parse(rotatey.Text);
            figure.Rotate(rotateAngleY, Axis.AXIS_Y);

            int rotateAngleZ = int.Parse(rotatez.Text);
            figure.Rotate(rotateAngleZ, Axis.AXIS_Z);

            g.Clear(Color.White);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
        //поворот относительно произвольной линии
        private void button3_Click(object sender, EventArgs e)
        {
            Line rotateLine = new Line(
                                new PointD(
                                     int.Parse(x1_text.Text),
                                     int.Parse(y1_text.Text),
                                     int.Parse(z1_text.Text)),
                                new PointD(
                                    int.Parse(x2_text.Text),
                                     int.Parse(y2_text.Text),
                                     int.Parse(z2_text.Text)));

            float Ax = rotateLine.First.X, Ay = rotateLine.First.Y, Az = rotateLine.First.Z;
            figure.Translate(-Ax, -Ay, -Az);

            double angle = double.Parse(angle_text.Text);
            figure.Rotate(angle, rotateLineMode, rotateLine);

            figure.Translate(Ax, Ay, Az);
            g.Clear(Color.White);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            float old_x = figure.Center.X, old_y = figure.Center.Y, old_z = figure.Center.Z;
            figure.Translate(-old_x, -old_y, -old_z);

            float kx = int.Parse(xScale.Text), ky = int.Parse(yScale.Text), kz = int.Parse(zScale.Text);
            figure.Scale(kx, ky, kz);

            figure.Translate(old_x, old_y, old_z);
            g.Clear(Color.White);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void buttonMirror_Click(object sender, EventArgs e)
        {

            switch (comboBoxAxis.SelectedIndex)
            {
                case 0://z
                    figure.reflectZ();
                    break;
                case 1://y
                    figure.reflectY();
                    break;
                case 2://x
                    figure.reflectX();
                    break;
            }

            g.Clear(Color.White);
            //теперь везде ресуем в зависимости от того, включен zbuf или нет
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        { }
        Graph graph = null;
        private void button1_Click(object sender, EventArgs e)
        {
            graph = new Graph(comboBox1.SelectedIndex);

            figure = graph;

            g.Clear(Color.White);
            graph.picture = pictureBox1;
            graph.DrawGraphic();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.W: UpBtn_Click();  break;
                case Keys.A: LeftBtn_Click(); break;
                case Keys.S: DownBtn_Click(); break;
                case Keys.D: RightBtn_Click(); break;

                case Keys.Left: RotLeftBtn_Click(); break;
                case Keys.Right:  RotRightBtn_Click(); break;
                case Keys.Up:BackBtn_Click(); break;
                case Keys.Down:  ForwardBtn_Click(); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void UpBtn_Click()
        {

            figure.Translate(0,(float)-5, 0);

            camera.translate(0, (float)5, 0);

            g.Clear(Color.White);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void DownBtn_Click()
        {
            figure.Translate(0, (float)5, 0);

            camera.translate(0, (float)-5, 0);

            g.Clear(Color.White);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void RightBtn_Click()
        {
            figure.Translate((float)-5, 0, 0);

            camera.translate((float)5, 0, 0);



            g.Clear(Color.White);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void LeftBtn_Click()
        {
            figure.Translate((float)5, 0, 0);

            camera.translate((float)-5, 0, 0);

            g.Clear(Color.White);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void ForwardBtn_Click()
        {

            double angleOY = 5;
            figure.Rotate(-angleOY, Axis.AXIS_X);
            camera.rotate(angleOY, Axis.AXIS_X);
            g.Clear(Color.White);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void BackBtn_Click()
        {
            double angleOY = 5;
            figure.Rotate(angleOY, Axis.AXIS_X);
            camera.rotate(-angleOY, Axis.AXIS_X);
     
            g.Clear(Color.White);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void RotRightBtn_Click()
        {
  double angleOX = 5;
            figure.Rotate(-angleOX, Axis.AXIS_Y);
            camera.rotate(angleOX, Axis.AXIS_Y);
            g.Clear(Color.White);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }

        private void RotLeftBtn_Click()
        {
            double angleOX = 5;
            figure.Rotate(angleOX, Axis.AXIS_Y);
            camera.rotate(angleOX, Axis.AXIS_Y);
            g.Clear(Color.White);
            figure.DrawLines(g, projection);
            if (clipping == 0)
                figure.DrawLines(g, projection);
            else if (clipping == Clipping.ZBuffer)
                show_z_buff();
            else if (clipping == Clipping.Gouro)
                show_gouro();
        }
    }
}
