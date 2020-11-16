using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    class Excercise
    {
        public static void MainEx()
        {
            //part 1: School
            //Course math = new Course("Math", 20, 20);
            //Course science = new Course("Science", 20, 20);
            //Course physics = new Course("Physics", 20, 20);
            //Course cs = new Course("Computer Science", 20, 20);
            //Teacher sirShakeel = new Teacher("Sir Shakeel", cs);
            //Teacher missSara = new Teacher("Miss Sara", physics);
            //Teacher missAmber = new Teacher("Miss Amber", science);
            //Teacher sirtashfeen = new Teacher("Sir Tashfeen", math);

            //Classes secondyear = new Classes();
            //secondyear.AddTeacher(sirShakeel);
            //secondyear.AddTeacher(missAmber);
            //secondyear.AddStudent(new Student("Dilawar", 1));
            //secondyear.AddStudent(new Student("Sohaib", 2));
            //secondyear.AddStudent(new Student("Shahzil", 3));
            //secondyear.AddStudent(new Student("Burair", 4));

            //Display.DisplayClass(secondyear);

            //part 2: human inherit student and worker
            
            //P2Student s = new P2Student("John", "Watson");
            //P2Worker w = new P2Worker("Dale", "Carnegie");
            //Console.WriteLine(w);
            //Console.WriteLine("Hourly Wage: " + w.CalculateHourlyWage(30, 12));
            //Console.WriteLine(s);

            //part3: ascending order by marks of 10 value array of student
           
            //string[] names = { "john", "siri", "shan", "dale", "ahri", "usmon", "harry", "arial", "rehim", "loki" };
            //string[] lastname = { "Anton", "Arif", "Reanold", "Ana", "Sam", "Rajput", "lulugio", "Diil", "Khan", "Sir" };
            //int[] marks = { 10, 20, 40, 40, 30, 8, 25, 38, 29, 30 };
            //Random rn = new Random();
            //List<P2Student> students = new List<P2Student>();
            //P2Student[] s = new P2Student[10];
            //for (int i = 0; i < 10; i++)
            //{
            //    s[i] = new P2Student(names[rn.Next(0, 9)], lastname[rn.Next(0, 9)], marks[rn.Next(0, 9)]);
            //    students.Add(new P2Student(names[rn.Next(0, 9)], lastname[rn.Next(0, 9)], marks[rn.Next(0, 9)]));
            //}
            //students.Sort();

            //// sort in array
            //Array.Sort(s);

            //foreach (var item in s)
            //{
            //    Console.WriteLine(item);
            //}

            //part 4: Decesding order in Worker class
           
            //P2Worker[] worker = new P2Worker[10];

            //for (int i = 0; i < worker.Length; i++)
            //{
            //    worker[i] = new P2Worker(names[rn.Next(0,9)], lastname[rn.Next(0,9)]);
            //    // marks is used as wage and hours
            //    worker[i].CalculateHourlyWage(marks[rn.Next(0, 9)], 12);
            //}
            //Array.Sort(worker);

            //foreach (var item in worker)
            //{
            //    Console.WriteLine(item);
            //}

            //pat 5: create array of each shapes and calculate the surface in each other
            //Shapes[] traingle = new Shapes[3];

            //traingle[0] = new Circle(10);
            //traingle[1] = new Traingle(5, 10);
            //traingle[2] = new Rectangle(4, 6);                        

            //for (int i = 0; i < 3; i++)
            //{
            //    traingle[i].CalculateSurface();
            //}            

            //foreach (var item in traingle)
            //{
            //    Console.WriteLine(item);
            //}

            //part 6 and part 7 array of different animal and class diagram respectively
           
            //AnimalEx[] animals = {
            //                       new DogEx("Spark", 3, true),
            //                       new CatEx("LiLy", 2, false),
            //                       new KittenEx("Orik", 1, false),
            //                       new FrogEx("Lu", 3, true),
            //                       new TomcatEx("Tom", 4, true)
            //                   };

            //foreach (var item in animals)
            //{
            //    Console.Write(item + " Make Sound:" + item.MakeSound());

            //    Console.WriteLine();
            //}

            Individual i = new Individual();
            i.FirstName = "Tom";
            i.LastName = "Jerry";
            i.Deposit.DepositAmount(10000);
            i.Deposit.WithdrawAmount(5000);
            double interestRate = i.Deposit.InterestRate(10);
            i.Deposit.CurrentBalance();
            Console.WriteLine("Interest Rate: " + interestRate);

            i.Loan.DepositAmount(2000);
            interestRate = i.Loan.InterestRate(12);
            i.Loan.CurrentBalance();
            Console.WriteLine("Interest Rate: " + interestRate);

            i.Mortage.DepositAmount(10000);
            interestRate = i.Mortage.InterestRate(6);
            i.Mortage.CurrentBalance();
            Console.WriteLine("Interest Rate: " + interestRate);

            Company c1 = new Company();
            c1.FirstName = "Tommy";
            c1.LastName = "Heaven";
            c1.Deposit.DepositAmount(10000);
            c1.Deposit.WithdrawAmount(5000);
            interestRate = c1.Deposit.InterestRate(10);
            c1.Deposit.CurrentBalance();
            Console.WriteLine("Interest Rate: " + interestRate);

            c1.Loan.DepositAmount(2000);
            interestRate = c1.Loan.InterestRate(12);
            c1.Loan.CurrentBalance();
            Console.WriteLine("Interest Rate: " + interestRate);

            c1.Mortage.DepositAmount(10000);
            interestRate = c1.Mortage.InterestRate(6);
            c1.Mortage.CurrentBalance();
            Console.WriteLine("Interest Rate: " + interestRate);        
        }
    }
}
