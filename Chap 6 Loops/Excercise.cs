using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace Chap6LoopExcercisee
{
    class Program
    {
        static void Main(string[] args)
        {
            //part 2: 1 to N not divisior by 3 and 7
            
            
            //Console.WriteLine("Enter any number: ");
            //int num = int.Parse(Console.ReadLine());
            /*
            for (int i = 1; i <= num; i++)
            {
                if (i % 3 != 0 && i % 7 != 0)
                {
                    Console.Write(i + " ");
                }
            }*/

            //part 3:find small and large number 
           
            /*int small = 1000, large = -1;
            while (num >= 0)
            {
                if (large < num)
                {
                    large = num;
                }
                else
                {
                    if (small > num)
                    {
                        small = num;
                    }

                }
                Console.Write("To exit enter -1 otherwise, enter number : ");
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Smallest = {0} \nLargest = {1}", small, large);
            */
            
            //part 5:Fibonnacci sequence to n number
            /*
            int sum = 0, randomno = 1;
            Console.Write("0 ");
            for (int i = 0; i <= num; )
            {
                i = randomno;
                randomno = sum;
                sum = randomno + i;
                Console.Write(sum + " ");
            }
            */
           
            //part 6: N!/K!;
            /*
            Console.Write("Enter the value of N: ");    //same input in Q6,7,8
            int numfact1 = int.Parse(Console.ReadLine()); // input value of factorial

            Console.Write("Enter value of K: ");
            int numfact2 = int.Parse(Console.ReadLine()); // value of K factorial
            
            // part 6:
            int factorialN = 1; // to calculate N factorial
            int factorialK = 1; // to calculate K factorial

            int numfactsub = numfact1 - numfact2; // question 7 
            int factsub = 1; // to calculate question 7 factorial

            if (numfact2 < numfact1)  // condition is k is less than N then run
            {
                
                for (int i = numfact1; i > 0;i--)  
                {
                    factorialN *= i;
                                       
                }
                
                for (int j = numfact2; j > 0; j--)
                {
                    factorialK *= j;
                }
                for (int k = numfactsub; k > 0; k--)
                {
                    factsub *= k;
                }
               
                Console.WriteLine("N! = {0} \nK! = {1} \nN!/K! = {2}",factorialN,factorialK,factorialN/factorialK);
               
                // part 7: 

                double question7 = 0;
                question7 = (factorialN * factorialK) / factsub;
                Console.WriteLine("N! * K!/(N - K)! = {0}",question7);
                                          
            }
            */
           
            //part 8: Catalan number = (2n)! / (n+1)!n!
            /*
            int doublenum = 2 * numfact1;   // to verify 2n
            int doublefact = 1; // to calculate 2n factorial
            int addnumN = numfact1 + 1; // to verify n+1 
            int addfact = 1;  // to calculate n+1 factorial

            for (int i = doublenum; i > 0; i--)
            {
                doublefact *= i;
            }
            for (int j = addnumN; j > 0; j--)
            {
                addfact *= j;
            }
            double result8 = doublefact / (addfact * factorialN); // formula to calculate 
            Console.WriteLine("(2n)! / (n+1)!*n! = {0}",result8);
            */
           
            //part 9: 1 + 1!/x1 + 2!/x2....N!/xN
            /*
            Console.Write("Enter any number: ");
            int num = int.Parse(Console.ReadLine()); // factorial number mean how much loop run
            Console.Write("x = ");
            int x = int.Parse(Console.ReadLine()); // value of x in the formula

            int fact = 1; // to calculate factorial
            double sum = 1; // to add the whole formula
            for (int i = 1; i <= num; i++)
            { 
                fact *= i;  // first it calcyulate the factorial 
                sum += (fact / Math.Pow(x, i)); // add 
            }
            Console.WriteLine(sum); // display
            */
           
            // part 10: matrix 
            /*
            Console.Write("Enter any number: ");
            int matrixvalue = int.Parse(Console.ReadLine());

            for (int i = 0; i < matrixvalue; i++) // start with zero and end with less then given value of matrixvalue
            {
                for (int j = i + 1; j <= matrixvalue + i; j++) // add one to the value of i equal j and in the conditon add one to the value matrix
                {
                    Console.Write(j + " ");

                }
                Console.WriteLine();

            }*/
            //output 
            //1 2 3
            //2 3 4
            //3 4 5

            // part 11: find zero in factorial result
           
            /*Console.Write("Enter any number: ");
            int factvalue = int.Parse(Console.ReadLine());

            BigInteger factorial = 1;     // value is bigger than decimal that why use factorial in biginterger
            for (int i = factvalue; i > 0; i--)
            {
                factorial *= i; // to calculate factorial
            }
            Console.WriteLine(factorial); // display factorial
            int numberofzeroes = 0; // initialize to calculate number of zeroes

            string str = factorial.ToString(); // convert factorial into string so loop execute number of digit in factorial value eg. 120 = 3 digit
            Console.WriteLine(str.Length);  // to display factorial length 
           
            int modevariable = 1; // random varaible
            for (int j = 1; j < str.Length; j++)
            {                               
                modevariable *= 10; // multiply 10 every time to calculate zero
                if (factorial % modevariable == 0) // if factorial value is zero then add 1 to variable 
                {
                    numberofzeroes++;
                }
            }
            
            Console.WriteLine(numberofzeroes); // display
            */

            //part 12: decimal to binary
            /*
            Console.Write("Enter any number to convert it into binary: ");
            int binary = int.Parse(Console.ReadLine()); 
            int arrayvalue = 0; // calculate the how many time loop execute
           
            int[] binaryholder = new int[16]; // initialize 16 bit array
            for (int i = 0; binary > 0 ; i++) // i used to store value in array, loop run untill binary value in greater than 0
            {
                binaryholder[i] = binary % 2; // module by 2 to get the last value in array
               // Console.Write(binaryholder[i]+" ");
                binary = binary / 2; // divide value on binary so it act like LCM
                
                arrayvalue++; // how many time loop run
            }
            
            for (int j = arrayvalue - 1; j >= 0  ; j--) // to reserve the array value to get accurate binary value
            {   
                Console.Write(binaryholder[j] + " "); // display
            }
           */

            // decimal into hexa

            //Console.WriteLine("Enter any num in convert it into hexadecimal: ");
            //int hexadecimal = int.Parse(Console.ReadLine());
            //Console.WriteLine("{0:X}",hexadecimal);

            // hexa into decimal
            //string hexa = Console.ReadLine();
            //hexa = hexa.Replace("x", string.Empty);
            //long result = 0;
            //long.TryParse(hexa, System.Globalization.NumberStyles.HexNumber, null, out result);
            //Console.WriteLine(result);


            //part 13:
            /*
            Console.Write("Enter binary to convert in into decimal: ");
            int binarynum = int.Parse(Console.ReadLine()); // input binary number into int

            string binarydigit = binarynum.ToString(); // convert into string to find the length of number

            int[] binaryholder = new int[binarydigit.Length]; /// declare its length into array
                                                              /// \binaryholder holds the value of each binary digit in it 
        
            //  Console.WriteLine("i         decimalHolder       decimalnum"); // display like a table grab are 9,19
            for (int i = 0; binarynum > 0; i++)   
            {
                binaryholder[i] = binarynum % 10; // modulus use to separate the last number from binarynum and store its value in binaryholder
                binarynum = binarynum / 10; // divide the binarynum so last digit in binarynum is remove from number 

                //Console.WriteLine("{0,-9} {1,-19} {2}", i, binaryholder[i], binarynum); // show as a table
            }

            Console.WriteLine(); // new line
            int sum = 0; // to calculate sum
            //Console.WriteLine("j         decimalholder       sum"); // show as a table
            for (int j = 0; j < binaryholder.Length; j+=2) // loop execute untill the length of binaryholder
            {
                /// Math.Pow were in double that why type cast it to 'Int'
                /// multiply 2 to digit with respective to its position that why used Math.pow and add two bit at a same time. eg 1010 
                /// sum = 0*2^0 (0 is the value of j) + 1*2^1(j + 1) then sum = 0*2^3 (j increament by 2) + 1*2^4 
                /// result = 10
                sum += (binaryholder[j] * (int)Math.Pow(2, j)) + (binaryholder[j + 1] * (int)Math.Pow(2, j + 1));
               // Console.WriteLine("{0,-9} {1,-19} {2}",j,binaryholder[j],sum); //display as a table
            }
            Console.WriteLine("Result = "+sum);
            */

            // spiral matrix: incomplete    
            int[,] spiralmatrix = new int[3, 3];
            int result = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    spiralmatrix[i, j] = result++;

                }

            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(spiralmatrix[i, j]);
                    if (j == 2)
                    {
                        i = 1;
                        for (j = 0; j <= 1; j++)
                        {
                            Console.WriteLine();
                            Console.Write(spiralmatrix[i, j]);
                        }
                        continue;
                    }
                } 
            }
            Console.WriteLine("stop");
        }
    }
}

