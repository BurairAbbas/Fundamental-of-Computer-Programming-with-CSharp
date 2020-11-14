using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap9Ex
{
    class Excercise
    {
        static void PrintName(string name)
        {
            Console.WriteLine("\"Hello, {0}!\"", name);
            // Console.WriteLine("\"Hello, " + name + "!\"");
        }

        static int GetMax(int first, int second)
        {
            Console.WriteLine("Values before Getting Maximum are {0},{1}", first, second);

            if (first < second)
            {
                Console.WriteLine(second);
            }
            else
            {
                Console.WriteLine(first);
            }
            // Console.WriteLine(first < second ? second : first);
            return first < second ? second : first;

        }

        static string EnglishNameOfLastDigit(string userinput)
        {
            int num = int.Parse(userinput);
            int lastnum = num % 10;
            switch (lastnum)
            {
                case 1:
                    return "One";

                case 2:
                    return "Two";

                case 3:
                    return "Three";

                case 4:
                    return "Four";

                case 5:
                    return "Five";

                case 6:
                    return "Six";

                case 7:
                    return "Seven";

                case 8:
                    return "Eight";

                case 9:
                    return "Nine";

                default:
                    return "Incorrect value";
            }
        }

        static int FindNumberInGivenArray(int num, params int[] array)
        {
            int count = 0; // to count how many times number comes in array
            int[] indexnumber = new int[5]; // to get the value of index

            // for statics values
            for (int i = 0; i < array.Length; i++) // display the given array by user
            {
                Console.Write(array[i]);
                if (i < array.Length - 1) // print commas between number untill the last number
                {
                    Console.Write(",");
                }
            }

            for (int i = 0; i < array.Length; i++) 
            {
                if (array[i] == num) // condition to find the number of times number comes
                {
                    indexnumber[count] = i; 
                    count++; 
                }
            }
            Console.WriteLine(); 
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("at index " + indexnumber[i]); // text msg to print index of array
            }
            return count; 
        }

        static int PrintArrayOfAboveMeethod()
        {
            Console.WriteLine("Enter the value of array: ");
            int[] array = new int[6];

            // int sum = 0; // for question 11 

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                // sum += array[i]; //part 11
            }

            //Console.Write("Enter the number u want to find in given array: ");
            //int number = int.Parse(Console.ReadLine());

            // FindNumberInGivenArray(array, num: number);
            // if we are rearrangement argument than we have to rearrange all the argument of parameter otherwise how this array: 
            // Named argument 'num' specifies a parameter for which a positional argument has already been given

            // return FindNumberInGivenArray(array: array, num: number);

            /*Console.Write("Enter the index of array: ");
            int number = int.Parse(Console.ReadLine());
            return Convert.ToInt32(CheckElementNeighbor(number, array));        
             */

            //return GreaterElementInFirstOccurrence(array);
            //return BiggestElement(array);

            // return sum; // part 11

            return 0;
        }

        //part 5:
        static bool CheckElementNeighbor(int num, params int[] array)
        {
            if (num > 0 && num < array.Length - 1)
            {
                return (array[num - 1] < array[num]) && (array[num + 1] > array[num]) ? true : false;
            }
            else
            {
                Console.WriteLine("Wrong index number");
                return false;
            }
        }

        //part 6: 
        static int GreaterElementInFirstOccurrence(params int[] array)
        {
            for (int i = 0; i < array.Length - 2; i++)
            {
                if ((array[i] > array[i + 1]) && (array[i] > array[i + 2]))
                {
                    Console.WriteLine("number = " + array[i]);
                    return 1;
                }
            }
            return -1;
        }

        // part 7
        static int[] ReverseNumber(int num)
        {
            int[] reversearray = new int[num.ToString().Length];
            for (int i = 0; i < reversearray.Length; i++)
            {
                reversearray[i] = num % 10;
                num = num / 10;
            }
            return reversearray;
        }

        // part 8
        static void LongSum(ulong firstnum, ulong secondnum)
        {
            ulong[] array = new ulong[10000];
            ulong sum = firstnum + secondnum;
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (sum > 0)
                {
                    array[i] = sum % 10;
                    sum = sum / 10;
                    count++;
                }
            }
            Console.WriteLine("Value of count: " + count);
            for (int i = count - 1; i >= 0; i--)
            {
                Console.Write(array[i]);
                if (i % 3 == 0 && i != 0)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine();
        }

        // part 9
        static int BiggestElement(int[] array)
        {
            int max = 0;

            for (int j = 0; j < array.Length - 1; j++)
            {
                if ((array[j] < array[j + 1]) && (max < array[j + 1]))
                {
                    max = array[j + 1];
                }
            }

            return SortByAboveArray(max, array);
        }

        static int SortByAboveArray(int maximum, params int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        maximum = array[i];
                        array[i] = array[j];
                        array[j] = maximum;
                    }
                }
            }
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }

            return 0;
        }

        static void Factorial()
        {
            ulong sum = 1;
            int fact = int.Parse(Console.ReadLine());
            for (int i = fact; i > 0; i--)
            {
                sum = sum * (ulong)i;
            }
            Console.WriteLine(sum);
        }

        static void TextMenu()
        {
            do
            {
                Console.WriteLine("Enter appropiate number for tasks");
                Console.WriteLine("1- To Reverse th Digit");
                Console.WriteLine("2- To find average of given number");
                Console.WriteLine("3- Solve Linear Equation ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Write("Enter any number: ");
                        int num = int.Parse(Console.ReadLine());
                        int[] reversearray = ReverseNumber(num);
                        foreach (int item in reversearray)
                        {
                            Console.Write(item);
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        /// https://www.physicsforums.com/threads/converting-integer-into-array-of-single-digits-in-c.558588/
                        int avg;
                        int sum = PrintArrayOfAboveMeethod();
                        avg = sum / 6;
                        Console.WriteLine(avg);
                        break;

                    case 3:
                        int a;
                        double b, x;
                        Console.WriteLine("Enter the value of equation a * x + b:");
                        Console.Write("a = ");
                        a = int.Parse(Console.ReadLine());
                        Console.Write("b = ");
                        b = double.Parse(Console.ReadLine());
                        Console.Write("x = ");
                        x = double.Parse(Console.ReadLine());
                        LinearEquation(a, b, x);
                        break;
                }
            } while (true);
        }

        static void LinearEquation(int a, double b, double x)
        {
            double result = a * x + b;
            if (result == 0)
            {
                Console.WriteLine("Linear Equation");
            }
            else
            {
                Console.WriteLine("Non-linear equation");
            }

        }

        static double firstPolynomial(int x, double xx)
        {
            double result = 0;
            if (x != 0)
            {
                //(3x2 + x - 3) + (x - 1) = (3x2 + 2x - 4).
                result = ((3 * Math.Pow(x,2)) + x - 3) + (x - 1);
            }
            else
            {
                //(3x2 + x - 3) * (x - 1) = (3x3 - 2x2 - 4x + 3).
                result = ((3 * Math.Pow(xx, 2)) + xx - 3) * (xx - 1);
            }
            return result;
        }

        static double SecondPoly(int x, double xx)
        {
            double resultsec = 0;
            if (x != 0)
            {
                resultsec = (3 * Math.Pow(x,2)) + (2 * x) - 4;
            }
            else
            {
                resultsec = (3 * Math.Pow(xx, 3)) - (2 * Math.Pow(xx, 2)) - 4 * xx + 3;
            }
            return resultsec;
        }

        static void Main(string[] args)
        {

            /*
            // console nsame and print with "Hello,<name>!" this format 
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            PrintName(name);

            // part 2: method which tell max number on 2 input and three input
            GetMax(5, 2);
            int first, second, third, max;
            
            Console.WriteLine("Enter 3 number: ");
            first = int.Parse(Console.ReadLine());
            second = int.Parse(Console.ReadLine());
            third = int.Parse(Console.ReadLine());
            
            max = GetMax(first, second);
            GetMax(max, third); */

            //part 3: take console in string and write the name of last digit 
            //Console.Write("Write any number ");
            //string userinput = Console.ReadLine();
            //string str = EnglishNameOfLastDigit(userinput);
            //Console.WriteLine(str);

            // part 4:
            // for static values
            //int a = FindNumberInGivenArray(1, 2, 3, 4, 5, 1, 2, 1, 1, 2, 3);
            //Console.WriteLine("Number of time your number comes is " + a);
            // for dyamics
            //int count = PrintArrayOfAboveMeethod();
            //Console.WriteLine("number comes " + count);

            // part 5: write an method to check form certain position that element is greater of less from neighbor
            //int check = PrintArrayOfAboveMeethod();
            //Console.WriteLine(check == 0 ? "False": "True");

            // part 6: first occurrence element which is greater then its two neighbor otherwise result is -1
            // Console.WriteLine(PrintArrayOfAboveMeethod() == 1 ? "true" : "false" );

            // part 7: print number in reverse order
            /*
            Console.Write("Enter any number: ");
            int inputnumber = int.Parse(Console.ReadLine());

            Console.Write("After method number is ");
            foreach (var item in ReverseNumber(inputnumber))
            {
                Console.Write(item);
            }
            Console.WriteLine();*/

            //part 8: sum of long positive integer number and sum are represented in array 
            //Console.Write("Enter first long number: ");
            //ulong firstnum = ulong.Parse(Console.ReadLine());
            //Console.Write("Enter secnond number: ");
            //ulong second = ulong.Parse(Console.ReadLine());

            //LongSum(firstnum, second);

            //part 9: find biggest array and sort with that
            //PrintArrayOfAboveMeethod();

            //part 10: factorial ooper hai
            // Factorial();

            //part 11:  3 task !! digit in resverse, avg, a * x + b = 0
            // TextMenu();

            // paart 12: 
            //Console.WriteLine("Enter the value of x for equation (3x2 + x - 3) + (x - 1) = (3x2 + 2x - 4)");
            //Console.Write("x = ");
            //int x = int.Parse(Console.ReadLine());
            //double resultfirst = firstPolynomial(x,0);
            //double resultsec = SecondPoly(x,0);
            //Console.WriteLine(resultfirst == resultsec ? "true" : "False");

            
           
            // part 13: (3x2 + x - 3) * (x - 1) = (3x3 - 2x2 - 4x + 3)
            Console.WriteLine("Enter the value of x to find (3x2 + x - 3) * (x - 1) = (3x3 - 2x2 - 4x + 3)");
            double x = double.Parse(Console.ReadLine());
            double resultfirst = firstPolynomial(xx: x, x: 0);
            double resultsec = SecondPoly(xx: x, x: 0);
            Console.WriteLine(resultfirst == resultsec ? "True" : "False");

        }
    }
}
