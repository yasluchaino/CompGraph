using System.Collections.Generic;
using System.Drawing;

namespace Lab8
{
    class RotationFigure : Polyhedra
    {
        public List<PointD> Points { get; }

        public RotationFigure(List<PointD> points)
        {
            Points = new List<PointD>(points);
        }

        public RotationFigure(List<PointD> startPoints, Axis axis, int partitions)
        {
            Polygons = new List<Polygon>();
            List<PointD> rotatedPoints = new List<PointD>();
            float angle = 360f / partitions;

            foreach (var p in startPoints)
            {
                rotatedPoints.Add(new PointD(p.X, p.Y, p.Z));
            }
            var n = startPoints.Count;
            for (int i = 0; i < partitions; ++i)
            {
                foreach (var p in rotatedPoints)
                    p.Rotate(angle, axis);

                for (int j = 1; j < n-1; ++j)
                {
                    Polygon p = new Polygon(
                                    new List<PointD>()
                                    {
                                        new PointD(startPoints[j - 1]),
                                        new PointD(rotatedPoints[j - 1]),
                                        new PointD(rotatedPoints[j]),
                                        new PointD(startPoints[j])
                                    });

                    Polygons.Add(p);
                }

                foreach (var p in startPoints)
                    p.Rotate(angle, axis);
            }
        }

        public new void DrawLines(Graphics g, Projection pr = 0, Pen pen = null)
        {
            foreach (Polygon f in Polygons)
            {
                f.DrawLines(g, pr, pen);
            }
        }

    }
}
