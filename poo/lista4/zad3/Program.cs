using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace zad3
{
    public class Plane
    {
    }

    public class PlaneWrapper
    {
        private Plane _reusable;
        private Airport _pool;

        public Plane Reusable => _reusable;

        public PlaneWrapper(Airport pool)
        {
            _pool = pool;
            _reusable = _pool.AcquirePlane();
        }

        public void Release()
        {
            _pool.ReleaseReusable(_reusable);
        }
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

        public Plane AcquirePlane()
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

        public void ReleaseReusable(Plane reusable)
        {
            if (!_released.Contains(reusable))
            {
                throw new ArgumentException("can not release non-taken resource");
            }

            _ready.Add(reusable);
            _released.Remove(reusable);
        }
    }


    internal class Program
    {
        public static void Main(string[] args)
        {
            var ap = new Airport(3);
            var plane = new PlaneWrapper(ap);
            plane.Release();
        }
    }
}