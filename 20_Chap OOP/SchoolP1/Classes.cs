using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Classes
    {
        HashSet<Teacher> teacher;
        HashSet<Student> student;

        public Classes()
        {
            teacher = new HashSet<Teacher>();
            student = new HashSet<Student>();
        }

        public HashSet<Teacher> Teacher
        {
            get { return teacher; }
        }

        public HashSet<Student> Student 
        {
            get { return student; }
        }

        public void AddTeacher(Teacher teacher) 
        {
            this.teacher.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            this.student.Add(student);
        }       
        
    }
}
