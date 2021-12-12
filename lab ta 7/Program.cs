using System;
using System.Collections.Generic;
using System.IO;

namespace TA_7
{
    class Graph
    {
        class NodeData
        {
            private int index;
            public string data;
            public NodeData(string data, int index)
            {
                this.index = index;
                this.data = data;
            }
        }
        private List<NodeData> vertices;
        private int graphSize;
        private StreamReader sr;
        private int[,] adjMatrix;
        private const int infinity = 9999;
        public Graph()
        {
            vertices = new List<NodeData>();
            sr = new StreamReader("graph.txt");
            CreateGraph();
        }
        private void CreateGraph()
        {
            graphSize = Convert.ToInt32(sr.ReadLine()) + 1;
            adjMatrix = new int[graphSize, graphSize];
            for (int i = 0; i < graphSize; i++)
                adjMatrix[i, 0] = i;
            if (sr.EndOfStream)
                return;
            vertices.Add(new NodeData("    ", -1));
            for (int i = 1; i < graphSize; i++)
            {
                string[] line = sr.ReadLine().Split(',');
                vertices.Add(new NodeData(line[0], Convert.ToInt32(line[1])));
            }
            if (sr.EndOfStream)
                return;
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(',');
                int fromNode = Convert.ToInt32(line[0]);
                int toNode = Convert.ToInt32(line[1]);
                int cost = Convert.ToInt32(line[2]);
                AddEdge(fromNode, toNode, cost);
            }
        }
        public void RunDijkstra()
        {
            Console.WriteLine("\tDijkstra's Shortest Path");
            int[] distance = new int[graphSize];
            int[] previous = new int[graphSize];

            for (int source = 1; source < graphSize; source++)
            {
                for (int i = 1; i < graphSize; i++)
                {
                    distance[i] = infinity;
                    previous[i] = 0;
                }
                distance[source] = 0;
                PriorityQueue<int> pq = new PriorityQueue<int>();
                pq.Enqueue(source, adjMatrix[source, source]);
                for (int i = 1; i < graphSize; i++)
                {
                    for (int j = 1; j < graphSize; j++)
                    {
                        if (adjMatrix[i, j] > 0 && adjMatrix[i, j] != adjMatrix[source, source])
                            pq.Enqueue(i, adjMatrix[i, j]);
                    }
                }
                while (!pq.Empty())
                {
                    int u = pq.dequeue_min();

                    for (int v = 1; v < graphSize; v++)
                    {
                        if (adjMatrix[u, v] > 0)
                        {
                            int alt = distance[u] + adjMatrix[u, v];
                            if (alt < distance[v])
                            {
                                distance[v] = alt;
                                previous[v] = u;
                                pq.Enqueue(u, distance[v]);
                            }
                        }
                    }
                }
                for (int i = 1; i < graphSize; i++)
                {
                    if (distance[i] == infinity || distance[i] == 0)
                        Console.WriteLine($"Distance from {source} to {i}: --");
                    else
                        Console.WriteLine($"Distance from {source} to {i}: {distance[i]}");
                }
                Console.WriteLine();
                for (int i = 1; i < graphSize; i++)
                {
                    printPath(previous, source, i);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        private void printPath(int[] path, int start, int end)
        {
            Console.Write($"Shortest path from {start} to {end}: ");
            int temp = end;
            Stack<int> s = new Stack<int>();
            while (temp != start)
            {
                s.Push(temp);
                temp = path[temp];
                if (temp == 0)
                    break;
            }
            if (temp == 0 || start == end)
            {
                Console.Write("No path");
                s.Clear();
                return;
            }
            Console.Write($"{temp} ");
            while (s.Count != 0)
                Console.Write($"-> {s.Pop()} ");
        }
        public void AddEdge(int vertexA, int vertexB, int distance)
        {
            if (vertexA > 0 && vertexB > 0 && vertexA <= graphSize && vertexB <= graphSize)
                adjMatrix[vertexA, vertexB] = distance;
        }
        public void RemoveEdge(int vertexA, int vertexB)
        {
            if (vertexA > 0 && vertexB > 0 && vertexA <= graphSize && vertexB <= graphSize)
                adjMatrix[vertexA, vertexB] = 0;
        }
        public bool Adjacent(int vertexA, int vertexB)
        {
            return (adjMatrix[vertexA, vertexB] > 0);
        }
        public int length(int vertex_u, int vertex_v)
        {
            return adjMatrix[vertex_u, vertex_v];
        }
        public void Display()
        {
            Console.WriteLine("\tAdjacency Matrix Representation\n");
            Console.WriteLine($"Number of nodes: {graphSize - 1}\n");
            foreach (NodeData n in vertices)
                Console.Write($"{n.data}\t");
            Console.WriteLine();
            for (int i = 1; i < graphSize; i++)
            {
                Console.Write($"{vertices[adjMatrix[i, 0]].data}\t");
                for (int j = 1; j < graphSize; j++)
                    Console.Write($"{adjMatrix[i, j]}\t");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        private void DisplayNodeData(int v)
        {
            Console.WriteLine(vertices[v].data);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.Display();
            graph.RunDijkstra();
            Console.Read();
        }
    }

    class PriorityQueue<T>
    {
        class Node
        {
            public T data;
            public int priority;
            public static bool operator <(Node n1, Node n2)
            {
                return (n1.priority < n2.priority);
            }
            public static bool operator >(Node n1, Node n2)
            {
                return (n1.priority > n2.priority);
            }
            public static bool operator <=(Node n1, Node n2)
            {
                return (n1.priority <= n2.priority);
            }
            public static bool operator >=(Node n1, Node n2)
            {
                return (n1.priority >= n2.priority);
            }
            public static bool operator ==(Node n1, Node n2)
            {
                return (n1.priority == n2.priority && (dynamic)n1.data == (dynamic)n2.data);
            }
            public static bool operator !=(Node n1, Node n2)
            {
                return (n1.priority != n2.priority && (dynamic)n1.data != (dynamic)n2.data);
            }
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
        Node[] arr;
        private int count;
        private const int arrSize = 100;
        public PriorityQueue()
        {
            arr = new Node[arrSize];
            count = 0;
        }
        public void Enqueue(T nData, int priority)
        {
            Node nObj = new Node();
            nObj.data = nData;
            nObj.priority = priority;
            if (count == arr.Length)
            {
                throw new Exception("Priority Queue is at full capacity");
            }
            else
            {
                arr[count] = nObj;
                count++;
                siftUp(count - 1);
            }
        }
        private void siftUp(int index)
        {
            int parentIndex;
            Node temp;
            if (index != 0)
            {
                parentIndex = getParentIndex(index);
                if (arr[parentIndex] > arr[index])
                {
                    temp = arr[parentIndex];
                    arr[parentIndex] = arr[index];
                    arr[index] = temp;
                    siftUp(parentIndex);
                }
            }
        }
        private int getParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        public void decrease_priority(T target, int newPriority)
        {
            //find the target first
            Node n = new Node();
            n.data = target;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == n)
                {
                    if (newPriority > arr[i].priority)
                    {
                        throw new Exception("New priority assignment must be less than current priority");
                    }
                    else
                    {
                        arr[i].priority = newPriority;
                        siftUp(i);
                    }
                    break;
                }
            }
        }
        public T dequeue_min()
        {
            Node nObj;
            if (count == 0)
            {
                throw new Exception("Priority Queue is empty");
            }
            else
            {
                nObj = arr[0];
                arr[0] = arr[count - 1];
                count--;
                if (count > 0)
                {
                    siftDown(0);
                }
            }
            arr[count] = null;
            return nObj.data;
        }
        public void siftDown(int nodeIndex)
        {
            int leftChildIndex, rightChildIndex, minIndex;
            Node temp;
            leftChildIndex = getLeftChildIndex(nodeIndex);
            rightChildIndex = getRightChildIndex(nodeIndex);
            if (rightChildIndex >= count)
            {
                if (leftChildIndex >= count)
                {
                    return;
                }
                else
                {
                    minIndex = leftChildIndex;
                }
            }
            else
            {
                if (arr[leftChildIndex] <= arr[rightChildIndex])
                {
                    minIndex = leftChildIndex;
                }
                else
                {
                    minIndex = rightChildIndex;
                }
            }
            if (arr[nodeIndex] > arr[minIndex])
            {
                temp = arr[minIndex];
                arr[minIndex] = arr[nodeIndex];
                arr[nodeIndex] = temp;
                siftDown(minIndex);
            }
        }
        private int getLeftChildIndex(int index)
        {
            return (2 * index) + 1;
        }
        private int getRightChildIndex(int index)
        {
            return (2 * index) + 2;
        }
        public T peek()
        {
            return arr[0].data;
        }
        public bool Empty()
        {
            return (count == 0);
        }
    }
}