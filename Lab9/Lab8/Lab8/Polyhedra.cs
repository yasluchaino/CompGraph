using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;

namespace Lab8
{
    class Polyhedra
    {
        public List<Polygon> Polygons { get; set; } = null;
        public PointD Center { get; set; } = new PointD(0, 0, 0);
        public Polyhedra(List<Polygon> fs = null)
        {
            if (fs != null)
            {
                Polygons = fs.Select(face => new Polygon(face)).ToList();
                UpdateCenter();
            }
        }

        public Polyhedra(Polyhedra polyhedron)
        {
            Polygons = polyhedron.Polygons.Select(face => new Polygon(face)).ToList();
            Center = new PointD(polyhedron.Center);
        }
        private void UpdateCenter()
        {
            Center.X = 0;
            Center.Y = 0;
            Center.Z = 0;
            foreach (Polygon f in Polygons)
            {
                Center.X += f.Center.X;
                Center.Y += f.Center.Y;
                Center.Z += f.Center.Z;
            }
            Center.X /= Polygons.Count;
            Center.Y /= Polygons.Count;
            Center.Z /= Polygons.Count;
        }

        public void DrawLines(Graphics g, Projection pr = 0, Pen pen = null)
        {
            foreach (Polygon f in Polygons)
            {
                f.FindNormal(Center, new Line(new PointD(0, 0, 500), new PointD(0, 0, 500)));
                if (f.IsVisible)
                    f.DrawLines(g, pr, pen);
            }
        }

        public void Translate(float x, float y, float z)
        {
            foreach (Polygon f in Polygons)
                f.translate(x, y, z);
            UpdateCenter();
        }

        public void Rotate(double angle, Axis a, Line line = null)
        {
            foreach (Polygon f in Polygons)
                f.rotate(angle, a, line);
            UpdateCenter();
        }

        public void Scale(float kx, float ky, float kz)
        {
            foreach (Polygon f in Polygons)
                f.scale(kx, ky, kz);
            UpdateCenter();
        }

        public void reflectX()
        {
            if (Polygons != null)
                foreach (var f in Polygons)
                    f.reflectX();
            UpdateCenter();
        }

        public void reflectY()
        {
            if (Polygons != null)
                foreach (var f in Polygons)
                    f.reflectY();
            UpdateCenter();
        }

        public void reflectZ()
        {
            if (Polygons != null)
                foreach (var f in Polygons)
                    f.reflectZ();
            UpdateCenter();
        }

        public void Hexahedron(float size = 50)
        {
            Polygon f = new Polygon(
        new List<PointD>
        {
            new PointD(-size, size, size),
            new PointD(size, size, size),
            new PointD(size, -size, size),
            new PointD(-size, -size, size)
        }
    );

            Polygon f1 = new Polygon(
                new List<PointD>
                {
            new PointD(-size, size, -size),
            new PointD(-size, -size, -size),
            new PointD(size, -size, -size),
            new PointD(size, size, -size)
                }
            );

            Polygon f2 = new Polygon(
                new List<PointD>
                {
            new PointD(-size, size, size),
            new PointD(-size, -size, size),
            new PointD(-size, -size, -size),
            new PointD(-size, size, -size)
                }
            );

            Polygon f3 = new Polygon(
                new List<PointD>
                {
            new PointD(size, size, size),
            new PointD(size, -size, size),
            new PointD(size, -size, -size),
            new PointD(size, size, -size)
                }
            );

            Polygon f4 = new Polygon(
                new List<PointD>
                {
            new PointD(-size, size, size),
            new PointD(-size, size, -size),
            new PointD(size, size, -size),
            new PointD(size, size, size)
                }
            );

            Polygon f5 = new Polygon(
                new List<PointD>
                {
            new PointD(-size, -size, size),
            new PointD(-size, -size, -size),
            new PointD(size, -size, -size),
            new PointD(size, -size, size)
                }
            );

            Polygons = new List<Polygon> { f, f1, f2, f3, f4, f5 };

            UpdateCenter();
        }

