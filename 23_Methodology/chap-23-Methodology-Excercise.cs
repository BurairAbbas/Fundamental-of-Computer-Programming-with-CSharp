using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Chap23MethodolologyProblemSolving
{
    class Excercise
    {
        public static void MainEx()
        {
            Excercise ex = new Excercise();
            //ex.Find2DLines();

            // Limitation: Can't take less than k=3  
            //int[] arr = {2, 5, 3, 4};
            //int k = 3;

            //ex.AlternativeSequence(arr, k);

            // print path is incomplete

            SampleMapGraph map = new SampleMapGraph();
            //map.AddCrossRoadsAndLength('A', 'B', 10);
            //map.AddCrossRoadsAndLength('A', 'C', 12);
            //map.AddCrossRoadsAndLength('A', 'D', 12);
            //map.AddCrossRoadsAndLength('B' , 'A', 10);
            //map.AddCrossRoadsAndLength('B', 'C', 5);
            //map.AddCrossRoadsAndLength('B', 'D', 8);
            //map.AddCrossRoadsAndLength('B', 'E', 20);
            //map.AddCrossRoadsAndLength('C' , 'A', 12);
            //map.AddCrossRoadsAndLength('C' , 'B', 5);
            //map.AddCrossRoadsAndLength('C', 'E', 10);
            //map.AddCrossRoadsAndLength('D', 'E', 12);
            //map.AddCrossRoadsAndLength('D' , 'A', 12);
            //map.AddCrossRoadsAndLength('D' , 'B', 8);
            //map.AddCrossRoadsAndLength('E' , 'B', 20);
            //map.AddCrossRoadsAndLength('E' , 'C', 10);
            //map.AddCrossRoadsAndLength('E' , 'D', 12);



            map.AddCrossRoadsAndLength('A', 'B', 20);
            map.AddCrossRoadsAndLength('A', 'H', 30);

            map.AddCrossRoadsAndLength('B', 'C', 30);
            map.AddCrossRoadsAndLength('B', 'H', 5);
            map.AddCrossRoadsAndLength('B', 'J', 10);
            map.AddCrossRoadsAndLength('B', 'A', 20);

            map.AddCrossRoadsAndLength('C', 'E', 15);
            map.AddCrossRoadsAndLength('C', 'F', 10);
            map.AddCrossRoadsAndLength('C', 'H', 25);
            map.AddCrossRoadsAndLength('C', 'J', 15);
            map.AddCrossRoadsAndLength('C', 'B', 30);

            map.AddCrossRoadsAndLength('D', 'E', 40);
            map.AddCrossRoadsAndLength('D', 'F', 15);
            map.AddCrossRoadsAndLength('D', 'I', 5);

            map.AddCrossRoadsAndLength('E', 'H', 10);
            map.AddCrossRoadsAndLength('E', 'F', 25);
            map.AddCrossRoadsAndLength('E', 'I', 45);
            map.AddCrossRoadsAndLength('E', 'G', 20);
            map.AddCrossRoadsAndLength('E', 'D', 40);
            map.AddCrossRoadsAndLength('E', 'C', 15);

            map.AddCrossRoadsAndLength('F', 'C', 10);
            map.AddCrossRoadsAndLength('F', 'E', 25);
            map.AddCrossRoadsAndLength('F', 'J', 30);
            map.AddCrossRoadsAndLength('F', 'D', 15);

            map.AddCrossRoadsAndLength('G', 'I', 20);
            map.AddCrossRoadsAndLength('G', 'E', 20);
            map.AddCrossRoadsAndLength('G', 'H', 25);

            map.AddCrossRoadsAndLength('H', 'A', 30);
            map.AddCrossRoadsAndLength('H', 'B', 5);
            map.AddCrossRoadsAndLength('H', 'C', 25);
            map.AddCrossRoadsAndLength('H', 'E', 10);
            map.AddCrossRoadsAndLength('H', 'G', 25);

            map.AddCrossRoadsAndLength('I', 'G', 20);
            map.AddCrossRoadsAndLength('I', 'E', 45);
            map.AddCrossRoadsAndLength('I', 'D', 5);

            map.AddCrossRoadsAndLength('J', 'B', 10);
            map.AddCrossRoadsAndLength('J', 'C', 15);
            map.AddCrossRoadsAndLength('J', 'F', 30);
           

            //map.AddCrossRoadsAndLength('A' , 'B', 12 );
            //map.AddCrossRoadsAndLength('A' , 'C', 5);
            //map.AddCrossRoadsAndLength('B' , 'A', 12);
            //map.AddCrossRoadsAndLength('B' , 'C', 5);
            //map.AddCrossRoadsAndLength('B' , 'D', 3);
            //map.AddCrossRoadsAndLength('C' , 'A', 5);
            //map.AddCrossRoadsAndLength('C' , 'B', 5);
            //map.AddCrossRoadsAndLength('C' , 'D', 10);
            //map.AddCrossRoadsAndLength('D' , 'B', 3);
            //map.AddCrossRoadsAndLength('D' , 'C', 10);


            Console.WriteLine("Shortest Distance: " + map.FindShortestDistance('A', 'M'));

        }

        //Part 1: find all horizontal and vertical lines on N points 
        public void Find2DLines()
        {
            FindLines();
            TestSinglePointLine();
            TestEmptyPointLine();
            Test90000PointLine();
            TestPointOnHorizontalLine();
            TestPointOnVerticalLine();
        }

        public void FindLines()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point() { X_Coordinate = 1, Y_Coordinate = 1 });
            points.Add(new Point() { X_Coordinate = 2, Y_Coordinate = 2 });
            points.Add(new Point() { X_Coordinate = 3, Y_Coordinate = 3 });
            points.Add(new Point() { X_Coordinate = 4, Y_Coordinate = 4 });
            points.Add(new Point() { X_Coordinate = 0, Y_Coordinate = 2 });
            PrintLineCoordinates(points);

            List<int> horizontalLines = FindAllHorizontalLines(points);
            List<int> verticalLines = FindAllVerticalLines(points);

            Console.Write("Horizontal Lines: ");
            PrintAllLines(horizontalLines);

            Console.Write("Vertical Lines: ");
            PrintAllLines(verticalLines);

        }
        public void TestSinglePointLine()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point() { X_Coordinate = 5, Y_Coordinate = 6 });
            PrintLineCoordinates(points);

            List<int> horizontalLines = FindAllHorizontalLines(points);
            List<int> verticalLines = FindAllVerticalLines(points);

            Console.Write("Horizontal Lines: ");
            PrintAllLines(horizontalLines);

            Console.Write("Vertical Lines: ");
            PrintAllLines(verticalLines);

        }
        public void TestEmptyPointLine()
        {
            List<Point> points = new List<Point>();
            PrintLineCoordinates(points);

            List<int> horizontalLines = FindAllHorizontalLines(points);
            List<int> verticalLines = FindAllVerticalLines(points);

            Console.Write("Horizontal Lines: ");
            PrintAllLines(horizontalLines);

            Console.Write("Vertical Lines: ");
            PrintAllLines(verticalLines);
        }
        public void Test90000PointLine()
        {
            List<Point> points = new List<Point>();
            Random rnd = new Random();

            for (int i = 0; i < 90000; i++)
            {
                points.Add(new Point() { X_Coordinate = rnd.Next(100), Y_Coordinate = rnd.Next(100) });
            }

            DateTime startTime = DateTime.Now;
            List<int> horizontalLines = FindAllHorizontalLines(points);
            List<int> verticalLines = FindAllVerticalLines(points);

            Console.Write("Horizontal Lines: ");
            PrintAllLines(horizontalLines);

            Console.Write("Vertical Lines: ");
            PrintAllLines(verticalLines);
            Console.WriteLine("Execute Time: {0}", DateTime.Now - startTime);

        }
        public void TestPointOnHorizontalLine()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point() { X_Coordinate = 2, Y_Coordinate = 3 });
            points.Add(new Point() { X_Coordinate = 4, Y_Coordinate = 3 });
            points.Add(new Point() { X_Coordinate = 5, Y_Coordinate = 3 });
            points.Add(new Point() { X_Coordinate = 6, Y_Coordinate = 3 });
            PrintLineCoordinates(points);

            List<int> horizontalLines = FindAllHorizontalLines(points);
            List<int> verticalLines = FindAllVerticalLines(points);

            Console.Write("Horizontal Lines: ");
            PrintAllLines(horizontalLines);

            Console.Write("Vertical Lines: ");
            PrintAllLines(verticalLines);
        }
        public void TestPointOnVerticalLine()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point() { X_Coordinate = 2, Y_Coordinate = 3 });
            points.Add(new Point() { X_Coordinate = 2, Y_Coordinate = 6 });
            points.Add(new Point() { X_Coordinate = 2, Y_Coordinate = 7 });
            points.Add(new Point() { X_Coordinate = 2, Y_Coordinate = 8 });
            PrintLineCoordinates(points);

            List<int> horizontalLines = FindAllHorizontalLines(points);
            List<int> verticalLines = FindAllVerticalLines(points);

            Console.Write("Horizontal Lines: ");
            PrintAllLines(horizontalLines);

            Console.Write("Vertical Lines: ");
            PrintAllLines(verticalLines);
        }

        private void PrintLineCoordinates(List<Point> points)
        {
            if (points.Count > 0)
            {
                Console.WriteLine("Points: ");
                foreach (Point point in points)
                {
                    Console.Write(point);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No Coordinates of point");
            }
        }

        private int FindSingleHorizontalLine(Point point)
        {
            if (point != null)
            {
                int horitonalLine = point.Y_Coordinate;
                return horitonalLine;
            }
            return 0;
        }

        public void PrintAllLines(List<int> lines)
        {
            foreach (int line in lines)
            {
                Console.Write(line + " ");
            }
            Console.WriteLine();
        }

        private int FindSingleVerticalLine(Point point)
        {
            if (point != null)
            {
                int verticalLines = point.X_Coordinate;
                return verticalLines;
            }
            return 0;
        }

        public List<int> FindAllHorizontalLines(List<Point> points)
        {
            List<int> allHoritonalLines = new List<int>();
            foreach (Point point in points)
            {
                if (!allHoritonalLines.Contains(point.Y_Coordinate))
                {
                    allHoritonalLines.Add(FindSingleHorizontalLine(point));
                }
            }
            return allHoritonalLines;
        }

        public List<int> FindAllVerticalLines(List<Point> points)
        {
            List<int> allVerticalLines = new List<int>();
            foreach (Point point in points)
            {
                if (!allVerticalLines.Contains(point.X_Coordinate))
                {
                    allVerticalLines.Add(FindSingleVerticalLine(point));
                }
            }
            return allVerticalLines;
        }

        //Part 2: Aternative sequence 
        static void PrintSequence(List<int[]> sets)
        {
            foreach (var set in sets)
            {
                Console.Write("{");
                for (int i = 0; i < set.Length; i++)
                {
                    if (i != set.Length - 1)
                        Console.Write(set[i]);
                    else
                        Console.Write(set[i]);
                }
                Console.Write("}");
                Console.WriteLine();
            }
            Console.WriteLine("Total Number: " + sets.Count);
        }
        /// <summary>
        ///  Create all the possible combination of positive interger values
        /// </summary>
        /// <param name="arr">positive value given by user</param>
        /// <param name="data">temporary variable to store one by one every sequence</param>
        /// <param name="index">smooth flow for 'data' variable</param>
        /// <param name="r">contain 'r' different element in one sequence </param>
        /// <param name="possibleCombination">store every sequence in this variable</param>
        static void combinationUtil(int[] arr, int[] data, int index,
            int r, List<int[]> possibleCombination)
        {
            if (index == r)
            {
                /// replacing 'data' value in temporay array. if data value change becz of recursion it doesn't change my possibleCombination
                int[] replaceAddress = new int[r];
                for (int i = 0; i < r; i++)
                {
                    replaceAddress[i] = data[i];
                    // to get the possible value 
                    if (i == r - 1)
                        data[i] = 0;
                }
                possibleCombination.Add(replaceAddress);
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (!data.Contains(arr[i]) || index == 0)
                {
                    data[index] = arr[i];
                    combinationUtil(arr, data,
                                    index + 1, r, possibleCombination);
                }
            }
        }

        public void AlternativeSequence(int[] arr, int k)
        {
            // A temporary array to store  
            // all combination one by one 
            int[] data = new int[k];

            // List of all the temporary combinations
            List<int[]> possibleCombition = new List<int[]>();

            Array.Sort(arr);
            combinationUtil(arr, data,
                            0, k, possibleCombition);


            PrintSequence(possibleCombition);
            DateTime startTime = DateTime.Now;
            List<int[]> alternatSeq = new List<int[]>();
            foreach (var item in possibleCombition)
            {
                CheckAlternativeSequence(possibleCombition, item, alternatSeq);
            }
            Console.WriteLine("\n\n\n  {0}", DateTime.Now - startTime);
            PrintSequence(alternatSeq);
        }

        static void CheckAlternativeSequence(List<int[]> possibleCombination, int[] sequence,
            List<int[]> alternativeSequence)
        {
            for (int i = 0; i < sequence.Length - 2; i++)
            {
                // checking Ascending to Descending
                if ((sequence[i] < sequence[i + 1] && sequence[i + 1] > sequence[i + 2]))
                {
                    if (i == sequence.Length - 3)
                        alternativeSequence.Add(sequence);
                }
                // checking Descening to Ascending
                else if ((sequence[i] > sequence[i + 1] && sequence[i + 1] < sequence[i + 2]))
                {
                    if (i == sequence.Length - 3)
                        alternativeSequence.Add(sequence);
                }
            }
        }

        public void ReadTextFile()
        {
            using(StreamReader reader = new StreamReader("Map.txt"))
            {
                string str = reader.ReadToEnd();
                Console.WriteLine(str);
            }
        }
    }

    class Point
    {
        public int X_Coordinate { get; set; }
        public int Y_Coordinate { get; set; }

        public override string ToString()
        {
            return "(" + this.X_Coordinate + "," + this.Y_Coordinate + ")";
        }
    }

    class SampleMapGraph
    {
        private List<char>[] sampleMap;
        private int[,] length;
        private bool[] visited;
        private Stack<int> distanceStack;
        private Stack<char> pathStack;

        public SampleMapGraph()
        {
            this.sampleMap = new List<char>[100];
            this.length = new int[100, 100];
            this.visited = new bool[100];
            this.distanceStack = new Stack<int>();
            this.distanceStack.Push(0); // to resolve stack empty error
            this.pathStack = new Stack<char>();
            this.pathStack.Push(' ');
            for (int i = 0; i < 100; i++)
            {
                this.sampleMap[i] = new List<char>();
            }
        }

        public void AddCrossRoadsAndLength(char road1, char road2, int length)
        {
            this.sampleMap[road1].Add(road2);
            this.length[road1, road2] = length;
        }

        private int shortestDistance = int.MaxValue;
        private int distance = 0;
        public int FindShortestDistance(char firstRoad, char lastRoad)
        {
            if (!visited[firstRoad])
            {
                visited[firstRoad] = true;

                foreach (var road in sampleMap[firstRoad])
                {
                    if (!visited[road]) // if road is not visited than it proceed with it otherwise leave it
                    {
                        distance += length[firstRoad, road];
                        this.distanceStack.Push(length[firstRoad, road]);
                        if (road != lastRoad)
                        {
                            FindShortestDistance(road, lastRoad);
                        }
                        else
                        {
                            if (shortestDistance > distance)
                                shortestDistance = distance;
                            distance -= this.distanceStack.Pop();
                        }
                    }
                }
                visited[firstRoad] = false;
                distance -= this.distanceStack.Pop();
            }
            return shortestDistance;
        }


        public void Print(char road)
        {
            //if (!visited[road])
            //{
            //    visited[road] = true;
            //    //Console.Write(road);
            //    foreach (var relatedRoad in sampleMap[road])
            //    {
            //        Console.Write(road + "" + relatedRoad + " " + length[road, relatedRoad]);
            //        Console.WriteLine();
            //        Print(relatedRoad);
            //    }
            //}
        }

    }
}
