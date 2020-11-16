using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public abstract class AnimalEx
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public bool GenderMale { get; set; }

        public virtual string MakeSound()
        {
            return "Geeerr";
        }

    }
}
