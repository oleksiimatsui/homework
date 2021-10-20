using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Triangle
    {
        protected double a;
        protected double b;
        protected double c;

        public Triangle(double side_a, double side_b, double side_c)
        {
            if (check_sides(side_a, side_b, side_c))
            {
                a = side_a;
                b = side_b;
                c = side_c;
            }
            else sthrow new ArgumentException(String.Format("wrong parametres"));

        }
        protected bool check_sides(double side_a, double side_b, double side_c)
        {
            if ((side_a <= 0) || (side_b <= 0) || (side_c <= 0) ||
                (side_a + side_b <= side_c) || (side_a + side_c <= side_b) || (side_c + side_b <= side_a))
            {
                return false;
            }
            else return true;
        }
        public bool ChangeSide(double side_a, double side_b, double side_c)
        {

            if (!check_sides(side_a, side_b, side_c)) return false;
            a = side_a;
            b = side_b;
            c = side_c;
            return true;
            
        }
        public double GetPerimeter()
        {
            return a + b + c;
        }
        public List<double> GetAngles()
        {
            List<double> angles = new List<double>();
            double angle_c = Math.Acos((a * a + b * b - c * c) / (2 * a * b)) / Math.PI * 180.0;
            double angle_a = Math.Acos((c * c + b * b - a * a) / (2 * c * b)) / Math.PI * 180.0;
            double angle_b = Math.Acos((a * a + c * c - b * b) / (2 * a * c)) / Math.PI * 180.0;

            angles.Add(angle_a);
            angles.Add(angle_b);
            angles.Add(angle_c);
            return angles;
        }
    }

    public class EquilateralTriangle : Triangle
    {
        private double scale;

        public EquilateralTriangle(double a) : base(a, a, a)
        {

        }

        new protected bool check_sides(double side_a, double side_b, double side_c)
        {
            if (side_a != side_b || side_b != side_c || side_c != side_a)
            {
                return false;
            }
            else return true;
        }
        public double GetScale()
        {
            scale = a * a * Math.Sqrt(3) / 4;
            return scale;
        }
    }
}
