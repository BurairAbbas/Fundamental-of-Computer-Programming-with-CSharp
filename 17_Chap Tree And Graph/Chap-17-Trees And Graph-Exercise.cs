using System;
using System.Collections.Generic;
using System.IO;

namespace Chap17TreesAndGraphs
{
    // Incompleted Parts Are: 14,15,16,17,18 
    class Exercise
    {
        // Practice before practice
        int age;
        string name;

        public Exercise()
            : this(0)
        {
        }
        public Exercise(int age)
            : this(age, null)
        {
        }
        public Exercise(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public void Print()
        {
            Console.WriteLine(age + " " + name);
        }

        public void CheckCondition(int a)
        {
            if (a > 0)
            {
                Console.WriteLine("a = " + (a + 1));
            }
            else if (a > 10)
            {
                Console.WriteLine("a + " + (a + 1));
            }
            else if (a > 100)
            {
                Console.WriteLine("a = " + (a + 1));
            }
            else if (a > 1000)
            {
                Console.WriteLine("a = " + (a + 1));
            }
        }

        public void CompareToMethod(int value, int value2)
        {
            int compareTo = value.CompareTo(value2);
            Console.WriteLine(compareTo);

            //List<string> str = new List<string>();
            List<int> i = new List<int>();
            //str.Add("string");
            //i.Add(1);
            //for (int j = 0; j < str.Count; j++)
            //{
            //    Console.WriteLine("str = " + str[j] + "weight = " + i[j]);
            //}
            i = new List<int>() { 2, 3, 4, 5 };
            foreach (var item in i)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// part 1: number of occurrence number in a tree
        /// part 2: show root of sub-tree having exactly k node, k is integer 
        /// </summary>
        class TreeFindOccurrenceNumber
        {
            /// <summary>
            /// Class that have value of tree root and his child
            /// </summary>
            internal class TreeChild
            {
                int value;
                public int Value
                {
                    get { return this.value; }
                    set { this.value = value; }
                }
                public List<TreeChild> childNode = new List<TreeChild>();

                public TreeChild(int value)
                {
                    this.value = value;
                }

                public void AddChild(TreeChild node)
                {
                    this.childNode.Add(node);
                }

                public TreeChild getChild(int index)
                {
                    return childNode[index];
                }

                public int Size
                {
                    get { return this.childNode.Count; }
                }

            }

            TreeChild root;
            // add value in the root
            public TreeFindOccurrenceNumber(int value)
            {
                this.root = new TreeChild(value);
            }
            // add value in the root and add children of the root
            public TreeFindOccurrenceNumber(int value, params TreeFindOccurrenceNumber[] children)
            {
                this.root = new TreeChild(value);
                foreach (TreeFindOccurrenceNumber child in children)
                {
                    this.root.AddChild(child.root);
                }
            }
            public TreeChild Root
            {
                get { return this.root; }
            }

            public void PrintDFS(TreeChild root, string space)
            {
                Console.WriteLine(space + root.Value);
                for (int i = 0; i < root.Size; i++)
                {
                    //get the children of the node
                    PrintDFS(root.getChild(i), space + " ");
                }
            }
            int count = 0;
            /// <summary>
            /// Find the given number in the tree
            /// </summary>
            /// <param name="value">the given number</param>
            public void NumberOfOccurrence(int value)
            {
                NumberOfOccurrence(value, this.root);
                Console.WriteLine("Number of times " + value + " occurrence in tree: " + count);
            }

            /// <summary>
            /// Find the given value in a tree
            /// </summary>
            /// <param name="value">the given value</param>
            /// <param name="node">root of the tree</param>
            private void NumberOfOccurrence(int value, TreeChild node)
            {
                if (value == node.Value)
                {
                    count++;
                }
                // to traverse all the node child
                for (int i = 0; i < node.Size; i++)
                {
                    NumberOfOccurrence(value, node.getChild(i));
                }
            }

            /// <summary> part 2:
            /// show node having k number of children
            /// </summary>
            /// <param name="k">number of children</param>
            public void ShowNodeOf(int k)
            {
                Console.Write("Number of nodes with " + k + " child : ");
                ShowNodeOf(k, this.root);
            }

            private void ShowNodeOf(int k, TreeChild node)
            {
                if (k == node.childNode.Count)
                {
                    Console.Write(node.Value + " ");
                }
                for (int i = 0; i < node.Size; i++)
                {
                    ShowNodeOf(k, node.getChild(i));
                }
            }

            /// <summary> part 3:
            /// Display number of leaf in the tree
            /// </summary>
            /// <returns>Return number of leaf in tree</returns>
            public void NumberOfLeaf()
            {
                Console.WriteLine("Number of leaf: " + NumberOfLeaf(this.root));
            }

            // count number of leaf in the tree
            int numberOfLeaf = 0;
            private int NumberOfLeaf(TreeChild node)
            {
                if (node.childNode.Count == 0)
                {
                    numberOfLeaf++;
                }
                for (int i = 0; i < node.Size; i++)
                {
                    NumberOfLeaf(node.getChild(i));
                }
                return numberOfLeaf;
            }

            /// <summary> part 3:
            /// Display number of internal vertices in a tree
            /// </summary>
            public void NumberOfInternalNodes()
            {
                Console.WriteLine("Number of internal nodes in tree: " + NumberOfInternalNodes(this.root));
            }

            //count number of number of vertices
            int numberOfVertices = 0;
            private int NumberOfInternalNodes(TreeChild node)
            {
                if (node.childNode.Count != 0 && node != this.root)
                {
                    numberOfVertices++;
                }
                for (int i = 0; i < node.Size; i++)
                {
                    NumberOfInternalNodes(node.getChild(i));
                }
                return numberOfVertices;
            }

            /// <summary> part 4:
            /// Return sum of the vertices in a tree
            /// </summary>
            /// <returns>Return sum of vertices</returns>
            public void SumOfVerticesatEachLevel()
            {
                numberOfVertices = 0;
                numberOfLeaf = 0;
                SumOfNodes(this.root);
                Console.WriteLine("Sum of vertices at level 1: " + numberOfVertices);
                Console.WriteLine("Sum of vertices at level 2: " + numberOfLeaf);
            }

            private void SumOfNodes(TreeChild node)
            {
                if (node.childNode.Count != 0 && node != this.root)
                {
                    numberOfVertices += node.Value;
                }
                if (node.childNode.Count == 0)
                {
                    numberOfLeaf += node.Value;
                }
                for (int i = 0; i < node.Size; i++)
                {
                    SumOfNodes(node.getChild(i));
                }
            }

            /// <summary> part 5:
            /// print the vertices of a tree having leave successors
            /// </summary>
            public void PrintVertices(TreeChild node)
            {
                if (node.childNode.Count != 0 && node != this.root)
                {
                    Console.Write(node.Value + " ");
                }
                for (int i = 0; i < node.Size; i++)
                {
                    PrintVertices(node.getChild(i));
                }
            }
        }

        class BinaryTreeEx
        {
            int Value { get; set; }
            BinaryTreeEx leftNode;
            BinaryTreeEx rightNode;

            public BinaryTreeEx(int value)
                : this(value, null, null)
            { }

            public BinaryTreeEx(int value, BinaryTreeEx LN, BinaryTreeEx RN)
            {
                this.Value = value;
                this.leftNode = LN;
                this.rightNode = RN;
            }

            public void PrintDFS(BinaryTreeEx node, string space)
            {
                Console.WriteLine(space + node.Value);
                if (node.leftNode != null)
                {
                    PrintDFS(node.leftNode, space + " ");
                }
                if (node.rightNode != null)
                {
                    PrintDFS(node.rightNode, space + " ");
                }
            }

            int LeftSubtreeHeight = 0;
            int rightSubtreeHeight = 0;
            // part 6: tells that binary tree is prefectly balanced: copied from Greekforgreek
            public bool IsBalanced(BinaryTreeEx node)
            {
                if (node == null)
                {
                    return true;
                }

                LeftSubtreeHeight = Height(node.leftNode);
                rightSubtreeHeight = Height(node.rightNode);

                if (Math.Abs(LeftSubtreeHeight - rightSubtreeHeight) <= 1)
                {
                    return true;
                }
                return false;
            }

            private int Height(BinaryTreeEx node)
            {
                if (node == null)
                {
                    return 0;
                }
                return 1 + Math.Max(Height(node.leftNode), Height(node.rightNode));
            }

        }

        class Graph
        {
            int[,] weight;
            List<int>[] childNode;
            public bool[] visited;
            public Graph(int size)
            {
                childNode = new List<int>[size];
                weight = new int[size, size];
                visited = new bool[size];
                for (int i = 0; i < size; i++)
                {
                    this.childNode[i] = new List<int>();
                }
            }

            /// <summary>
            /// Adding egde in the graph
            /// </summary>
            /// <param name="u"> starting egde</param>
            /// <param name="v"> ending egde</param>
            public void AddEgde(int u, int v, int weight)
            {
                childNode[u].Add(v);
                this.weight[u, v] = weight;
            }

            public void Remove(int u, int v)
            {
                childNode[u].Remove(v);
                weight[u, v] = 0;
            }

            /// <summary>
            /// part 7: find the shortest distance between two vertices for directed note
            /// </summary>
            int shortestDistance = int.MaxValue;
            int distance = 0;
            public int ShortestDistance(int startNode, int endNode)
            {
                // to get the childNode of starting node of graph
                foreach (int item in childNode[startNode])
                {
                    distance += this.weight[startNode, item];
                    if (item != endNode)
                    {
                        // recursion untill child of any node equal to end node given by user
                        ShortestDistance(item, endNode);
                        if (shortestDistance > distance && distance != 0)
                        {
                            shortestDistance = distance;
                            distance = 0;
                        }
                    }
                    else
                    {
                        return distance;
                    }
                }
                return shortestDistance;
            }

            //part 9: Traverse the undirected graph
            public void Print(int u)
            {
                if (!visited[u])
                {
                    visited[u] = true;
                    Console.Write(u + " ");
                    foreach (int item in childNode[u])
                    {
                        Print(item);
                    }
                }
            }

            //psrt 10: traverse with BFS
            public void PrintBFS(int u)
            {
                Queue<int> visistedNode = new Queue<int>();
                visistedNode.Enqueue(u);
                while (visistedNode.Count > 0)
                {
                    int currentValue = visistedNode.Dequeue();
                    Console.WriteLine(currentValue + " ");

                    foreach (int item in childNode[currentValue])
                    {
                        visistedNode.Enqueue(item);
                    }
                }

            }

            bool found = false;

            //part 8: Is graph cyclic
            public bool IsGraphCyclic(int node)
            {
                foreach (var item in childNode[node])
                {
                    if (visited[item])
                    {
                        visited[item] = false;
                        if (item == 1)
                        {
                            found = true;
                        }
                        IsGraphCyclic(item);
                    }
                }
                return found;
            }
        }

        public static void MainEx()
        {
            // part 1 to 5
            //TreeFindOccurrenceNumber trees = new TreeFindOccurrenceNumber(2,
            //    new TreeFindOccurrenceNumber(3,
            //       new TreeFindOccurrenceNumber(4),
            //       new TreeFindOccurrenceNumber(5),
            //       new TreeFindOccurrenceNumber(6),
            //       new TreeFindOccurrenceNumber(2)),
            //new TreeFindOccurrenceNumber(8,
            //    new TreeFindOccurrenceNumber(2),
            //    new TreeFindOccurrenceNumber(5),
            //    new TreeFindOccurrenceNumber(10),
            //    new TreeFindOccurrenceNumber(5)),
            //new TreeFindOccurrenceNumber(5,
            //    new TreeFindOccurrenceNumber(8),
            //    new TreeFindOccurrenceNumber(9),
            //    new TreeFindOccurrenceNumber(2),
            //    new TreeFindOccurrenceNumber(3)),
            //new TreeFindOccurrenceNumber(4,
            //    new TreeFindOccurrenceNumber(2),
            //    new TreeFindOccurrenceNumber(3)),
            //    new TreeFindOccurrenceNumber(10,
            //        new TreeFindOccurrenceNumber(11),
            //        new TreeFindOccurrenceNumber(15)),
            //    new TreeFindOccurrenceNumber(13)
            //        );
            //trees.PrintDFS(trees.Root, string.Empty);
            //trees.NumberOfOccurrence(15);
            //trees.ShowNodeOf(2);
            //Console.WriteLine();
            //trees.NumberOfLeaf();
            //trees.NumberOfInternalNodes();
            //trees.SumOfVerticesatEachLevel();
            //trees.PrintVertices(trees.Root);
            //Console.WriteLine();

            //BinaryTreeEx bt = new BinaryTreeEx(17,
            //    new BinaryTreeEx(9,
            //        new BinaryTreeEx(6),
            //        new BinaryTreeEx(5)),
            //    new BinaryTreeEx(15,
            //        new BinaryTreeEx(8),
            //        new BinaryTreeEx(10,
            //            new BinaryTreeEx(14),
            //            new BinaryTreeEx(15,
            //                null,
            //                new BinaryTreeEx(20))
            //                ))
            //        );

            //bt.PrintDFS(bt, string.Empty);
            //Console.WriteLine(bt.IsBalanced(bt));

            Graph g = new Graph(10);
            // checking for shortest distance
            g.AddEgde(1, 2, 10);
            g.AddEgde(1, 3, 12);
            g.AddEgde(2, 3, 5);
            g.AddEgde(2, 4, 3);
            g.AddEgde(3, 5, 10);
            g.AddEgde(4, 5, 7);

            //g.AddEgde(1, 2, 3);
            //g.AddEgde(2, 3, 2);
            //g.AddEgde(3, 4, 2);
            //g.AddEgde(1, 6, 3);
            //g.AddEgde(6, 5, 4);
            //g.AddEgde(5, 4, 2);
            //g.AddEgde(0, 7, 4);
            //g.AddEgde(8, 0, 0);
            //g.AddEgde(4, 5, 2);
            //g.AddEgde(5, 6, 4);
            //g.AddEgde(6, 1, 3);

            //for (int i = 0; i < 10; i++)
            //{
            //    if (!g.visited[i])
            //    {
            //        g.Print(i);
            //        Console.WriteLine();
            //    }                
            //}
            //Console.WriteLine();
            Console.WriteLine("Shortest Distances form 1 to 4 is: " + g.ShortestDistance(1, 5));
            //Console.WriteLine(g.IsGraphCyclic(1));
            //g.PrintBFS(1);

            //DirectoryTraverseDFSEnternsionEXE.TraverseDir(@"C:\Windows"); // take to long to print all seriously 

            // part 12: after 1 whole day aprrox. 7 to 8 hours
            //TreeForFolder tf = new TreeForFolder();
            //tf.TraverseDir(@"E:\download\season");
            //tf.PrintDFS(tf.root, string.Empty);
            //Console.WriteLine("File Size of this folder: " + tf.FileSize);

            // find loop of only one (root) vertices
            //DirectedGraphLoopFinded graph = new DirectedGraphLoopFinded(7);
            //graph.root.AddEgde(1, 2);
            //graph.root.AddEgde(2, 3);
            //graph.root.AddEgde(3, 4);
            //graph.root.AddEgde(3, 6);
            //graph.root.AddEgde(4, 5);
            //graph.root.AddEgde(5, 6);
            //graph.root.AddEgde(2, 6);
            //graph.root.AddEgde(6, 1);
            //graph.PrintGraph(1);
            //Console.WriteLine();
            //Console.WriteLine("Number of loop in graph: " + graph.LoopFinded);


        }
    }
    /// <summary>
    /// Find the maximal connected sub graph in the graph!!
    /// </summary>
    public class MaximalConnectedSubGraph
    {
        private class GraphNode
        {
            public List<int>[] childNode;

            public GraphNode(int size)
            {
                childNode = new List<int>[size];
                for (int i = 0; i < size; i++)
                {
                    childNode[i] = new List<int>();
                }
            }

            public void AddEgde(int u, int v)
            {
                childNode[u].Add(v);
            }

            public IList<int> GetSuccessor(int index)
            {
                return childNode[index];
            }

            public int Size { get { return this.childNode.Length; } }
        }

        GraphNode root;
        bool[] visited;

        public MaximalConnectedSubGraph(int size)
        {
            root = new GraphNode(size);
            visited = new bool[size];
        }

        int[] MaximalSubgraph = new int[3];
        List<int>[] vertices = new List<int>[7];
        int temp = 0;
        private void TraverseGraph(int u, List<int> vertices)
        {
            
            if (!visited[u])
            {
                Console.Write(u + " ");
                visited[u] = true;
                if (!vertices.Contains(u))
                    vertices.Add(u);
                foreach (int child in root.GetSuccessor(u))
                {
                    vertices.Add(child);
                    TraverseGraph(child, vertices);
                }
            }
        }

        public void PrintGraph()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = new List<int>();
            }
            Console.WriteLine("Connected Graph: ");
            for (int i = 0; i < root.Size; i++)
            {
                if (!visited[i])
                {
                   
                    TraverseGraph(i, this.vertices[i]);
                }
            }
        }

    }


