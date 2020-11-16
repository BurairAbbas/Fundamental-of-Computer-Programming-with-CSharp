using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Circle : Shapes
    {
        public Circle(int radius)
        {
            base.width = 3.1415;
            base.height = radius;
        }
        public override double CalculateSurface()
        {
            return (width * Math.Pow(height, 2));
        }

        public override string ToString()
        {
            return "Area: " + CalculateSurface();
        }
    }
}
