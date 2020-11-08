using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chap10RecursionEx
{
    class RecursionEx
    {
        void NSimulator(int n)
        {
            if (n < 0)
            {
                return;
            }
            NSimulator(n - 1);
            Console.Write(n + " ");
        }
        int[] number;
        int position = 0;
        int parentvalueofn = 0;
        // int n = 1;
        int Subsets(int n, int max)
        {
            // after 2 days of work not showing desire result on every user input except n = 3 k = 2
            position = 0;
            number[position] = ++parentvalueofn;
            if (parentvalueofn <= max)
            {
                parentvalueofn--;
                if (n == 3)
                {
                    ++parentvalueofn;
                }

                if (n <= max)
                {
                    position++;
                    number[position] = n;
                    n++;
                    Printarray(max - 1);
                    Subsets(Subsets(n, max), max);
                }
            }

            return 1;
        }
        void Printarray(int k)
        {
            Console.Write("(");
            for (int i = 0; i < k; i++)
            {
                Console.Write(number[i]);
            }
            Console.Write(")" + " ");
            position--;
        }



        public void MethodOfExcersice()
        {
            // part 1: simulate n nested loop from 1 to n
            //Console.Write("Enter the value to run loop by Recursion: ");
            //int n = int.Parse(Console.ReadLine());
            //NSimulator(n - 1);

            //part 2: generate all variations with duplicates
            // after 2 days of work not showing desire result on every user input except num = 3, elementinset = 2
            Console.Write("Enter the value of N =");
            int numberofsubsets = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the value of element in the subsets: ");
            int elementinset = Convert.ToInt32(Console.ReadLine());

            number = new int[elementinset];
            Subsets(1, numberofsubsets);


        }

    }
}
