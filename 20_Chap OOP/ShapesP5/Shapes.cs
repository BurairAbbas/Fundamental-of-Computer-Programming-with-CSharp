using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public abstract class Shapes
    {
        public double width;
        public double height;

        public Shapes()
        {
            this.width = 0;
            this.height = 0;
        }

        public abstract double CalculateSurface();
        
    }
}
