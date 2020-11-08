using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // part 1: initialize array of 20 element of int and multipy each element with 5 
            /*int[] array = new int[20];

            for (int index = 1; index < array.Length; index++)  
            {
                array[index] = index * 5;
                Console.WriteLine("index = {0}, array[index] = {1}", index, array[index]);
            }
            foreach (int outputarray in array)
            {
                Console.WriteLine(outputarray);
            }*/

            //part 2: read two array from console and check they are equal or not

            /*int[] firstarray = new int[5];
            int[] secondarray = new int[5];
            bool checkcondition = true;

            Console.WriteLine("Enter value of first array");
            for (int index = 0; index <= firstarray.Length - 1; index++)
            {
                firstarray[index] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter value of second array");
            for (int index = 0; index <= secondarray.Length - 1; index++)
            {
                secondarray[index] = int.Parse(Console.ReadLine());
            }
            for (int index = 0; index <= firstarray.Length - 1; index++)
            {
                if (firstarray[index] != secondarray[index])
                {
                    Console.WriteLine("Not equal");
                    checkcondition = false;
                    break;
                }
                checkcondition = true;
            }
            Console.WriteLine(checkcondition ? "All are equal" : "");
            */

            // part 3: compare two array (char), which come first in lexicographicalorder


            // same input used in 4,5,6
            //Console.Write("Enter length of Array: ");
            //int n = int.Parse(Console.ReadLine()); 


            //int[] maximal = new int[n]; 
            //Console.WriteLine("Value of array: ");
            //for (int i = 0; i < maximal.Length; i++)
            //{
            //    maximal[i] = int.Parse(Console.ReadLine());   // take the value of array
            //}
            //*****************//


            //used same varaible in question 4,5

            //int sum = 0, bestsum = -1; 
            //int start = 0; // starting of array
            //int end = 0; // end condition of array

            //int start2 = 0; // to calculate starting index of any other equal maximul sequence
            //int sumstart = 0, sumstart2 = 0; // to calculate the sum of two starting sequence, so we can check which is greater and print it.
            //********************//


            //part 4: maximal sequence eg.{1,2,4,1,1,1,3,4} output {1,1,1}

            /*
            for (int index = 0; index < maximal.Length - 1; index++) // condition in '- 1' so compiler dont throw exception of outofRange 
            {
                if (maximal[index] != maximal[index + 1]) // condition for maximal equal sequence 
                {
                    sum = 0; // not equal then sum is zero
                }
                else
                {
                    sum++; // if equal, increase sum by one

                    if (sum == 1) // if sum is one which is on first index so take the value of starting index in the start variable
                    {
                        if (start == 0) // if start is 0 then it initialize the value of index in 'start'
                        {
                            start = index;
                            Console.WriteLine("start = {0}",start); //for improve logical error
                        }
                        else
                        {
                            start2 = index; // if start already have value then it will send the index value to 'start2' of new equal sequence
                            Console.WriteLine("Start2 = {0}",start2); //to improve logic
                        }
                    }
                    if (start != 0 && start2 == 0) 
                    {
                        sumstart = sum;
                        Console.WriteLine("sumstart = {0}",sumstart);
                    }
                    else
                    {
                        sumstart2 = sum;
                        Console.WriteLine("sumstart2 = {0}", sumstart2);
                    }
                    if (sum > bestsum) // to check the largest equal sequence in the maximal
                    {
                        bestsum = sum; // initialize the large sequence in bestsum
                    }

                }

            }
            // number of time loop will execute is sum of bestsum and start becoz start is the starting index and bestsum is the number which are equal in the sequences 
            //  end = bestsum + start; 
            if (sumstart > sumstart2) // if sumstart is greater then sumstart2 then first equal sequence is greater so print it!
            {
                end = bestsum + start; // describe above
                Console.WriteLine("Result");
                Console.Write("{"); // to show starting bracket           
                for (int index = start; index <= end; index++)
                {
                    Console.Write(maximal[index]);

                    // condition statement: if index is equal to its last value then print '}' to close set, otherwise print ',' to sepearate number in set.
                    Console.Write(index == end ? "}" : ",");  
                }
            }
            else // else print the other sequence 
            {
                end = bestsum + start2;
                Console.WriteLine("Result");
                Console.Write("{"); // to show starting bracket           
                for (int index = start2; index <= end; index++)
                {
                    Console.Write(maximal[index]);
                    Console.Write(index == end ? "}" : ","); 
                }
            }*/
            // there is still some bugs in the code


            // part 5: increase maximal e.g {2,2,3,4,2}, {2,3,4}

            /*
             for (int index = 0; index < maximal.Length - 1; index++)
             {
                 if (maximal[index] + 1 == maximal[index + 1])
                 {
                     sum++;
                     if (sum == 1)
                     {
                         if (start == 0)
                         {
                             start = index;
                         }
                         else
                         {
                             start2 = index;
                         }
                     }
                     if (start != 0 && start2 == 0)
                     {
                         sumstart = sum;
                     }
                     else
                     {
                         sumstart2 = sum;
                     }

                     if (bestsum < sum)
                     {
                         bestsum = sum;
                     }
                 }
                 else
                 {
                     sum = 0;
                 }
             }
             if (sumstart > sumstart2)
             {
                 end = bestsum + start;
                 Console.WriteLine("Result");
                 Console.Write("{");
                 for (int index = start; index <= end; index++)
                 {
                     Console.Write(maximal[index]);
                     Console.Write(index == end ? "}" : ",");
                 }
             }
             else
             {
                 end = bestsum + start2;
                 Console.WriteLine("Result");
                 Console.Write("{");
                 for (int index = start2; index <= end; index++)
                 {
                     Console.Write(maximal[index]);
                     Console.Write(index == end ? "}" : ",");
                 }
             }*/

            // part 6: maximial {9,6,2,7,4,7,6,5,9,4} get {2,4,6,8}
            /*
            int leastnum = maximal.Min(); // to get the minimum value in the given array;
            int ratio; // variable to check even number
            if (leastnum % 2 != 0)   //if minimun value in the array is odd than chnage it into even
            {
                leastnum++;
            }
            int leastmaximalvalue = leastnum; // variable t change minimum value a/c to current loop 

            //   Console.WriteLine(leastnum);
            for (int index = 0; index < maximal.Length; index++) // loop to check which index number inarray contain minimum value
            {
                if (maximal[index] == leastnum) // if index reach to minimum value then start check give loop
                {
                    for (int i = index; i < maximal.Length; i++) // loop which check rest of number in array after minimum value
                    {
                        ratio = maximal[i] % 2; // if value in array is even then it store zero in ratio
                        
                        // to find logical error
                        //Console.WriteLine("ratio = {0}",ratio); 
                        //Console.WriteLine("least = {0}",leastnum); 
                        
                        if ((ratio == 0) && (maximal[i] >= leastmaximalvalue)) //if ratio is zero(even) and value of current number is greater then leastmaximul then print it;
                        {
                            Console.WriteLine("maximal[{0}] = {1}", i, maximal[i]); // to show display
                            leastmaximalvalue = maximal[i]; // to update the leastmaximul everytime, it store current minimum so it will print in even form;
                        }
                    }
                }
                else if (index > leastnum)
                {
                    break; // if index goes greater than least number then break the loop so it will not reapeat the first loop/parent loop
                }
                
            }
            */

            // part 7: enter array N and integer K. find maximum sum in array w.r.t K integer. eg{1,2,3,4,5,6} (N = 6 element) K = 2, So, first check sum of 1,2 (0,1) then 2,3(1,2) so on untill max sum is find. find sum in array by given integer in K 

            /*
            Console.Write("Enter the value of N: ");
            int n = int.Parse(Console.ReadLine()); // input: enter index of array N 
            Console.Write("Enter the value of K: ");
            int k = int.Parse(Console.ReadLine()); // input: integer of K, consecutive max sum

            int[] N = new int[n]; // initialize array of N

            if (k < n) // if k is small then take value of array N
            {

                Console.WriteLine("Enter the value of N array: ");
                for (int index = 0; index < N.Length; index++)
                {
                    N[index] = int.Parse(Console.ReadLine()); 
                }

            }

            int sum = 0, maxisum = int.MinValue; // variable to get the sum
            int startingmaxindex = 0; // index of max sum to print vaue in output
            int conditionK = k; // variable used in loop conditional part to run program smoothly
            for (int i = 0; i < conditionK; i++) // less then conditionK if K is 2 than run t 0,1
            {
                for (int j = i; j < conditionK; j++) //start j with i (j = i) so it increase its initialize value everytime
                {
                    sum = sum + N[j]; // to calculate sum
                    if (maxisum < sum) // if sum is greater than maxisum than initialize value of sum to maxisum 
                    {
                        maxisum = sum;
                        startingmaxindex = i; // initialize the index of i in startingmaxindex so the maxisum value will print
                    }
                }
                sum = 0; // sum zero after every nested loop so it will only sum a/c to conditionK number not everynumber in the array

                conditionK++; // increasement by one 
                if (conditionK > n) // if condition K is greater than n (index of array N) then Loop break. without this, loop become infinite or throw exceptional
                {
                    
                    break;
                }

            }
            Console.WriteLine("Maximum sum is {0}", maxisum); // to print max sum
            for (int i = startingmaxindex; i < k + startingmaxindex; i++) 
            {
                Console.WriteLine("At Index = {0}", N[i]);
            }
            */

            // part 8: sorting
            /*
            int[] sorting = new int[6] { 4, 5, 2, 7, 6, 1 };
            int swap;
            for (int i = 0; i < sorting.Length; i++) // execute loop till every array value is sorted 
            {
                for (int index = 0; index < sorting.Length - 1; index++)
                {

                    if (sorting[index] > sorting[index + 1])
                    {
                        // swaping
                        swap = sorting[index];
                        sorting[index] = sorting[index + 1];
                        sorting[index + 1] = swap;
                    }
                }
            }
            Console.WriteLine("result");
            for (int i = 0; i < sorting.Length; i++)
            {
                Console.WriteLine(sorting[i]);
            }
            */

            //part 9: maximum sum


            //*************************** input used in 9,10,11 *************************//
            /*Console.WriteLine("Enter the length of array: ");
            int n = int.Parse(Console.ReadLine());
            int[] N = new int[n];
            Console.WriteLine("Enter the value of array: ");
            for (int i = 0; i < N.Length; i++)
            {
                N[i] = int.Parse(Console.ReadLine());
            }
             */


            /*int sum = 0;
            int bestsum = int.MinValue;
            int startingindex = 0;
            for (int i = 0; i < N.Length; i++)
            {
                Console.WriteLine("bestsum "+bestsum);

                for (int j = i; j < N.Length; j++)
                {
                    Console.WriteLine("sum = sum + N[i] == {0} = {1} + {2}", sum, sum, N[j]);
                    sum = sum + N[j];
                    
                    if (bestsum < sum)
                    {
                        bestsum = sum;
                        
                        startingindex = i;

                    }
                }
                sum = 0;
            }
            Console.WriteLine("Startingindex = {0}",startingindex);
            Console.WriteLine("result");
            Console.WriteLine("Bestsum is " + bestsum);
            for (int i = startingindex; i < startingindex + 4; i++) // in e.g they show only 4 digits that why in condition i used to run loop 4 times
            {
                Console.WriteLine(N[i]);
            }*/

            // part 10: most frequently number
            /*
            int swap = 0;
             // sort the loop
            for (int i = 0; i < N.Length; i++)
            {
                for (int j = 0; j < N.Length - 1; j++)
                {
                    if (N[j] >= N[j + 1])
                    {
                        swap = N[j];
                        N[j] = N[j + 1];
                        N[j + 1] = swap;

                    }
                }
            }

            //Console.WriteLine("sorted array");
            //foreach (int iteam in N)
            //{
            //    Console.WriteLine(iteam);
            //}

            int sum = 0,bestsum = int.MinValue;
             // to find most frequent number
            for (int index = 0; index < N.Length - 1; index++)
            {
                if (N[index] == N[index + 1]) // if number is equal then add 1 in sum
                {
                    sum++; 
                    swap = N[index]; // to store index value of most repeated number so it can be printed in output
                    if (bestsum < sum) // if sum is greater then bestsum(which value is sum of previous greater number) than declara value to bestsum
                    {
                        bestsum = sum;
                    }

                }
                else
                {
                    sum = 0; 
                }
            }
            Console.WriteLine("The number {0} is repeated mostly {1} times", swap, bestsum + 1); // output
            */

            // part 11: of given integer, find the sum in array in row
            /*
            Console.Write("Enter the number to find sum in array: ");
            int findsum = int.Parse(Console.ReadLine());

            int sum = 0;
            int indexstart = 0;
            int indexend = 0;
            for (int i = 0; i < N.Length; i++)
            {
                for (int j = i; j < N.Length; j++)
                {
                    sum = sum + N[j];
                    
                    if (sum > findsum)
                    {
                        break;
                    }
                    else if (sum == findsum)
                    {
                        indexstart = i;
                        indexend = j;
                        break;
                    }

                }
                if (sum == findsum) { break; }
                sum = 0;
            }
            
            for (int k = indexstart; k <= indexend; k++)
            {
                Console.WriteLine("index are {0}",N[k]);
            }
             */

            // part 12: patterns

            //int[,] matrix = new int[4, 4] {                            // matrix in which pattern are formed
            //                              {1,2,3,4},
            //                              {5,6,7,8},
            //                              {9,10,11,12},
            //                              {13,14,15,16}
            //                               };

            //pattern number 1st: solved by changing row into col and col into row
            /// 1 5 9 13
            /// 2 6 10 14
            /// 3 7 11 15
            /// 4 8 12 16

            //for (int col = 0; col < 4; col++)
            //{
            //    for (int row = 0; row < 4; row++)
            //    {
            //        Console.Write(" "+matrix[row,col]);
            //    }
            //    Console.WriteLine();
            //}

            //pattern number 2: solved by swaping row 1,3 from ascending to decending and 1st format
            /// 1 8 9 16
            /// 2 7 10 15
            /// 3 6 11 14
            /// 4 5 12 13
            /*
            int swap;
            for (int i = 0; i < 4; i++) // run nested loop 4times so condition in nested loop check every value
            {
                for (int col = 0; col < 4 - 1; col++) // this loop used to check condition only 4 time
                {
                    if (matrix[1, col] < matrix[1, col + 1]) // for changing row 1, only col is changing that why we put loop variable in matrix 
                    {
                        swap = matrix[1, col + 1];
                        matrix[1, col + 1] = matrix[1, col];
                        matrix[1, col] = swap;
                    }
                    if (matrix[3, col] < matrix[3, col + 1]) // for changing row 3
                    {
                        swap = matrix[3, col + 1];
                        matrix[3, col + 1] = matrix[3, col];
                        matrix[3, col] = swap;

                    }
                }
            }

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write(" " + matrix[col, row]);  // change the position of row and col becoz in format rows print in same cols and cols in same rows(same as 1st) 
                }
                Console.WriteLine();
            }*/
            // part 3 and 4 remain pg 258

            //for (int row = 3; row >= 0 ; row--)
            //{
            //    for (int col = 3; col >= 0; col--)
            //    {
            //        Console.Write(" " + matrix[col,row]);
            //    }
            //    Console.WriteLine();
            //}

            //part 13: find max sum of 3x3 from mxn matrix

            /*
            Console.WriteLine("Find the 3x3 matrix maximum sum. so enter row and col of unknow matrix more than 3x3");
            Console.Write("Enter the row of matrix: ");
            int m = int.Parse(Console.ReadLine());    // row of unknow matrix
            Console.Write("Enter the colume of the matrix: ");
            int n = int.Parse(Console.ReadLine());  // colume of unknow matrix

            int[,] matrix = new int[m, n]; // declara the value of user given dimension in matrix variable
            Console.WriteLine("Enter the value of unknow matrix");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine()); // input the value in matrix 
                }
                
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(" " + matrix[i, j]); // display the matrix
                }
                Console.WriteLine();
            }



            int sum = 0; // to find sum of every 3x3 matrix
            int bestsum = int.MinValue; // to store maximum value of 3x3 matrix
            int bestrow = 0, bestcol = 0; // to store row and col of that maximum 3x3 matrix

            for (int unknow_row = 0; unknow_row < m - 2; unknow_row++) // this loop used for row of unknow matrix and it condition is -2 becoz in nested it run 2 step more to cover 3x3 matrix, if i remove - 2 then it thrown exceptional
            {

            // loop used for col of unknow matrix and its condition is same as above. e.g it user given 7x7 matrix and array start from '0' then matrix run untill '6'. So, it nested we have to find 3x3 matrix we run 2 step ahead that why 7 - 2 = 5 loop run of unknow matrix in 4 times, and 4 + 3 = 7 in nested in still run 7 times 
                for (int unknow_col = 0; unknow_col < n - 2; unknow_col++) 
                {
                    for (int row_3x3 = unknow_row; row_3x3 < 3 + unknow_row  ; row_3x3++) // start from unknow row(if zero than zero if 2 then 2) and condition add unknow row so it everytime when unknow row increase untill unknow reach its limit(which is 4 + 3 = 7). So,its check every possible row and colume.
                    {
                        for (int col_3x3 = unknow_col; col_3x3 < 3 + unknow_col  ; col_3x3++)// same as above condition
                        {
                            // to remove logical error
                            //Console.WriteLine("unkow_row = {0}\tunknow_col = {1}\trow3x3 = {2}\tcol3x3 = {3}\tsum = {4}", unknow_row, unknow_col, row_3x3, col_3x3, sum);
                            
                            sum = sum + matrix[row_3x3, col_3x3]; // sum of 3x3 matrix step by step
                            //Console.WriteLine("sum = " + sum); //to remove logical error
                            if (bestsum < sum) // if bestsum is small than send value of sum to bestsum
                            {
                                bestsum = sum;
                                bestrow = unknow_row; // store the maximum number given row in bestrow
                                bestcol = unknow_col; // store the maximum number given colume in bestcol

                                //Console.WriteLine("bestsum = {0}\tbestrow = {1}\tbestcol = {2}",bestsum,bestrow,bestcol); // for logical error
                            }
                        }
                       
                    }
                    sum = 0; // sum is zero after every 3x3 matrix
                    
                }
                
            }
            Console.WriteLine("Bestsum is " + bestsum); // display maximum sum
            for (int row = bestrow; row < 3 + bestrow; row++) // start from maximum row and condition run 2 step more row and colume
            {
                for (int col = bestcol; col < 3 + bestcol; col++)
                {
                    Console.Write(" " + matrix[row,col]); // display of 3x3 matrix
                }
                Console.WriteLine();
            }
            */

            //part 14: longest string in sequence in same row,col, diagonal
            /*
            string[,] stringmatrix = new string[3, 3]; // declara 3x3 string matrix
            Console.WriteLine("Enter any word or letter in string matrix: ");
            
            for (int m = 0; m < stringmatrix.GetLength(0); m++)
            {
                for (int n = 0; n < stringmatrix.GetLength(1); n++)
                {
                    Console.Write("Enter value in ({0},{1}): ", m, n); // to get string a/c toindex of array
                    stringmatrix[m, n] = Console.ReadLine();
                }
            }

            int same_row_sum = 0, same_col_sum = 0, same_diagonal_sum = 0; // sum variable for row,colume,diagonal
            int starting_index_row = 0, starting_index_col = 0; // to find starting index of same sequence in matrix
            bool roow = false, cool = false, diagonalforward = false, diagonalbackward = false; // find the sequence help in display

            for (int row = 0; row < stringmatrix.GetLength(0); row++) // loop to find same row seqence in string array
            {
                for (int j = 0; j < stringmatrix.GetLength(1) - 1; j++)
                {
                    if (stringmatrix[row, j] == stringmatrix[row, j + 1]) // row same and colume increase by 1 in same row sequence
                    {
                        same_row_sum++; // increase if array contain same string in matrix
                       
                        if (same_row_sum == 2) // in 3x3 matrix maximum sum is 2 so if same_row_sum reach it max value then convert roow in true
                        {
                            roow = true;
                            starting_index_row = row; // to find starting index of max seqeunce of string
                        }
                    }

                }
            }
            for (int col = 0; col < stringmatrix.GetLength(1); col++) // loop to find the colume of same string in the matrix
            {
                for (int i = 0; i < stringmatrix.GetLength(0) - 1; i++) // col same and row is increase by 1
                {
                    if (stringmatrix[i, col] == stringmatrix[i + 1, col]) 
                    {
                        same_col_sum++; // same as above
                        
                        if (same_col_sum == 2) // max sum is 2 
                        {
                            cool = true; // cool convert in true if after max same_col_sum
                            starting_index_col = col; // to get the index of max sum
                        }
                    }
                }

            }
            for (int i = 0; i < stringmatrix.GetLength(0); i++) // loop to find diagonal
            {
                for (int j = 0; j < stringmatrix.GetLength(1) - 1; j++)
                {
                    //Console.WriteLine("j = {0} \t i = {1}",j,i); // logical error
                    if (stringmatrix[i, j] == stringmatrix[i + 1, j + 1]) // if in diagonal string is same in the matrix than increase by 1
                    {
                        same_diagonal_sum++;
                        i++; // increase i too becoz in diagional it check in {(0,0),(1,1),(2,2)} way
                        if (same_diagonal_sum == 2) // reach it max value than make it true
                        {
                            diagonalforward = true;
                            break; // break so it will not waste time to run rest of unneccessary work
                        }
                    }
                    else if (j == 1) // j is 1 becoz in condition its '- 1' so '1' is max value. This condition used to find reserve diagonal
                    {
                        i = 0; // convert it again zero becoz if 1 and 5 value are same than it not make program unreachable
                        same_diagonal_sum = 0;// same as above reason
                        for (j = 2; j >= 0 + 1; j--) // loop in reserve becoz {(0,2),(1,1),(2,0)} colume is in decreament
                        {
                            if (stringmatrix[i, j] == stringmatrix[i + 1, j - 1]) // to check the diagonal
                            {
                                same_diagonal_sum++; // sum to find max sum
                                i++; // i is increaseing in reserve 
                                if (same_diagonal_sum == 2) // at max sum make it true
                                {
                                    diagonalbackward = true;

                                }
                            }

                        }
                        break; // break so it will not repeat the loop j and freeze in infinite
                    }
                }

                break; // to stop i loop so it will run more than 1 time
            }

            if (roow == true) // if row is true than print its value
            {
                
                for (int row = starting_index_row; row <= starting_index_row; row++) // start and end index on same max row best row is same 
                {
                    for (int i = 0; i < stringmatrix.GetLength(1); i++)
                    {
                        Console.Write(stringmatrix[row, i]+" "); // display
                    }
                    Console.WriteLine();
                }
            }
            else if (cool == true) // for col display
            {
                
                for (int col = starting_index_col; col <= starting_index_col; col++)
                {
                    for (int i = 0; i < stringmatrix.GetLength(0); i++)
                    {
                        Console.WriteLine(" " + stringmatrix[i, col]);
                    }
                }
            }
            else if (diagonalforward == true) // for forward diagonal
            {
               
                Console.WriteLine(stringmatrix[0, 0] + "\n  " + stringmatrix[1, 1] + "\n    " + stringmatrix[2, 2]);
            }
            else if (diagonalbackward == true) // for backward
            {
               
                Console.WriteLine("    "+stringmatrix[0, 2] + "\n  " + stringmatrix[1, 1] + "\n" + stringmatrix[2, 0]);
            }
            else
            {
                
                Console.WriteLine("Nothing is same kid!!!"); // if no string are same
            }
        */
            // part 15: convert latin word into letter index 
            /*
            string st = Console.ReadLine(); // too take input from user
            int integer; // variable

            char[] ch = st.ToCharArray(); // this syntax is used to convert string into char
                     
            for (int i = 0; i < st.Length ; i++)  // a/c to condtion the length of word run loop untill that time
            {               

                //integer = Convert.ToChar(ch[i]); // convert char value into int by their index, char[index] have value which user input  
                //Console.WriteLine(integer);

                integer = Convert.ToChar(st[i]); // do same as above but are optimatize mean u don't need to declara char variable
                Console.WriteLine(integer);

                //integer = st[i]; // idk how it work but it works and more optimize way
                //Console.WriteLine(integer);

                //Console.WriteLine(integer = st[i]); // same as above how it work
            } */

            // part 16:  binary search 
            int[] binary = new int[5];
          
            Console.WriteLine("Enter the value of array: ");
            for (int index = 0; index < binary.Length; index++)
            {
                binary[index] = int.Parse(Console.ReadLine());
            }
            
            int value_finder = int.Parse(Console.ReadLine());

            int mid;
            mid = binary.Length / 2;

            int[] binarymid = new int[mid];

            if (binary[mid] == value_finder)
            {
                Console.WriteLine(binary[mid]);
            }
            else if (binary[mid] < value_finder )
            {
                for (int i = mid + 1; i < binary.Length; i++)
                {
                    // incomplete;
                }
            }

            // book excerice
            //Symmetic 
            /*Console.Write("Enter any value: ");
            int n = int.Parse(Console.ReadLine());
            int[] smarray = new int[n];

            Console.WriteLine("Enter value of array ");
            for (int i = 0; i < n; i++)
            {
                smarray[i] = int.Parse(Console.ReadLine());
            }

            bool symmetric = true;
            for (int i = 0; i < n; i++)
            {
                if (smarray[i] != smarray[n - i - 1])
                {
                    symmetric = false;
                    break;
                }
            }
            Console.WriteLine("Is symmetric? {0}", symmetric);

            // Declare and initialize the matrix
            int[,] matrix = {
{ 0, 2, 4, 0, 9, 5 },
{ 7, 1, 3, 3, 2, 1 },
{ 1, 3, 9, 8, 5, 6 },
{ 4, 6, 7, 9, 1, 0 }
};

            // Find the maximal sum platform of size 2 x 2
            long bestSum = long.MinValue;
            int bestRow = 0;
            int bestCol = 0;
            //Console.WriteLine("\n matrix(0) = {0}\n matrix(1) = {1}",matrix.GetLength(0),matrix.GetLength(1));

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++) // loop run 2 value less then array length becoz if row 0 and col run 5th time it show indexoutofRange becoz in sum condition row +1 and col + 1 which doesnot exist in array
                {
                    long sum = matrix[row, col] + matrix[row, col + 1] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1];
                    //Console.Write("matrix[{0},{1}]+matrix[{2},{3}]+matrix[{4},{5}]+matrix[{6},{7}]", row, col, row, col + 1, row + 1, col, row + 1, col + 1);
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                    // Console.WriteLine();
                }
            }
            // Print the result
            Console.WriteLine("The best platform is:");
            Console.WriteLine(" {0} {1}",
            matrix[bestRow, bestCol],
            matrix[bestRow, bestCol + 1]);
            Console.WriteLine(" {0} {1}",
            matrix[bestRow + 1, bestCol],
            matrix[bestRow + 1, bestCol + 1]);
            Console.WriteLine("The maximal sum is: {0}", bestSum);
            */






        }
    }
}
