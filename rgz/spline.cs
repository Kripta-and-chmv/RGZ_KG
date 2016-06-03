using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace rgz
{
    class spline
    {
        List<PointF> points;
        double[] a, b, c, beta;
        private int point_count = 0;

        public void Add_point(PointF point)
        {
            points.Add(point);
            points.Sort();
            point_count++;
            a = new double[point_count];
            b = new double[point_count];
            c = new double[point_count];
            beta = new double[point_count];
            create_spline();
        }

        public void create_spline()
        {
            double dif = (points[1].Y - points[0].Y)/(points[1].X - points[0].X);
            a[0] = (points[1].Y - points[0].Y)/Math.Pow((points[1].X - points[0].X), 2) -
                   dif/(points[1].X - points[0].X);
            b[0] = dif - 2*a[0]*points[0].X;
            c[0] = points[0].Y - dif*points[0].X + a[0]*Math.Pow(points[0].X, 2);

            for (int i = 1; i < point_count; i++)
            {
                beta[i] = 2*a[i - 1]*points[i].X + b[i - 1];
                a[i] = (points[i+1].Y - points[i].Y) / Math.Pow((points[i+1].X - points[i].X), 2) -
                   beta[i] / (points[i+1].X - points[i].X);
                b[i] = beta[i] - 2 * a[i] * points[i].X;
                c[i] = points[i].Y - beta[i] * points[i].X + a[i] * Math.Pow(points[i].X, 2);
            }
        }

    }
}
