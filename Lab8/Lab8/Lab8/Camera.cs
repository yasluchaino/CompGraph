using System.Drawing;

namespace Lab8
{
    internal class Camera
    {
        public Line view = new Line(new PointD(0, 0, 280), new PointD(0, 0, 230));
        public PointD position;
        public Projection projection;
        public double Fi { get; set; }
        public double Theta { get; set; }

        public Camera(PointD _position,Projection p, double angleY, double angleX)
        {
            this.position = _position;
            position = _position;
            Fi = angleY;
            Theta = angleX;
        }

        public void translate(float x, float y, float z)
        {
            view.translate(x, y, z);
            position.Translate(x, y, z);
        }

        public void rotate(double angle, Axis a, Line line = null)
        {
            view.rotate(angle, a, line);
            position.Rotate(angle, a, line);
        }
    }
}