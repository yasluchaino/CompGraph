using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace lab5
{
    
   
    public partial class Task1 : Form
    { 
        const int MAX_IT = 5;
        private class LineSegment
        {
            public float  CurrentX{ get; }
            public float CurrentY { get; }
            public float NewX { get; }
            public float NewY { get; }

            public LineSegment(float startX, float startY, float EndX, float EndY)
            {
                CurrentX = startX;
                CurrentY = startY;
                NewX = EndX;
                NewY = EndY;
            }
        }

        private string atom;
        private double angle;
        private int direction;
        private List<string> rules;
        private Dictionary<string, List<string>> rulesDict;
        private int startX;
        private int startY;
        private double maxh;
        private double maxw;
        private double minh;
        private double minw;
        private int maxlevel = 0;
        private double scale;
        private bool randomize;
        private Graphics graphics;
        private Pen pen;
  
        private List<LineSegment> lines = new List<LineSegment>();
        private int level = 0;
        private List<int> levels = new List<int>();

        public Task1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            pen = new Pen(Color.Black);
            atom = "";
            angle = 0;
            direction = 0;
            rules = new List<string>();
            rulesDict = new Dictionary<string, List<string>>();
            startX = pictureBox1.Width / 2;
            startY = pictureBox1.Height;
            maxh = startY;
            maxw = startX;
            minh = startY;
            minw = startX;
            scale = 50;
            randomize = false;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string[] fileLines = File.ReadAllLines(filePath);

                ParseLSystem(fileLines);
                SetRules();
                DrawFractal();

            }
        }
        private void SetRules()
        {
            rulesDict.Clear();

            foreach (var rule in rules)
            {
                string[] parts = rule.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string itemRule = parts[1].Trim();

                    if (rulesDict.ContainsKey(key))
                    {
                        rulesDict[key].Add(itemRule);
                    }
                    else
                    {
                        rulesDict[key] = new List<string> { itemRule };
                    }
                }
            }
        }


        private void ParseLSystem(string[] lines)
        {
            atom = lines[0].Split(' ')[0];
            angle = Convert.ToDouble(lines[0].Split(' ')[1]);
            direction = Convert.ToInt32(lines[0].Split(' ')[2]);
            
            rules.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                rules.Add(lines[i]);
            }

        }
        private string GenerateFractalString()
        {
            if (rules.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder fractalBuilder = new StringBuilder();
            fractalBuilder.Append(atom);

            for (int i = 1; i < MAX_IT; i++)
            {
                fractalBuilder = ApplyRules(fractalBuilder);
            }

            return fractalBuilder.ToString();
        }

        private StringBuilder ApplyRules(StringBuilder fractal)
        {
            foreach (var rule in rulesDict)
            {
                var key = rule.Key;
                var value = rule.Value[0];
                fractal.Replace(key, value);
            }

            return fractal;
        }

        private void UpdateMinMaxValues(double newX, double newY)
        {
            maxh = Math.Max(maxh, newY);
            maxw = Math.Max(maxw, newX);
            minh = Math.Min(minh, newY);
            minw = Math.Min(minw, newX);
        }
        private void DrawFractal()
        {
            graphics.Clear(Color.White);
            var positionStack = new Stack<double>();
            var angleStack = new Stack<double>();
            var lines = new List<LineSegment>();
            levels = new List<int>();
            var random = new Random();
            var randomDouble = random.NextDouble() * angle;
            double currentAngle = direction;
            double currentX = startX;
            double currentY = startY;

            foreach (char character in GenerateFractalString())
            {
                if (character == 'F')
                {
                    var (newX, newY) = UpdatePosition(currentX, currentY, currentAngle, randomDouble, lines, levels);
                    UpdateMinMaxValues(newX, newY);
                    currentX = newX;
                    currentY = newY;
                }
                else if (character == '+') currentAngle += angle;
                else if (character == '@') randomDouble = currentAngle + (random.NextDouble() - 0.5) * (angle + 40);
                else if (character == '-') currentAngle -= angle;
                else if (character == '[')
                {
                    positionStack.Push(currentX);
                    positionStack.Push(currentY);
                    angleStack.Push(currentAngle);
                }
                else if (character == ']')
                {
                    RestoreState(positionStack, angleStack, ref currentX, ref currentY, ref currentAngle);
                }
            }

            DrawLines(lines);
        }

        private (double, double) UpdatePosition(double currentX, double currentY, double currentAngle, double randomd, List<LineSegment> lines, List<int> levels)
        {
            double newX, newY;
            if (randomize)
            {
                newX = currentX + scale * Math.Cos(randomd * Math.PI / 180);
                newY = currentY + scale * Math.Sin(randomd * Math.PI / 180);
            }
            else
            {
                newX = currentX + scale * Math.Cos(currentAngle * Math.PI / 180);
                newY = currentY + scale * Math.Sin(currentAngle * Math.PI / 180);
            }
            levels.Add(level);
            lines.Add(new LineSegment((float)currentX, (float)currentY, (float)newX, (float)newY));
            return (newX, newY);
        }

        private void RestoreState(Stack<double> positionStack, Stack<double> angleStack, ref double currentX, ref double currentY, ref double currentAngle)
        {
            level--;
            randomize = false;
            currentAngle = angleStack.Pop();
            currentY = positionStack.Pop();
            currentX = positionStack.Pop();
        }

        private void DrawLines(List<LineSegment> lines)
        {
            var cnt = 0;//
          
            foreach (var line in lines)
            {
                var xStep = (float)(pictureBox1.Width / (maxw - minw));
                if (checkBox1.Checked)
                {
                    cnt++;
                    var progress = (double)cnt / lines.Count;
                    var blendedColor = InterpolateColor(Color.Brown, Color.Green, progress);
                    var width = 10f * (float)Math.Pow(0.5f, cnt) * 0.5f + 5f;
                    pen.Color = blendedColor; pen.Width = width; 
                    graphics.DrawLine(pen, (line.CurrentX - (float)minw) * xStep, pictureBox1.Height * (float)((line.CurrentY - minh) / (maxh - minh)),
                        (line.NewX - (float)minw) * xStep, pictureBox1.Height * (float)((line.NewY - minh) / (maxh - minh)));
                }
                else
                {
                    graphics.DrawLine(pen, (line.CurrentX - (float)minw) * xStep, pictureBox1.Height * (float)((line.CurrentY - minh) / (maxh - minh)),
                        (line.NewX - (float)minw) * xStep, pictureBox1.Height * (float)((line.NewY - minh) / (maxh - minh)));
                }
            }
        }

        private Color InterpolateColor(Color start, Color end, double progress)
        {
            int r = (int)(start.R + (end.R - start.R) * progress);
            int g = (int)(start.G + (end.G - start.G) * progress);
            int b = (int)(start.B + (end.B - start.B) * progress);
            return Color.FromArgb(r, g, b);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DrawFractal();  // Перерисовать при изменении чекбокса
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

