using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Chap18HashTableExcercise
{
    //InCompleted part 7,9,10,11,12,13

    /// <summary>
    /// part 4: Implement ISet 
    /// </summary>
    /// <typeparam name="TValue">value type</typeparam>
    struct KeyValuePairSet<TValue>
    {
        //public TValue Key { get; set; }
        public TValue Value { get; set; }

        public KeyValuePairSet(TValue value)
            : this()
        {
            //this.Key = key;
            this.Value = value;
        }

    }

    interface IDictHashSet<T> : IEnumerable<KeyValuePairSet<T>>
    {
        bool Add(T element);

        bool Contain(T element);

        bool Remove(T element);

        void Clear();

        int Count { get; }

    }

    class DictHashSet<T> : IDictHashSet<T>, IEnumerable<KeyValuePairSet<T>>
    {
        private List<KeyValuePairSet<T>>[] setTable;
        private const int INITIAL_CAPACITY = 16;
        private int initialCapacity;
        private int size;

        // parameterless constructor
        public DictHashSet()
            : this(INITIAL_CAPACITY)
        { }

        // Constructor with capacity
        public DictHashSet(int capacity)
        {
            this.initialCapacity = capacity;
            setTable = new List<KeyValuePairSet<T>>[capacity];
            this.size = 0;
        }

        //For intersection purpose
        public DictHashSet(DictHashSet<T> other)
        {
            this.setTable = other.setTable;
            this.initialCapacity = other.initialCapacity;
            this.size = other.size;
        }

        //Create the list at index by GetHashCode()
        private List<KeyValuePairSet<T>> FindSlot(T key, bool createIfMisiing)
        {
            int index = key.GetHashCode();
            index = index & 0x7FFFFFFF; // negative sign
            index = index % this.initialCapacity;

            if (this.setTable[index] == null && createIfMisiing)
            {
                setTable[index] = new List<KeyValuePairSet<T>>();
            }
            return setTable[index] as List<KeyValuePairSet<T>>;
        }

        /// <summary>
        /// Add element in the set
        /// </summary>
        /// <param name="value">value you want to add</param>
        /// <returns>if value added return true, otherwise return false</returns>
        public bool Add(T value)
        {
            List<KeyValuePairSet<T>> freeSlot = FindSlot(value, true);
            for (int i = 0; i < freeSlot.Count; i++)
            {
                KeyValuePairSet<T> entry = freeSlot[i];
                if (entry.Value.Equals(value))
                {
                    return false;
                }
            }
            freeSlot.Add(new KeyValuePairSet<T>(value));
            this.size++;
            return true;
        }

        /// <summary>
        /// if Table contain element return True otherwise, false
        /// </summary>
        /// <param name="value"> value you want to check</param>
        public bool Contain(T value)
        {
            List<KeyValuePairSet<T>> slot = FindSlot(value, false);
            if (slot != null)
            {
                foreach (KeyValuePairSet<T> item in slot)
                {
                    if (item.Value.Equals(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Remove any specific element from the set
        /// </summary>
        /// <param name="value">element you want to remove</param>
        /// <returns>Return true if element removed, otherwise false</returns>
        public bool Remove(T value)
        {
            List<KeyValuePairSet<T>> slot = FindSlot(value, false);
            for (int i = 0; i < slot.Count; i++)
            {
                KeyValuePairSet<T> entry = slot[i];
                if (entry.Value.Equals(value))
                {
                    slot.RemoveAt(i);
                    this.size--;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Return number of element in the set
        /// </summary>
        public int Count { get { return this.size; } }

        /// <summary>
        /// Clear set 
        /// </summary>
        public void Clear()
        {
            this.setTable = new List<KeyValuePairSet<T>>[initialCapacity];
            this.size = 0;
        }

        /// <summary>
        /// put each elements together of any two table 
        /// </summary>
        /// <param name="other">other table you want to union with</param>
        public void UnionWith(DictHashSet<T> other)
        {
            for (int i = 0; i < other.setTable.Length; i++)
            {
                List<KeyValuePairSet<T>> otherObj = other.setTable[i];
                if (otherObj != null)
                {
                    foreach (KeyValuePairSet<T> otherEntry in otherObj)
                    {
                        T value = otherEntry.Value;
                        if (!this.Contain(value))
                        {
                            this.Add(value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Put element together with is common in any two table
        /// </summary>
        /// <param name="other">other table you want to compare with</param>
        public void IntersectWith(DictHashSet<T> other)
        {
            if (this.size > 0) // if set table have element
            {
                List<T> objList = new List<T>();
                for (int i = 0; i < other.setTable.Length; i++)
                {
                    List<KeyValuePairSet<T>> otherObj = other.setTable[i];
                    if (otherObj != null)
                    {
                        foreach (KeyValuePairSet<T> otherEntry in otherObj)
                        {
                            T value = otherEntry.Value;
                            if (this.Contain(value)) // place same element in the objlist
                            {
                                objList.Add(value);
                            }
                        }
                    }
                }
                this.Clear(); // clear every other element in the table
                foreach (var value in objList)
                {
                    this.Add(value); // add element in the current table
                }
            }
            else
            {
                Console.WriteLine("Error! Set is Empty. Please insert Set table in Object");
            }
        }


        // To run for loop
        IEnumerator<KeyValuePairSet<T>> IEnumerable<KeyValuePairSet<T>>.GetEnumerator()
        {
            foreach (List<KeyValuePairSet<T>> chain in this.setTable)
            {
                if (chain != null)
                {
                    foreach (KeyValuePairSet<T> entry in chain)
                    {
                        yield return entry; // See eg Costumer() to understand yield    
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePairSet<T>>)this).GetEnumerator();
        }

    }

    /// <summary>
    /// Part 5: Implement double key dictionary
    /// </summary>
    /// <typeparam name="TKey1">key1 of element</typeparam>
    /// <typeparam name="TKey2">key2 of element</typeparam>
    /// <typeparam name="TValue">value type of element</typeparam>
    public struct DoubleKeyValuePair<TKey1, TKey2, TValue>
    {
        public TKey1 Key1 { get; set; }
        public TKey2 Key2 { get; set; }
        public TValue Value { get; set; }

        public DoubleKeyValuePair(TKey1 key1, TKey2 key2, TValue value)
            : this()
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Value = value;
        }
    }

    public interface IDoubleKeyDict<K1, K2, V> : IEnumerable<DoubleKeyValuePair<K1, K2, V>>
    {
        V Get(K1 key1, K2 key2);

        V Set(K1 key1, K2 key2, V value);

        V this[K1 key1, K2 key2] { get; set; }

        bool Remove(K1 key1, K2 key2);

        int Count { get; }

        void Clear();
    }

    public class DoubleKeyDictionary<K1, K2, V> : IDoubleKeyDict<K1, K2, V>, IEnumerable<DoubleKeyValuePair<K1, K2, V>>
    {
        private const int INITIAL_CAPACITY = 5;
        private const double LOAD_FACTOR = 0.75;
        private List<DoubleKeyValuePair<K1, K2, V>>[,] table;
        private int initailCapacity;
        private int threshold;
        private int size;
        private double loadFactor;

        public DoubleKeyDictionary()
            : this(INITIAL_CAPACITY, LOAD_FACTOR)
        {

        }

        public DoubleKeyDictionary(int capacity, double loadFactor)
        {
            this.initailCapacity = capacity * capacity;
            this.table = new List<DoubleKeyValuePair<K1, K2, V>>[capacity, capacity];
            this.size = 0;
            this.loadFactor = loadFactor;
            this.threshold = (int)(this.table.Length * loadFactor);
        }

        private List<DoubleKeyValuePair<K1, K2, V>> FindChain(K1 key1, K2 key2, bool createIfMissing)
        {
            int index1 = key1.GetHashCode() & 0x7FFFFFFF;
            int index2 = key2.GetHashCode() & 0x7FFFFFFF;
            index1 = index1 % initailCapacity;
            index2 = index2 % initailCapacity;

            if (this.table[index1, index2] == null && createIfMissing)
            {
                this.table[index1, index2] = new List<DoubleKeyValuePair<K1, K2, V>>();
            }
            return this.table[index1, index2] as List<DoubleKeyValuePair<K1, K2, V>>;
        }

        public V this[K1 key1, K2 key2]
        {
            get { return Get(key1, key2); }
            set { Set(key1, key2, value); }
        }

        public V Get(K1 key1, K2 key2)
        {
            List<DoubleKeyValuePair<K1, K2, V>> chain = FindChain(key1, key2, false);
            if (chain != null)
            {
                foreach (DoubleKeyValuePair<K1, K2, V> entry in chain)
                {
                    if (entry.Key1.Equals(key1) && entry.Key2.Equals(key2))
                    {
                        return entry.Value;
                    }
                }
            }
            return default(V);
        }

        public V Set(K1 key1, K2 key2, V value)
        {
            if (!(this.size >= this.threshold))
            {
                List<DoubleKeyValuePair<K1, K2, V>> chain = FindChain(key1, key2, true);

                for (int i = 0; i < chain.Count; i++)
                {
                    DoubleKeyValuePair<K1, K2, V> entry = chain[i];
                    if (entry.Key1.Equals(key1) && entry.Key2.Equals(key2))
                    {
                        DoubleKeyValuePair<K1, K2, V> newEntry = new DoubleKeyValuePair<K1, K2, V>(key1, key2, value);
                        chain[i] = newEntry;
                        return entry.Value;
                    }
                }
                chain.Add(new DoubleKeyValuePair<K1, K2, V>(key1, key2, value));
                this.size++;
                return default(V);
            }
            else
            {
                Console.WriteLine("Dictionary is full");
                return default(V);
            }
        }

        public bool Remove(K1 key1, K2 key2)
        {
            List<DoubleKeyValuePair<K1, K2, V>> chain = FindChain(key1, key2, false);
            for (int i = 0; i < chain.Count; i++)
            {
                DoubleKeyValuePair<K1, K2, V> entry = chain[i];
                if (entry.Key1.Equals(key1) && entry.Key2.Equals(key2))
                {
                    chain.RemoveAt(i);
                    this.size--;
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            this.table = new List<DoubleKeyValuePair<K1, K2, V>>[initailCapacity, initailCapacity];
            this.size = 0;
        }

        public int Count
        {
            get { return this.size; }
        }

        // foreach-loop
        IEnumerator<DoubleKeyValuePair<K1, K2, V>> IEnumerable<DoubleKeyValuePair<K1, K2, V>>.GetEnumerator()
        {
            foreach (List<DoubleKeyValuePair<K1, K2, V>> chain in this.table)
            {
                if (chain != null)
                {
                    foreach (DoubleKeyValuePair<K1, K2, V> entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DoubleKeyValuePair<K1, K2, V>>)this).GetEnumerator();
        }
    }

    /// <summary>
    /// Part 6: more than one value for single key
    /// </summary>
    struct DoubleValueKeyPair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public List<TValue> Value { get; set; }

        public DoubleValueKeyPair(TKey key, params TValue[] value)
            : this()
        {
            this.Key = key;
            this.Value = new List<TValue>(value);
        }
    }

    interface IDoubleValueDict<K, V> : IEnumerable<DoubleValueKeyPair<K, V>>
    {
        List<V> Get(K key);

        List<V> this[K key] { get; }

        void Add(K key, params V[] value);

        bool Remove(K key);

        void Clear();

        int Count { get; }
    }


    public class DoubleValueDict<K, V> : IDoubleValueDict<K, V>, IEnumerable<DoubleValueKeyPair<K, V>>
    {
        private const int INITIAL_CAPACITY = 8;
        private const double LOAD_FACTOR = 0.75;
        private List<DoubleValueKeyPair<K, V>>[] table;
        private int initialCapacity;
        private double loadFactor;
        private int threshold;
        private int size;

        public DoubleValueDict()
            : this(INITIAL_CAPACITY, LOAD_FACTOR) { }

        public DoubleValueDict(int capacity, double loadFactor)
        {
            this.initialCapacity = capacity;
            this.loadFactor = loadFactor;
            this.table = new List<DoubleValueKeyPair<K, V>>[capacity];
            this.threshold = (int)(this.table.Length * loadFactor);
            this.size = 0;
        }

        private List<DoubleValueKeyPair<K, V>> FindChain(K key, bool createIfMissing)
        {
            int index = key.GetHashCode() & 0x7FFFFFFF;
            index = index % initialCapacity;

            if (this.table[index] == null && createIfMissing)
            {
                this.table[index] = new List<DoubleValueKeyPair<K, V>>();
            }
            return this.table[index] as List<DoubleValueKeyPair<K, V>>;
        }

        public List<V> this[K key]
        {
            get { return this.Get(key); }
        }

        public List<V> Get(K key)
        {
            List<DoubleValueKeyPair<K, V>> chain = FindChain(key, false);
            if (chain != null)
            {
                foreach (DoubleValueKeyPair<K, V> entry in chain)
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }
                }

            }
            return null;
        }
        // Take value in array(becoz its eassy) passed in DoubleValueKeyPair
        public void Add(K key, params V[] value)
        {
            List<DoubleValueKeyPair<K, V>> chain = FindChain(key, true);

            for (int i = 0; i < chain.Count; i++)
            {
                DoubleValueKeyPair<K, V> entry = chain[i];
                if (entry.Key.Equals(key))
                {
                    DoubleValueKeyPair<K, V> newEntry = new DoubleValueKeyPair<K, V>(key, value);
                    chain[i] = newEntry;
                    return;
                }

                chain = QuadracticProbing(key, true);
                if (chain == null)
                {
                    Console.WriteLine("Full");
                    return;
                }
                break;
            }
            chain.Add(new DoubleValueKeyPair<K, V>(key, value));
            this.size++;
        }
        /// <summary>
        /// Part 8: used Quadractic probing
        /// </summary>
        private List<DoubleValueKeyPair<K, V>> QuadracticProbing(K key, bool createIfMissing)
        {
            int index = key.GetHashCode() & 0x7FFFFFFF;
            index = index % initialCapacity;

            int newPosition = 0;
            int count = 0;
            do
            {
                count++;
                // linear probing
                //index++;
                //newPosition = index % initialCapacity;
                newPosition = (index + (count*count)) % initialCapacity; // formula for net


            } while (this.table[newPosition] != null && count < initialCapacity);
            if (count < initialCapacity)
            {
                if (createIfMissing)
                {
                    this.table[newPosition] = new List<DoubleValueKeyPair<K, V>>();
                }
                return this.table[newPosition] as List<DoubleValueKeyPair<K, V>>;
            }
            return null;
        }

        public bool Remove(K key)
        {
            List<DoubleValueKeyPair<K, V>> chain = FindChain(key, false);
            for (int i = 0; i < chain.Count; i++)
            {
                DoubleValueKeyPair<K, V> entry = chain[i];
                if (entry.Key.Equals(key))
                {
                    chain.RemoveAt(i);
                }
            }
            return false;
        }


        public int Count { get { return this.size; } }

        public void Clear()
        {
            this.table = new List<DoubleValueKeyPair<K, V>>[initialCapacity];
            this.size = 0;
        }


        IEnumerator<DoubleValueKeyPair<K, V>> IEnumerable<DoubleValueKeyPair<K, V>>.GetEnumerator()
        {
            foreach (List<DoubleValueKeyPair<K, V>> chain in this.table)
            {
                if (chain != null)
                {
                    foreach (DoubleValueKeyPair<K, V> entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DoubleValueKeyPair<K, V>>)this).GetEnumerator();
        }
    }




    class Excercise
    {
        public static void MainEx()
        {
            Excercise ex = new Excercise();
            //ex.CountsNumberOfOccurrence();
            //ex.RemoveOddOccurrenceNumber();
            //ex.TextOccurrence();
            //ex.DictHashMainMethod();
            //ex.DoubleKeyDictMethod();
            //ex.DoubleValueMethod();



            ex.RandomMethod("Burair", "Asad");
        }
        public void RandomMethod(params string[] str)
        {

        }

        //part 6 and 8: more than one value for single key, Used Quadratic probing
        public void DoubleValueMethod()
        {
            DoubleValueDict<string, string> dict = new DoubleValueDict<string, string>();
            dict.Add("University", "John", "Asad", "Uran");
            dict.Add("School", "Ron", "Harry", "Hamza");
            dict.Add("Eureka", "Ahsan", "Panlo", "Harai");
            dict.Add("Coaching", "Dale", "Carnegie", "Anas");
            dict.Add("Other Loyal", "Wick", "Joker", "Loki");
            dict.Add("Good Friend", "Eckhart", "Dale", "Rebert");
            dict.Add("John", "");
            dict.Add("Noah", "");
            dict.Add("as", "");

            dict.Remove("Other Loyal");
            List<string> frined = dict["University"];
            dict.Add("University", "Jasan", "Rhonda", "Wayne");

            foreach (var listItem in dict)
            {
                Console.Write("key " + listItem.Key + ": ");
                foreach (string itemValue in listItem.Value)
                {
                    Console.Write(itemValue + " ");
                }
                Console.WriteLine();
            }
            foreach (var item in frined)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// part 5: Implement double key dictionary
        /// </summary>
        public void DoubleKeyDictMethod()
        {
            DoubleKeyDictionary<int, int, string> matrixName = new DoubleKeyDictionary<int, int, string>();
            matrixName[1, 1] = "John";
            matrixName[1, 2] = "Harry";
            matrixName[2, 1] = "Ron";
            matrixName[1, 3] = "Loki";
            matrixName[4, 1] = "Wayne";
            matrixName[3, 1] = "Eckhart";
            matrixName[1, 3] = "Robert";
            matrixName.Remove(3, 1);
            foreach (var item in matrixName)
            {
                Console.WriteLine(item.Value);
            }
            Console.WriteLine(matrixName.Count);
            matrixName.Clear();
            foreach (var item in matrixName)
            {
                Console.WriteLine(item.Value);
            }
        }

        /// <summary>
        /// part 4: implement the Set like HashDictionary
        /// </summary>
        public void DictHashMainMethod()
        {
            DictHashSet<string> dict = new DictHashSet<string>();
            dict.Add("John");
            dict.Add("Tolle");
            dict.Add("Dale");
            dict.Contain("Dale");
            dict.Add("Robert");
            dict.Add("Noah");

            foreach (var item in dict)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine(dict.Count);

            Console.WriteLine("Is Dale Removed ? " + (dict.Remove("Dale") ? "Yes!" : "No"));
            foreach (var item in dict)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine(dict.Count);

            DictHashSet<string> dict2 = new DictHashSet<string>();
            dict2.Add("Harry");
            dict2.Add("Karish");
            dict2.Add("Ali");
            dict2.Add("Shahzil");

            foreach (var item in dict2)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine(dict.Count);

            DictHashSet<string> allDict = new DictHashSet<string>();
            allDict.UnionWith(dict);
            allDict.UnionWith(dict2);

            Console.Write("Union: ");
            foreach (var item in allDict)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine(allDict.Count);

            DictHashSet<string> sameDict = new DictHashSet<string>(dict);
            sameDict.IntersectWith(dict2);

            Console.Write("Intersect: ");
            foreach (KeyValuePairSet<string> item in sameDict)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine(sameDict.Count > 0 ? sameDict.Count.ToString() : "false");
        }

        /// <summary>
        /// part 3: number of time each word occurs in the text
        /// </summary>
        public void TextOccurrence()
        {
            StreamReader reader = new StreamReader("Text.txt");
            string text = reader.ReadLine();
            char[] separator = { '!', ' ', ',', '-', '.', '?' };
            string[] textArray = text.ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries);

            SortedDictionary<string, int> wordsOccurs = new SortedDictionary<string, int>();
            for (int i = 0; i < textArray.Length; i++)
            {
                if (!wordsOccurs.ContainsKey(textArray[i]))
                {
                    wordsOccurs[textArray[i]] = 1;
                }
                else
                {
                    wordsOccurs[textArray[i]] = wordsOccurs[textArray[i]] + 1;
                }
            }
            // sorted the dictionary by Value
            var ordered = wordsOccurs.OrderBy(x => x.Value);

            Console.Write("Result: ");
            foreach (KeyValuePair<string, int> item in ordered)
            {
                Console.Write(item.Key + "->" + item.Value + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// part 2: Remove odd occurrence number from sequence
        /// </summary>
        public void RemoveOddOccurrenceNumber()
        {
            int[] number = { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6 };
            Dictionary<int, int> oddSequence = new Dictionary<int, int>();
            for (int i = 0; i < number.Length; i++)
            {
                if (oddSequence.ContainsKey(number[i]))
                {
                    oddSequence[number[i]] = oddSequence[number[i]] + 1;
                }
                else
                {
                    oddSequence[number[i]] = 1;
                }
            }
            List<int> oddlist = new List<int>();

            // Make this logic in less than a minute. after wake up in morning
            for (int i = 0; i < number.Length; i++)
            {
                if (oddSequence[number[i]] % 2 == 0)
                {
                    oddlist.Add(number[i]);
                }
            }

            Console.WriteLine("{" + string.Join(",", oddlist) + "}");

            // get frustrated making logic in night(become tired) and leave it being upset that i am not a good programmer 
            //for (int i = 1; i <= number.Max() ; i++)
            //{

            //    if (oddSequence[i] % 2 == 0)
            //    {
            //        oddlist.Add(i);
            //    }
            //}
            //Console.Write("{");
            //int count = 0;
            //foreach (KeyValuePair<int, int> item in oddSequence)
            //{
            //    count = 0;
            //    while (item.Value > count)
            //    {
            //        Console.Write(item.Key + " ");
            //        count++;
            //    }
            //}
            //Console.WriteLine("}");

        }


        /// <summary>
        /// part 1: the number of occurrence of each integer
        /// </summary>
        public void CountsNumberOfOccurrence()
        {
            int[] number = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            SortedDictionary<int, int> counts = new SortedDictionary<int, int>();
            for (int i = 0; i < number.Length; i++)
            {
                if (counts.ContainsKey(number[i]))
                {
                    counts[number[i]] = counts[number[i]] + 1;
                }
                else
                {
                    counts[number[i]] = 1;
                }
            }
            foreach (KeyValuePair<int, int> item in counts)
            {
                Console.WriteLine(item.Key + " --> " + item.Value);
            }
        }
    }
}
