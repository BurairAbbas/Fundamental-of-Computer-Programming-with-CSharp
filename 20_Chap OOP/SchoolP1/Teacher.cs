using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Teacher
    {
        private string name;
        HashSet<Course> courseSet;
        public Teacher(string name, Course course)
        {
            this.Name = name;
            this.courseSet = new HashSet<Course>();
            this.courseSet.Add(course);
        }
        public Teacher()
            : this(null, null)
        {
        }
        public HashSet<Course> course 
        {
            get { return courseSet; }
        }
        public string Name
        {
            get
            {
                if (name == null)
                {
                    Console.WriteLine("Please Enter Techer Name");
                }
                return name;
            }
            set
            {
                this.name = value;
            }
        }


        
    }
}
