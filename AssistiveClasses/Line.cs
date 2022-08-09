using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_Kulazhin
{
    public class Line
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Line(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public double GetLength()
        {
            double x = Math.Pow(StartPoint.X - EndPoint.X, 2);
            double y = Math.Pow(StartPoint.Y - EndPoint.Y, 2);

            double length = Math.Sqrt(x + y);
            return length;
        }

        public double GetCoefficient()
        {
            double coef = (EndPoint.Y - StartPoint.Y) / (EndPoint.X - StartPoint.X);
            return coef;
        }
    }
}