    /// <summary> Not calculate all the loop in the graph, only the loop end on specific given number
    /// part 13: Find loop in the directed graph
    /// </summary>
    public class DirectedGraphLoopFinded
    {
        public class GraphNode
        {
            List<int>[] childNode;

            public GraphNode(int size)
            {
                childNode = new List<int>[size];
                for (int i = 0; i < size; i++)
                {
                    childNode[i] = new List<int>();
                }
            }

            public void AddEgde(int u, int v)
            {
                childNode[u].Add(v);
            }

            /// <summary> problem is: it get the starting index of array not Graph index which is root of graph
            /// To get the starting index of graph which is not null
            /// </summary>
            /// <returns>Return the index of arra</returns>
            public int GetStartValue()
            {
                int value = -1;
                for (int i = 0; i < childNode.Length; i++)
                {
                    if (childNode[i].Count != 0)
                    {
                        value = i;
                        break;
                    }
                }
                return value;
            }

            public IList<int> GetSuccessor(int index)
            {
                return childNode[index];
            }
        }

        public GraphNode root;
        public int LoopFinded { get; set; }
        public bool[,] visited;
        public DirectedGraphLoopFinded(int size)
        {
            this.root = new GraphNode(size);
            visited = new bool[size, size];
        }

        public void PrintGraph(int u)
        {
            foreach (int v in root.GetSuccessor(u))
            {
                // if vertices again pointed to the starting key of graph then to add one in loop field
                // only calculated loop of one vertices not all graph loops
                if (v == root.GetStartValue())
                {
                    LoopFinded++;
                }
                if (!visited[u, v])
                {
                    visited[u, v] = true;
                    Console.Write(u + "->" + v + " ");
                    PrintGraph(v);
                }
                else
                    return;
            }
        }
    }


