using System;
using System.Linq;

namespace zadanie1._3._7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var item = new {Field1 = "The value", Field2 = 5};

            var theList = new[] {item}.ToList();
            
            theList.Add(new {Field1 = "nowy obiekt", Field2 = 2});
            theList.Add(new {Field1 = "jeszcze nowszy obiekt", Field2 = 3});

            foreach (var i in theList)
            {
                Console.WriteLine($"{i.Field1}, {i.Field2}");
            }
        }
    }
}