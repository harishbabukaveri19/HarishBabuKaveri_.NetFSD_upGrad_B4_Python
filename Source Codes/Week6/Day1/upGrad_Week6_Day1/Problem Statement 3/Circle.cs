using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_3
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
