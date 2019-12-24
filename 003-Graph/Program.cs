using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test01
            MyAdjacencyListTest();
            // Test02
            //AdjacencyListTraverseTest();
            

            Console.ReadKey();
        }

        #region Test01:图的邻接表存储基本测试
        static void MyAdjacencyListTest()
        {
            Console.WriteLine("------------无向图------------");
            AdjacencyList<string> adjList = new AdjacencyList<string>();
            // 添加顶点
            adjList.AddVertex("A");
            adjList.AddVertex("B");
            adjList.AddVertex("C");
            adjList.AddVertex("D");
            //adjList.AddVertex("D"); // 会报异常：添加了重复的节点
            // 添加无向边
            adjList.AddEdge("A", "B");
            adjList.AddEdge("A", "C");
            adjList.AddEdge("A", "D");
            adjList.AddEdge("B", "D");
            //adjList.AddEdge("B", "D"); // 会报异常：添加了重复的边

            Console.Write(adjList.GetGraphInfo());

            Console.WriteLine("------------有向图------------");
            AdjacencyList<string> dirAdjList = new AdjacencyList<string>();
            // 添加顶点
            dirAdjList.AddVertex("A");
            dirAdjList.AddVertex("B");
            dirAdjList.AddVertex("C");
            dirAdjList.AddVertex("D");
            dirAdjList.AddVertex("E");
            dirAdjList.AddVertex("F");
            // 添加有向边
            //dirAdjList.AddDirectedEdge("A", "B");
            //dirAdjList.AddDirectedEdge("A", "C");
            //dirAdjList.AddDirectedEdge("A", "D");
            //dirAdjList.AddDirectedEdge("B", "D");

            dirAdjList.AddDirectedEdge("A", "B");
            dirAdjList.AddDirectedEdge("B", "C");
            dirAdjList.AddDirectedEdge("A", "D");
            dirAdjList.AddDirectedEdge("B", "E");
            dirAdjList.AddDirectedEdge("C", "F");

            Console.Write(dirAdjList.GetGraphInfo(true));
            Console.WriteLine("\n搜索两点路径:");
            dirAdjList.SearchPath("A", "F");
            dirAdjList.SearchPath("A", "E");
            dirAdjList.SearchPath("F", "A");
        }
        #endregion

        #region Test02:图的邻接表遍历算法测试
        static void MyAdjacencyListTraverseTest()
        {
            Console.WriteLine("------------连通图的遍历------------");
            Console.Write("深度优先遍历：");
            AdjacencyList<string> adjList = new AdjacencyList<string>();
            // 添加顶点
            adjList.AddVertex("V1");
            adjList.AddVertex("V2");
            adjList.AddVertex("V3");
            adjList.AddVertex("V4");
            adjList.AddVertex("V5");
            adjList.AddVertex("V6");
            adjList.AddVertex("V7");
            adjList.AddVertex("V8");
            // 添加边
            adjList.AddEdge("V1", "V2");
            adjList.AddEdge("V1", "V3");
            adjList.AddEdge("V2", "V4");
            adjList.AddEdge("V2", "V5");
            adjList.AddEdge("V3", "V6");
            adjList.AddEdge("V3", "V7");
            adjList.AddEdge("V4", "V8");
            adjList.AddEdge("V5", "V8");
            adjList.AddEdge("V6", "V8");
            adjList.AddEdge("V7", "V8");
            // DFS遍历
            adjList.DFSTraverse();
            Console.WriteLine();
            Console.Write("广度优先遍历：");
            // BFS遍历
            adjList.BFSTraverse();
            Console.WriteLine();

            Console.WriteLine("------------非连通图的遍历------------");
            AdjacencyList<string> numAdjList = new AdjacencyList<string>();
            // 添加顶点
            numAdjList.AddVertex("V1");
            numAdjList.AddVertex("V2");
            numAdjList.AddVertex("V3");
            numAdjList.AddVertex("V4");
            numAdjList.AddVertex("V5");
            numAdjList.AddVertex("V6");
            numAdjList.AddVertex("V7");
            numAdjList.AddVertex("V8");
            // 添加边
            numAdjList.AddEdge("V1", "V2");
            numAdjList.AddEdge("V1", "V4");
            numAdjList.AddEdge("V2", "V3");
            numAdjList.AddEdge("V2", "V5");
            numAdjList.AddEdge("V4", "V5");
            numAdjList.AddEdge("V6", "V7");
            numAdjList.AddEdge("V6", "V8");
            Console.Write("深度优先遍历：");
            // DFS遍历
            numAdjList.DFSTraverse4NUG();
            Console.WriteLine();
            Console.Write("广度优先遍历：");
            // BFS遍历
            numAdjList.BFSTraverse4NUG();
        }
        #endregion

    }
}
