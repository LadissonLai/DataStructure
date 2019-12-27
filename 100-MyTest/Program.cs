using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100_MyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowArray1();

            ShowArray2();

            ShowArray3();

            ShowArray4();

            MyType type = MyType.Dian;
            Console.WriteLine(Convert.ToInt32(type));
            Console.WriteLine(type);
            Console.WriteLine(type.ToString());

            Console.ReadKey();

        }

        static void ShowArray1()
        {
            //方式一
            string[] arr1 = new string[] { "mm", "gg" };
            foreach (var item in arr1)
            {
                Console.WriteLine(item);
            }
        }

        static void ShowArray2()
        {
            string[] arr1 = new string[2] { "mm", "gg" };
            foreach (var item in arr1)
            {
                Console.WriteLine(item);
            }
        }

        static void ShowArray3()
        {
            string[] arr1 = { "mm", "gg" };
            foreach (var item in arr1)
            {
                Console.WriteLine(item);
            }
        }

        static void ShowArray4()
        {
            string[] arr1 = new string[5];
            arr1 = new string[] { "bai", "du" };
            foreach (var item in arr1)
            {
                Console.WriteLine(item);
            }
        }

        public enum MyType
        {
            Dian,
            Ying,
        }
    }
}
