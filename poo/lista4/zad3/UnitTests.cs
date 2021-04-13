using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace zad3
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void InvalidCapacity()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var ap = new Airport(0);
            });
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var ap = new Airport(-3);
            });
        }

        [TestMethod]
        public void ValidCapacity()
        {
            var ap = new Airport(4);
            Assert.IsNotNull(ap);
        }

        [TestMethod]
        public void CapacityDepleted()
        {
            var ap = new Airport(1);
            Assert.IsNotNull(ap);
            var r1 = new PlaneWrapper(ap);
            Assert.IsNotNull(r1);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var r2 = new PlaneWrapper(ap);
            });
        }
        
        [TestMethod]
        public void ReusedObject()
        {
            var ap = new Airport(1);
            Assert.IsNotNull(ap);
            var r1 = new PlaneWrapper(ap);
            Assert.IsNotNull(r1);
            r1.Release();
            var r2 = new PlaneWrapper(ap);
            Assert.IsNotNull(r1);
            Assert.AreEqual(r1.Reusable, r2.Reusable);
        }


        [TestMethod] 
        public void ReleaseInvalidReusable()
        {
            var ap = new Airport(1);
            Assert.IsNotNull(ap);
            var r1 = new Plane();
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ap.ReleaseReusable(r1);
            });
        }
    }
}