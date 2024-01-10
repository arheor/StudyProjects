using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijkstra_ford
{
    class Program
    {
        static int V = 9;
        static int minDistance(int[] dist,
                        bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            return min_index;
        }

        static void printSolution(int[] dist)
        {
            Console.WriteLine("Вершина Расстояние от исходной вершины");
            for (int i = 0; i < V; ++i)
                Console.WriteLine(i + "\t\t" + dist[i]);
        }

        static void dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[V]; 

            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;


            for (int count = 0; count < V - 1; count++)
            {

                int u = minDistance(dist, sptSet);

                sptSet[u] = true;
 
                for (int v = 0; v < V; v++)

                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }

            printSolution(dist);
        }

        public static void Main()
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

            Console.WriteLine("Реализация алгоритма Дейкстры");
            dijkstra(graph, 3);


            int Vert = 5;  
            int Edge = 8; 
            Graph g = new Graph(Vert, Edge);

            g.edge[0].src = 0;
            g.edge[0].dest = 1;
            g.edge[0].weight = -1;

            g.edge[1].src = 0;
            g.edge[1].dest = 2;
            g.edge[1].weight = 4;

            g.edge[2].src = 1;
            g.edge[2].dest = 2;
            g.edge[2].weight = 3;

            g.edge[3].src = 1;
            g.edge[3].dest = 3;
            g.edge[3].weight = 2;
 
            g.edge[4].src = 1;
            g.edge[4].dest = 4;
            g.edge[4].weight = 2;

            g.edge[5].src = 3;
            g.edge[5].dest = 2;
            g.edge[5].weight = 5;

            g.edge[6].src = 3;
            g.edge[6].dest = 1;
            g.edge[6].weight = 1;

            g.edge[7].src = 4;
            g.edge[7].dest = 3;
            g.edge[7].weight = -3;

            Console.WriteLine("\nРеализация алгоритма Беллмана-Форда");
            g.BellmanFord(g, 0);
            Console.ReadKey();
        }
    }
}
