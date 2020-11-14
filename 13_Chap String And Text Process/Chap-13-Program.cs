using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap13StringAndTextProcessEx
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcerciseString exString = new ExcerciseString();
            exString.MainEx();
            long memory = GC.GetTotalMemory(true);
           // Console.WriteLine(memory);
        }
    }
}
