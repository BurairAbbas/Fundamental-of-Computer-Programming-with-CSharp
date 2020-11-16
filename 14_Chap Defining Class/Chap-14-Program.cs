using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap14DefiningClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //Practical p = new Practical();
            //p.P_Method();

            Exercise e = new Exercise();
            e.Main();

            // just using static modifier
            //M2();
            //Sta s = new Sta();
            //s.Master();
            
            
        }
        
        static void M2(int x)
        {
             
            Console.WriteLine();
        }

    }
    class Sta
    {
        public void Master()
        {
            M3();
        }
        static void M3()
        {
            Console.WriteLine("HI");
        }
    }
}
