using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Triangle : Figure
    {
        public Triangle(double side_a, double side_b, double side_c)
        {
            if (check_sides(side_a, side_b, side_c))
            {
                a = side_a;
                b = side_b;
                c = side_c;
            }
            else throw new ArgumentException(String.Format("wrong parametres"));

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
        override public double GetPerimeter()
        {
            return a + b + c;
        }
        override public double GetScale()
        {
            return Math.Sqrt((a + b + c) * (a + b - c) * (a + c - b) * (b + c - a)) / 4;
        }
    }
}

