using System;

namespace zad3
{
    public abstract class EmailHandler
    {
        private EmailHandler Next { get; set; }

        public void AttachNext(EmailHandler next)
        {
            if (Next == null)
            {
                Next = next;
            }
            else
            {
                Next.AttachNext(next);
            }
        }

        public void DispatchRequest(string request)
        {
            var result = ProcessRequest(request);

            if (result)
            {
                var arch = new ArchiwumHandler();
                arch.ProcessRequest(request);
            }
            else if (Next != null)
            {
                Next.DispatchRequest(request);
            }
        }

        protected abstract bool ProcessRequest(string request);
    }

    public class PrezesHandler : EmailHandler
    {
        protected override bool ProcessRequest(string request)
        {
            if (request == "pochwała")
            {
                Console.WriteLine("pochwała dotarła do prezesa");
                return true;
            }

            return false;
        }
    }

    public class PrawnyHandler : EmailHandler
    {
        protected override bool ProcessRequest(string request)
        {
            if (request == "skarga")
            {
                Console.WriteLine("skarga trafiła do działu prawnego");
                return true;
            }

            return false;
        }
    }

    public class HandlowyHandler : EmailHandler
    {
        protected override bool ProcessRequest(string request)
        {
            if (request == "zamówienie")
            {
                Console.WriteLine("zamówienie trafiło do działu handlowego");
                return true;
            }

            return false;
        }
    }

    public class MarketingowyHandler : EmailHandler
    {
        protected override bool ProcessRequest(string request)
        {
            Console.WriteLine("email trrafił do działu handlowego");
            return true;
        }
    }

    public class ArchiwumHandler : EmailHandler
    {
        protected override bool ProcessRequest(string request)
        {
            Console.WriteLine($"\"{request}\" zarchiwizowano");
            return true;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var head = new PrezesHandler();
            head.AttachNext(new PrawnyHandler());
            head.AttachNext(new HandlowyHandler());
            head.AttachNext(new MarketingowyHandler());

            var req1 = "pochwała";
            var req2 = "essa";
            var req3 = "skarga";

            head.DispatchRequest(req1);
            head.DispatchRequest(req2);
            head.DispatchRequest(req3);
        }
    }
}