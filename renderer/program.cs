
//Code created by thelogical1 
//used as renderer in c#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TomoGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap(256, 256);

            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.LightBlue);

            Pen pen1 = new Pen(Color.Black, 1.0f);
            Pen pen3 = new Pen(Color.Black, 3.0f);

            PointF[] p = new PointF[4];
            p[0] = new PointF(57, 80);
            p[1] = new PointF(74, 71);
            p[2] = new PointF(97, 70);
            p[3] = new PointF(113, 78);

            PointF[] q = new PointF[4];
            q[0] = new PointF(61, 47);
            q[1] = new PointF(81, 49);
            q[2] = new PointF(100, 61);
            q[3] = new PointF(115, 80);

            PointF[] u = new PointF[4];
            u[0] = new PointF(57, 60);
            u[1] = new PointF(74, 51);
            u[2] = new PointF(97, 50);
            u[3] = new PointF(113, 58);

            g.DrawEllipse(pen3, new RectangleF(10, 10, 235, 235));

            g.DrawCurve(pen1, p);
            g.DrawCurve(pen1, q);
            g.DrawCurve(pen1, u);

            float t0 = 0.3f;
            float t1 = 0.5f;
            float t2 = 0.2f;

            g.DrawCurve(pen3,
                TweenCurves(
                    TweenCurves(p, q, t1 / (t0 + t1)),
                    TweenCurves(p, u, t2 / (t0 + t2)),
                    t2 / (t1 + t2)));

            g.FillClosedCurve(Brushes.Blue, p);

            bmp.Save("output.bmp");
        }

        static PointF[] TweenCurves(PointF[] p, PointF[] q, float t)
        {
            float s = 1 - t;

            PointF[] r = new PointF[Math.Min(p.Length, q.Length)];

            for (int i = 0; i < r.Length; ++i)
            {
                r[i] = new PointF(p[i].X * s + q[i].X * t, p[i].Y * s + q[i].Y * t);
            }

            return r;
        }

        //static PointF[] TweenCurves(PointF[][] p, float t[])
        //{
        //    float s = t;

        //    PointF[] r = new PointF[Math.Min(p.Length, q.Length)];

        //    for (int i = 0; i < r.Length; ++i)
        //    {
        //        r[i] = new PointF(p[i].X * s + q[i].X * t, p[i].Y * s + q[i].Y * t);
        //    }

        //    return r;
        //}
    }
}