        public void Tetrahedron(float size = 100)
        {
            float sqrt2 = (float)Math.Sqrt(2);

            Polygon f0 = new Polygon(
                new List<PointD>
                {
            new PointD(-size, -size / sqrt2, -size / sqrt2),
            new PointD(size, -size / sqrt2, -size / sqrt2),
            new PointD(0, size / sqrt2, -size / sqrt2)
                }
            );

            Polygon f1 = new Polygon(
                new List<PointD>
                {
            new PointD(-size, -size / sqrt2, -size / sqrt2),
            new PointD(size, -size / sqrt2, -size / sqrt2),
            new PointD(0, 0, size / sqrt2)
                }
            );

            Polygon f2 = new Polygon(
                new List<PointD>
                {
            new PointD(-size, -size / sqrt2, -size / sqrt2),
            new PointD(0, size / sqrt2, -size / sqrt2),
            new PointD(0, 0, size / sqrt2)
                }
            );

            Polygon f3 = new Polygon(
                new List<PointD>
                {
            new PointD(size, -size / sqrt2, -size / sqrt2),
            new PointD(0, size / sqrt2, -size / sqrt2),
            new PointD(0, 0, size / sqrt2)
                }
            );

            Polygons = new List<Polygon> { f0, f1, f2, f3 };
            //Polygons[0].TextureCoord.Add(new Vector2(0, 0));
            //Polygons[0].TextureCoord.Add(new Vector2(1, 0));
            //Polygons[0].TextureCoord.Add(new Vector2(1, 1));

            //Polygons[1].TextureCoord.Add(new Vector2(0, 0));
            //Polygons[1].TextureCoord.Add(new Vector2(1, 0));
            //Polygons[1].TextureCoord.Add(new Vector2(1, 1));

            //Polygons[2].TextureCoord.Add(new Vector2(0, 0));
            //Polygons[2].TextureCoord.Add(new Vector2(1, 0));
            //Polygons[2].TextureCoord.Add(new Vector2(1, 1));

            //Polygons[3].TextureCoord.Add(new Vector2(0, 0));
            //Polygons[3].TextureCoord.Add(new Vector2(1, 0));
            //Polygons[3].TextureCoord.Add(new Vector2(1, 1));
            UpdateCenter();
        }

        public void Octahedron(Polyhedra cube = null)
        {
            if (cube == null)
            {
                cube = new Polyhedra();
                cube.Hexahedron();
            }

            Polygon f0 = new Polygon(
                new List<PointD>
                {
              new PointD(cube.Polygons[2].Center),
              new PointD(cube.Polygons[1].Center),
              new PointD(cube.Polygons[4].Center)
                }
            );

            Polygon f1 = new Polygon(
                new List<PointD>
                {
              new PointD(cube.Polygons[2].Center),
              new PointD(cube.Polygons[1].Center),
              new PointD(cube.Polygons[5].Center)
                }
            );

            Polygon f2 = new Polygon(
                new List<PointD>
                {
              new PointD(cube.Polygons[2].Center),
              new PointD(cube.Polygons[5].Center),
              new PointD(cube.Polygons[0].Center)
                }
            );

            Polygon f3 = new Polygon(
                new List<PointD>
                {
              new PointD(cube.Polygons[2].Center),
              new PointD(cube.Polygons[0].Center),
              new PointD(cube.Polygons[4].Center)
                }
            );

            Polygon f4 = new Polygon(
                new List<PointD>
                {
              new PointD(cube.Polygons[3].Center),
              new PointD(cube.Polygons[1].Center),
              new PointD(cube.Polygons[4].Center)
                }
            );

            Polygon f5 = new Polygon(
                new List<PointD>
                {
              new PointD(cube.Polygons[3].Center),
              new PointD(cube.Polygons[1].Center),
              new PointD(cube.Polygons[5].Center)
                }
            );

            Polygon f6 = new Polygon(
                new List<PointD>
                {
              new PointD(cube.Polygons[3].Center),
              new PointD(cube.Polygons[5].Center),
              new PointD(cube.Polygons[0].Center)
                }
            );

            Polygon f7 = new Polygon(
                new List<PointD>
                {
              new PointD(cube.Polygons[3].Center),
              new PointD(cube.Polygons[0].Center),
              new PointD(cube.Polygons[4].Center)
                }
            );

            Polygons = new List<Polygon> { f0, f1, f2, f3, f4, f5, f6, f7 };
            UpdateCenter();
        }

