using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Chap12ExceptionalEx
{
    class Excerise
    {
        public void MainEx()
        {
            // SquareRoot();

            // ReadNumber(1, 100);

            //string createText = "Hello and Welcome World" + Environment.NewLine;

            ///// Compile consider '\' as a escape charactor and by using '@' tell the compiler to ignore the escape sequence, or by '\\'  
            //System.IO.File.WriteAllText(@"C:\Users\Documents\Visual Studio 2012\Projects\aFundamental of CSharpe\Chap12ExceptionalEx\MyTextFile.txt", createText);

            //string readText = File.ReadAllText(@"C:\Users\Documents\Visual Studio 2012\Projects\aFundamental of CSharpe\Chap12ExceptionalEx\MyTextFile.txt");

            //string fileName = @"C:\Users\Documents\Visual Studio 2012\Projects\aFundamental of CSharpe\Chap12ExceptionalEx\MyTextFile.txt";
            //Console.WriteLine(ReadText(fileName));
            
            PractBinaryStm();

        }

        protected void PractBinaryStm()
        {
            string path = @"C:\Users\Documents\Visual Studio 2012\Projects\aFundamental of CSharpe\Chap12ExceptionalEx\Binarytext.txt";
            Stream writestream = new FileStream(path, FileMode.Create);

            byte[] bytes = new byte[] { 72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100 };
            if (writestream.CanWrite)
            {
                writestream.Write(bytes, 0, bytes.Length);
                writestream.WriteByte(33);
            }
            writestream.Close();
            Console.ReadLine();
            Console.WriteLine("a");
        }

        //Part 7: Take +ve integer and if wrong Print Invalid and Goodbye in All cases
        protected void SquareRoot()
        {
            Console.WriteLine("Enter any positive integer: ");
            double userinput = 0, sqroot;

            try
            {
                userinput = double.Parse(Console.ReadLine());
                if (userinput < 0)
                {
                    Console.WriteLine("Invalid Number");
                }
                else
                {
                    sqroot = Math.Sqrt(userinput);
                    Console.WriteLine(sqroot);
                }
            }
            catch
            {
                Console.WriteLine("Something Wrong");
            }
            finally
            {
                Console.WriteLine("GoodBye");
            }
        }

        //Part 8 method take integer in the range and throw exceptional if invalid or out of range!
        protected void ReadNumber(int start, int end)
        {
            Console.WriteLine("Enter any number: ");

            int userinput = 0, count = 0;

            do
            {
                count++;
                try
                {
                    userinput = int.Parse(Console.ReadLine());
                    if (userinput <= start || userinput >= end)
                    {
                        Console.WriteLine("Invalid Number");
                    }
                    else
                    {
                        start = userinput;
                        Console.WriteLine(userinput + " in range");
                    }
                }
                catch (SystemException)
                {
                    Console.WriteLine("Please Enter Integer!! ");
                }
            } while (start < userinput || count <= 10);
        }
        protected string ReadText(string fileName)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(fileName);
                string line = reader.ReadLine();
                return line;
            }
            catch (FormatException)
            {
                return "Format of file not Supportive";
            }
            catch (NotSupportedException)
            {
                return "format of file ";
            }
            catch (IOException)
            {
                return "Wrong path of File,Please recheck the file path ";
            }
        }
    }
}
