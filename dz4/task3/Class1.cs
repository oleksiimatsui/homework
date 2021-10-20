using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    abstract public class Triangle
    {
        protected double A;
        protected double B;
        protected double Angle;
        virtual public double CalcPer(double a, double b, double angle) 
        {
            return a + b + Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angle));
        }
        virtual public double CalcScale(double a, double b, double angle)
        {
            return a * b * Math.Sin(angle * Math.PI / 180.0);
        }
    }

    public class RightTriangle:Triangle
    {
        public RightTriangle(double a, double b)
        {
            A = a;
            B = b;
            Angle = 90;
        }
        public double GetPer()
        {
            return base.CalcPer(A, B, 90);
        }
        public double GetScale()
        {
            return base.CalcScale(A, B, 90);
        }

    }

    public class EquilateralTriangle:Triangle
    {
        public EquilateralTriangle(double a)
        {
            A = a;
            B = a;
            Angle = 60;
        }

        public double GetPer()
        {
            return base.CalcPer(A, A, 60);
        }
        public double GetScale()
        {
            return base.CalcScale(A, A, 60);
        }
    }
}
