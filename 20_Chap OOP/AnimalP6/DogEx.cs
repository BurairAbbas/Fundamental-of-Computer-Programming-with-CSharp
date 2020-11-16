using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class DogEx : AnimalEx
    {
        public DogEx(string name, int age, bool isMale)
        {
            base.Name = name;
            base.Age = age;
            base.GenderMale = isMale;
        }

        public override string MakeSound()
        {
            return "WoofWoo";
        }

        public override string ToString()
        {
            return string.Format("Name: {0} Age: {1} IsMale: {2} ", base.Name, base.Age, base.GenderMale);
        }
    }
}