        public string Save()
        {
            string res = "";
            foreach (var poly in Polygons)
            {
                foreach (var point in poly.Points)
                {
                    res += Math.Truncate(point.X) + " ";
                    res += Math.Truncate(point.Y) + " ";
                    res += Math.Truncate(point.Z) + " ";
                }
                res += '\n';
            }
            return res;
        }

        //---------------------------------LAB8------------------------------------------------------\\
        //  Z-буфера (алгоритм из презентации)
        public void calculateZBuffer(int width, int height, out int[] zbuf)
        {
            // Создание буфера глубины Z для хранения значений Z для каждого пикселя
            zbuf = new int[width * height];

            // Инициализация буфера минимальными значениями Z
            for (int i = 0; i < width * height; ++i)
                zbuf[i] = int.MinValue;

            // Проход по всем полигонам для их растеризации
            foreach (var f in Polygons)
            {
                // Получение точек полигона
                PointD P0 = new PointD(f.Points[0]);
                PointD P1 = new PointD(f.Points[1]);
                PointD P2 = new PointD(f.Points[2]);

                // Растеризация текущего полигона и заполнение Z-буфера
                helpForZbuf(P0, P1, P2, zbuf, width, height);

                // Проверка наличия дополнительных точек полигона для обработки
                if (f.Points.Count > 3)
                {
                    P0 = new PointD(f.Points[2]);
                    P1 = new PointD(f.Points[3]);
                    P2 = new PointD(f.Points[0]);
                    helpForZbuf(P0, P1, P2, zbuf, width, height);
                }
                if (f.Points.Count > 4)
                {
                    P0 = new PointD(f.Points[3]);
                    P1 = new PointD(f.Points[4]);
                    P2 = new PointD(f.Points[0]);
                    helpForZbuf(P0, P1, P2, zbuf, width, height);
                }
            }

            // Нахождение минимального и максимального значения Z
            int min_z = int.MaxValue;
            int max_z = 0;
            for (int i = 0; i < width * height; ++i)
            {
                if (zbuf[i] != int.MinValue && zbuf[i] < min_z)
                    min_z = zbuf[i];
                if (zbuf[i] > max_z)
                    max_z = zbuf[i];
            }

            // Нормализация значений Z для приведения их к диапазону от 0 до 255
            if (min_z < 0)
            {
                min_z = -min_z;
                max_z += min_z;
                for (int i = 0; i < width * height; ++i)
                    if (zbuf[i] != int.MinValue)
                        zbuf[i] = (zbuf[i] + min_z) % int.MaxValue;
            }

            for (int i = 0; i < width * height; ++i)
            {
                // Заполнение буфера кадра атрибутами многоугольников, учитывая Z-буфер
                // Если глубина Z текущего пикселя больше, чем значение Z-буфера в этой же позиции,
                // то атрибуты многоугольника записываются в буфер кадра, а Z-буфер обновляется значением глубины Z.
                if (zbuf[i] == int.MinValue)
                    zbuf[i] = 255;
                else if (max_z != 0)
                    zbuf[i] = zbuf[i] * 225 / max_z;
            }
        }

