using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        #region StaticFields
        private static List<int> _integers = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 9 };

        private static List<string> _strings = new List<string> {
            "Hello",
            "World!",
            "I",
            "am",
            "a",
            "list",
            "of",
            "strings",
        };

        #endregion

        #region StaticMethods
        static int Aggregate(Func<int, int, int> f, List<int> list)
        {
            int result = list[0];
            for (int i = 1; i < list.Count; ++i)
            {
                result = f(result, list[i]);
            }

            return result;
        }

        static IEnumerable<int> Select(Func<int, int> f, IEnumerable<int> list)
        {
            List<int> result = new List<int>();
            foreach (int val in list)
            {
                result.Add(f(val));
            }
            return result;
        }

        static void ForEach<T>(Action<T> f, IEnumerable<T> list)
        {
            foreach (T val in list)
            {
                f(val);
            }
        }

        #endregion

        static int Sum(int x, int y)
        {
            int z = x + y;
            return z;
        }

        static int Multiply(int a, int b)
        {
            int c = a * b;
            return c;
        }

        static int MakeDouble(int d)
        {
            int e = d * 2;
            return e;
        }

        static int Square(int g)
        {
            int h = g * g;
            return h;
        }

        static void Main(string[] args)
        {
          
            Console.WriteLine(Aggregate(Sum, new List<int>()));

            Console.WriteLine(Aggregate(Multiply, new List<int>()));

            Console.WriteLine(Aggregate((p, q) => p + q, new List<int>()));

            Console.WriteLine(Aggregate((p, q) => p * q, new List<int>()));

            Console.WriteLine(Select(MakeDouble, new List<int>()));

            Console.WriteLine(Select(Square, new List<int>()));

            Console.WriteLine(Select((k) => k * 2, new List<int>()));

            Console.WriteLine(Select((k) => k * k, new List<int>()));

            ForEach<int>(x => Console.Write(x), _integers);

            ForEach<string>(x => Console.Write(x), _strings);
        }
    }
}