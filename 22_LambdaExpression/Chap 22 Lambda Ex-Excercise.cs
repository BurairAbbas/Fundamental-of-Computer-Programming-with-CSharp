using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Chap22LambaExpression
{
    class Excercise
    {
        public static void MainEx()
        {
            //// Part 1: Extension of StringBuilder SubString  which work like string substring
            // StringBuilder str = new StringBuilder();
            // str.Append("Hello");
            // str.Append("World");
            // StringBuilder str1 = str.SubString(0, 5);
            // Console.WriteLine(str1);

            // //Part 2: IEnumerable Extension of Sum, Max, Min, Avg
            // List<int> numbers = new List<int> { 11, 2, 4, 10, 5, 6, 1 };
            // int sum = numbers.Sum();
            // int min = numbers.Min();
            // int max = numbers.Max();
            // double avg = numbers.Average();
            // Console.WriteLine("Sum: {0} \tMinimun value: {1} \tMaximum Value: {2} \t Average: {3: 0.00}", sum, min, max, avg);

            List<Student> students = new List<Student>()
            {
                new Student { FirstName = "John", LastName = "Barbosa", Age = 20},
                new Student { FirstName = "Neil", LastName = "Rehna", Age = 20 },
                new Student { FirstName = "Soha", LastName = "Arif", Age = 20 },
                new Student { FirstName = "Ali", LastName = "Ahmed", Age = 19 },
                new Student { FirstName = "Ron", LastName = "Uzham", Age = 17 },
                new Student { FirstName = "Harry", LastName = "Alam", Age = 24},
                new Student { FirstName = "Arian", LastName = "Alba", Age = 25 }
            };

            //var studentNameList = from student in students
            //                      group student by student.LastName.CompareTo(student.FirstName) into groups
            //                      select new { Key = groups.Key, Names = groups };

            //foreach (var item in studentNameList)
            //{
            //    if (item.Key == -1)
            //    {
            //        foreach (var item2 in item.Names)
            //        {
            //            Console.WriteLine(item2);
            //        }
            //    }
            //}

            //One solution Two differenct approach

            //var studentNameList = from student in students
            //                      where student.LastName.CompareTo(student.FirstName) == -1
            //                      select student;
            //foreach (var item in studentNameList)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //// part 4: age difference between 18 to 24
            //var studentWithAge = from student in students
            //                     where (student.Age >= 18 && student.Age <= 24)
            //                     select student;
            //foreach (var item in studentWithAge)
            //{
            //    Console.WriteLine(item);
            //}

            //part 5: OrderBy and ThenBy in descending Order
            //var descendingByFirstName = students.OrderBy();
            //foreach (var item in descendingByFirstName)
            //{
            //    Console.WriteLine(item);
            //}

            //var descendingByLastName = students.ThenBy();
            //foreach (var item in descendingByLastName)
            //{
            //    Console.WriteLine(item);
            //}

            //// Part 6: use built-in method to find number multiple by 3 and 7
            //List<int> numbers = new List<int> { 10, 5, 2, 6, 88, 49, 9, 111, 35, 3, 7, 13, 21 };
            ////List<int> numberDivisibleBy3and7 = numbers.FindAll(x => (x % 3 == 0) && ( x % 7 == 0 ));

            //var numberDivisibleBy3And7 = from number in numbers
            //                                   where number % 3 == 0 && number % 7 == 0
            //                                   select number;

            //foreach (var item in numberDivisibleBy3And7)
            //{
            //    Console.WriteLine(item);
            //}

            string sentence = "this iS a Sample sentence.";
            string standardSentence = sentence.FirstLetterCapital();
            Console.WriteLine(standardSentence);

            PhoneBookDifferenceBetweenHashTableAndCollectionOfData();

        }

        public static void PhoneBookDifferenceBetweenHashTableAndCollectionOfData()
        {
            Dictionary<string, int> phoneBook = new Dictionary<string, int>();
            string[] firstName = { 
                "John", "Babosa", "Nail", "Arif", "Ron", "Rehman", "Ali", "Haider", "Kate", "Wilson", "Steve", "Milton", "John", "Peterson",
                            "Curie", "Albert", "Tesla", "Bill", "Sam", "Iqbal", "Nazish", "Raza", "Rapshon", "Watson", "Dinael", "Brien",
                            "Diease", "Washington", "Jocab", "Philip", "Max", "Bohr", "Newton", "Isaac", "Stovic", "Linton"};
            string[] lastName = {
               "John", "Babrosa", "Nail", "Arif", "Ron", "Rehman", "Ali", "Haider", "Kate", "Wilson", "Steve", "Milton", "John", "Peterson",
                            "Curie", "Albert", "Tesla", "Bill", "Sam", "Iqbal", "Nazish", "Raza", "Rapshon", "Watson", "Dinael", "Brien",
                            "Diease", "Washington", "Jocab", "Philip", "Max", "Bohr", "Newton", "Isaac", "Stovic", "Linton"};

            int[] randomNumberArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 11, 10, 12, 45, 56, 76, 90, 43, 56, 72, 90 };
            
            Random rnd = new Random();
            for (int i = 0; i < 50000; i++)
            {
                List<int> numbers = new List<int>();
                string number = randomNumberArray[rnd.Next(0, 19)].ToString() + rnd.Next(10, 20).ToString() + rnd.Next(30, 40).ToString() +
                    rnd.Next(40, 50).ToString();
                string name = firstName[rnd.Next(0, firstName.Length)] + " " + lastName[rnd.Next(0, lastName.Length)];
                if(!phoneBook.ContainsKey(name)) // to avoid collision
                     phoneBook.Add(name, Convert.ToInt32(number));

            }

            DateTime startTime = DateTime.Now;
            for (int i = 0; i < 50000; i++)
            {
                bool found = phoneBook.ContainsKey("Max Isaac");
            }

            Console.WriteLine("Contain method of table execute time: {0} ", DateTime.Now - startTime);
            // outPut: 00.00.00

            startTime = DateTime.Now;
            for (int i = 0; i < 50000; i++)
            {
                phoneBook.Where(x => x.Key.Equals("Max Isaac"));
            }
            Console.WriteLine("Where method Execute time: {0}", DateTime.Now - startTime);
            // output: 00.018
        }


    }
    //Part 1:
    public static class StringBuilderExtension
    {
        public static StringBuilder SubString(this StringBuilder str, int index, int length)
        {
            StringBuilder subString = new StringBuilder();
            for (int i = index; i < length; i++)
            {
                subString.Append(str[i]);
            }
            return subString;
        }
    }

    //Part 2:
    public static class IEnumerableExtension
    {
        public static int Sum(this IEnumerable<int> element)
        {
            int sum = 0;
            foreach (var item in element)
            {
                sum += item;
            }
            return sum;
        }

        public static int Min(this IEnumerable<int> element)
        {
            int min = int.MaxValue;
            foreach (var item in element)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        public static int Max(this IEnumerable<int> element)
        {
            int max = 0;
            foreach (var item in element)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

        public static double Average(this IEnumerable<int> element)
        {
            double sum = 0;
            foreach (var item in element)
            {
                sum += item;
            }
            double avg = sum / element.Count();
            return avg;
        }
    }

    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;

        public Student()
        {
            firstName = null;
            lastName = null;
            age = 0;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public override string ToString()
        {
            return string.Format("FirstName: {0} LastName: {1} Age: {2} ", FirstName, LastName, Age);
        }
    }

    //part 5: OrderBy and ThenBy in descending Order
    public static class IListExtension
    {
        public static dynamic OrderBy(this List<Student> elements)
        {
            var sortedByFirstName = elements.OrderByDescending(x => x.FirstName);

            //var sortedByFirstName = from element in elements
            //                        orderby element.FirstName descending
            //                        select element;

            return sortedByFirstName;
        }

        public static dynamic ThenBy(this List<Student> elements)
        {
            //var sortedByLastName = element.OrderByDescending(x => x.LastName);

            var sortedByLastName = from element in elements
                                   orderby element.LastName descending
                                   select element;

            return sortedByLastName;
        }
    }

    public static class StringExtension
    {
        public static string FirstLetterCapital(this string str)
        {
            StringBuilder capital = new StringBuilder();
            string[] splitString = str.Split(' ');
            for (int i = 0; i < splitString.Length; i++)
            {
                //StackOverFlow
                string restOfLetter = "";
                if (splitString[i].Length > 1)
                {
                    restOfLetter = splitString[i].Substring(1).ToLower();
                }
                char firstChar = char.ToUpper(splitString[i][0]);
                splitString[i] = firstChar + splitString[i].Substring(1).ToLower() + " ";
                capital.Append(splitString[i]);
            }

            // Book solution
            string capital2 = new CultureInfo("en-US", false).TextInfo.ToTitleCase(str);

            return capital.ToString();
        }

    }


}
