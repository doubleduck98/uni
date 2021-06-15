using System;
using System.Linq;
using Unity;

namespace zad1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // composition root
            var container = new UnityContainer();
            var session = new ParentChildrenContext();
            container.RegisterInstance(session);
            container.RegisterType<IUnitOfWork, ParentChildrenUoW>();
            UowFactory.SetProvider(() => container.Resolve<IUnitOfWork>());

            // app
            var db = new UowFactory().Create();
            var p = db.Parents.New();
            p.Name = "Parent";
            p.Surname = "Sample";
            var c = new Child {Name = "Child", Surname = "Sample", Parent = p};
            db.Children.Insert(c);

            var ch = db.Parents.GetChildrenOfParent(p.Id);
            ch.ForEach(chld => { Console.WriteLine($"{chld.Name} {chld.Surname}"); });

            var ps = db.Parents.GetAllParents();
            ps.ForEach(pa => Console.WriteLine($"{pa.Id} - {pa.Surname}"));

            foreach (var parent in db.Parents.Query.Where(pa => pa.Id < 7))
            {
                Console.WriteLine($"<7 - {parent.Name} {parent.Surname}");
            }
        }
    }
}