        private void helpForZbuf(PointD P0, PointD P1, PointD P2, int[] buff, int width, int height)
        {
            
            PointF p0 = P0.make_perspective();
            PointF p1 = P1.make_perspective();
            PointF p2 = P2.make_perspective();

            //упорядочивание вершин треугольника по y
            if (p1.Y < p0.Y)
            {
                // вторая вершина ниже первой? меняем их местами
                PointD tmp = new PointD(P0);
                P0.X = P1.X; P0.Y = P1.Y; P0.Z = P1.Z;
                P1.X = tmp.X; P1.Y = tmp.Y; P1.Z = tmp.Z;

                PointF tmpp = new PointF(p0.X, p0.Y);
                p0.X = p1.X; p0.Y = p1.Y;
                p1.X = tmpp.X; p1.Y = tmpp.Y;
            }
            if (p2.Y < p0.Y)
            {
                // третья вершина ниже первой? меняем их местами
                PointD tmp = new PointD(P0);
                P0.X = P2.X; P0.Y = P2.Y; P0.Z = P2.Z;
                P2.X = tmp.X; P2.Y = tmp.Y; P2.Z = tmp.Z;

                PointF tmpp = new PointF(p0.X, p0.Y);
                p0.X = p2.X; p0.Y = p2.Y;
                p2.X = tmpp.X; p2.Y = tmpp.Y;
            }
            if (p2.Y < p1.Y)
            {
                //  третья вершина ниже второй?-> меняем их местами
                PointD tmp = new PointD(P1);
                P1.X = P2.X; P1.Y = P2.Y; P1.Z = P2.Z;
                P2.X = tmp.X; P2.Y = tmp.Y; P2.Z = tmp.Z;

                PointF tmpp = new PointF(p1.X, p1.Y);
                p1.X = p2.X; p1.Y = p2.Y;
                p2.X = tmpp.X; p2.Y = tmpp.Y;
            }


            drawFilledTriangle(P0, P1, P2, buff, width, height);
        }


        private void drawFilledTriangle(PointD P0, PointD P1, PointD P2, int[] buff, int width, int height)
        {
            // Преобразование трехмерных точек в двумерные точки с учетом перспективы
            PointF p0 = P0.make_perspective();
            PointF p1 = P1.make_perspective();
            PointF p2 = P2.make_perspective();

            // просто преобразуем в целые числа
            int y0 = (int)p0.Y; int x0 = (int)p0.X; int z0 = (int)P0.Z;
            int y1 = (int)p1.Y; int x1 = (int)p1.X; int z1 = (int)P1.Z;
            int y2 = (int)p2.Y; int x2 = (int)p2.X; int z2 = (int)P2.Z;

            // интерполяция координат между вершинами треугольника
            var x01 = Interpolate(y0, x0, y1, x1);
            var x12 = Interpolate(y1, x1, y2, x2);
            var x02 = Interpolate(y0, x0, y2, x2);
            //интерполяция глубины между вершинами треугольника
            var h01 = Interpolate(y0, z0, y1, z1);
            var h12 = Interpolate(y1, z1, y2, z2);
            var h02 = Interpolate(y0, z0, y2, z2);

            // Объединяем короткие стороны треугольника
            int[] x012 = x01.Take(x01.Length - 1).Concat(x12).ToArray();
            int[] h012 = h01.Take(h01.Length - 1).Concat(h12).ToArray();

            // Определяем, какая сторона является левой и правой
            int m = x012.Length / 2; // это средняя
            int[] x_left, x_right, h_left, h_right; //x это координаты  h это глубина  
            if (x02[m] < x012[m])
            {
                x_left = x02;
                x_right = x012;

                h_left = h02;
                h_right = h012;
            }
            else
            {
                x_left = x012;
                x_right = x02;

                h_left = h012;
                h_right = h02;
            }

            // Отрисовка горизонтальных отрезков
            for (int y = y0; y <= y2; ++y)
            {
                int x_l = x_left[y - y0];
                int x_r = x_right[y - y0];
                int[] h_segment;

                h_segment = Interpolate(x_l, h_left[y - y0], x_r, h_right[y - y0]);
                for (int x = x_l; x <= x_r; ++x)
                {
                    int z = h_segment[x - x_l];

                    // Преобразование координат для рисования на холсте
                    int xx = x + width / 2;
                    int yy = -y + height / 2;

                    // Проверка глубины z для отрисовки пикселя
                    if (z > buff[xx * height + yy])
                    {
                        buff[xx * height + yy] = (int)(z);
                    }
                }
            }
        }
        private Dictionary<PointD, float> point_to_intensive = null;

