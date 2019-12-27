using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Graph
{
    public static class ListExtension
    {
        public static bool IsNullOrEmpty<T>(this List<T> self)
        {
            if (self == null)
            {
                return true;
            }
            if(self.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