    /// <summary> part 12:
    ///  File and Folder class and put all directory in these class and also calculate the size of file in it.
    /// </summary>
    public class MyFiles
    {
        public string name;
        public long size;

        public MyFiles() { }

    }
    public class MyFolder
    {
        public string name;
        public MyFiles[] files;
        public MyFolder[] childFolders;

        public MyFolder()
        {
        }

        public MyFolder(string name)
        {
            this.name = name;
        }

        public void AddMyFolderSize(int size)
        {
            childFolders = new MyFolder[size];
            for (int i = 0; i < size; i++)
            {
                childFolders[i] = new MyFolder();
            }
        }
        public void AddFileSize(int size)
        {
            files = new MyFiles[size];
            for (int i = 0; i < size; i++)
            {
                files[i] = new MyFiles();
            }
        }

        public MyFolder GetFolder(int index)
        {
            return childFolders[index];
        }
    }
    public class TreeForFolder
    {
        public MyFolder root;
        public TreeForFolder() { }

        private void TraverseDFS(DirectoryInfo dir)
        {
            try
            {
                // To get the subFolder of main directory
                DirectoryInfo[] children = dir.GetDirectories();
                root = new MyFolder(dir.FullName);

                // initialize the array length of MyFolder field in class
                this.root.AddMyFolderSize(children.Length);

                for (int i = 0; i < children.Length; i++)
                {
                    // get the name of folder in name field of MyFolder class
                    this.root.childFolders[i].name = root.name + "\\" + children[i].Name;

                    // get the files of sub-folder
                    FileInfo[] files = children[i].GetFiles();
                    this.root.childFolders[i].AddFileSize(files.Length);
                    for (int j = 0; j < files.Length; j++)
                    {
                        this.root.childFolders[i].files[j].name = files[j].ToString();
                        this.root.childFolders[i].files[j].size = files[j].Length;
                    }
                    //TraverseDFS(children[i]); // occurs problem but still i can solve this if instead of recursion we call other method who take the sub-folder of current folder and put in childfolder to current childfolder
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception Occurs");
            }
        }
        public void TraverseDir(string path)
        {
            TraverseDFS(new DirectoryInfo(path));
        }

        // to get the Size of all files from user given path folder
        ulong fileSize = 0;
        public void PrintDFS(MyFolder root, string space)
        {
            Console.WriteLine(space + root.name);
            if (root.childFolders == null) { return; }
            for (int i = 0; i < root.childFolders.Length; i++)
            {
                if (root.childFolders[i].files == null) { return; }
                for (int j = 0; j < root.childFolders[i].files.Length; j++)
                {
                    fileSize += (ulong)root.childFolders[i].files[j].size;
                    Console.WriteLine(root.childFolders[i].files[j].name);
                }
                PrintDFS(root.GetFolder(i), space + " ");
            }
        }
        /// <summary>
        /// Property to get the fileSize field 
        /// </summary>
        public ulong FileSize { get { return this.fileSize; } }

    }

    //part 11:
    public static class DirectoryTraverseDFSEnternsionEXE
    {
        /// <summary>part 11:
        /// Traverse and print the directory of given path
        /// </summary>
        /// <param name="dir">the directory to be traverse</param>
        /// <param name="space">represent the relation between parent and child</param>
        private static void TraverseDFS(DirectoryInfo dir, string space)
        {
            // to get the Directories of given folder
            DirectoryInfo[] children = dir.GetDirectories();
            foreach (DirectoryInfo child in children)
            {
                // to prevent the Exceptional of Unauthorized error
                try
                {
                    // get the file 'exe' extension
                    FileInfo[] file = child.GetFiles("*.exe");
                    foreach (FileInfo fileExe in file)
                    {
                        Console.WriteLine(fileExe + " ");
                    }
                    TraverseDFS(child, space + " ");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Unauthorized Access Exception");
                }
            }
        }

        public static void TraverseDir(string path)
        {
            TraverseDFS(new DirectoryInfo(path), string.Empty);
        }
    }

}
