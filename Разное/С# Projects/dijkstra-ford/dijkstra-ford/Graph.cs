using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijkstra_ford
{
    class Graph
    {
        public class Edge
        {
            public int src, dest, weight;
            public Edge()
            {
                src = dest = weight = 0;
            }
        };

        int V, E;
        public Edge[] edge;
 
        public Graph(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[e];
            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        public void BellmanFord(Graph graph, int src)
        {
            int V = graph.V, E = graph.E;
            int[] dist = new int[V];

            for (int i = 0; i < V; ++i)
                dist[i] = int.MaxValue;
            dist[src] = 0;

            for (int i = 1; i < V; ++i)
            {
                for (int j = 0; j < E; ++j)
                {
                    int u = graph.edge[j].src;
                    int v = graph.edge[j].dest;
                    int weight = graph.edge[j].weight;
                    if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                        dist[v] = dist[u] + weight;
                }
            }

            for (int j = 0; j < E; ++j)
            {
                int u = graph.edge[j].src;
                int v = graph.edge[j].dest;
                int weight = graph.edge[j].weight;
                if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                {
                    Console.WriteLine("Граф содержит негативный цикл");
                    return;
                }
            }
            printArr(dist, V);
        }

        public void printArr(int[] dist, int V)
        {
            Console.WriteLine("Вершина Расстояние от исходной вершины");
            for (int i = 0; i < V; ++i)
                Console.WriteLine(i + "\t\t" + dist[i]);
        }
    }
}
