using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zad1
{
    public interface IFoo
    {
    }

    public class Foo : IFoo
    {
    }

    public class FooTwo : IFoo
    {
    }

    public abstract class AbstractBar
    {
    }

    public class Bar : AbstractBar
    {
    }

    public class BarTwo : AbstractBar
    {
    }


    [TestClass]
    public class L9Tests
    {
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
            var f2 = c.Resolve<Foo>();
            Assert.IsNotNull(f2);
            Assert.IsTrue(f2.GetType() == typeof(Foo));
            Assert.AreNotSame(f1, f2);
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
            Assert.ThrowsException<DependencyNotRegisteredException>(() => { c.Resolve<IFoo>(); });
            Assert.ThrowsException<DependencyNotRegisteredException>(() => { c.Resolve<AbstractBar>(); });
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

    [TestClass]
    public class L10Tests
    {
        [TestMethod]
        public void ConcreteInstance()
        {
            var c = new SimpleContainer();
            var foo1 = new Foo();
            c.RegisterInstance(foo1);
            var foo2 = c.Resolve<Foo>();
            Assert.IsNotNull(foo2);
            Assert.IsTrue(foo2.GetType() == typeof(Foo));
            Assert.AreSame(foo1, foo2);
        }

        [TestMethod]
        public void RegisterInstance()
        {
            var c = new SimpleContainer();
            var foo1 = new Foo();
            c.RegisterInstance<IFoo>(foo1);
            var foo2 = c.Resolve<IFoo>();
            Assert.IsNotNull(foo2);
            Assert.IsTrue(foo2.GetType() == typeof(Foo));
            Assert.AreSame(foo1, foo2);

            c.RegisterInstance<IFoo>(new FooTwo());
            var foo3 = c.Resolve<IFoo>();
            Assert.IsNotNull(foo3);
            Assert.IsTrue(foo3.GetType() == typeof(FooTwo));
            Assert.AreNotSame(foo1, foo3);
        }

        [TestMethod]
        public void RegisterInstanceString()
        {
            var c = new SimpleContainer();
            c.RegisterInstance("ala ma kota");
            var s = c.Resolve<string>();
            Assert.IsNotNull(s);
            Assert.AreEqual("ala ma kota", s);
        }

        [TestMethod]
        public void SequentialRegisters()
        {
            var c = new SimpleContainer();
            c.RegisterType<IFoo, Foo>(true);
            var f1 = c.Resolve<IFoo>();
            Assert.IsNotNull(f1);
            Assert.IsTrue(f1.GetType() == typeof(Foo));

            var f2 = new FooTwo();
            c.RegisterInstance<IFoo>(f2);
            var f3 = c.Resolve<IFoo>();
            Assert.IsNotNull(f3);
            Assert.IsTrue(f3.GetType() == typeof(FooTwo));

            c.RegisterType<IFoo, Foo>(true);
            var f4 = c.Resolve<IFoo>();
            Assert.IsNotNull(f4);
            Assert.IsTrue(f4.GetType() == typeof(Foo));
        }

        private class A
        {
            public B B;

            public A(B b)
            {
                B = b;
            }
        }

        private class B
        {
        }

        private class X
        {
            public readonly string a;

            public X(Y d, string a)
            {
                this.a = a;
            }
        }

        private class Y
        {
            public Y(int d)
            {
            }

            public Y(D d)
            {
            }
        }

        private class D
        {
        }

        [TestMethod]
        public void Example1()
        {
            var c = new SimpleContainer();
            var a = c.Resolve<A>();
            Assert.IsNotNull(a);
            Assert.IsNotNull(a.B);
        }

        [TestMethod]
        public void Example2()
        {
            var c = new SimpleContainer();
            Assert.ThrowsException<DependencyResolveException>(() => { c.Resolve<X>(); });
            c.RegisterInstance("ala ma kota");
            c.RegisterInstance(2);
            var x = c.Resolve<X>();
            Assert.IsNotNull(x);
            Assert.AreEqual("ala ma kota", x.a);
        }

        private class LoopA
        {
            public LoopA(LoopA l)
            {
            }
        }

        private class LoopB
        {
            public LoopB(LoopC l)
            {
            }
        }

        private class LoopC
        {
            public LoopC(LoopB l)
            {
            }
        }

        [TestMethod]
        public void DependencyCycleDetected()
        {
            var c = new SimpleContainer();
            Assert.ThrowsException<DependencyResolveException>(() => { c.Resolve<LoopA>(); });
            Assert.ThrowsException<DependencyResolveException>(() => { c.Resolve<LoopB>(); });
            Assert.ThrowsException<DependencyResolveException>(() => { c.Resolve<LoopC>(); });
        }

        private class Attributed
        {
            public readonly bool Foo;

            public Attributed()
            {
                Foo = false;
            }

            public Attributed(Foo f, Bar b)
            {
                Foo = false;
            }

            [DependencyConstructor]
            public Attributed(Bar b)
            {
                Foo = true;
            }
        }

        private class BadAttributed
        {
            [DependencyConstructor]
            public BadAttributed(Foo f)
            {
            }

            [DependencyConstructor]
            public BadAttributed(Bar b)
            {
            }
        }

        [TestMethod]
        public void DependencyAttribute()
        {
            var c = new SimpleContainer();
            var f = c.Resolve<Attributed>();
            Assert.IsTrue(f.Foo);
        }

        [TestMethod]
        public void BadDependencyAttribute()
        {
            var c = new SimpleContainer();
            Assert.ThrowsException<DependencyAttributeException>(() => { c.Resolve<BadAttributed>(); });
        }
    }
}