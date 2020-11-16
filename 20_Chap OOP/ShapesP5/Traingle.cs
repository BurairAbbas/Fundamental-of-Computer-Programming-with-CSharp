﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Traingle : Shapes
    {
        public Traingle(int width, int height)
        {
            base.width = width;
            base.height = height;
        }
        public override double CalculateSurface()
        {
            return (width * height) / 2;
        }

        public override string ToString()
        {
            return "Area: " + CalculateSurface();
        }
    }
}
