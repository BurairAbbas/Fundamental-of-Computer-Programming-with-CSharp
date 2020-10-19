using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap8Numerical
{
    class Program
    {
        static void decimal_into_Binary(int deci)
        {
            int sum = 0; // to get the accute number of binary bits of given argument
            int[] binary = new int[100]; // declare array
            for (int i = 0; deci > 0; i++) // loop to get the value of binary bit by bit. loop ends when deci goes to negative
            {
                binary[i] = deci % 2; // get the modulus value in binary bits
                deci = deci / 2; // divide for LCM
                sum++; // number of bits in the array
                // Console.WriteLine("deci = {0}     binary = {1}",deci,binary[i]); // logical error display 

            }
            Console.Write("Binary = ");
            for (int i = sum - 1; i >= 0; i--)
            {
                Console.Write(i % 4 == 0 ? binary[i] + " " : binary[i] + "");
            }
            Console.WriteLine();
        }

        static void hexa_into_decimal_and_binary(string hexa)
        {
            int deci = Convert.ToInt32(hexa, 16);
            Console.WriteLine("Decimal = " + deci);
            decimal_into_Binary(deci);

        }

        static void binary_into_decimal(ulong binary)
        {
            string str = binary.ToString();
            uint[] binaryarray = new uint[str.Length];
            for (int i = 0; i < binaryarray.Length; i++)
            {
                binaryarray[i] = (uint)binary % 2;
                binary = binary / 10;
            }
            uint deci = 0;
            //for (int i = 0; i < binaryarray.Length; i++)
            //{
            //    Console.Write(binaryarray[i]); // for logic
            //}
            for (int i = 0; i < binaryarray.Length; i++)
            {
                // to get the decimal value of its formula e.g: 1101 so 1*2^3 + 1*2^2 + 0 + 1*2^0
                deci = ((uint)Math.Pow(2, i) * binaryarray[i]) + deci;
            }

            Console.WriteLine("Decimal = " + deci); // display
        }

        static void decimal_into_hexa(int deci)
        {
            string[] hexaarray = new string[10]; // to store value of hexa
            int count = 0; // to count how many value are declare in array
            int deci_into_str = 0; // to get the modulus result

            for (int i = 0; deci > 0; i++) // loop run untill deci is less then 1
            {
                deci_into_str = deci % 16; // to get the remainder after divid it with 16
                deci = deci / 16; // get the value after taking mudulus of value
                count++; // count the loop
                hexaarray[i] = deci_into_str.ToString(); // convert value of remainder into string and declara it in array of hexa
                // conditions to convert 10...15 into A...F
                if (hexaarray[i] == "10")
                {
                    hexaarray[i] = "A";
                }
                else if (hexaarray[i] == "11")
                {
                    hexaarray[i] = "B";
                }
                else if (hexaarray[i] == "12")
                {
                    hexaarray[i] = "C";
                }
                else if (hexaarray[i] == "13")
                {
                    hexaarray[i] = "D";
                }
                else if (hexaarray[i] == "14")
                {
                    hexaarray[i] = "E";
                }
                else if (hexaarray[i] == "15")
                {
                    hexaarray[i] = "F";
                }
            }

            Console.Write("Hexadecimal = "); // display
            for (int i = count - 1; i >= 0; i--) // loop start from index where last number is located
            {
                Console.Write(hexaarray[i]);
            }
            Console.WriteLine();

        }

        static void hexa_into_decimal(string hexa)
        {
            //int deci = Convert.ToInt32(hexa, 16);

            char[] splithexa = hexa.ToCharArray(); // to split the string hexa value in Char so it become easy to convert in decimal
            Array.Reverse(splithexa); // to reverse the array becoz i.e A1 is split as splithexa[0] = A and [1] = 1 and we need [0] = 1 and [1] = A (it takes approx 50 mints to get this)

            //for (int i = 0; i < hexa.Length; i++)
            //{
            //    Console.WriteLine("split[{0}] = "+splithexa[i],i); // to check the values in splithexa 
            //}

            int[] deci = new int[hexa.Length]; // initialize for decimalvalues

            for (int i = 0; i < hexa.Length; i++) // conversion from alphabate to decimal 
            {
                if (splithexa[i] == 'A')
                {
                    deci[i] = 10;
                }
                else if (splithexa[i] == 'B')
                {
                    deci[i] = 11;
                }
                else if (splithexa[i] == 'C')
                {
                    deci[i] = 12;
                }
                else if (splithexa[i] == 'D')
                {
                    deci[i] = 13;
                }
                else if (splithexa[i] == 'E')
                {
                    deci[i] = 14;
                }
                else if (splithexa[i] == 'F')
                {
                    deci[i] = 15;
                }
                else
                {
                    deci[i] = int.Parse(splithexa[i].ToString()); /// to convert char value into same int value not in ASCEIIcode of char 
                    /// so first change char into string than change string into int like we do simply
                    /// without this i.e A1 1 is saved as 49(ASCEII) code of 1 in deci which was creating logical error
                }

            }
            int sum = 0;

            for (int i = 0; i < hexa.Length; i++)
            {
                sum += deci[i] * (int)Math.Pow(16, i); // simple implementation of formula
            }
            Console.WriteLine("decimal = " + sum);

        }

        //part 8:
        static void hexa_into_binary(string hexaB)
        {
            char[] splithexa = hexaB.ToCharArray();

            int[] binary = new int[hexaB.Length];

            for (int i = 0; i < hexaB.Length; i++)
            {
                if (splithexa[i] == 'A')
                {
                    binary[i] = 10;
                }
                else if (splithexa[i] == 'B')
                {
                    binary[i] = 11;
                }
                else if (splithexa[i] == 'C')
                {
                    binary[i] = 12;
                }
                else if (splithexa[i] == 'D')
                {
                    binary[i] = 13;
                }
                else if (splithexa[i] == 'E')
                {
                    binary[i] = 14;
                }
                else if (splithexa[i] == 'F')
                {
                    binary[i] = 15;
                }
                else
                {
                    binary[i] = int.Parse(splithexa[i].ToString());
                }
            }

            int[,] binary2 = new int[hexaB.Length, 4];

            for (int i = 0; i < hexaB.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    binary2[i, j] = binary[i] % 2;
                    binary[i] /= 2;
                }

            }
            for (int i = 0; i < hexaB.Length; i++)
            {
                for (int j = 4 - 1; j >= 0; j--)
                {
                    Console.Write(binary2[i, j]);
                }

            }


        }



        static void Main(string[] args)
        {
            //int y = Convert.ToInt32("0x000A", 16); // 0x (syntax) value , base
            //Console.WriteLine(y);
            //y = Convert.ToInt32("1001", 2); // value , base
            //Console.WriteLine(y);

            //float i = 1234567.123F;

            //Console.WriteLine(i);

            //checked // throw Exceptional instead of showing wrong value. remove checked and see result to understand it.
            //{
            //    int a = int.MaxValue;
            //    a = a + 1;
            //    Console.WriteLine(a);
            //}

            // Floating-point error

            //double sum = 0.0;
            //for (int i = 1; i <= 10; i++)
            //{
            //    sum += 0.1;
            //}

            //Console.WriteLine("{0:r}",sum); // round-trip format specifier 
            // output: 0.9999994 // in financial calculation this can is wrong and consisted to be error
            //Console.WriteLine(sum); // output 1

            // practice Numerical systems

            // part 1: Conversion
            //Numerical_Conversion(151);
            //Numerical_Conversion(35);
            //Numerical_Conversion(43);
            //Numerical_Conversion(251);
            //Numerical_Conversion(1024);
            //Numerical_Conversion(1023);

            // part 2: convert in hexa and decimal number system
            //int deci;
            //deci = Convert.ToInt32("1111010110011110", 2); // convert binary into decimal by int32 
            //Console.WriteLine(deci);

            //string strbinary = "1111010110011110"; // declara in string (from stackflow)
            //string strHex = Convert.ToInt32(strbinary, 2).ToString("X"); // convert in into hexa by 'X'(format used for hexa)
            //Console.WriteLine(strHex);  // display

            //part 3: hexa into binanry and decimal
            //hexa_into_decimal_and_binary("FA");
            //hexa_into_decimal_and_binary("2A3E");
            //hexa_into_decimal_and_binary("FFFF");
            //hexa_into_decimal_and_binary("5A0E9");

            //part 4: decimal into binary user input number
            //Console.Write("Enter any decimal number to convert it into Binary number system: ");
            //int deci = int.Parse(Console.ReadLine());
            //Binary_Conversion(deci);

            //part 5: binary into decimal
            //Console.Write("Enter any binary number: ");
            //ulong binary = ulong.Parse(Console.ReadLine()); // binary as last as 20 digits that why declara in long
            //binary_into_decimal(binary);

            //part 6: decimal into hexa 

            //string str = deci.ToString("X"); // this way but its cheating 
            //Console.WriteLine(str);

            //Console.Write("Enter nmber to convert decimal into hexa: ");
            //int deci = int.Parse(Console.ReadLine()); // input
            //decimal_into_hexa(deci); // passing argument in parameter

            //part 7: hexa into decimal 

            //int hexa = Convert.ToInt32("0x00FA", 16);
            //Console.WriteLine(hexa);

            //Console.Write("Hexadecimal into decimal: ");
            //string hexa = Console.ReadLine();
            //hexa_into_decimal(hexa);

            // part 8: hexa into binary
            //Console.WriteLine("hexa into binary");
            //string hexaB = Console.ReadLine();
            //hexa_into_binary(hexaB);

            //part 14: adding number

            //float sum = 0;
            //float result = 0.000001F * 50000000;
            //Console.WriteLine(result);
            //for (int i = 1; i <= 50000000 ; i++)
            //{
            //    sum =0.000001F + 0.000001F;
            //}
            //Console.WriteLine("sum = " + sum);
            //double dsum = 0;
            //for (int i = 0; i <= 50000000; i++)
            //{
            //    dsum = 0.000001 + 0.000001;
            //}
            //Console.WriteLine(dsum);
            //decimal ddsum = 0;
            //for (int i = 0; i <= 50000000; i++)
            //{
            //   ddsum = (decimal)0.000001 + (decimal)0.000001;
            //}
            //Console.WriteLine(ddsum);

            //part 13:user given base conversion
            Console.Write("Enter number for conversion: ");
            string str = Console.ReadLine();
            int num = int.Parse(str);
            int S, D;
            Console.Write("Enter the base number of your value: ");
            S = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the base number u want to convert: ");
            D = Convert.ToInt32(Console.ReadLine());

            if (S == 16 && D == 2)
            {
                hexa_into_binary(str);
            }
            else if (S == 16 && D == 10)
            {

                hexa_into_decimal(str);
            }
            else if (S == 10 && D == 2)
            {

                decimal_into_Binary(num);
            }
            else if (S == 10 && D == 16)
            {
                decimal_into_hexa(num);
            }
            else if (S == 2 && D == 10)
            {
                binary_into_decimal((ulong)num);
            }
            else { Console.WriteLine("wrong base"); }


        }
    }
}
