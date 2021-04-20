using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zad4
{
    [TestClass]
    public class UnitTests
    {
        static int IntComparer(int x, int y)
        {
            return x.CompareTo(y);
        }

        [TestMethod]
        public void Sort()
        {
            ArrayList a = new ArrayList() {1, 5, 3, 3, 2, 4, 3};
            a.Sort(new Program.IntComparerToIComparer(IntComparer));
            CollectionAssert.AreEqual(new ArrayList() {1, 2, 3, 3, 3, 4, 5}, a);
        }
    }
}