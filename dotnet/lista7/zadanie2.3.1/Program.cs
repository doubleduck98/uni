using System;

namespace zadanie2._3._1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var c1 = new Complex(-5, 5.1124);
            var c2 = new Complex(5, 5);
            var c3 = new Complex(-5, -5);
            var c4 = new Complex(5, -5);
            Console.WriteLine($"{c1}");
            Console.WriteLine($"{c2}");
            Console.WriteLine($"{c3:w}");
            Console.WriteLine($"{c4:w}");
            Console.WriteLine(new Complex(2, 3) + new Complex(5, -1));
            Console.WriteLine(new Complex(2, 3) - new Complex(5, -1));
            Console.WriteLine(new Complex(2, 3) * new Complex(5, -1));
            Console.WriteLine(new Complex(2, 3) / new Complex(5, -1));
        }
    }
}