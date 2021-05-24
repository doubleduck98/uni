using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zad1
{
    [TestClass]
    public class UnitTests
    {
        private interface IFoo
        {
        }

        private class Foo : IFoo
        {
        }

        private class FooTwo : IFoo
        {
        }

        private abstract class AbstractBar
        {
        }

        private class Bar : AbstractBar
        {
        }

        private class BarTwo : AbstractBar
        {
        }

        [TestMethod]
        public void ConcreteType()
        {
            var c = new SimpleContainer();
            c.RegisterType<Foo>(false);
            var f1 = c.Resolve<Foo>();
            Assert.IsNotNull(f1);
            Assert.IsTrue(f1.GetType() == typeof(Foo));
            var f2 = c.Resolve<Foo>();
            Assert.IsNotNull(f2);
            Assert.IsTrue(f2.GetType() == typeof(Foo));
            Assert.AreNotSame(f1, f2);
        }

        [TestMethod]
        public void ConcreteTypeNotRegistered()
        {
            var c = new SimpleContainer();
            var f1 = c.Resolve<Foo>();
            Assert.IsNotNull(f1);
            Assert.IsTrue(f1.GetType() == typeof(Foo));
        }

        [TestMethod]
        public void Interface()
        {
            var c = new SimpleContainer();
            c.RegisterType<IFoo, Foo>(false);
            var f1 = c.Resolve<IFoo>();
            Assert.IsNotNull(f1);
            Assert.IsTrue(f1.GetType() == typeof(Foo));

            c.RegisterType<IFoo, FooTwo>(false);
            var f2 = c.Resolve<IFoo>();
            Assert.IsNotNull(f2);
            Assert.IsTrue(f2.GetType() == typeof(FooTwo));
        }

        [TestMethod]
        public void AbstractClass()
        {
            var c = new SimpleContainer();
            c.RegisterType<AbstractBar, Bar>(false);
            var f1 = c.Resolve<AbstractBar>();
            Assert.IsNotNull(f1);
            Assert.IsTrue(f1.GetType() == typeof(Bar));

            c.RegisterType<AbstractBar, BarTwo>(false);
            var f2 = c.Resolve<AbstractBar>();
            Assert.IsNotNull(f2);
            Assert.IsTrue(f2.GetType() == typeof(BarTwo));
        }

        [TestMethod]
        public void AbstractTypeNotRegistered()
        {
            var c = new SimpleContainer();
            Assert.ThrowsException<ArgumentException>(() => { c.Resolve<IFoo>(); });
            Assert.ThrowsException<ArgumentException>(() => { c.Resolve<AbstractBar>(); });
        }

        [TestMethod]
        public void SingletonConcreteType()
        {
            var c = new SimpleContainer();
            c.RegisterType<Foo>(true);
            var f1 = c.Resolve<Foo>();
            Assert.IsNotNull(f1);
            Assert.IsTrue(f1.GetType() == typeof(Foo));
            
            var f2 = c.Resolve<Foo>();
            Assert.IsNotNull(f2);
            Assert.IsTrue(f2.GetType() == typeof(Foo));
            Assert.AreSame(f1, f2);
        }

        [TestMethod]
        public void SingletonInterface()
        {
            var c = new SimpleContainer();
            c.RegisterType<IFoo, Foo>(true);
            var f1 = c.Resolve<IFoo>();
            Assert.IsNotNull(f1);
            Assert.IsTrue(f1.GetType() == typeof(Foo));
            var f2 = c.Resolve<IFoo>();
            Assert.IsNotNull(f2);
            Assert.IsTrue(f2.GetType() == typeof(Foo));
            Assert.AreSame(f1, f2);

            c.RegisterType<IFoo, FooTwo>(true);
            var f3 = c.Resolve<IFoo>();
            Assert.IsNotNull(f3);
            Assert.IsTrue(f3.GetType() == typeof(FooTwo));
            var f4 = c.Resolve<IFoo>();
            Assert.IsNotNull(f4);
            Assert.IsTrue(f4.GetType() == typeof(FooTwo));
            Assert.AreSame(f3, f4);
            Assert.AreNotSame(f1, f3);
        }

        [TestMethod]
        public void SingletonAbstractClass()
        {
            var c = new SimpleContainer();
            c.RegisterType<AbstractBar, Bar>(true);
            var f1 = c.Resolve<AbstractBar>();
            Assert.IsNotNull(f1);
            Assert.IsTrue(f1.GetType() == typeof(Bar));
            var f2 = c.Resolve<AbstractBar>();
            Assert.IsNotNull(f2);
            Assert.IsTrue(f2.GetType() == typeof(Bar));
            Assert.AreSame(f1, f2);

            c.RegisterType<AbstractBar, BarTwo>(true);
            var f3 = c.Resolve<AbstractBar>();
            Assert.IsNotNull(f3);
            Assert.IsTrue(f3.GetType() == typeof(BarTwo));
            var f4 = c.Resolve<AbstractBar>();
            Assert.IsNotNull(f4);
            Assert.IsTrue(f4.GetType() == typeof(BarTwo));
            Assert.AreSame(f3, f4);
            Assert.AreNotSame(f1, f3);
        }
    }
}