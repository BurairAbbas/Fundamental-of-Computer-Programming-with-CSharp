using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace Chap16LinearDS
{
    // part 11:
    class DynamicDoubleLinked<T>
    {
        public class Node
        {
            internal T Element { get; set; }
            internal Node NextNode { get; set; }
            internal Node PrevNode { get; set; }

            public Node(T element)
            {
                this.Element = element;
                this.NextNode = this.PrevNode = null;
            }
            public Node(T item, Node prevNode)
            {
                this.Element = item;
                prevNode.NextNode = this;
                prevNode.NextNode.PrevNode = prevNode;
            }
        }
        private Node head;
        private Node tail;
        private int count;

        public DynamicDoubleLinked()
        {
            head = tail = null;
            count = 0;
        }

        /// <summary>
        /// Insert element in a list
        /// </summary>
        /// <param name="item">item you want to add</param>
        public void Add(T item)
        {
            if (head == null)
            {
                this.head = new Node(item);
                this.tail = this.head;
            }
            else
            {
                Node newNode = new Node(item, this.tail);
                this.tail = newNode;
            }
            this.count++;
        }

        /// <summary>
        /// Search an element from a list
        /// </summary>
        /// <param name="item">item you want to search</param>
        /// <returns>Return true if element found otherwise, return false</returns>
        public bool Search(T item)
        {
            Node currentNode = this.head;
            while (currentNode != null)
            {
                if (object.Equals(currentNode.Element, item))
                {
                    return true;
                }
                currentNode = currentNode.NextNode;
            }
            return false;
        }

        /// <summary>
        /// Remove specific element from the list
        /// </summary>
        /// <param name="item">item you want to remove</param>
        /// <returns>Return removed element from list or default value of datatype</returns>
        public T Remove(T item)
        {
            Node currentNode = this.head;
            Node tempNode = null;

            while (currentNode != null)
            {
                if (object.Equals(currentNode.Element, item))
                {
                    RemoveListNode(currentNode, tempNode);
                    return currentNode.Element;
                }
                else
                {
                    tempNode = currentNode;
                    currentNode = currentNode.NextNode;
                }
            }
            return default(T);
        }

        /// <summary>
        /// To remove element from the list
        /// </summary>
        /// <param name="node">Node that is removed</param>
        /// <param name="prevNode">previous node of removed node</param>
        public void RemoveListNode(Node node, Node prevNode)
        {
            this.count--;
            if (count == 0)
            {
                head = tail = null;
            }
            else if (prevNode == null)
            {
                this.head = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }
            else
            {
                prevNode.NextNode = node.NextNode;
                if (node.NextNode != null)
                {
                    node.NextNode.PrevNode = prevNode;
                }
            }

            if (object.ReferenceEquals(this.tail, node))
            {
                this.tail = prevNode;
            }

        }

        /// <summary>
        /// Find the element by specific position
        /// </summary>
        /// <param name="index">item you want to find out by specific index</param>
        /// <returns>Return element or default value of given datatype</returns>
        public T IndexOf(int index)
        {
            if (index + 1 > this.count || index < 0)
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            else
            {
                int currentIndex = 0;
                Node currentNode = this.head;
                while (currentIndex < index)
                {
                    currentNode = currentNode.NextNode;
                    currentIndex++;
                }
                return currentNode.Element;
            }
        }

        /// <summary>
        /// Insert element at specific position
        /// </summary>
        /// <param name="item">item you want to insert</param>
        /// <param name="index">At the specific position you want to insert an item</param>
        public void Insert(T item, int index)
        {
            if (index + 1 > this.count || index < 0)
                throw new ArgumentOutOfRangeException("Invalid index: " + index);

            Node currentNode = this.head;
            Node tempNode = null;
            int currentIndex = 0;
            this.count++;
            while (currentIndex < index)
            {
                tempNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }
            if (tempNode != null)
            {
                Node newnNode = new Node(item, tempNode);
                currentNode.PrevNode = newnNode;
                newnNode.NextNode = currentNode;
            }
            else
            {
                Node newNode = new Node(item);
                currentNode.PrevNode = newNode;
                newNode.NextNode = currentNode;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index + 1 > this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                Node tempNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    tempNode = tempNode.NextNode;
                }
                return tempNode.Element;
            }
            set
            {
                if (index + 1 > this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                Node tempNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    tempNode = tempNode.NextNode;
                }
                tempNode.Element = value;
            }
        }

        /// <summary>
        /// Convert the list into array
        /// </summary>
        /// <returns>Return array of converted list</returns>
        public T[] ToArray()
        {
            T[] arr = new T[this.count];
            Node currentNode = this.head;
            for (int i = 0; i < this.count; i++)
            {
                arr[i] = currentNode.Element;
                currentNode = currentNode.NextNode;
            }
            return arr;
        }


        public void Print()
        {
            Node node = this.head;
            while (node != null)
            {
                Console.Write(node.Element + " ");
                node = node.NextNode;
            }
            Console.WriteLine();
        }
        public void ReversePrint()
        {
            Node node = this.tail;
            for (int i = this.count - 1; i >= 0; i--)
            {
                Console.Write(node.Element + " ");
                node = node.PrevNode;
            }
            Console.WriteLine();
        }
    }

    /*************************************** Circular Queue Implementation Array Based *****************************/
    //part 14: copied from includehelp.com
    public class CircularQueue<T>
    {
        T[] arr;
        int front;
        int rear;
        int max;
        int count;

        public CircularQueue()
        {
            arr = new T[10];
            front = 0;
            rear = -1;
            max = 10;
            count = 0;
        }

        /// <summary>
        /// Insert element in the queue
        /// </summary>
        /// <param name="item">item you want to add</param>
        public void Enquene(T item)
        {
            if (count == max)
            {
                Console.WriteLine("Queue is Full");
            }
            else
            {
                rear = (rear + 1) % max;
                this.arr[rear] = item;
                count++;
            }
        }


        public void Dequeue()
        {
            if (count == 0)
            {
                Console.WriteLine("Queue is Empty");
            }
            else
            {
                Console.WriteLine("Deleted element is: " + arr[front]);
                front = (front + 1) % max;
                count--;
            }
        }

        public void Print()
        {
            int i = 0;
            int j = 0;
            if (count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                for (i = front; j < count; )
                {
                    Console.WriteLine("item = [" + (i + 1) + "] = " + this.arr[i]);
                    i = (i + 1) % max;
                    j++;
                }
            }
        }
    }
   

    //part 15: traversal of all directories on your hard disk Using queue
    class TraversalDir 
    {
        //Queue<
        public static IEnumerable<string> Traverse(string rootDirectory)
        {
            IEnumerable<string> files = Enumerable.Empty<string>();
            IEnumerable<string> directories = Enumerable.Empty<string>();
            try
            {
                // The test for UnauthorizedAccessException.
                //var permission = new FileIOPermission(FileIOPermissionAccess.PathDiscovery, rootDirectory);
                //permission.Demand();

                files = Directory.GetFiles(rootDirectory);
                directories = Directory.GetDirectories(rootDirectory);
                //string print = Directory.;
                //Console.WriteLine(print);
                
            }
            catch
            {
                // Ignore folder (access denied).
                rootDirectory = null;
            }

            if (rootDirectory != null)
                yield return rootDirectory;

            foreach (var file in files)
            {
                yield return file;
            }
            // Recursive call for SelectMany.
            var subdirectoryItems = directories.SelectMany(Traverse);
            foreach (var result in subdirectoryItems)
            {
                yield return result;
            }
        }
    }

    class Excercise
    {
        public void MainEx()
        {
            var path = TraversalDir.Traverse(@"C:\Users\Downloads\movies");
            File.WriteAllLines(@"File path for the list", path);



            //CircularQueue<int> numbers = new CircularQueue<int>();
            //numbers.Enquene(1);
            //numbers.Enquene(2);
            //numbers.Enquene(3);
            //numbers.Enquene(4);
            //numbers.Enquene(5);
            //numbers.Enquene(6);
            //numbers.Enquene(7);
            //numbers.Enquene(8);
            //numbers.Enquene(9);
            //numbers.Enquene(10);
            //numbers.Dequeue();
            //numbers.Enquene(10);
            //numbers.Enquene(10);
            //numbers.Dequeue();
            //numbers.Dequeue();
            //numbers.Dequeue();
            //numbers.Dequeue();
            //numbers.Dequeue();
            //numbers.Print();

            //DynamicDoubleLinked<int> num = new DynamicDoubleLinked<int>();
            //num.Add(2);
            //num.Add(5);
            //num.Add(7);
            //num.Add(9);
            //num.Print();
            ////num.ReversePrint();
            //num.Remove(2);
            //num.Print();
            //num.Insert(6, 1);
            //num.Print();
            //num.Insert(10, 3);
            //num.Print();
            ////num.Insert(11, 5);
            //num.ReversePrint();
            //Console.WriteLine("At Index: " + num.IndexOf(2));
            //Console.WriteLine(num.Search(10));
            //Console.WriteLine(num[2]);
            //num.Remove(5);
            //num.Print();
            //num.ReversePrint();

            //SumOfList(); part1
            //List<int> longlist = LongestSubsequenceOfEqualNumber(2, 3, 4, 5, 6, 7, 2, 2, 3, 4, 2, 4, 5, 3, 2, 2, 6, 5, 4, 7, 7, 7, 7, 7, 7, 8, 9, 3, 2, 3, 4, 5, 6, 7, 3, 2, 3, 5);
            //for (int i = 0; i < longlist.Count; i++)
            //{
            //    Console.Write(longlist[i] + " ");
            //}
            //Console.WriteLine();

            //RemoveNegativeNumber(23, -12, -24, -5, 21, 23, -56, 3, -2, 3, -87, -100, 23);

            //RemoveOddNumber(2, 3, 4, 5, 6, 7, 2, 2, 3, 4, 2, 4, 5, 3, 2, 2, 6, 5, 4, 7, 7, 7, 7, 7, 7, 8, 9, 3, 2, 3, 4, 5, 6, 7, 3, 2, 3, 5);

            //EachTimeOccurs(2, 3, 4, 5, 6, 7, 2, 2, 3, 4, 2, 4, 5, 3, 2, 2, 6, 5, 4, 7, 7, 7, 7, 7, 7, 8, 9, 3, 2, 3, 4, 5, 6, 7, 3, 2, 3, 5);

            //SequenceQueuePattern(2);

            //ShortestSequence(5, 16);

        }

        /// part 10:
        /// <summary>
        /// Find the Shortest sequence from operation start from N and end on M!
        /// </summary>
        /// Example: N = 5, M = 16 --> 5 -> 7 -> 8 -> 16 !!
        public void ShortestSequence(int startnumber, int endnumber)
        {
            Stack<int> sequence = new Stack<int>();
            int multnum = 0;
            int add2num = 0;
            int addOneNum = 0;

            int startnum = startnumber;
            int endnum = endnumber;
            sequence.Push(endnumber);

            while (startnumber <= endnumber)
            {
                if ((startnumber <= (endnumber / 2)) && (multnum == 0))
                {
                    endnumber = endnumber / 2;
                    sequence.Push(endnumber);
                    add2num = addOneNum = 0;
                    multnum = 1;
                }
                else if ((startnumber <= (endnumber - 1)) && (add2num == 0))
                {
                    endnumber = endnumber - 1;
                    sequence.Push(endnumber);
                    addOneNum = multnum = 0;
                    add2num = 1;
                }
                else if ((startnumber <= (endnumber - 2)) && (addOneNum == 0))
                {
                    endnumber = endnumber - 2;
                    sequence.Push(endnumber);
                    multnum = add2num = 0;
                    addOneNum = 1;
                }
                else
                {
                    if (sequence.Peek() != endnumber)
                    {
                        endnumber = startnumber;
                        sequence.Push(endnumber);
                    }
                    endnumber--;
                }
            }
            while (sequence.Count > 0)
            {
                Console.Write(sequence.Pop() + " ");
            }
            Console.WriteLine();
        }


        /// part 9:
        /// <summary>
        /// S1 = N
        /// S2 = S1 + 1
        /// S3 = S1*2 + 1
        /// S4 = S1 + 2
        /// S5 = S2 + 1
        /// S6 = S2*2 + 1
        /// S7 = S2 + 2
        /// ... 50 Sequence
        /// </summary>
        public void SequenceQueuePattern(int n)
        {
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);
            int count = 0;
            Console.Write("N = " + n + "->");
            while (count < 50)
            {
                int currentValue = sequence.Dequeue();
                Console.Write(" " + currentValue);
                sequence.Enqueue(currentValue + 1);
                sequence.Enqueue((2 * currentValue) + 1);
                sequence.Enqueue(currentValue + 2);
                count++;
            }
            Console.WriteLine();
        }

        ///part 7
        /// <summary>
        /// Find in given array (range 0 to 1000) how many time each number occurs 
        /// </summary>
        public void EachTimeOccurs(params int[] arr)
        {
            int count = 1;
            int num = -1;
            List<int> numbers = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                // if numbers list doesnot contain same element than run the loop, otherwise we get the same number times each occurs
                // eg. we get 2 at [0] and 2 at [6] it again print how many time 2 occurs 
                if (!numbers.Contains(arr[i]))
                {
                    for (int j = 0; j < arr.Length; j++)
                    {

                        if (i != j)
                        {
                            if (arr[i] == arr[j])
                            {
                                count++;
                                num = arr[i];
                            }
                        }
                    }
                    if (count > 1)
                    {
                        Console.WriteLine(num + "->" + count + "times");
                        count = 1;
                        // add occur number in list to ignore same number occurs
                        numbers.Add(num);
                    }
                }
            }
        }

        ///part 6
        /// <summary>
        /// Remove odd number from the list
        /// </summary>
        /// <param name="arr"></param>
        public void RemoveOddNumber(params int[] arr)
        {
            List<int> number = new List<int>();
            //number.AddRange(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    number.Add(arr[i]);
                    //i--;
                    arr[i] = 0;
                }
            }
            Console.Write("Removed Odd Number: ");
            for (int i = 0; i < number.Count; i++)
            {
                Console.Write(number[i] + " ");
            }
            Console.WriteLine();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] != 0) 
            //    {
            //        Console.Write(arr[i] + " ");
            //    }
            //}

            Console.WriteLine();
        }

        /// part 5
        /// <summary>
        /// Remove all negative number from list
        /// </summary>
        // [23, -12, -24, -5, 21, 23, -56, 3, -2, 3, -87, -100, 23] values in Array
        public void RemoveNegativeNumber(params int[] arr)
        {
            List<int> numbers = new List<int>();
            numbers.AddRange(arr);

            for (int i = 0; i < numbers.Count; i++)
            {
                //remove negative number
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                    // i - 1 so the new element at the place of previous element also check eg. if i remove '-12' so '-24' take place of '-12'
                    // and if i++ it start checking from '-5' (one number after previous index), if previous index have negative value it remain
                    // in list.
                    // So i subtract 1 from 'i' so that if again check which value come in current index 
                    i--;
                }
            }

            //display the list after removing negative number
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }










        /// Part 4:
        /// <summary>
        /// Return Longest subsequence of enqual number in List<int>
        /// </summary>
        /// <returns>Return list</returns>
        public List<int> LongestSubsequenceOfEqualNumber(params int[] arrNumbers)
        {
            List<int> number = new List<int>();
            //for (int i = 0; i < arrNumbers.Length; i++)
            //{
            //    number.Add(arrNumbers[i]);
            //}
            // same as above
            number.AddRange(arrNumbers);
            int count = 0;
            int maxcount = 0;
            int num = 0;

            for (int i = 0; i < number.Count; i++)
            {
                for (int j = 0; j < number.Count; j++)
                {
                    if (i != j)
                    {
                        if (number[i] == number[j])
                        {
                            count++;
                            if (maxcount < count)
                            {
                                maxcount = count;
                                num = number[i];
                            }
                        }
                    }
                }
                count = 0;
            }
            number.Clear();
            while (maxcount + 1 > 0)
            {
                number.Add(num);
                maxcount--;
            }
            return number;
        }



        ///  part 1
        ///  <summary>
        /// Read sequence of positive integer number, stop when empty line is enter and print sum and avg of sequence!!
        /// </summary>
        public void SumOfList()
        {
            List<int> numbers = new List<int>();
            int sum = 0;
            Console.WriteLine("Enter numbers : ");
            string userinput = Console.ReadLine();
            while (!string.IsNullOrEmpty(userinput))
            {
                int num = int.Parse(userinput);
                sum += num;
                numbers.Add(num);
                userinput = Console.ReadLine();
            }
            Console.WriteLine("Sum of sequence is " + sum);
            if (sum != 0)
            {
                Console.WriteLine("Average of sequence is " + (sum / numbers.Count));
                //Console.WriteLine(numbers.Average()); //built-in method
            }
            else
            {
                throw new DivideByZeroException("There are no element in the list!");
            }
            //part 3: Sort the positive integer and print it
            numbers.Sort();
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }



    }
}
