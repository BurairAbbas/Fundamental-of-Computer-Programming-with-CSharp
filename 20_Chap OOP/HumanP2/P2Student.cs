using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class P2Student : Human, IComparable<P2Student>
    {
        private int mark;
        public int Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }

        public int CompareTo(P2Student other)
        {
            if (this.Mark > other.Mark)
                return 1;
            else if (this.Mark < other.Mark)
                return -1;
            return
                0;
        }

        public P2Student(string firstName, string lastName, int mark)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Mark = mark;
        }

        public override string ToString()
        {
            return "First Name: " + this.FirstName + " Last Name: " + this.LastName + " Mark: " + this.Mark;
        }

    }
}
