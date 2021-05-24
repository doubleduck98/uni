using System;

namespace zad1
{
    internal class Program
    {
        private interface IFoo
        {
            void IntroduceYourself();
        }

        private class Foo : IFoo
        {
            public void IntroduceYourself()
            {
                Console.WriteLine("hi i'm foo");
            }
        }

        private class FooTwo : IFoo
        {
            public void IntroduceYourself()
            {
                Console.WriteLine("hi i'm, foo2");
            }
        }
        
        public static void Main(string[] args)
        {
            var c = new SimpleContainer();
            c.RegisterType<IFoo, Foo>(false);
            var f = c.Resolve<IFoo>();
            f.IntroduceYourself();
            c.RegisterType<IFoo, FooTwo>(false);
            var f2 = c.Resolve<IFoo>();
            f2.IntroduceYourself();
            Console.WriteLine(f2.GetType());
        }
    }
}