using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace Lab8
{
    class Polygon
    {
        public List<PointD> Points { get; }
        public PointD Center { get; set; } = new PointD(0, 0, 0);
        public List<float> Normal { get; set; }
        public bool IsVisible { get; set; }
        public List<Vector2> TextureCoord;

        public Polygon(Polygon face)
        {
            Points = face.Points.Select(pt => new PointD(pt.X, pt.Y, pt.Z)).ToList();
            Center = new PointD(face.Center);
        }

        public Polygon(List<PointD> pts = null)
        {
            if (pts != null)
            {
                Points = new List<PointD>(pts);
                UpdateCenter();
            }
        }

        private void UpdateCenter()
        {
            Center.X = 0;
            Center.Y = 0;
            Center.Z = 0;
            foreach (PointD p in Points)
            {
                Center.X += p.X;
                Center.Y += p.Y;
                Center.Z += p.Z;
            }
            Center.X /= Points.Count;
            Center.Y /= Points.Count;
            Center.Z /= Points.Count;
        }

        public void reflectX()
        {
            Center.X = -Center.X;
            if (Points != null)
                foreach (var p in Points)
                    p.reflectX();
        }
        public void reflectY()
        {
            Center.Y = -Center.Y;
            if (Points != null)
                foreach (var p in Points)
                    p.reflectY();
        }
        public void reflectZ()
        {
            Center.Z = -Center.Z;
            if (Points != null)
                foreach (var p in Points)
                    p.reflectZ();
        }

        public List<PointF> make_perspective(float k = 1000, float z_camera = 1000)
        {
            List<PointF> res = new List<PointF>();

            foreach (PointD p in Points)
            {
                res.Add(p.make_perspective(k));
            }
            return res;
        }

        public List<PointF> make_isometric()
        {
            List<PointF> res = new List<PointF>();

            foreach (PointD p in Points)
                res.Add(p.make_isometric());

            return res;
        }

        public void DrawLines(Graphics g, Projection pr = 0, Pen pen = null)
        {
            if (pen == null)
                pen = new Pen(Color.Black, 2);

            List<PointF> pts;

            switch (pr)
            {
                case Projection.AXONOMETRIC:
                    pts = make_isometric();
                    break;
                default:
                    pts = make_perspective(1000);
                    break;
            }

            if (pts.Count > 1)
            {
                g.DrawLines(pen, pts.ToArray());
                g.DrawLine(pen, pts[0], pts[pts.Count - 1]);
            }
            else if (pts.Count == 1)
                g.DrawRectangle(pen, pts[0].X, pts[0].Y, 1, 1);
        }

        public void translate(float x, float y, float z)
        {
            foreach (PointD p in Points)
                p.Translate(x, y, z);
            UpdateCenter();
        }

        public void rotate(double angle, Axis a, Line line = null)
        {
            foreach (PointD p in Points)
                p.Rotate(angle, a, line);
            UpdateCenter();
        }

        public void scale(float kx, float ky, float kz)
        {
            foreach (PointD p in Points)
                p.Scale(kx, ky, kz);
            UpdateCenter();
        }

   //--------------------------------------------------LAB8-------------------------------------\\
                    //vector normal
        public void FindNormal(PointD pCenter, Line camera)
        {
            PointD first = Points[0], second = Points[1], third = Points[2];
            var A = first.Y * (second.Z - third.Z) + second.Y * (third.Z - first.Z) + third.Y * (first.Z - second.Z);
            var B = first.Z * (second.X - third.X) + second.Z * (third.X - first.X) + third.Z * (first.X - second.X);
            var C = first.X * (second.Y - third.Y) + second.X * (third.Y - first.Y) + third.X * (first.Y - second.Y);

            Normal = new List<float> { A, B, C };

            List<float> SC = new List<float> { second.X - pCenter.X, second.Y - pCenter.Y, second.Z - pCenter.Z };
            if (PointD.mul_matrix(Normal, 1, 3, SC, 3, 1)[0] > 1E-6)
            {
                Normal[0] *= -1;
                Normal[1] *= -1;
                Normal[2] *= -1;
            }

            PointD P = camera.First;
            PointD E = new PointD(P.X - Center.X, P.Y - Center.Y, P.Z - Center.Z);
            double angle = Math.Acos((Normal[0] * E.X + Normal[1] * E.Y + Normal[2] * E.Z) /
                ((Math.Sqrt(Normal[0] * Normal[0] + Normal[1] * Normal[1] + Normal[2] * Normal[2]) *
                Math.Sqrt(E.X * E.X + E.Y * E.Y + E.Z * E.Z))));
            angle = angle * 180 / Math.PI;

            IsVisible = angle >= 90;
        }
    }
}
