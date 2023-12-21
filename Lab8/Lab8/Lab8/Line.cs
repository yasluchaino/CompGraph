using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab8
{
    class Line
    {
        public PointD First { get; set; }
        public PointD Second { get; set; }

        public Line(PointD p1, PointD p2)
        {
            First = new PointD(p1);
            Second = new PointD(p2);
        }
   
        public void translate(float x, float y, float z)
        {
            First.Translate(x, y, z);
            Second.Translate(x, y, z);
        }

        public void rotate(double angle, Axis a, Line line = null)
        {
            First.Rotate(angle, a, line);
            Second.Rotate(angle, a, line);
        }

        public void scale(float kx, float ky, float kz)
        {
            First.Scale(kx, ky, kz);
            Second.Scale(kx, ky, kz);
        }
    }
}
