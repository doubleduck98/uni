using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Security;

namespace zad2
{
    public interface IShape
    {
        void IntroduceYourself();
    }

    public class Square : IShape
    {
        private int _len;

        public Square(object len)
        {
            _len = (int) len;
        }

        public void IntroduceYourself()
        {
            Console.WriteLine("hello, i'm a square");
        }
    }

    public class Rectangle : IShape
    {
        private int _a, _b;

        public Rectangle(object a, object b)
        {
            _a = (int) a;
            _b = (int) b;
        }

        public void IntroduceYourself()
        {
            Console.WriteLine("hello, i'm a rectangle");
        }
    }

    public interface IShapeFactoryWorker
    {
        bool ParameterCheck(string name, params object[] parametes);
        IShape Create(string name, params object[] parameters);
    }

    public class SquareWorker : IShapeFactoryWorker
    {
        public bool ParameterCheck(string name, params object[] parametes)
        {
            return name == "square";
        }

        public IShape Create(string name, params object[] parameters)
        {
            return new Square(parameters[0]);
        }
    }

    public class RectangleWorker : IShapeFactoryWorker
    {
        public bool ParameterCheck(string name, params object[] parametes)
        {
            return name == "rectangle";
        }

        public IShape Create(string name, params object[] parameters)
        {
            return new Rectangle(parameters[0], parameters[1]);
        }
    }


    public class ShapeFactory
    {
        private List<IShapeFactoryWorker> _workers = new List<IShapeFactoryWorker>();

        public void RegisterWorker(IShapeFactoryWorker worker)
        {
            _workers.Add(worker);
        }

        public IShape CreateShape(string shapeName, params object[] parameters)
        {
            foreach (var wrkr in _workers)
            {
                if (wrkr.ParameterCheck(shapeName, parameters))
                {
                    return wrkr.Create(shapeName, parameters);
                }
            }

            throw new ArgumentException("worker not present");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}