using System;
using System.Collections.Generic;
using System.Linq;

namespace zadanie1._3._8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            

            foreach (var item in list.Select(delegate(int i)
            {
                return i <= 2 ? 1 : delegate(i - 1)*
            }))
            {
                Console.WriteLine(item);
            }
        }
    }
}