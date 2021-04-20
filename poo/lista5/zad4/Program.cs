using System;
using System.Collections;

namespace zad4
{
    internal class Program
    {
        public class IntComparerToIComparer : IComparer
        {
            private static Func<int, int, int> _compareFunction;

            public IntComparerToIComparer(Func<int, int, int> compareFunction)
            {
                _compareFunction = compareFunction;
            }

            public int Compare(object x, object y)
            {
                return _compareFunction((int) x, (int) y);
            }
        }

        public static void Main(string[] args)
        {
        }
    }
}