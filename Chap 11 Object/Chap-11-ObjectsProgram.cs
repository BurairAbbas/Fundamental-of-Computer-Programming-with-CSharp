using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap11objectEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int starttime = Environment.TickCount;

            Excercise ex = new Excercise();
            ex.MainMethodOfEx();

            int endtime = Environment.TickCount;
            int time = endtime - starttime;
            time /= 1000;
            Console.WriteLine("Sec = " + time);
            //time /= 60;
            //Console.WriteLine("minute = " + time );
            //time /= 60;
            //Console.WriteLine("Hour = " + time);
            //time /= 24;
            //Console.WriteLine("Day = " + time);
            
             }
    }
}
