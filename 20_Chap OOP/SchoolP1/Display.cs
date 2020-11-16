using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Display
    {
        public static void DisplayClass(Classes classes)
        {
            PrintTeacherInfo(classes.Teacher);
        }
        private static void PrintTeacherInfo(HashSet<Teacher> teacher)
        {
            foreach (var item in teacher)
            {
                Console.WriteLine(item.Name);
                foreach (var course in item.course)
                {
                    Console.WriteLine(course);
                }
            }
        }
        private static void PrintStudent(HashSet<Student> student)
        {
            foreach (var item in student)
            {
                Console.WriteLine(item);
            }
        }

    }
}