        public void calcGouro(Line camera, int width, int height, out float[] intensive, PointD light)
            {
                int[] buf = new int[width * height];
                for (int i = 0; i < width * height; ++i)
                    buf[i] = int.MinValue;
                intensive = new float[width * height];
                for (int i = 0; i < width * height; ++i)
                    intensive[i] = 0;

            CalculateLightingMap(camera, light);
                foreach (var f in Polygons)
                {
                    // треугольник
                    PointD P0 = new PointD(f.Points[0]);
                    PointD P1 = new PointD(f.Points[1]);
                    PointD P2 = new PointD(f.Points[2]);
                    float i_p0 = point_to_intensive[P0], i_p1 = point_to_intensive[P1], i_p2 = point_to_intensive[P2];
                    helpForGouro(camera, P0, P1, P2, buf, width, height, intensive, i_p0, i_p1, i_p2);
                    // 4
                    if (f.Points.Count > 3)
                    {
                        P0 = new PointD(f.Points[2]);
                        P1 = new PointD(f.Points[3]);
                        P2 = new PointD(f.Points[0]);
                        i_p0 = point_to_intensive[P0]; i_p1 = point_to_intensive[P1]; i_p2 = point_to_intensive[P2];
                    helpForGouro(camera, P0, P1, P2, buf, width, height, intensive, i_p0, i_p1, i_p2);
                    }
                    // 5
                    if (f.Points.Count > 4)
                    {
                        P0 = new PointD(f.Points[3]);
                        P1 = new PointD(f.Points[4]);
                        P2 = new PointD(f.Points[0]);
                        i_p0 = point_to_intensive[P0]; i_p1 = point_to_intensive[P1]; i_p2 = point_to_intensive[P2];
                    helpForGouro(camera, P0, P1, P2, buf, width, height, intensive, i_p0, i_p1, i_p2);
                    }
                }

                SortedSet<float> test = new SortedSet<float>();
                for (int i = 0; i < width * height; ++i)
                    test.Add(intensive[i]);
            }
        private Dictionary<PointD, List<float>> point_to_normal = null;

        private Dictionary<PointD, List<int>> map = null;

        private void CalculateLightingMap(Line camera, PointD light)
        {
            // Словарь для связи точек на поверхности с полигонами, содержащими эти точки
            map = new Dictionary<PointD, List<int>>(new Point3dComparer());

            // Словарь для хранения нормалей для каждой точки
            point_to_normal = new Dictionary<PointD, List<float>>(new Point3dComparer());

            // Словарь для хранения интенсивности освещения для каждой точки
            point_to_intensive = new Dictionary<PointD, float>(new Point3dComparer());

            // Проходимся по всем полигонам в модели
            for (int i = 0; i < Polygons.Count; ++i)
            {
                // Находим нормаль для каждого полигона относительно камеры
                Polygons[i].FindNormal(Center, camera);
                var n = Polygons[i].Normal;

                // Для каждой точки полигона
                foreach (var p in Polygons[i].Points)
                {
                    // Добавляем соответствие точек и полигонов в map
                    if (!map.ContainsKey(p))
                        map[p] = new List<int>();
                    map[p].Add(i);

                    // Суммируем нормали для точек
                    if (!point_to_normal.ContainsKey(p))
                        point_to_normal[p] = new List<float>() { 0, 0, 0 };
                    point_to_normal[p][0] += n[0];
                    point_to_normal[p][1] += n[1];
                    point_to_normal[p][2] += n[2];
                }
            }

            // Нормализуем нормали и вычисляем интенсивность освещения для каждой точки
            float max = 0;
            foreach (var el in map)
            {
                var p = el.Key;

                // Нормализуем нормали для точек
                var length = (float)Math.Sqrt(point_to_normal[p][0] * point_to_normal[p][0] + point_to_normal[p][1] * point_to_normal[p][1] + point_to_normal[p][2] * point_to_normal[p][2]);
                point_to_normal[p][0] /= length;
                point_to_normal[p][1] /= length;
                point_to_normal[p][2] /= length;

                // Находим вектор от точки к источнику света
                List<float> to_light = new List<float>() { -light.X + p.X, -light.Y + p.Y, -light.Z + p.Z };
                length = (float)Math.Sqrt(to_light[0] * to_light[0] + to_light[1] * to_light[1] + to_light[2] * to_light[2]);
                to_light[0] /= length; to_light[1] /= length; to_light[2] /= length;

                // Коэффициенты для модели освещения: ka, ia, kd, id
                float ka = 1; float ia = 0.7f; // Фоновое освещение
                float kd = 0.7f; float id = 1f; // Рассеянное освещение

                // Вычисляем интенсивность освещения для точки
                float Ia = ka * ia;
                float Id = kd * id * (point_to_normal[p][0] * to_light[0] + point_to_normal[p][1] * to_light[1] + point_to_normal[p][2] * to_light[2]);
                point_to_intensive[p] = Ia + Id;

                // Находим максимальное значение интенсивности для нормализации
                if (point_to_intensive[p] > max)
                    max = point_to_intensive[p];
            }

            // Нормализуем интенсивность в диапазоне [0, 1]
            if (max != 0)
            {
                foreach (var el in point_to_normal)
                {
                    point_to_intensive[el.Key] /= max;
                    if (point_to_intensive[el.Key] < 0)
                        point_to_intensive[el.Key] = 0;
                }
            }
        }


