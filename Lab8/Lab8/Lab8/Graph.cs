﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Graph : Polyhedra
    {
        public Func<double, double, double> F;
        public int X0 { get; }
        public int X1 { get; }
        public int Y0 { get; }
        public int Y1 { get; }
        public int CountOfSplits { get; }

        public Graph(int x0, int x1, int y0, int y1, int count, int func)
        {
            X0 = x0;
            X1 = x1;
            Y0 = y0;
            Y1 = y1;
            CountOfSplits = count;
            Polygons = new List<Polygon>();

            float dx = (Math.Abs(x0) + Math.Abs(x1)) / (float)count;
            float dy = (Math.Abs(y0) + Math.Abs(y1)) / (float)count;

            List<PointD> points0 = new List<PointD>();
            List<PointD> points = new List<PointD>();

            switch (func)
            {
                case 0:
                    F = (x, y) => x + y;
                    break;
                case 1:
                    F = (x, y) => (float)Math.Cos(x * x + y * y);
                    break;
                case 2:
                    F = (x, y) => (float)Math.Sin(x) * 10f + (float)Math.Cos(y) * 10f;
                    break;
                case 3:
                    F = (x, y) => (float)Math.Sin(x) * 5f;
                    break;
                case 4:
                    F = (x, y) => x + (y * y);
                    break;
                default:
                    F = (x, y) => x + y;
                    break;
            }

            for (float x = x0; x < x1; x += dx)
            {
                for (float y = y0; y < y1; y += dy)
                {
                    var z = F(x, y);
                    points.Add(new PointD(x, y, (float)z));
                }

                if (points0.Count != 0)
                    for (int i = 1; i < points0.Count; ++i)
                    {
                        Polygons.Add(new Polygon(new List<PointD>()
                        {
                                new PointD(points0[i - 1]),
                                new PointD(points[i - 1]),
                                new PointD(points[i]),
                                new PointD(points0[i])
                        }));
                    }
                points0.Clear();
                points0 = points;
                points = new List<PointD>();
            }
        }
    }
}
