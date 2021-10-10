using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Ok
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("please, input some numeric\n");
            string input = Console.ReadLine();
            double num = Convert.ToDouble(input);
            Converter superconv = new Converter(26.28, 30.36);
            Console.Write(num+" grn is " + superconv.GrnToEur(num) + " eur\n");
            Console.Write(num+" eur is " + superconv.EurToGrn(num) + " grn\n");
            Console.Write(num+" grn is " + superconv.GrnToUsd(num) + " usd\n");
            Console.Write(num+" usd is " + superconv.UsdToGrn(num) + " grn\n");
        }
        public class Converter
        {
            public Converter(double usd, double eur)
            {
                usd_course = usd;
                eur_course = eur;
            }
            public double GrnToEur(double a) { return a / eur_course; }
            public double EurToGrn(double a) { return a * eur_course; }
            public double GrnToUsd(double a) { return a / usd_course; }
            public double UsdToGrn(double a) { return a * usd_course; }

            private double usd_course;
            private double eur_course;
        }
    }
}