        public class Point3dComparer : IEqualityComparer<PointD>
{
    public bool Equals(PointD x, PointD y)
    {
        return x.X.Equals(y.X) && x.Y.Equals(y.Y) && x.Z.Equals(y.Z);
    }

    public int GetHashCode(PointD obj)
    {
        return obj.X.GetHashCode() + obj.Y.GetHashCode() + obj.Z.GetHashCode();
    }
}
private void helpForGouro(Line camera, PointD P0, PointD P1, PointD P2, int[] buff, int width, int height, float[] colors, float c_P0, float c_P1, float c_P2)
        {
            // сортируем p0, p1, p2: y0 <= y1 <= y2
            PointF p0 = P0.make_perspective();
            PointF p1 = P1.make_perspective();
            PointF p2 = P2.make_perspective();

            if (p1.Y < p0.Y)
            {
                PointD tmpp = new PointD(P0);
                P0.X = P1.X; P0.Y = P1.Y; P0.Z = P1.Z;
                P1.X = tmpp.X; P1.Y = tmpp.Y; P1.Z = tmpp.Z;
                PointF tmppp = new PointF(p0.X, p0.Y);
                p0.X = p1.X; p0.Y = p1.Y;
                p1.X = tmppp.X; p1.Y = tmppp.Y;
                var tmpc = c_P1;
                c_P1 = c_P0;
                c_P0 = tmpc;
            }
            if (p2.Y < p0.Y)
            {
                PointD tmpp = new PointD(P0);
                P0.X = P2.X; P0.Y = P2.Y; P0.Z = P2.Z;
                P2.X = tmpp.X; P2.Y = tmpp.Y; P2.Z = tmpp.Z;
                PointF tmppp = new PointF(p0.X, p0.Y);
                p0.X = p2.X; p0.Y = p2.Y;
                p2.X = tmppp.X; p2.Y = tmppp.Y;
                var tmpc = c_P2;
                c_P2 = c_P0;
                c_P0 = tmpc;
            }
            if (p2.Y < p1.Y)
            {
                PointD tmpp = new PointD(P1);
                P1.X = P2.X; P1.Y = P2.Y; P1.Z = P2.Z;
                P2.X = tmpp.X; P2.Y = tmpp.Y; P2.Z = tmpp.Z;
                PointF tmppp = new PointF(p1.X, p1.Y);
                p1.X = p2.X; p1.Y = p2.Y;
                p2.X = tmppp.X; p2.Y = tmppp.Y;
                var tmpc = c_P1;
                c_P1 = c_P2;
                c_P2 = tmpc;
            }

            DrawFilledTriangleWithColor(camera, P0, P1, P2, buff, width, height, colors, c_P0, c_P1, c_P2);
        }
        private void DrawFilledTriangleWithColor(Line camera, PointD P0, PointD P1, PointD P2, int[] buff, int width, int height, float[] colors, float c_P0, float c_P1, float c_P2)
        {
            PointF p0 = P0.make_perspective();
            PointF p1 = P1.make_perspective();
            PointF p2 = P2.make_perspective();

            //y0 <= y1 <= y2
            int y0 = (int)p0.Y; int x0 = (int)p0.X; int z0 = (int)P0.Z;
            int y1 = (int)p1.Y; int x1 = (int)p1.X; int z1 = (int)P1.Z;
            int y2 = (int)p2.Y; int x2 = (int)p2.X; int z2 = (int)P2.Z;

            var x01 = Interpolate(y0, x0, y1, x1);
            var x12 = Interpolate(y1, x1, y2, x2);
            var x02 = Interpolate(y0, x0, y2, x2);

            var h01 = Interpolate(y0, z0, y1, z1);
            var h12 = Interpolate(y1, z1, y2, z2);
            var h02 = Interpolate(y0, z0, y2, z2);

            var c01 = Interpolate(y0, (int)(c_P0 * 100), y1, (int)(c_P1 * 100));
            var c12 = Interpolate(y1, (int)(c_P1 * 100), y2, (int)(c_P2 * 100));
            var c02 = Interpolate(y0, (int)(c_P0 * 100), y2, (int)(c_P2 * 100));
            // Конкатенация коротких сторон
            int[] x012 = x01.Take(x01.Length - 1).Concat(x12).ToArray();
            int[] h012 = h01.Take(h01.Length - 1).Concat(h12).ToArray();
            int[] c012 = c01.Take(c01.Length - 1).Concat(c12).ToArray();

            // Определяем, какая из сторон левая и правая
            int m = x012.Length / 2;
            int[] x_left, x_right, h_left, h_right, c_left, c_right;
            if (x02[m] < x012[m])
            {
                x_left = x02;
                x_right = x012;

                h_left = h02;
                h_right = h012;

                c_left = c02;
                c_right = c012;
            }
            else
            {
                x_left = x012;
                x_right = x02;

                h_left = h012;
                h_right = h02;

                c_left = c012;
                c_right = c02;
            }

            // Отрисовка горизонтальных отрезков
            for (int y = y0; y <= y2; ++y)
            {
                int x_l = x_left[y - y0];
                int x_r = x_right[y - y0];
                int[] h_segment;
                int[] c_segment;
                // interpolation
                if (x_l > x_r)
                    continue;
                h_segment = Interpolate(x_l, h_left[y - y0], x_r, h_right[y - y0]);
                c_segment = Interpolate(x_l, c_left[y - y0], x_r, c_right[y - y0]);
                for (int x = x_l; x <= x_r; ++x)
                {
                    int z = h_segment[x - x_l];
                    float color = c_segment[x - x_l] / 100f;
                    int xx = x + width / 2;
                    int yy = -y + height / 2;
                    if (xx < 0 || xx > width || yy < 0 || yy > height || (xx * height + yy) < 0 || (xx * height + yy) > (buff.Length - 1))
                        continue;
                    if (z > buff[xx * height + yy])
                    {
                        buff[xx * height + yy] = (int)(z + 0.5);
                        colors[xx * height + yy] = color;
                    }
                }
            }
        }

   
        int[] Interpolate(int i0, int d0, int i1, int d1)
            {
                if (i0 == i1)
                {
                    return new int[] { d0 };
                }
                int[] values = new int[i1 - i0 + 1];
                double a = (double)(d1 - d0) / (i1 - i0);
                double d = d0;
                int ind = 0;
                for (int i = i0; i <= i1; ++i)
                {
                    values[ind] = (int)(d);
                    d = d + a;
                    ++ind;
                }
                return values;
            } 
                       
    }
    class Graph : Polyhedra
    {
        public Func<double, double, double> F;
        public PictureBox picture;

