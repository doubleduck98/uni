using System;

namespace zadanie1._4._1
{
    internal class Program
    {
        /* Wyniki na mojej maszynie:
         * konkretny typ -> 00:00:00.0049969
         * dynamiczny typ -> 00:00:00.1818965
         */
        public static void Main(string[] args)
        {
            int Foo(int x, int y)
            {
                var z = x + y;
                return z * x * y;
            }

            dynamic Bar(dynamic x, dynamic y)
            {
                var z = x + y;
                return z * x * y;
            }

            // rozgrzewka
            for (var i = 0; i < 100000; i += 2)
            {
                i -= 1;
            }

            const int liczbaProb = 100000;
            var start = DateTime.Now;
            for (var proba = 0; proba < liczbaProb; proba++)
            {
                var res = Foo(proba, proba);
            }

            var end = DateTime.Now;
            var czas = end - start;
            Console.WriteLine(czas);

            start = DateTime.Now;
            for (var proba = 0; proba < liczbaProb; proba++)
            {
                var res = Bar(proba, proba);
            }
            end = DateTime.Now;
            czas = end - start;
            Console.WriteLine(czas);
            Console.ReadKey();
        }
    }
}