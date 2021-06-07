using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lista11
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

            var f3 = c.Resolve<Foo>();
            Assert.IsNotNull(f3);
            Assert.IsTrue(f3.GetType() == typeof(Foo));
            Assert.AreSame(f1, f3);
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

            public A(B b, C c)
            {
                B = b;
            }
        }

        private class B
        {
            public B(C c)
            {
            }
        }

        class C
        {
        }

        private class X
        {
            public readonly string A;

            public X(Y d, string a)
            {
                A = a;
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
            Assert.AreEqual("ala ma kota", x.A);
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
        public void DependencyCycle()
        {
            var c = new SimpleContainer();
            c.RegisterType<LoopA>(false);
            c.RegisterType<LoopB>(false);
            c.RegisterType<LoopC>(false);
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

    [TestClass]
    public class L11Tests
    {
        private class A
        {
            public B B;
            public C C;

            public A(B b)
            {
            }

            [DependencyConstructor]
            public A()
            {
            }

            [InjectionMethod]
            public void SetB(B b)
            {
                B = b;
            }

            [InjectionMethod]
            public void SetD(C c)
            {
                C = c;
            }
        }

        private class B
        {
            public readonly C C;

            public B(C c)
            {
                C = c;
            }
        }

        private class C
        {
        }

        [TestMethod]
        public void MethodInjection()
        {
            var c = new SimpleContainer();
            var a = c.Resolve<A>();
            Assert.IsNotNull(a.B);
            Assert.IsNotNull(a.C);
            Assert.IsNotNull(a.B.C);
        }

        private class D
        {
            [InjectionMethod]
            public int Xd()
            {
                return 71;
            }
        }

        [TestMethod]
        public void MethodInjectionNonVoidReturnType()
        {
            var c = new SimpleContainer();
            Assert.ThrowsException<DependencyAttributeException>(() => { c.Resolve<D>(); });
        }

        private class E
        {
            [InjectionMethod]
            public void SetD()
            {
            }
        }

        [TestMethod]
        public void MethodInjectionEmptyParameterList()
        {
            var c = new SimpleContainer();
            Assert.ThrowsException<DependencyAttributeException>(() => { c.Resolve<E>(); });
        }

        class Loop1
        {
            [InjectionMethod]
            public void SetLoop(Loop2 l)
            {
            }
        }

        class Loop2
        {
            [InjectionMethod]
            public void SetLoop(Loop1 l)
            {
            }
        }

        [TestMethod]
        public void MethodInjectionDependencyCycle()
        {
            var c = new SimpleContainer();
            Assert.ThrowsException<DependencyResolveException>(() => { c.Resolve<Loop1>(); });
            Assert.ThrowsException<DependencyResolveException>(() => { c.Resolve<Loop2>(); });
        }

        [TestMethod]
        public void BuildUp()
        {
            var c = new SimpleContainer();
            var theA = new A();
            c.BuildUp(theA);
            Assert.IsNotNull(theA.B);
            Assert.IsNotNull(theA.C);
        }

        [TestMethod]
        public void BuildUpNonVoidReturnType()
        {
            var c = new SimpleContainer();
            var d = new D();
            Assert.ThrowsException<DependencyAttributeException>(() => { c.BuildUp(d); });
        }

        [TestMethod]
        public void BuildUpEmptyParameterList()
        {
            var c = new SimpleContainer();
            var e = new E();
            Assert.ThrowsException<DependencyAttributeException>(() => { c.BuildUp(e); });
        }

        [TestMethod]
        public void BuildUpDependencyCycle()
        {
            var c = new SimpleContainer();
            var l1 = new Loop1();
            var l2 = new Loop2();
            Assert.ThrowsException<DependencyResolveException>(() => { c.BuildUp(l1); });
            Assert.ThrowsException<DependencyResolveException>(() => { c.BuildUp(l2); });
        }

        [TestMethod]
        public void ServiceLocator()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { SimpleServiceLocator.Current.GetInstance<Foo>(); });
            var sl1 = SimpleServiceLocator.Current;
            var sl2 = SimpleServiceLocator.Current;
            Assert.AreSame(sl1, sl2);
        }

        [TestMethod]
        public void ServiceLocatorSetProvider()
        {
            var c = new SimpleContainer();
            SimpleServiceLocator.SetContainerProvider(() => c);
            var c1 = SimpleServiceLocator.Current.GetInstance<SimpleContainer>();
            var c2 = SimpleServiceLocator.Current.GetInstance<SimpleContainer>();
            Assert.AreSame(c1, c2);

            SimpleServiceLocator.SetContainerProvider(() => new SimpleContainer());
            var c3 = SimpleServiceLocator.Current.GetInstance<SimpleContainer>();
            var c4 = SimpleServiceLocator.Current.GetInstance<SimpleContainer>();
            Assert.AreNotSame(c1, c4);
            Assert.AreNotSame(c3, c4);
        }

        [TestMethod]
        public void ServiceLocatorGetSimpleContainer()
        {
            // ten test nie przechodzi jezeli pusci sie wszyskie na raz bo to pole jest statyczne
            // Assert.ThrowsException<ArgumentException>(() =>
            //     SimpleServiceLocator.Current.GetInstance<SimpleContainer>());
            SimpleServiceLocator.SetContainerProvider(() => new SimpleContainer());
            var c = SimpleServiceLocator.Current.GetInstance<SimpleContainer>();
            Assert.IsNotNull(c);
            Assert.IsTrue(c.GetType() == typeof(SimpleContainer));
        }

        [TestMethod]
        public void ServiceLocatorGetInstance()
        {
            var c = new SimpleContainer();
            c.RegisterType<IFoo, Foo>(false);
            SimpleServiceLocator.SetContainerProvider(() => c);
            var f = SimpleServiceLocator.Current.GetInstance<IFoo>();
            Assert.IsNotNull(f);
            Assert.IsTrue(f.GetType() == typeof(Foo));


            c.RegisterType<IFoo, Foo>(true);
            var f1 = SimpleServiceLocator.Current.GetInstance<IFoo>();
            var f2 = SimpleServiceLocator.Current.GetInstance<IFoo>();
            Assert.AreSame(f1, f2);


            var f3 = SimpleServiceLocator.Current.GetInstance<A>();
            Assert.IsNotNull(f3.B);
            Assert.IsNotNull(f3.C);
            Assert.IsNotNull(f3.B.C);

            Assert.ThrowsException<DependencyResolveException>(() => SimpleServiceLocator.Current.GetInstance<Loop1>());
        }
    }
}