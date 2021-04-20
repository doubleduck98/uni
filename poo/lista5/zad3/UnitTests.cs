using System;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace zad3
{
    [TestClass]
    public class TimeGatedTests
    {
        [TestMethod]
        public void InvalidCapacity()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var ap = new AirportProxy(0);
            });
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var ap = new AirportProxy(-3);
            });
        }

        [TestMethod]
        public void ValidCapacity()
        {
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 22)
            {
                var ap = new AirportProxy(4);
                Assert.IsNotNull(ap);
            }
            else
            {
                Assert.ThrowsException<AccessViolationException>(() =>
                {
                    var ap = new AirportProxy(4);
                    Assert.IsNotNull(ap);
                    var r = ap.AcquirePlane();
                });
            }
        }
    }

    [TestClass]
    public class LoggingTest
    {
        [TestMethod]
        public void InvalidCapacity()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var ap = new AirportLoggingProxy(0);
            });
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var ap = new AirportLoggingProxy(-3);
            });
        }

        [TestMethod]
        public void ValidCapacity()
        {
            var ap = new AirportLoggingProxy(4);
            Assert.IsNotNull(ap);
        }

        [TestMethod]
        public void ReusedObject()
        {
            var ap = new AirportLoggingProxy(1);
            Assert.IsNotNull(ap);
            var r1 = ap.AcquirePlane();
            Assert.IsNotNull(r1);
            ap.ReleaseReusable(r1);
            var r2 = ap.AcquirePlane();
            Assert.IsNotNull(r1);
            Assert.AreEqual(r1, r2);
        }

        [TestMethod]
        public void ReleaseInvalidReusable()
        {
            var ap = new AirportLoggingProxy(1);
            Assert.IsNotNull(ap);
            var r1 = new Plane();
            Assert.ThrowsException<ArgumentException>(() => { ap.ReleaseReusable(r1); });
        }
    }
}