using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;

namespace zadanie2._3._2
{
    public class Set : IEnumerable<int>
    {
        private HashSet<int> _set;

        public Set()
        {
            _set = new HashSet<int>();
        }

        public Set(IEnumerable<int> items)
        {
            _set = new HashSet<int>(items);
        }

        public bool Add(int item)
        {
            return _set.Add(item);
        }

        public void Clear()
        {
            _set.Clear();
        }

        public bool Remove(int item)
        {
            return _set.Remove(item);
        }

        public bool Contains(int item)
        {
            return _set.Contains(item);
        }

        public void UnionWith(IEnumerable<int> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            _set.UnionWith(other);
        }

        public void ExceptWith(IEnumerable<int> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            _set.ExceptWith(other);
        }

        public void IntersectWith(IEnumerable<int> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            _set.IntersectWith(other);
        }

        public void Wypisz()
        {
            foreach (var item in _set)
            {
                Console.WriteLine(item);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}