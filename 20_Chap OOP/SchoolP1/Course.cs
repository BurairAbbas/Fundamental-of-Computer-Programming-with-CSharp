using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Course
    {
        private string nameofCourse;
        private int countOfClasses;
        private int countOfExcercise;

        public Course()
            :this(null, 0 ,0)
        {
            
        }
        public Course(string name, int countofClasses, int countofExcercise)
        {
            this.NameOfCourse = name;
            this.CountOfClasses = countofClasses;
            this.CountOfExcercise = countofExcercise;
        }

        public string NameOfCourse
        {
            get
            {
                return nameofCourse;
            }
            private set
            {
                nameofCourse = value;
            }
        }

        public int CountOfClasses
        {
            get
            {
                return countOfClasses;
            }
            private set
            {
                countOfClasses = value;
            }
        }

        public int CountOfExcercise
        {
            get
            {
                return countOfExcercise;
            }
            private set
            {
                countOfExcercise = value;
            }
        }

        public override string ToString()
        {
            return "Name of course" + this.nameofCourse + "\nCount of Classes: " + this.countOfClasses + "\nCount of Excercise: " + this.countOfExcercise;
        }
    }
}
