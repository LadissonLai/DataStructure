using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Graph
{
    class MyAdjList<T> where T : class
    {
        public List<MyVertex<T>> items;
        public MyAdjList()
            : this(10)
        {
        }

        public MyAdjList(int capacity)
        {
            this.items = new List<MyVertex<T>>(capacity);
        }

        #region 基本方法，添加点和边
        public void AddVertex(T item)
        {
            if (Contains(item))
            {
                throw new ArgumentException("添加了重复的顶点！");
            }

            MyVertex<T> newVertex = new MyVertex<T>(item);
            items.Add(newVertex);
        }

        /// <summary>
        /// 添加一条有向边
        /// </summary>
        /// <param name="fromVertex">头顶点</param>
        /// <param name="toVertex">尾顶点</param>
        private void AddDirectedEdge(MyVertex<T> fromVertex, MyVertex<T> toVertex)
        {
            fromVertex.nextVex.Add(toVertex);
        }

        private bool Contains(T item)
        {
            foreach (MyVertex<T> v in items)
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
        private MyVertex<T> Find(T item)
        {
            foreach (MyVertex<T> v in items)
            {
                if (v.data.Equals(item))
                {
                    return v;
                }
            }

            return null;
        }

        /// <summary>
        /// 添加一条有向边
        /// </summary>
        /// <param name="from">头结点data</param>
        /// <param name="to">尾节点data</param>
        public void AddDirectedEdge(T from, T to)
        {
            MyVertex<T> fromVertex = Find(from);
            if (fromVertex == null)
            {
                throw new ArgumentException("头顶点不存在！");
            }

            MyVertex<T> toVertex = Find(to);
            if (toVertex == null)
            {
                throw new ArgumentException("尾顶点不存在！");
            }

            AddDirectedEdge(fromVertex, toVertex);
        }
        #endregion


        public void DFS(T start)
        {
            MyVertex<T> my = Find(start);
            if (my != null)
            {
                InitVisited(true);
                DFS(my);
            }
        }

        public void DFS(MyVertex<T> startVex)
        {
            startVex.isVisited = true;
            Console.Write(startVex.data.ToString() + ",");
            if (!startVex.nextVex.IsNullOrEmpty())
            {
                foreach (MyVertex<T> item in startVex.nextVex)
                {
                    if (!item.isVisited)
                    {
                        DFS(item);
                    }
                }
            }
        }

        private void InitVisited(bool value)
        {
            if (value)
            {
                foreach (var item in items)
                {
                    item.isVisited = false;
                }
            }
        }

        public class MyVertex<Tvalue>
        {
            public Tvalue data;

            public List<MyVertex<T>> nextVex;

            public bool isVisited;
            
            public MyVertex()
            {
                data = default(Tvalue);
                nextVex = new List<MyVertex<T>>();
            }

            public MyVertex(Tvalue value)
            {
                data = value;
                nextVex = new List<MyVertex<T>>();
            }
        }
    }
}
