using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Chap22LambaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //Excercise.MainEx();


            //// Extension Method Example
            //string helloString = "Hello, Extension Method";
            //int wordCount = helloString.WordCount();
            //Console.WriteLine(wordCount);

            //List<int> number = new List<int> { 1 };
            //Console.WriteLine(number.ToString<int>());
            //number.IncreaseWith(5);
            //Console.WriteLine(number.ToString<int>());

            //// Anonymous type 
            //// Compiler guess the types of properties by it own
            //var myCar = new { Color = "Red", Brand = "BMW", Speed = 180 };
            //Console.WriteLine("My {0} Color is {1}", myCar.Brand, myCar.Color);
            //Console.WriteLine("It run with speed of {0}km/h", myCar.Speed);

            //// Compiler also generate the redefine method
            //Console.WriteLine(myCar.ToString());
            //Console.WriteLine("The hash code is: {0}", myCar.GetHashCode().ToString());
            //Console.WriteLine("Equals? {0}", myCar.Equals(new { Color = "Red", Brand = "BMW", Speed = 180 }));
            //Console.WriteLine("Speed is Equal? {0} ", myCar.Speed.Equals(180));
            //Console.WriteLine("Type name: {0}", myCar.GetType());

            //// Anonymous type Array
            //var arr = new[] 
            //{
            //   new { X = 3, Y = 5 },
            //   new { X = 2, Y = 10 },
            //   new { X = 5, Y = 12 }
            //};
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Lamba Expression

            //List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            //List<int> evenNumber = list.FindAll(x => (x % 2) == 0);
            //foreach (var item in evenNumber)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //List<Dog> dogs = new List<Dog>()
            //{
            //    new Dog { Name = "Rex", Age = 11 },
            //    new Dog { Name = "Pit", Age = 2 },
            //    new Dog { Name = "Su", Age = 4 }
            //};

            //var names = dogs.Select(x => x.Name);

            //foreach (var item in names)
            //{
            //    Console.WriteLine(item);
            //}

            //// Lamba with Anonymous Expression

            //var newDogsList = dogs.Select(
            //    x => new { Age = x.Age, FirstLetter = x.Name[0] });
            //foreach (var item in newDogsList)
            //{
            //    Console.WriteLine(item);
            //}

            ////Sorting with lamba Expression

            //var sortedDogs = dogs.OrderByDescending(x => x.Age);
            //foreach (var item in sortedDogs)
            //{
            //    Console.WriteLine("Dog Name: {0} with age {1}", item.Name, item.Age);
            //}

            //// Lambda With Body
            //var evenNumber2 = list.FindAll(i =>
            //{
            //    Console.WriteLine("Number in list are: {0}", i);
            //    return i % 2 == 0;
            //});

            //foreach (var item in evenNumber2)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //Delegates
            //// parameter less function and return 'true' whenever call
            //Func<bool> boolFunct = () => true;
            ////function with parameter and return bool if condition is satisfied 
            //Func<int, bool> intFunc = (x) =>
            //    {
            //        return x < 10;
            //    };  
            //if (boolFunct() && intFunc(11))
            //{
            //    Console.WriteLine("5 < 10");
            //}

            //LINQ

            //var cul = (from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
            //           where culture.Name.StartsWith("b")
            //           select culture);
            //foreach (var item in cul)
            //{
            //    Console.WriteLine(item);
            //}

            //List<int> number = new List<int>(){
            //    1, 2, 3, 10, 5, 8, 7, 4, 9, 6
            //};

            //var evenNumber = from num in number
            //                 where num % 2 == 0
            //                 select num;
            //foreach (var item in evenNumber)
            //{
            //    Console.WriteLine(item);
            //}

            //// sort
            //var sortedNumber = from num in number
            //                   orderby num ascending
            //                   select num;
            //foreach (var item in sortedNumber)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //string[] words = { "Cherry", "WaterMalon", "Applepie" };
            //var sortedWord = from word in words
            //                 orderby word.Length ascending
            //                 select word;
            //foreach (var item in sortedWord)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            // Grouping
            //int[] numbers ={
            //    1, 2, 3, 4, 5, 6, 10, 12, 13, 14, 15, 9, 8
            //};
            //int divisor = 5;

            //var numberGroup = from number2 in numbers
            //                  group number2 by number2 % divisor into groups
            //                  select new { Remainder = groups.Key, Numbers = groups };
            //// the condition after by if become key 

            //foreach (var item in numberGroup)
            //{
            //    Console.WriteLine(
            //        "Numbers with a remainder of {0} when divided by {1}: ", item.Remainder, divisor);
            //    foreach (var number in item.Numbers)
            //    {
            //        Console.WriteLine(number);
            //    }
            //}

            //List<Category> categorys = new List<Category>()
            //{
            //    new Category { ID = 1, Name = "Fruit" },
            //    new Category { ID = 2, Name ="Food" },
            //    new Category { ID = 3, Name = "Shoe" },
            //    new Category { ID = 4, Name = "Juice"}
            //};

            //List<Product> products = new List<Product>()
            //{
            //    new Product { CategoryID = 1, Name = "berry"},
            //    new Product { CategoryID = 1, Name = "banana" },
            //    new Product { CategoryID = 3, Name = "Sandal" },
            //    new Product { CategoryID = 2, Name = "Fish"},
            //    new Product { CategoryID = 3, Name = "Chicken Meat" },
            //    new Product { CategoryID = 4, Name = "Alpple Juice" },
            //    new Product { CategoryID = 4, Name = "Orange Juice" }
            //};

            //var productWithCategory = from product in products
            //                          join category in categorys
            //                          on product.CategoryID equals category.ID
            //                          select new { Name = product.Name, Category = category.Name };
            //foreach (var item in productWithCategory)
            //{
            //    Console.WriteLine(item);
            //}

            ////Nested Queue
            //var productWithCategory2 = from product in products
            //                           select new
            //                           {
            //                               Name = product.Name,
            //                               Category =
            //                               (from category in categorys
            //                                where category.ID == product.CategoryID
            //                                select category.Name)
            //                           };
            //foreach (var item in productWithCategory2)
            //{
            //    Console.Write(item.Name);
            //    foreach (var item2 in item.Category)
            //    {
            //        Console.WriteLine(item2);
            //    }
            //}

            // LINQ Performance
            //    List<int> l1 = new List<int>();
            //    DateTime startTime = DateTime.Now;
            //    l1.AddRange(Enumerable.Range(1, 50000000));
            //    Console.WriteLine("Ext.method: \t{0}", DateTime.Now - startTime);

            //    startTime = DateTime.Now;
            //    List<int> l2 = new List<int>();
            //    for (int i = 1; i < 50000000; i++)
            //    {
            //        l2.Add(i);
            //    }

            //    Console.WriteLine("For-Loop: \t{0}", DateTime.Now - startTime);

            //    List<int> list = new List<int>();
            //    list.AddRange(Enumerable.Range(1, 100000));
            //    startTime = DateTime.Now;
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        var element = list.Where(x => x > 20000);
            //    }           
            //    Console.WriteLine("No Execution: \t{0}", DateTime.Now - startTime);

            //    startTime = DateTime.Now;
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        var element = list.Where(x => x > 1000).First();
            //    }
            //    Console.WriteLine("Execution: \t{0}", DateTime.Now - startTime);

            //    // LINQ preformance with collection classe
            //    HashSet<Guid> set = new HashSet<Guid>();
            //    for (int i = 0; i < 50000; i++)
            //    {
            //        set.Add(Guid.NewGuid());
            //    }

            //    Guid keyForSearching = new Guid();
            //    startTime = DateTime.Now;
            //    for (int i = 0; i < 50000; i++)
            //    {
            //        bool found = set.Contains(keyForSearching);
            //    }
            //    Console.WriteLine("Hashtag: \t{0}", DateTime.Now - startTime);

            //    startTime = DateTime.Now;
            //    for (int i = 0; i < 50000; i++)
            //    {
            //        // Use IEnumerable<Guid>.Contains(…) extension method
            //        bool found = set.Contains<Guid>(keyForSearching);
            //    }
            //    Console.WriteLine("Contains: {0}", DateTime.Now - startTime);
            //    startTime = DateTime.Now;
            //    for (int i = 0; i < 50000; i++)
            //    {
            //        // Use IEnumerable<Guid>.Where(…) extension method
            //        bool found = set.Where(g => g == keyForSearching).Count() > 0;
            //    }
            //    Console.WriteLine("Where: {0}", DateTime.Now - startTime);
            //}

            //public class Product  
            //{
            //    public string Name { get; set; }
            //    public int CategoryID { get; set; }
            //}
            //public class Category
            //{
            //    public string Name { get; set; }
            //    public int ID { get; set; }
            //}
        }
    }
    
    class Dog
    {
        private string name;
        private int age;

        public Dog()
        {
            this.name = null;
            this.age = 0;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
    }

    //public static class IntExtension
    //{
    //    public static int WordCount(this string str)
    //    {
    //        return str.Split(new char[] { '.', ' ', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    //    }
    //}

    //public static class IListExtension
    //{
    //    public static void IncreaseWith(this List<int> list, int amount)
    //    {
    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            list[i] += amount;
    //        }
    //    }
    //}

    //public static class IEnumerableExtension
    //{
    //    public static string ToString<T>(this IEnumerable<T> enumerable)
    //    {
    //        StringBuilder result = new StringBuilder();
    //        result.Append('[');
    //        foreach (var item in enumerable)
    //        {
    //            result.Append(item);
    //            result.Append(", ");
    //        }
    //        if (result.Length > 1)
    //            result.Remove(result.Length - 2, 2);
    //        result.Append("]");
    //        return result.ToString();
    //    }
    //}
}
