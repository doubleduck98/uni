using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zad2
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestEx()
        {
            ShapeFactory factory = new ShapeFactory();
            Assert.IsNotNull(factory);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IShape square = factory.CreateShape("square", 5);
            });
        }

        [TestMethod]
        public void TestRect()
        {
            ShapeFactory factory = new ShapeFactory();
            Assert.IsNotNull(factory);
            factory.RegisterWorker(new RectangleWorker());
            IShape rect = factory.CreateShape("rectangle", 3, 5);
            Assert.IsNotNull(rect);
            Assert.IsInstanceOfType(rect, typeof(Rectangle));
        }
    }
}