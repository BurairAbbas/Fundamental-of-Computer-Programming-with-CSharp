using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Student
    {
        private string name;
        private int uniqueId;

        public Student()
            : this(null, 0)
        { }

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }


        public string Name
        {
            get
            {

                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.uniqueId;
            }
            set
            {
                this.uniqueId = value;
            }
        }

        public override string ToString()
        {
            return "ID Number: " + this.uniqueId + " Name: " + this.name;
        }


    }
}
