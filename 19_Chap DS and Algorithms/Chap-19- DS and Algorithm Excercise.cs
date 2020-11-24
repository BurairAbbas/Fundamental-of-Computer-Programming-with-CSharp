using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Chap19DSandAlgorithm
{
    
    class Excercise
    {
        public static void MainEx()
        {
            Excercise ex = new Excercise();
            //ex.HashMultiValue();
            //part 2 on pending
            //ex.StudentProfile();

            // part 4:
            //BiDictionary<int, int, string> dictionary = new BiDictionary<int, int, string>();
            //dictionary.Add(1, 0, "John");
            //dictionary.Add(1, 1, "Nick");
            //dictionary.Add(0, 2, "Harry");
            //dictionary.Add(3, 3, "Sam");

            //dictionary.SearchFirstKey(1);
            //dictionary.SearchSecondKey(1);

            // part 5:
            //SuperMarket sp = new SuperMarket();
            //sp.AddProduct(1, 5, "abc", "HouseMent");
            //sp.AddProduct(2, 5, "burger patees", "KNandS");
            //sp.AddProduct(3, 8, "Beef Burger", "American Health");
            //sp.AddProduct(4, 6, "Suger", "Refine Quality");
            //sp.AddProduct(11, 8, "Brown", "Refine Quality");
            //sp.AddProduct(5, 10, "Rice", "Ponam");
            //sp.AddProduct(6, 12, "Long Rice", "Ponam");
            //sp.AddProduct(7, 8, "Sila Rice", "Ponnam");
            //sp.AddProduct(8, 3, "Dates", "Ponam");
            //sp.AddProduct(9, 9, "Oliva Oil", "Health Pure");
            //sp.AddProduct(10, 7, "Cooking Oil", "Health Pure");
            //sp.AddProduct(12, 5, "Pespi", "Pespi");
            //sp.SearchWithBarCode(1);
            //sp.SearchWithBarCode(13);
            //Console.WriteLine();
            //sp.SearchWithRange(5, 10);

            DateTime d = DateTime.Now;
            Console.WriteLine(d);
            //sorte
            PriorityQuere<int> p = new PriorityQuere<int>();
            p.Add(2);
            p.Add(10);
            p.Add(1);
            p.Add(2);
            Console.WriteLine(p.GetSmallestElement());
        }

        /// <summary>
        /// Part 1: allow more than one value in the hash table
        /// </summary>
        public void HashMultiValue()
        {
            Dictionary<int, List<string>> empData = new Dictionary<int, List<string>>();
            string[] name = { "John", "Sam", "Nick", "Harry", "Hellboy" };
            string[] age = { "21", "22", "20", "24", "26" };
            string[] place = { "Jodan City", "Mari Land", "Sherlock Society", "Ilm Street", "Okata Palace" };
            string city = "Sidney";
            Random rn = new Random();

            for (int i = 0; i < 4; i++)
            {
                List<string> values = new List<string>();
                values.Add(name[rn.Next(name.Length)]); // randomly generated 
                values.Add(age[rn.Next(age.Length)]);
                values.Add(place[rn.Next(place.Length)]);
                values.Add(city);
                empData.Add(i + 1, values);
            }

            foreach (int key in empData.Keys)
            {
                Console.Write(key + " ");
                List<string> value = empData[key];
                foreach (string data in value)
                {
                    Console.Write(data + " ");
                }
                Console.WriteLine();
            }
        }

        //part 2:pending
        public void AddAndExtractSmallest()
        {
            SortedSet<List<int>> sortedElement = new SortedSet<List<int>>();
            List<int> value = new List<int>();
        }

        /// <summary>
        /// Part 3: used SortDictionary for field and names, print names sorted by family name than secondly firstname
        /// </summary>
        public void StudentProfile()
        {
            SortedDictionary<string, SortedDictionary<string, string>> studentData = new SortedDictionary<string, SortedDictionary<string, string>>();
            StreamReader reader = new StreamReader(@"Excercise/Student Field.txt");
            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    string[] entry = line.Split('|');
                    string[] name = entry[0].Split(' ');
                    string field = entry[1].Trim();
                    string firstName = name[0].Trim();
                    string familyName = name[1].Trim();
                    SortedDictionary<string, string> names;
                    if (!studentData.TryGetValue(field, out names))
                    {
                        names = new SortedDictionary<string, string>();
                        studentData.Add(field, names);
                    }
                    names.Add(firstName, familyName);
                }
            }

            foreach (var key in studentData.Keys)
            {
                Console.Write(key + ": ");
                SortedDictionary<string, string> names = studentData[key];
                // Sorted element by values(family name) otherwise its already sorted by key(firstname)
                var ordered = names.OrderBy(x => x.Value);
                foreach (var item in ordered)
                {
                    Console.Write(item.Key + " " + item.Value + ",");
                }
                Console.WriteLine();
            }
        }
    }

    //Part 4: Search with k1 k2 separately and also combine it.
    class BiDictionary<K1, K2, T>
    {
        /*const string AddT = @"Excercise/Part4AddT";
        const string Queries = @"Excercise/Part4Queries";
        static Dictionary<string, List<string>> biDictionary = new Dictionary<string, List<string>>();
        
        public static void MainDict()
        {
            ReadTs();
            ProcessTs();
        }

        static void ReadTs()
        {
            StreamReader reader = new StreamReader(AddT);
            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    string[] entry = line.Split('|');
                    string[] keys = entry[0].Split(',');
                    string T = entry[1].Trim();
                    foreach (var key in keys)
                    {
                        AddToDictionary(key, line);
                    }
                    string combineKey = CombineKeyT(keys[0], keys[1]);
                    AddToDictionary(combineKey, line);
                }
            }
        }

        static string CombineKeyT(string key1, string key2)
        {
            return key1 + "," + key2;
        }

        static void AddToDictionary(string key, string entry)
        {
            List<string> entries;
            if (!biDictionary.TryGetT(key, out entries))
            {

            }
        }

        static void ProcessTs() { }*/

        static Dictionary<K1, List<T>> key_1_Dictionary = new Dictionary<K1, List<T>>();
        static Dictionary<K2, List<T>> key_2_Dictionary = new Dictionary<K2, List<T>>();
        static Dictionary<Tuple<K1, K2>, List<T>> combineKeyDictionary = new Dictionary<Tuple<K1, K2>, List<T>>();

        public void Add(K1 key1, K2 key2, params T[] element)
        {
            List<T> elements;

            if (!key_1_Dictionary.TryGetValue(key1, out elements))
            {
                elements = new List<T>();
                key_1_Dictionary.Add(key1, elements);
            }
            elements.AddRange(element);

            if (!key_2_Dictionary.TryGetValue(key2, out elements))
            {
                elements = new List<T>();
                key_2_Dictionary.Add(key2, elements);
            }
            elements.AddRange(element);

            Tuple<K1, K2> combineKey = new Tuple<K1, K2>(key1, key2);
            if (!combineKeyDictionary.TryGetValue(combineKey, out elements))
            {
                elements = new List<T>();
                combineKeyDictionary.Add(combineKey, elements);
            }
            elements.AddRange(element);
        }
        public void Remove(K1 key1, K2 key2)
        {
            key_1_Dictionary.Remove(key1);
            key_2_Dictionary.Remove(key2);
            Tuple<K1, K2> combineKey = new Tuple<K1, K2>(key1, key2);
            combineKeyDictionary.Remove(combineKey);
        }

        public bool SearchFirstKey(K1 key)
        {
            Console.WriteLine("Values of key '" + key + "'  in 1st HashTable :");
            if (key_1_Dictionary.ContainsKey(key))
            {
                PrintAllValues(key_1_Dictionary[key]);
                return true;
            }
            return false;
        }
        public bool SearchSecondKey(K2 key)
        {
            Console.WriteLine("Values of key '" + key + "' in 2nd HashTable :");
            if (key_2_Dictionary.ContainsKey(key))
            {
                PrintAllValues(key_2_Dictionary[key]);
                return true;
            }
            return false;
        }
        public bool Search(K1 key1, K2 key2)
        {
            Tuple<K1, K2> combineKey = new Tuple<K1, K2>(key1, key2);
            if (combineKeyDictionary.ContainsKey(combineKey))
            {
                PrintAllValues(combineKeyDictionary[combineKey]);
                return true;
            }
            return false;
        }
        void PrintAllValues(List<T> elements)
        {
            foreach (var item in elements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

    }

    // part 5: each product have unique barCode and having price, product, producer names. and search between 5 to 10 dollar product.
    class SuperMarket
    {
        // feel the difference between justby changing the value type of this Dictionary in the code
        // instead of taking dictionary as a value type and that dictionary which hold the price as a key and value type as a list and list data
        // type is custom class, i just initailize the value type as the list of Product class which hold all the three values.
        Dictionary<int, List<ProductData>> superMarketList = new Dictionary<int, List<ProductData>>();

        // first attempt
        // to hold the barcode as a key and hold another dictionary as a value;
        //Dictionary<int, Dictionary<int, List<ProductData>>> superMarketDictionary = new Dictionary<int, Dictionary<int, List<ProductData>>>();
        
        // dictionary hold price as a key and product, producer name as a value in List, List datatype is ProductData which hold the value of both
        Dictionary<int, List<ProductData>> productAttribute = new Dictionary<int, List<ProductData>>();

        public void AddProduct(int barCode, int price, string productName, string producerName)
        {            
            List<ProductData> listOfName;
            // if price is not in the 2nd dictionary declared list in it
            if (!productAttribute.TryGetValue(price, out listOfName))
            {
                listOfName = new List<ProductData>();
                productAttribute.Add(price, listOfName);
            }
            // instance that contain product and producer name
            ProductData pd = new ProductData(productName, producerName);
            // add instance of class in list
            listOfName.Add(pd);
            
            if (!superMarketList.TryGetValue(barCode, out listOfName))
            {
                listOfName = new List<ProductData>();
                superMarketList.Add(barCode, listOfName);
            }
            pd = new ProductData(productName, producerName, price);
            listOfName.Add(pd);


            // declared another variable so 
            //Dictionary<int, List<ProductData>> product = new Dictionary<int, List<ProductData>>();
            //if (!product.TryGetValue(prices, out listOfName))
            //{
            //    listOfName = new List<ProductData>();
            //    product.Add(prices, listOfName);
            //}
            //listOfName.Add(pd);
            //superMarketDictionary.Add(barCode, product);
        }

        public void SearchWithBarCode(int barCode)
        {
            Console.WriteLine("BarCode of Product is " + barCode + " :");
            // if key found
            if (superMarketList.ContainsKey(barCode))
            {
                List<ProductData> pd = superMarketList[barCode];
                foreach (var item in pd)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("This Product is Not Found");
            }

            // first i removed the below code but i again undo it to just see how much code change by changing single thing

            // if contain the key
            //if (superMarketDictionary.ContainsKey(barCode))
            //{
            //    Console.WriteLine("BarCode of Product is: " + barCode);
            //    // get the value in respective data type from key
            //    Dictionary<int, List<ProductData>> productlist = superMarketDictionary[barCode];
                
            //    foreach (KeyValuePair<int, List<ProductData>> item in productlist)
            //    {
            //        Console.WriteLine("Prices is: " + item.Key);
            //        // further break and get the value in List
            //        List<ProductData> pd = productlist[item.Key];
            //        foreach (ProductData itemlist in pd)
            //        {
            //            // print data by override ToString()
            //            Console.Write("{0}", itemlist);
            //        }
            //        Console.WriteLine();
            //    }
            //}
            //    // if no key found
            //else
            //{
            //    Console.WriteLine("This Product Not Found");
            //}
        }

        public void SearchWithRange(int from, int to)
        {
            Console.WriteLine("The product Between " + from + " and " + to + "dollar :");
            while (from <= to)
            {
                List<ProductData> pd = productAttribute[from];
                foreach (var item in pd)
                {
                    Console.WriteLine(item.ToStringWithRange());
                }
                // add value so it print every value from to usergiven to (usergiven)
                from++;
            }            
        }        
    }
    class ProductData
    {
        string productName { get; set; }
        string producerName { get; set; }
        int prices { get; set; }

        public ProductData(string productName, string producerName)
            :this(producerName, producerName, 0)
        {
            
        }
        public ProductData(string productName, string producerName, int priice)
        {
            this.producerName = producerName;
            this.productName = productName;
            this.prices = prices;
        }

        public override string ToString()
        {
            return "Prices: " + prices + "Product Name: " + productName + " \nProducer Name: " + producerName;
        }
        public string ToStringWithRange()
        {
            return "Product Name: " + productName + "  Prooducer Name: " + producerName;
        }
    }

    //part 6: pending
    class ConferenceHall 
    {
        //class TimeSchedule : IComparable
        //{
        //    DateTime StartingInterval { get; set; }
        //    DateTime EndingInterval { get; set; }

        //    public TimeSchedule(DateTime start, DateTime end)
        //    {
        //        this.StartingInterval = start;
        //        this.EndingInterval = end;
        //    }
        //}
    }

    //part 7: i did it wrong btw
    class PriorityQuere<T>
    {
        SortedSet<T> sortSet = new SortedSet<T>();
        public void Add(T item)
        {
            sortSet.Add(item);
        }
        public T GetSmallestElement()
        {
            foreach (var item in sortSet)
            {
                Console.WriteLine(item);
            }
            return sortSet.First();
        }
    }    
}
