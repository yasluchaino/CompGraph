using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Lab4
{


    public partial class Form1 : Form
    {

        private List<Line> lines = new List<Line>();
        private Point point = new Point(0, 0);
        private List<PointF> polygonPoints = new List<PointF>();

        private SolidBrush brush = new SolidBrush(Color.BurlyWood);
        private Graphics g;

        private bool isDrawing = false;

        private PointF startPoint;
        private PointF endPoint;

        private PointF minPolyCoordinates;
        private PointF maxPolyCoordinates;

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();

        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                isDrawing = true;
            }
            else if (checkBox2.Checked)
            {

                isDrawing = true;
                startPoint = e.Location;
            }
            else if (checkBox3.Checked)
            {
                isDrawing = true;
                if (polygonPoints.Count == 0)
                {
                    startPoint = e.Location;
                    minPolyCoordinates = e.Location;
                    maxPolyCoordinates = e.Location;
                    polygonPoints.Add(startPoint);
                }

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && (checkBox2.Checked || checkBox3.Checked))
            {

                endPoint = e.Location;


                pictureBox1.Invalidate();
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (checkBox1.Checked)
            {
                isDrawing = false;
                point = e.Location;
                if (checkBox4.Checked)
                {
                    Right_Or_Left();
                }
                else if (checkBox5.Checked && Check_Convex())
                {
                    Inside_Convex_Polygon();
                }
                else if (checkBox6.Checked && !Check_Convex())
                {
                    Inside_Non_Convex_Polygon();
                }
            }

            else if (isDrawing && checkBox2.Checked)
            {
                isDrawing = false;

                // текущий отрезок
                Line line = new Line { StartPoint = startPoint, EndPoint = endPoint };
                lines.Add(line);

            }

            else if (isDrawing && checkBox3.Checked)
            {
                isDrawing = false;
                polygonPoints.Add(endPoint);

                if (endPoint.X < minPolyCoordinates.X)
                    minPolyCoordinates.X = endPoint.X;
                if (endPoint.Y < minPolyCoordinates.Y)
                    minPolyCoordinates.Y = endPoint.Y;
                if (endPoint.X > maxPolyCoordinates.X)
                    maxPolyCoordinates.X = endPoint.X;
                if (endPoint.Y > maxPolyCoordinates.Y)
                    maxPolyCoordinates.Y = endPoint.Y;
                startPoint = endPoint;


            }

            pictureBox1.Invalidate();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillEllipse(brush, point.X - 3, point.Y - 3, 5, 5);

            foreach (var line in lines)
            {
                e.Graphics.DrawLine(new Pen(line.Color), line.StartPoint, line.EndPoint);
            }

            if (isDrawing && checkBox2.Checked)
            {
                e.Graphics.DrawLine(Pens.BlueViolet, startPoint, endPoint);
            }



            if (polygonPoints.Count >= 2)
            {


                for (int i = 0; i < polygonPoints.Count - 1; i++)
                    e.Graphics.DrawLine(Pens.DeepPink, polygonPoints[i], polygonPoints[i + 1]);

                // соединяем последнбб точку с первой
                if (polygonPoints.Count > 2)
                    e.Graphics.DrawLine(Pens.DeepPink, polygonPoints[polygonPoints.Count - 1], polygonPoints[0]);
            }

            if (isDrawing && checkBox3.Checked)
            {
                e.Graphics.DrawLine(Pens.DeepPink, startPoint, endPoint);
            }

        }


        private void PrimitiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                groupBox1.Visible = true;
                // сбрасываем остальные, если уже какой-то выбран
                if (checkBox == checkBox1)
                {
                    line_box.Visible = false;
                    rotate_box.Visible = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Visible = true;
                    checkBox5.Visible = true;
                    checkBox6.Visible = true;
                }
                else if (checkBox == checkBox2)
                {
                    line_box.Visible = true;
                    rotate_box.Visible = true;
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Visible = false;
                    checkBox5.Visible = false;
                    checkBox6.Visible = false;
                }
                else if (checkBox == checkBox3)
                {
                    line_box.Visible = false;
                    rotate_box.Visible = false;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox4.Visible = false;
                    checkBox5.Visible = false;
                    checkBox6.Visible = false;
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            point = Point.Empty;
            polygonPoints.Clear();
            lines.Clear();
            groupBox1.Visible = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox4.Checked = false;
            g.Clear(Color.White);

        }

        private PointF intersect_point(PointF p0, PointF p1, PointF p2, PointF p3)
        {
            

            float a1 = p1.Y - p0.Y;
            float b1 = p0.X - p1.X;
            float c1 = a1 * p0.X + b1 * p0.Y;

            float a2 = p3.Y - p2.Y;
            float b2 = p2.X - p3.X;
            float c2 = a2 * p2.X + b2 * p2.Y;

            float d = a1 * b2 - a2 * b1;

            if (d== 0)//условие, что прямые параллельны
            {

                return Point.Empty;
            }

            float X = (b2 * c1 - b1 * c2) / d;
            float Y = (a1 * c2 - a2 * c1) / d;

            float minX1 = Math.Min(p0.X, p1.X);
            float maxX1 = Math.Max(p0.X, p1.X);
            float minY1 = Math.Min(p0.Y, p1.Y);
            float maxY1 = Math.Max(p0.Y, p1.Y);

            float minX2 = Math.Min(p2.X, p3.X);
            float maxX2 = Math.Max(p2.X, p3.X);
            float minY2 = Math.Min(p2.Y, p3.Y);
            float maxY2 = Math.Max(p2.Y, p3.Y);
          

            if (X >= minX1 && X <= maxX1 && Y >= minY1 && Y <= maxY1
                && X >= minX2 && X <= maxX2 && Y >= minY2 && Y <= maxY2)
            {
         
                return new PointF(X, Y);
            }

            return PointF.Empty;


        }


        //ищет пересеччение между только что нарисованным отрезком и предыдущим(главное не забыть какой был предыдущий)
        private void intersect_Click(object sender, EventArgs e)
        {
            PointF intersection = intersect_point(lines[lines.Count - 2].StartPoint, lines[lines.Count - 2].EndPoint, lines[lines.Count - 1].StartPoint, lines[lines.Count - 1].EndPoint);

            if (!intersection.IsEmpty)
            {
                g.FillEllipse(Brushes.YellowGreen, intersection.X - 3, intersection.Y - 3, 5, 5);
                //pictureBox1.Invalidate();
                pictureBox1.Update();
                textBox1.Text = intersection.Y.ToString();
                textBox2.Text = intersection.X.ToString();
                 
            }
            else
            {
                MessageBox.Show("Не пересекаются");
                textBox1.Text = "";
                textBox2.Text = "";
            }
           
        }
       
        //поворот многоугольника относительно начала координат (точки (0, 0)) на заданный угол.
        private void RotateAtOrigin(List<PointF> polygon, float angle)
        {
            float[,] rotationMatrix = AffineTransformations.rotateMatrix(angle);
            List<PointF> res = AffineTransformations.ApplyTransformationToPoints(rotationMatrix, polygon);
            polygon.Clear();
            polygon.AddRange(res);      
        }
       
        private void rotatePolygon(List<PointF> polygon, float angle, Point pivot)
        {
            /*PointF[] polygonArray = polygon.ToArray();
            Matrix rotationMatrix = new Matrix();
            rotationMatrix.RotateAt(angle, pivot);
            rotationMatrix.TransformPoints(polygonArray);
            polygon.Clear();
            polygon.AddRange(polygonArray);*/

            //смещает многоугольник так, чтобы его центр совпал с pivot
            translatePolygon(polygon, -pivot.X, -pivot.Y);
            //поворот на угол angle
            RotateAtOrigin(polygon, angle);
            //обратное смещение после поворота, возвращая многоугольник в исходное положение
            translatePolygon(polygon, pivot.X, pivot.Y);

        }
        private void translatePolygon(List<PointF> polygon, int dx, int dy)
        {
            /*PointF[] polygonArray = polygon.ToArray();  // Преобразуем List<Point> в массив Point[]
            Matrix translationMatrix = new Matrix();
            translationMatrix.Translate(dx, -dy);
            translationMatrix.TransformPoints(polygonArray);
            // Обновляем List<Point> с преобразованными значениями
            polygon.Clear();
            polygon.AddRange(polygonArray);*/

            List<PointF> res;
            float[,] translationMatrix = AffineTransformations.TranslationMatrix(dx, dy);
            res = AffineTransformations.ApplyTransformationToPoints(translationMatrix, polygon);
            polygon.Clear();
            polygon.AddRange(res);
   
        }
        private void scalePolygon(List<PointF> polygon, float scaleX, float scaleY, Point pivot)
        {
            PointF[] polygonArray = polygon.ToArray();
            Matrix scalingMatrix = new Matrix();
            scalingMatrix.Scale(scaleX, scaleY);
            scalingMatrix.Translate(pivot.X * (1 - scaleX), pivot.Y * (1 - scaleY), MatrixOrder.Append);
            scalingMatrix.TransformPoints(polygonArray);
            polygon.Clear();
            polygon.AddRange(polygonArray);

            //// Перенос к началу координат
            //translatePolygon(polygon, -pivot.X, -pivot.Y);
            //// Масштабирование относительно начала координат
            //float[,] scalingMatrix = AffineTransformations.ScaleMatrix(scaleX, scaleY);
            //List<PointF> transformedPoints = AffineTransformations.ApplyTransformationToPoints(scalingMatrix, polygon);
            //polygon.Clear();
            //polygon.AddRange(transformedPoints);
            //// Возврат к исходной позиции
            //translatePolygon(polygon, pivot.X, pivot.Y);  

        }

        private void move_button_Click(object sender, EventArgs e)
        {
            int dx = (int)numericUpDown1.Value;
            int dy = (int)numericUpDown2.Value;
            translatePolygon(polygonPoints, dx, -dy);
            pictureBox1.Invalidate();
        }
        private void rotate_button_Click(object sender, EventArgs e)
        {
            float angle = (float)numericUpDown3.Value;
            rotatePolygon(polygonPoints, angle, point);
            pictureBox1.Invalidate();  
        }
        private void scale_button_Click(object sender, EventArgs e)
        {
            float scaleX = (float)numericUpDown4.Value;
            float scaleY = (float)numericUpDown5.Value;
            scalePolygon(polygonPoints, scaleX, scaleY, point);
            pictureBox1.Invalidate();
        }
        public class Line
        {
            public PointF StartPoint { get; set; }
            public PointF EndPoint { get; set; }
            public Color Color { get; set; } = Color.BlueViolet;

            public Line() { }

            public Line(PointF start, PointF end, Color color)
            {
                StartPoint = start;
                EndPoint = end;
                Color = color;
            }
            public Line(PointF start, PointF end)
            {
                StartPoint = start;
                EndPoint = end;
                Color = Color.BlueViolet;
            }
        }
        public static class AffineTransformations
        {
            public static float[,] MultiplyMatrices(float[,] matrix1, float[,] matrix2)
            {
                int rows1 = matrix1.GetLength(0);
                int cols1 = matrix1.GetLength(1);
                int rows2 = matrix2.GetLength(0);
                int cols2 = matrix2.GetLength(1);

                if (cols1 != rows2)
                {
                    throw new ArgumentException("Invalid matrix dimensions for multiplication");
                }

                float[,] result = new float[rows1, cols2];

                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        float sum = 0;
                        for (int k = 0; k < cols1; k++)
                        {
                            sum += matrix1[i, k] * matrix2[k, j];
                        }
                        result[i, j] = sum;
                    }
                }

                return result;
            }
            //применяет аффинное преобразование, заданное матрицей transformationMatrix, ко всем точкам в списке points
            public static List<PointF> ApplyTransformationToPoints(float[,] transformationMatrix, List<PointF> points)
            {
                List<PointF> transformedPoints = new List<PointF>();

                foreach (var point in points)
                {
                    PointF transformedPoint = ApplyTransformation(transformationMatrix, point);
                    transformedPoints.Add(transformedPoint);
                }

                return transformedPoints;
            }
            //возвращает новую точку(PointF) с преобразованными координатами.
            public static PointF ApplyTransformation(float[,] transformationMatrix, PointF point)
            {
                float x = point.X;
                float y = point.Y;

                float transformedX = transformationMatrix[0, 0] * x + transformationMatrix[0, 1] * y + transformationMatrix[0, 2];
                float transformedY = transformationMatrix[1, 0] * x + transformationMatrix[1, 1] * y + transformationMatrix[1, 2];

                return new PointF(transformedX, transformedY);
            }
            public static float[,] rotateMatrix(float angle)
            {
                float sin = (float)Math.Sin(angle * Math.PI / 180);
                float cos = (float)Math.Cos(angle * Math.PI / 180);
                float[,] rotationMatrix =
                {
                    {cos, sin,0 },
                    {-sin, cos, 0},
                    { 0,0,1 }
                };
                return rotationMatrix;
            }
			public static float[,] TranslationMatrix(float dx, float dy)
			{
                //(x y 1 ) * ([1  0  0][0  1  0][dx dy 1])
				return new float[,] {
		            { 1, 0, dx },
		            { 0, 1, dy },
		            { 0, 0, 1 }
	               };
			}
            public static float[,] ScaleMatrix(float scaleX, float scaleY)
            {
                      return new float[,] {
                    { scaleX, 0, 0 },
                    { 0, scaleY, 0 },
                    { 0, 0, 1 }
                   };
            }
        }
        private void rotate_edge_Click(object sender, EventArgs e)
        {
            double angle = 90;


            for (int i = 0; i < lines.Count; i++)
            {
                PointF center = new PointF((lines[i].StartPoint.X + lines[i].EndPoint.X) / 2,
                                           (lines[i].StartPoint.Y + lines[i].EndPoint.Y) / 2);

                Matrix rotationMatrix = new Matrix();
                rotationMatrix.RotateAt((float)angle, center);

                PointF[] points = { lines[i].StartPoint, lines[i].EndPoint };
                rotationMatrix.TransformPoints(points);

                lines[i] = new Line(points[0], points[1], lines[i].Color);
            }

            pictureBox1.Invalidate();
        }

        private void Inner_checkBoxes_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                if (checkBox == checkBox4)
                {
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                }
                else if (checkBox == checkBox5)
                {
                    checkBox4.Checked = false;
                    checkBox6.Checked = false;
                }
                else if (checkBox == checkBox6)
                {
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                }
            }
        }

        private void Right_Or_Left()
        {
            double min_dist = double.MaxValue;
            var Mx = point.X;
            var My = point.Y;
            int ind = 0;
            int end_ind = 0;
            foreach (Line line in lines)
            {
                var A = line.EndPoint.Y - line.StartPoint.Y;
                var B = -1 * (line.EndPoint.X - line.StartPoint.X);
                var C = line.StartPoint.Y * line.EndPoint.X - line.StartPoint.X * line.EndPoint.Y;
                var d = Math.Abs(A * Mx + B * My + C) / Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
                //Console.WriteLine(d);
                if (d < min_dist)
                {
                    min_dist = d;
                    end_ind = ind;
                }
                ind++;
            }
            //Console.WriteLine(end_ind);
            PointF[] pf = new PointF[3];
            pf[0] = lines[end_ind].StartPoint;
            pf[1] = lines[end_ind].EndPoint;
            pf[2] = point;

            pf[1].X -= pf[0].X;
            pf[1].Y -= pf[0].Y;
            pf[2].X -= pf[0].X;
            pf[2].Y -= pf[0].Y;
            //Console.WriteLine(pf[2].Y * pf[1].X - pf[2].X * pf[1].Y);
            if (pf[2].Y * pf[1].X - pf[2].X * pf[1].Y > 0)
            {
                MessageBox.Show("Справа!");
            }
            else if (pf[2].Y * pf[1].X - pf[2].X * pf[1].Y < 0)
            {
                MessageBox.Show("Слева!");
            }
        }

        private void Inside_Convex_Polygon()
        {
            bool flag = true;
            for (int i = 1; i < polygonPoints.Count; i++)
            {
                PointF[] pf = new PointF[3];
                pf[0] = polygonPoints[i - 1];
                pf[1] = polygonPoints[i];
                pf[2] = point;
                pf[1].X -= pf[0].X;
                pf[1].Y -= pf[0].Y;
                pf[2].X -= pf[0].X;
                pf[2].Y -= pf[0].Y;
                if (pf[2].Y * pf[1].X - pf[2].X * pf[1].Y < 0)
                {
                    flag = false;
                }
            }
            if (flag)
                MessageBox.Show("Внутри!");
            else
                MessageBox.Show("Снаружи!");
        }

        private bool Check_Convex() 
        {
            int tf = 0;
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                var j = (i + 1) % polygonPoints.Count;
                var k = (i + 2) % polygonPoints.Count;
                var z = (polygonPoints[j].X - polygonPoints[i].X) * (polygonPoints[k].Y - polygonPoints[j].Y);
                z -= (polygonPoints[j].Y - polygonPoints[i].Y) * (polygonPoints[k].X - polygonPoints[j].X);
                if (z < 0)
                    tf |= 1;
                else if (z > 0)
                    tf |= 2;
                if (tf == 3)
                    return false;
            }
            if (tf != 0)
                return true;
            else
                return false;
        }

        private void Inside_Non_Convex_Polygon() 
        {
            int count = 0;
            bool flag = true;
            PointF end_point = new PointF(pictureBox1.Size.Width, point.Y);
            for (int i = 1; i < polygonPoints.Count; i++) 
            {
                var tt = intersect_point(point, end_point, polygonPoints[i - 1], polygonPoints[i]);
                if (tt != PointF.Empty) 
                {
                    if (polygonPoints[i - 1].Y == point.Y || polygonPoints[i].Y == point.Y)
                    {
                        if (flag)
                        {
                            count++;
                            flag = false;
                            continue;
                        }
                        else 
                        {
                            flag = true;
                            continue;
                        }
                    }
                    count++;
                }
            }
            var t = intersect_point(point, end_point, polygonPoints[polygonPoints.Count-1], polygonPoints[0]);
            if (t != PointF.Empty)
            {
                count++;
            }

            if (count % 2 == 0)
                MessageBox.Show("Снаружи!");
            else
                MessageBox.Show("Внутри");
        }

    }
}
