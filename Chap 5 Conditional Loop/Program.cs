using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chap5Conditional_statement
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string str = "beer";
            string anotherstr = str;
            string thirdstr = "be" + "e" + "r";
            Console.WriteLine("str == " + str);
            Console.WriteLine("anotherstr == "+ anotherstr);
            Console.WriteLine("thirdstr == " + thirdstr);
            Console.WriteLine(str == anotherstr);
            Console.WriteLine(str == thirdstr);
            Console.WriteLine((object)str == (object)anotherstr);
            Console.WriteLine((object)str == (object)thirdstr);
            Console.WriteLine((object)str == (string)thirdstr);
            Console.WriteLine((string)str == (object)thirdstr); */

            //Part 1: take two integer value and exchange its value if greater
            /*
            Console.WriteLine("Enter two integer value: ");
            int firstnum = int.Parse(Console.ReadLine());
            int secondnum = int.Parse(Console.ReadLine());

            if (firstnum > secondnum)
            {
                int changenum;
                changenum = firstnum;
                firstnum = secondnum;
                secondnum = changenum;
                Console.WriteLine(firstnum + " " + secondnum);
            }
            else
            {
                Console.WriteLine(firstnum + " " + secondnum);
            }

            //part 2: show sign of 3 product without calculating it
            int thirdnum = int.Parse(Console.ReadLine());

            if ((firstnum < 0 && secondnum < 0) || (firstnum < 0 && thirdnum < 0) || (secondnum < 0 && thirdnum < 0))
            {
                Console.WriteLine("+"); // if 2 number is negative then value of product is position condition
            }
            else if (firstnum < 0)
            {
                Console.WriteLine("-");
            }
            else if (secondnum < 0)
            {
                Console.WriteLine("-");
            }
            else if (thirdnum < 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine("+");
            }

            // part 3: bigger value of integer nested loop
           
            if (firstnum > secondnum)
            {
                if (firstnum > thirdnum)
                {
                    Console.WriteLine(firstnum);
                }

            }
            else if (secondnum > firstnum)
            {
                if (secondnum > thirdnum)
                {
                    Console.WriteLine(secondnum);
                }
                
            }
            if (thirdnum > firstnum)
            {
                if (thirdnum > secondnum)
                {
                    Console.WriteLine(thirdnum);
                }
                else
                    Console.WriteLine("wtf");
            }
            else
                Console.WriteLine("hmm"); */
            //part 4: descending order 
            /*
            Console.WriteLine("Enter any 3 number: ");
            int firstnum = int.Parse(Console.ReadLine());
            int secondnum = int.Parse(Console.ReadLine());
            int thirdnum = int.Parse(Console.ReadLine());

            if (firstnum > secondnum && firstnum > thirdnum)
            {
                if (secondnum > thirdnum)
                {
                    Console.WriteLine(firstnum + " " + secondnum + " " + thirdnum);
                }
                else
                {
                    Console.WriteLine(firstnum + " " + thirdnum + " " + secondnum);
                }

            }
            else if (secondnum > firstnum && secondnum > thirdnum)
            {
                if (firstnum > thirdnum)
                {
                    Console.WriteLine(secondnum + " " + firstnum + " " + thirdnum);
                }
                else
                {
                    Console.WriteLine(secondnum + " " + thirdnum + " " + firstnum);
                }
            }
            else if (thirdnum > firstnum && thirdnum > secondnum)
            {
                if (firstnum > secondnum)
                {
                    Console.WriteLine(thirdnum +" "+firstnum+" "+secondnum);
                }
                else
                    Console.WriteLine(thirdnum +" "+secondnum +" "+thirdnum);
            }*/

            //part 5: show digit into word
            /*Console.Write("Enter nay number: ");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                case 3:
                    Console.WriteLine("Three");
                    break;
                case 4:
                    Console.WriteLine("Four");
                    break;
                case 5:
                    Console.WriteLine("Five");
                    break;
                case 6:
                    Console.WriteLine("six");
                    break;
                default:
                    Console.WriteLine("Wrong value");
                    break;
            }*/

            //part 6: print quadratic equation

            
            /*Console.WriteLine("Enter the coefficient of quadratic equation");
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("c = ");
            int c = int.Parse(Console.ReadLine());
            double x1, x2;
            double root = Math.Pow(b, 2) - 4 * a * c;
            Console.WriteLine(root);
            x1 = (-b - Math.Sqrt((Math.Pow(b, 2) - 4 * a * c))) / (2 * a);
            x2 = (-b + Math.Sqrt((Math.Pow(b, 2) - (4 * a * c)))) / (2 * a);
            Console.WriteLine(x1 +"\n"+ x2);
            if ((x1 == 0 || x1 == 1 || x1 == 2) && (x2 == 0 || x2 == 1 || x2 == 2))
            {
                Console.WriteLine(x1 +"\n"+ x2);
            }*/

            //part 7: 
            
            /*Console.Write("Enter any number: ");
            object var = Console.ReadLine();
            Console.WriteLine("type of variable");
            int type = int.Parse(Console.ReadLine());
            switch (type)
            {
                case 1:
                    type = int.Parse((string)var);
                    Console.WriteLine(type + 1);
                    break;
                case 2:
                    double dbl;
                    dbl = double.Parse((string)var);
                    Console.WriteLine(dbl + 1);
                    break;
                case 3:
                    Console.WriteLine(var +"*");
                    break;
            } */

            //part 9:
            // Incomplete
            Console.WriteLine("Enter any five number ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            Console.WriteLine("{" + a + "," + b + "," + c + "," + d + "," + e + "}");
            int sum = 0;
            if (a < 0)
            {
                if (b <= c && b <= d && b <= e)
                {
                    if (c <= d && c <= e)
                    {
                        if (d < e)
                        {
                            sum = a + b + c;
                            bool bl = sum == 0;
                            Console.WriteLine(bl ? "the sum of " + a + "," + b + "," + c + " = 0" : "no subset is zero");

                        }

                    }

                }
               
            }

            
            //part 10:
            Console.WriteLine("enter number between 0 and 9 to get bonus");
            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                case 2:
                case 3:
                    Console.WriteLine(num * 10);
                    break;
                case 4:
                case 5:
                case 6:
                    Console.WriteLine(num * 100);
                    break;
                case 7:
                case 8:
                case 9:
                    Console.WriteLine(num * 1000);
                    break;
                default:
                    Console.WriteLine("Wrong value");
                    break;
            }

            //part 11: 0 to 999 into words
            //incomplete
            
        }
    }
}
