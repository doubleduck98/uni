using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace zad1
{
    public interface IChildRepository
    {
        IQueryable<Child> Query { get; }
        void Insert(Child item);
        void Update(Child item);
        void Delete(Child item);
        Child New();
        Child GetChild(int id);
        Parent GetParentOfGetOfChild(int id);
        List<Child> GetAllChildren();
    }

    public class ChildRepository : IChildRepository
    {
        private readonly ParentChildrenContext _context;

        public ChildRepository(ParentChildrenContext context)
        {
            _context = context;
        }

        public IQueryable<Child> Query => _context.Child;

        public Child New()
        {
            return new Child();
        }

        public void Insert(Child item)
        {
            _context.Child.Add(item);
            _context.SaveChanges();
        }

        public void Update(Child item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Child item)
        {
            _context.Child.Remove(item);
            _context.SaveChanges();
        }

        public Child GetChild(int id)
        {
            return _context.Child.SingleOrDefault(c => c.Id == id);
        }

        public List<Child> GetAllChildren()
        {
            return (from child in _context.Child select child).ToList();
        }

        public Parent GetParentOfGetOfChild(int id)
        {
            return (from parent in _context.Parent
                join child in _context.Child on parent.Id equals child.ParentId
                select parent).FirstOrDefault();
        }
    }

    public interface IParentRepository
    {
        IQueryable<Parent> Query { get; }
        void Insert(Parent item);
        void Update(Parent item);
        void Delete(Parent item);
        Parent New();
        Parent GetParent(int id);
        List<Child> GetChildrenOfParent(int id);
        List<Parent> GetAllParents();
    }

    public class ParentRepository : IParentRepository
    {
        private readonly ParentChildrenContext _context;

        public ParentRepository(ParentChildrenContext context)
        {
            _context = context;
        }

        public IQueryable<Parent> Query => _context.Parent;

        public Parent New()
        {
            return new Parent();
        }

        public void Insert(Parent item)
        {
            _context.Parent.Add(item);
            _context.SaveChanges();
        }

        public void Update(Parent item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Parent item)
        {
            _context.Parent.Remove(item);
            _context.SaveChanges();
        }

        public Parent GetParent(int id)
        {
            return _context.Parent.FirstOrDefault(p => p.Id == id);
        }

        public List<Child> GetChildrenOfParent(int id)
        {
            return (from parent in _context.Parent
                join child in _context.Child on parent.Id equals child.ParentId
                select child).ToList();
        }

        public List<Parent> GetAllParents()
        {
            return _context.Parent.ToList();
        }
    }

    public interface IUnitOfWork : IDisposable
    {
        IParentRepository Parents { get; }
        IChildRepository Children { get; }
    }

    public class ParentChildrenUoW : IUnitOfWork
    {
        private readonly ParentChildrenContext _context;
        public IParentRepository Parents => new ParentRepository(_context);
        public IChildRepository Children => new ChildRepository(_context);

        public ParentChildrenUoW(ParentChildrenContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    public class UowFactory
    {
        private static Func<IUnitOfWork> _provider;

        public static void SetProvider(Func<IUnitOfWork> provider)
        {
            _provider = provider;
        }

        public IUnitOfWork Create()
        {
            if (_provider == null)
            {
                throw new ArgumentNullException(nameof(_provider), "Provider is not set.");
            }

            return _provider();
        }
    }
}