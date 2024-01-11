using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Graph
    {
        LinkedList<Tuple<int, int>>[] adjacencyList;

        // создаем Adjacency List
        public Graph(int vertices)
        {
            adjacencyList = new LinkedList<Tuple<int, int>>[vertices];
            for (int i = 0; i < adjacencyList.Length; ++i)
            {
                adjacencyList[i] = new LinkedList<Tuple<int, int>>();
            }
        }

        // добавляем новую вершину в список смежности
        public void addEdgeAtEnd(int startVertex, int endVertex, int weight)
        {
            adjacencyList[startVertex].AddLast(new Tuple<int, int>(endVertex, weight));
        }
        public string info()
        {
            string text = "";
            int i = 0;
            foreach (LinkedList<Tuple<int, int>> list in adjacencyList)
            {
                foreach (Tuple<int, int> edge in list)
                {
                    text += i + "->";
                    text += edge.Item1 + "(" + edge.Item2 + ")";
                    text += "\n";
                }
                ++i;
            }
            return text;
        }
    }
}