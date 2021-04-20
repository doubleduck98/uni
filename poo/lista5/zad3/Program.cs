using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace zad3
{
    public class Plane
    {
    }

    public class Airport
    {
        private int _capacity;

        private List<Plane> _ready = new List<Plane>();
        private List<Plane> _released = new List<Plane>();

        public Airport(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("capacity has to be >0");
            }


            _capacity = capacity;
        }

        public virtual Plane AcquirePlane()
        {
            if (_released.Count == _capacity)
            {
                throw new ArgumentException("max reached");
            }

            if (_ready.Count == 0)
            {
                _ready.Add(new Plane());
            }

            var reusable = _ready[0];
            _ready.Remove(reusable);
            _released.Add(reusable);

            return reusable;
        }

        public virtual void ReleaseReusable(Plane reusable)
        {
            if (!_released.Contains(reusable))
            {
                throw new ArgumentException("can not release non-taken resource");
            }

            _ready.Add(reusable);
            _released.Remove(reusable);
        }
    }

    public class AirportProxy : Airport
    {
        private static Airport _airport;

        public AirportProxy(int capacity) : base(capacity)
        {
            if (_airport == null)
            {
                _airport = new Airport(capacity);
            }
        }

        public override Plane AcquirePlane()
        {
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 22)
            {
                return _airport.AcquirePlane();
            }
            else
            {
                throw new AccessViolationException("mozna uzywac tylko pomiedzy 8:00 a 22:00");
            }
        }

        public override void ReleaseReusable(Plane reusable)
        {
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 22)
            {
                _airport.ReleaseReusable(reusable);
            }
            else
            {
                throw new AccessViolationException("mozna uzywac tylko pomiedzy 8:00 a 22:00");
            }
        }
    }

    public class AirportLoggingProxy : Airport
    {
        private static Airport _airport;

        public AirportLoggingProxy(int capacity) : base(capacity)
        {
            if (_airport == null)
            {
                _airport = new Airport(capacity);
            }
        }

        private void LogOnStart(string methodName)
        {
            Console.WriteLine($"START {DateTime.Now} {methodName}");
        }

        private void LogOnExit(string methodName)
        {
            Console.WriteLine($"EXIT {DateTime.Now} {methodName}");
        }

        public override Plane AcquirePlane()
        {
            LogOnStart("AcquirePlane");
            var ret = _airport.AcquirePlane();
            LogOnExit("AcquirePlane");
            return ret;
        }

        public override void ReleaseReusable(Plane reusable)
        {
            LogOnStart("ReleaseReusable");
            _airport.ReleaseReusable(reusable);
            LogOnExit("ReleaseReusable");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var log = new AirportLoggingProxy(5);
            var plane = log.AcquirePlane();
            log.ReleaseReusable(plane);
        }
    }
}