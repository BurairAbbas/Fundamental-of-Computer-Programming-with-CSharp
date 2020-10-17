using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercisechap4InputOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            //part 1: input 3 no and find sum
            //part 2: calculate area and perimater of circle

            Console.WriteLine("Enter the radius of circle: ");
            int radius = int.Parse(Console.ReadLine());

            Console.WriteLine("The area of circle is {0} inches", (3.14 * Math.Pow(radius, 2)));
            Console.WriteLine("The perimeter of circle is " + (3.14 * radius * 2) + " inches");

            //part 3:take the information and print it
            //part 4: take 3 number print in colume 1st number in hexa 2nd in posiive fraction 3rd in negative fraction
            Console.Write("Enter 3 number: ");
            int firstnum = int.Parse(Console.ReadLine());
            double secondnum = double.Parse(Console.ReadLine()); // in fraction that why take in double
            double thirdnum = double.Parse(Console.ReadLine());
            // firstnum change in hexa by specifier X, 
            Console.WriteLine("{0,-10:X} {1,-10:f2} {2,-10:f2}", firstnum, secondnum, thirdnum);

            //part 5: input 2 number and print number between them which are divisior by 5

            Console.Write("Enter number: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Enter number: ");
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                int result = i % 5;
                if (result == 0)
                    Console.WriteLine("Answer " + i);

            }

            // part 6: print greater without use of conditional statement

            Console.WriteLine("Enter two number: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int c = a - b;
            bool bl = c < 0;
            Console.WriteLine(bl ? b : a); // MyLogic
            Console.WriteLine(Math.Max(a, b));  // book guide

            // part 11: Fibonacci sequence 0,1,1,2,3,5,... 100
            /* 1 + 1 = 2
             * 1 + 2 = 3
             * 2 + 3 = 5
             * 3 + 5 = 8
             * 
             */
            Console.WriteLine("Enter any number to get fibinacci sequence: ");
            int num = int.Parse(Console.ReadLine());
            int sum = 1, a = 1;
            for (int i = 0; i <= 100;)
            {
                a = i;
                i = sum;
                sum = i + a;
                Console.WriteLine(sum);
            }

            // part 12: find sum of 1+1/2-1/3+1/4.... till 0.001(1/1000)           
            double sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                double divisor = (double)1 / i; // divide by 1 by 1 to 1000
                
                if (i != 1)
                {
                    if (i % 2 != 0) // if odd then add '-' sign with divisor to get desire result
                    {
                        divisor = -divisor;
                    }
                }
                
                sum = sum + divisor;

            }
            Console.WriteLine(Math.Round(sum,3)); // suum value
        }
    }
}
