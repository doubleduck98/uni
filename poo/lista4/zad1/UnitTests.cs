using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zad1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void VanillaTest()
        {
            var singleton = Singleton.Instance();
            var singleton2 = Singleton.Instance();

            Assert.IsNotNull(singleton);
            Assert.IsNotNull(singleton2);
            Assert.AreEqual(singleton, singleton2);
        }

        [TestMethod]
        public void ThreadedTest()
        {
            ThreadSingleton ts1 = null, ts2 = null, ts3 = null;

            var t1 = new Thread(() => { ts1 = ThreadSingleton.Instance(); });
            var t2 = new Thread(() => { ts2 = ThreadSingleton.Instance(); });
            var t3 = new Thread(() => { ts3 = ThreadSingleton.Instance(); });

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            // istnieja
            Assert.IsNotNull(ts1);
            Assert.IsNotNull(ts2);
            Assert.IsNotNull(ts3);
            // kazdy rozny
            Assert.AreNotEqual(ts1, ts2);
            Assert.AreNotEqual(ts1, ts3);
            Assert.AreNotEqual(ts2, ts3);
        }

        [TestMethod]
        public void TimedTest()
        {
            var s1 = TimedSingleton.Instance();
            var s2 = TimedSingleton.Instance();
            
            // istnieja
            Assert.IsNotNull(s1);
            Assert.IsNotNull(s2);
            // na razie takie same
            Assert.AreEqual(s1, s2);
            // za 5s powinny byc rozne
            Thread.Sleep(5000);
            var s3 = TimedSingleton.Instance();
            Assert.IsNotNull(s3);
            Assert.AreNotEqual(s1, s3);
            Assert.AreNotEqual(s2, s3);
        }
    }
}