        public double phi = 60, psi = 100;

        public Graph(int func)
        {
            switch (func)
            {
                case 0:
                    F = (x, y) => x + y;
                    break;
                case 1:
                    F = (x, y) => (float)Math.Cos(x);
                    break;
                case 2:
                    F = (x, y) => (float)Math.Sin(x);
                    break;
                default:
                    F = (x, y) => x + y;
                    break;
            }
        }

        public void DrawGraphic()
        {
            List<double> upFloatingHorizon = new List<double>(picture.Width);
            List<double> downFloatingHorizon = new List<double>(picture.Width);

            for (int i = 0; i < picture.Width; i++)
            {
                upFloatingHorizon.Add(0);
                downFloatingHorizon.Add(1000);
            }

            Bitmap resultBitmap = new Bitmap(picture.Width, picture.Height);

            for (double x = -5; x <= 5.001; x += 0.2)
            {
                List<Point> currentCurve = new List<Point>();
                for (double y = -5; y <= 5.001; y += 0.2)
                {
                    double z = F(x, y);
                    double projectedX = x * Math.Cos(phi * Math.PI / 180) - (-Math.Sin(psi * Math.PI / 180) * y + Math.Cos(psi * Math.PI / 180) * z) * Math.Sin(phi * Math.PI / 180);
                    double projectedY = y * Math.Cos(psi * Math.PI / 180) + z * Math.Sin(phi * Math.PI / 180);
                    currentCurve.Add(new Point((int)Math.Round(picture.Width / 2 + projectedX * 50d), (int)Math.Round(picture.Height / 2 + projectedY * 50d)));
                }
                DrawCurve(resultBitmap, currentCurve, upFloatingHorizon, downFloatingHorizon);
            }

            if (picture.Image != null)
            {
                picture.Image.Dispose();
            }
            picture.Image = resultBitmap;
        }

