using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Graph
{
    /// <summary>
    /// 模拟图的邻接表存储方式
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class AdjacencyList<T> where T : class
    {
        public List<Vertex<T>> items;  // 图的顶点集合

        public AdjacencyList()
            : this(10)
        {
        }

        public AdjacencyList(int capacity)
        {
            this.items = new List<Vertex<T>>(capacity);
        }

        #region 基本方法：为图中添加顶点、添加有向与无向边
        /// <summary>
        /// 添加一个顶点
        /// </summary>
        /// <param name="item">顶点元素data</param>
        public void AddVertex(T item)
        {
            if (Contains(item))
            {
                throw new ArgumentException("添加了重复的顶点！");
            }

            Vertex<T> newVertex = new Vertex<T>(item);
            items.Add(newVertex);
        }

        /// <summary>
        /// 添加一条无向边
        /// </summary>
        /// <param name="from">头顶点data</param>
        /// <param name="to">尾顶点data</param>
        /// <param name="weight">权值</param>
        public void AddEdge(T from, T to)
        {
            Vertex<T> fromVertex = Find(from);
            if (fromVertex == null)
            {
                throw new ArgumentException("头顶点不存在！");
            }

            Vertex<T> toVertex = Find(to);
            if (toVertex == null)
            {
                throw new ArgumentException("尾顶点不存在！");
            }

            // 无向图的两个顶点都需要记录边的信息
            AddDirectedEdge(fromVertex, toVertex);
            AddDirectedEdge(toVertex, fromVertex);
        }

        /// <summary>
        /// 添加一条有向边
        /// </summary>
        /// <param name="fromVertex">头顶点</param>
        /// <param name="toVertex">尾顶点</param>
        private void AddDirectedEdge(Vertex<T> fromVertex, Vertex<T> toVertex)
        {
            if (fromVertex.firstEdge == null)
            {
                fromVertex.firstEdge = new Node(toVertex);
            }
            else
            {
                Node temp = null;
                Node node = fromVertex.firstEdge;

                do
                {
                    // 检查是否添加了重复边
                    if (node.adjvex.data.Equals(toVertex.data))
                    {
                        throw new ArgumentException("添加了重复的边！");
                    }
                    temp = node;
                    node = node.next;
                } while (node != null);

                Node newNode = new Node(toVertex);
                temp.next = newNode;
            }
        }

        /// <summary>
        /// 添加一条有向边
        /// </summary>
        /// <param name="from">头结点data</param>
        /// <param name="to">尾节点data</param>
        public void AddDirectedEdge(T from, T to)
        {
            Vertex<T> fromVertex = Find(from);
            if (fromVertex == null)
            {
                throw new ArgumentException("头顶点不存在！");
            }

            Vertex<T> toVertex = Find(to);
            if (toVertex == null)
            {
                throw new ArgumentException("尾顶点不存在！");
            }

            AddDirectedEdge(fromVertex, toVertex);
        }

        /// <summary>
        /// 打印打印每个顶点和它的邻接点
        /// </summary>
        /// <param name="isDirectedGraph">是否是有向图</param>
        public string GetGraphInfo(bool isDirectedGraph = false)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Vertex<T> v in items)
            {
                sb.Append(v.data.ToString() + ":");
                if (v.firstEdge != null)
                {
                    Node temp = v.firstEdge;
                    while (temp != null)
                    {
                        if (isDirectedGraph)
                        {
                            sb.Append(v.data.ToString() + "→" + temp.adjvex.data.ToString() + " ");
                        }
                        else
                        {
                            sb.Append(temp.adjvex.data.ToString());
                        }
                        temp = temp.next;
                    }
                }
                sb.Append("\r\n");  // \r\n连用表示跳到下一行开头，和换行一样
            }

            return sb.ToString();
        }
        #endregion

        #region 辅助方法：图中是否包含某个元素、查找指定顶点、初始化visited标志
        /// <summary>
        /// 辅助方法：查找图中是否包含某个元素
        /// </summary>
        private bool Contains(T item)
        {
            foreach (Vertex<T> v in items)
            {
                if (v.data.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 辅助方法：查找指定项并返回
        /// </summary>
        private Vertex<T> Find(T item)
        {
            foreach (Vertex<T> v in items)
            {
                if (v.data.Equals(item))
                {
                    return v;
                }
            }

            return null;
        }

        /// <summary>
        /// 辅助方法：初始化顶点的visited标志为false
        /// </summary>
        private void InitVisited()
        {
            foreach (Vertex<T> v in items)
            {
                v.isVisited = false;
            }
        }

        /// <summary>
        /// 获取有向图的入度
        /// </summary>
        /// <param name="vertex">图中的点</param>
        /// <returns></returns>
        private List<Vertex<T>> GetInDegree(Vertex<T> vertex)
        {
            return null;
        }

        /// <summary>
        /// 获取有向图的出度
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private List<Vertex<T>> GetOutDegree(Vertex<T> vertex)
        {
            return null;
        }

        /// <summary>
        /// 搜索两点之间的路径
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        private void FindPath2Points(Vertex<T> from,Vertex<T> to)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(from.data.ToString());
            if(from.firstEdge != null)
            {
                Node node = from.firstEdge;
                sb.Append("->" + node.adjvex.data.ToString());
                if (node.adjvex == to)
                {
                    Console.WriteLine(sb.ToString());
                    sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    node = node.adjvex.firstEdge;
                    if(node != null)
                    {

                    }
                }

                while (node.next != null)
                {
                    node = node.next;
                    if(node.adjvex == to)
                    {
                        sb.Append("->" + node.adjvex.data.ToString());
                        Console.WriteLine(sb.ToString());
                        sb.Remove(sb.Length - 1, 1);
                    }
                    else
                    {

                    }
                }
            }
        }

        #endregion

        #region 遍历方法：深度优先遍历与广度优先遍历
        /// <summary>
        /// 深度优先遍历接口For连通图
        /// </summary>
        public void DFSTraverse()
        {
            InitVisited(); // 首先初始化visited标志
            DFS(items[0]); // 从第一个顶点开始遍历
        }

        /// <summary>
        /// 深度优先遍历算法
        /// </summary>
        /// <param name="v">顶点</param>
        private void DFS(Vertex<T> v)
        {
            v.isVisited = true; // 首先将访问标志设为true标识为已访问
            Console.Write(v.data.ToString() + " "); // 进行访问操作：这里是输出顶点data
            Node node = v.firstEdge;

            while (node != null)
            {
                if (node.adjvex.isVisited == false) // 如果邻接顶点未被访问
                {
                    DFS(node.adjvex); // 递归访问node的邻接顶点
                }
                node = node.next; // 访问下一个邻接点
            }
        }

        private Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
        private bool hasPath = false;
        private void SearchPathByDFS(Vertex<T> start,Vertex<T> end)
        {
            start.isVisited = true;
            stack.Push(start);
            if (start == end)
            {
                hasPath = true;
                //打印路径信息
                List<Vertex<T>> resultList = new List<Vertex<T>>();
                int stackCount = stack.Count;
                for (int i = 0; i < stackCount; i++)
                {
                    resultList.Add(stack.Pop());
                }
                for (int j = resultList.Count - 1; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        Console.Write(resultList[j].data.ToString());
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(resultList[j].data.ToString() + "->");
                    }
                }
                for (int i = resultList.Count - 1; i >= 0; i--)
                {
                    stack.Push(resultList[i]);
                }
                //退回到上一个节点，继续寻找
                stack.Pop();
                start.isVisited = false;
                return;
            }

            Node node = start.firstEdge;
            if (node == null)  //边缘节点
            {
                stack.Pop();
                start.isVisited = false;
                return;
            }

            while (node != null)
            {
                if (!node.adjvex.isVisited)
                {
                    SearchPathByDFS(node.adjvex, end);
                }

                if (node.next == null)
                {
                    stack.Pop();
                    node.adjvex.isVisited = false;
                }
                node = node.next;
            }
        }

        /// <summary>
        /// 搜索两个点之间的所有路径
        /// </summary>
        /// <param name="start">起始点</param>
        /// <param name="end">终点</param>
        public void SearchPath(T start, T end)
        {
            Vertex<T> startVex = Find(start);
            Vertex<T> endVex = Find(end);
            InitVisited();
            hasPath = false;
            SearchPathByDFS(startVex, endVex);
            if (!hasPath)
            {
                Console.WriteLine(string.Format("这两个点{0}、{1}之间没有路径！", start.ToString(), end.ToString()));
            }
        }

        /// <summary>
        /// 宽度优先遍历接口For连通图
        /// </summary>
        public void BFSTraverse()
        {
            InitVisited(); // 首先初始化visited标志
            BFS(items[0]); // 从第一个顶点开始遍历
        }

        /// <summary>
        /// 宽度优先遍历算法
        /// </summary>
        /// <param name="v">顶点</param>
        private void BFS(Vertex<T> v)
        {
            v.isVisited = true; // 首先将访问标志设为true标识为已访问
            Console.Write(v.data.ToString() + " "); // 进行访问操作：这里是输出顶点data
            Queue<Vertex<T>> verQueue = new Queue<Vertex<T>>(); // 使用队列存储
            verQueue.Enqueue(v);

            while (verQueue.Count > 0)
            {
                Vertex<T> w = verQueue.Dequeue();
                Node node = w.firstEdge;
                // 访问此顶点的所有邻接节点
                while (node != null)
                {
                    // 如果邻接节点没有被访问过则访问它的边
                    if (node.adjvex.isVisited == false)
                    {
                        node.adjvex.isVisited = true; // 设置为已访问
                        Console.Write(node.adjvex.data + " "); // 访问
                        verQueue.Enqueue(node.adjvex); // 入队
                    }
                    node = node.next; // 访问下一个邻接点
                }
            }
        }

        /// <summary>
        /// 深度优先遍历接口For非联通图
        /// </summary>
        public void DFSTraverse4NUG()
        {
            InitVisited();
            foreach (var v in items)
            {
                if (v.isVisited == false)
                {
                    DFS(v);
                }
            }
        }

        /// <summary>
        /// 广度优先遍历接口For非联通图
        /// </summary>
        public void BFSTraverse4NUG()
        {
            InitVisited();
            foreach (var v in items)
            {
                if (v.isVisited == false)
                {
                    BFS(v);
                }
            }
        }
        #endregion

        #region 嵌套类1：存放于数组中的表头节点
        /// <summary>
        /// 嵌套类：存放于数组中的表头节点
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        public class Vertex<TValue>
        {
            public TValue data;     // 数据
            public Node firstEdge;  // 邻接点链表头指针
            public bool isOn; // 判断设备开闭状态
            public bool isVisited;  // 访问标志：遍历时使用

            public Vertex()
            {
                this.data = default(TValue);
            }

            public Vertex(TValue value)
            {
                this.data = value;
            }
        }
        #endregion

        #region 嵌套类2：链表中的表节点
        /// <summary>
        /// 嵌套类：链表中的表节点
        /// </summary>
        public class Node
        {
            public Vertex<T> adjvex;    // 邻接点域
            public Node next;           // 下一个邻接点指针域

            public Node()
            {
                this.adjvex = null;
            }

            public Node(Vertex<T> value)
            {
                this.adjvex = value;
            }
        }
        #endregion
    }
}
