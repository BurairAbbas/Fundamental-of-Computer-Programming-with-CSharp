using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap11objectEx
{
    class Excercise
    {
        // initialize the variable
        private int leapyear;
        // using property of variable
        public int LeapYear
        {
            get
            {
                if (leapyear % 400 == 0)
                {
                    // if completely divide by 400 then its leapyear
                    return 1;
                }
                else
                {
                    if (leapyear % 4 == 0 && leapyear % 100 == 0)
                    {
                        // it divide by both 4 and 100 then leapyear
                        return 1;
                    }
                    else
                    {
                        // false if any one condition is false 
                        return 0;
                    }
                }
            }
            set
            {
                // taking value in varaible
                this.leapyear = value;
            }
        }

        public void RrandomNumber()
        {
            // initialize the variable to create Random number
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                // static range in Next method of rnd variable for limit of rnd number
                Console.WriteLine(rnd.Next(100, 200));
            }
        }

        public void Workdays()
        {
            // for current date
            DateTime drt = DateTime.Today;
            // userinput date
            Console.Write("Enter the last date in format MM/DD/YYYY");
            int usermonth = int.Parse(Console.ReadLine());

            //DateTime usrinput = DateTime.Parse(usermonth.ToString()); // converting int into Datetime
            // getting month to find the working days
            int month = usermonth - drt.Month;
            // if usermonth value is smaller than current months mean if user given next year month
            if (month < 0)
            {
                // add in 12 to get the difference
                month += 12;
            }
            // multiply to get the days
            month *= 30;
            int workingday = 0;
            int holidays = 0;
            int count = 0;
            for (int i = 1; i < month + 1; i++)
            {
                count++; // count start from 1
                if (count <= 5)
                {
                    // if count is less then 5 add one in working days
                    workingday++;
                }
                else
                {
                    holidays++;
                }
                // if count is equal too 7 (which is one week then count is reset)
                if (count == 7) { count = 0; }
            }
            // display output
            Console.WriteLine("There are {0} working days and {1} holidays", workingday, holidays);
        }
        public void StringSeparate(string strnumber)
        {
            // initalize string array and use method of Split in string variable, Split when there is ' '(space) in the string and get the value in string array
            string[] ss = strnumber.Split(' ');
            int sum = 0;
            for (int i = 0; i < ss.Length; i++) // length of loop is less then variable in the array
            {
                // convert array into int and add in sum
                sum += int.Parse(ss[i]);
            }
            // display output            
            Console.WriteLine("Sum of string is = " + sum);
        }
        // declara every area of task in array... first i declara it with const but const is not allowed with array so i removed it
        private string[] Phase = { "The product is excellent.", "This is a great product.", "I use this product constantly.", "This is the best product in this category." };
        private string[] Story = { "Now i feel better.", "I manage to change.", "It made some miracle.", "I can't believe this but, Now i feel great.", "You should try it, too. I am very satisfied" };
        private string[] Name = { "Dayan", "Burair", "Kate", "Stella" };
        private string[] LastName = { "Abbas", "Peterson", "Charls" };
        private string[] Cities = { "London", "Paris", "New York", "Madrid", "Berlin" };
        // rnd variable
        Random rnd = new Random();

        public void AdvertisementMessage()
        {
            // initialize string to hold the sentence in the array
            // declara Next method of rnd variable to get the Random index value of array in the variable; 
            string phase = Phase[rnd.Next(0, 4)];
            string story = Story[rnd.Next(0, 5)];
            string name = Name[rnd.Next(0, 4)];
            string lastname = LastName[rnd.Next(0, 3)];
            string city = Cities[rnd.Next(0, 5)];
            // display a/c to book
            Console.WriteLine("{0} {1} -- {2} {3},{4}", phase, story, name, lastname, city);
        }

        public void NumericalExpression(string numericalexpression)
        {
            // part 12: incomplete

            string[] separator = numericalexpression.Split(' ');
            int sum = 0;
            foreach (var item in separator)
            {
                Console.Write(item + " ");
            }

            for (int i = 0; i < separator.Length - 1; i++)
            {
                if (separator[i] == "*")
                {
                    sum = ParsingArrayIntoInt(separator[i - 1]) * ParsingArrayIntoInt(separator[i + 1]);
                    separator[i].Remove(i);
                }
            }

            foreach (var item in separator)
            {
                Console.Write(item + " ");
            }

            for (int i = 0; i < 10; i++)
            {
                
            }


        }
        protected int ParsingArrayIntoInt(string array)
        {
            return Convert.ToInt32(array);
        }

        public void MainMethodOfEx()
        {
            //Console.Write("Enter any year to get leapyear: ");
            //int a = int.Parse(Console.ReadLine());
            //LeapYear = a;
            //Console.WriteLine(LeapYear);

            //RrandomNumber();

            ////part 3: print today day
            //// get today date
            //DateTime dt = DateTime.Today;
            //// print day a/c to todays date
            //Console.WriteLine(dt.DayOfWeek);

            ////part 6
            //// nested namespaces 
            //  MynameSpace.calledNameSpace calledclassesofclasses = new MynameSpace.calledNameSpace();
            //CreatingAndUsingObject.Cat[] cat = new CreatingAndUsingObject.Cat[10];
            //CreatingAndUsingObject.Cat catobject = new CreatingAndUsingObject.Cat();

            //for (int i = 0; i < 10; i++)
            //{
            //    catobject = new CreatingAndUsingObject.Cat();
            //    cat[i] = catobject;
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("cat said");
            //    cat[i].SayMiau();
            //}

            //Workdays();

            // StringSeparate("43 68 9 23 318");
            AdvertisementMessage();

            // part 12: incomplete
           // NumericalExpression("-1 + 2 + 3 * 4 - 0.5");
        }
    }
}
// create namespace 
namespace CreatingAndUsingObject
{
    // create class 
    class Cat
    {
        public void SayMiau()
        {
            Console.WriteLine("Miauuu");
        }
    }
    class Seqence
    {
        public int a = 0;
        public int Nextvalue()
        {

            return a++;
        }
    }
}

namespace MynameSpace
{
    class calledNameSpace
    {
        // -called CreatingAndUsingObject namespace, called its class my '.'(dot) operator asign variable a/c to class
        //  CreatingAndUsingObject.Cat cat = new CreatingAndUsingObject.Cat(1);
        
        // calling namespace and its class it another namespace
        CreatingAndUsingObject.Seqence seq = new CreatingAndUsingObject.Seqence();
        public void aa()
        {
            seq.Nextvalue();
            Console.WriteLine(seq.Nextvalue());
        }

    }

}