        private void DrawCurve(Bitmap bitmap, List<Point> curve, List<double> upFloatingHorizon, List<double> downFloatingHorizon)
        {
            for (int i = 1; i < curve.Count; i++)
            {
                Point startPoint = curve[i - 1];
                Point endPoint = curve[i];
                int X1 = startPoint.X;
                int X2 = endPoint.X;
                    int Y1 = startPoint.Y;
                    int Y2 = endPoint.Y;
            bool needChange = Math.Abs(endPoint.Y - startPoint.Y) > Math.Abs(endPoint.X - startPoint.X);

                if (needChange)
                {
                    Swap(ref X1, ref Y1);
                    Swap(ref X2, ref Y2);
                }

                if (startPoint.X > endPoint.X)
                {
                    Swap(ref X1, ref X2);
                    Swap(ref Y1, ref Y2);
                }

                double df = (endPoint.Y * 1.0 - startPoint.Y) / (endPoint.X * 1.0 - startPoint.X);
                double y = startPoint.Y + df;

                for (int x = startPoint.X + 1; x < endPoint.X; x++)
                {
                    int currentX = needChange ? (int)Math.Round(y) : x;
                    int currentY = needChange ? x : (int)Math.Round(y);

                    if (currentX >= 0 && currentY >= 0 && currentX < bitmap.Width && currentY < bitmap.Height)
                    {
                        UpdatePixelColor(bitmap, currentX, currentY, upFloatingHorizon, downFloatingHorizon);
                    }

                    y += df;
                }
            }
        }

        private void UpdatePixelColor(Bitmap bitmap, int x, int y, List<double> upFloatingHorizon, List<double> downFloatingHorizon)
        {
            if (y >= upFloatingHorizon[x])
            {
                bitmap.SetPixel(x, y, Color.Black);
                upFloatingHorizon[x] = y;
            }
            else if (y <= downFloatingHorizon[x])
            {
                bitmap.SetPixel(x, y, Color.Black);
                downFloatingHorizon[x] = y;
            }
        }

        private void Swap(ref int firstValue, ref int secondValue)
        {
            int temp = firstValue;
            firstValue = secondValue;
            secondValue = temp;
        }

    }
}

