using System;

namespace zad4
{
    public interface IState
    {
        void AcceptOrder(string coffeeType);
        void CollectPayment();
        void PrepareCoffee();
        void ServeCoffee();
    }

    public class Ready : IState
    {
        private CoffeeMachine _machine;

        public Ready(CoffeeMachine machine)
        {
            _machine = machine;
        }

        public void AcceptOrder(string coffeeType)
        {
            Console.WriteLine($"{coffeeType} chosen, insert coins");
            _machine.SetState(new WaitingForPayment(_machine));
        }

        public void CollectPayment()
        {
            throw new Exception("choose coffee type");
        }

        public void PrepareCoffee()
        {
            throw new Exception("choose coffee type");
        }

        public void ServeCoffee()
        {
            throw new Exception("choose coffee type");
        }
    }

    public class WaitingForPayment : IState
    {
        private CoffeeMachine _machine;

        public WaitingForPayment(CoffeeMachine machine)
        {
            _machine = machine;
        }

        public void AcceptOrder(string coffeeType)
        {
            Console.WriteLine("insert coins");
            _machine.SetState(this);
        }

        public void CollectPayment()
        {
            Console.WriteLine("preparing.. please wait");
            _machine.SetState(new Working(_machine));
        }

        public void PrepareCoffee()
        {
            throw new Exception("insert coins");
        }

        public void ServeCoffee()
        {
            throw new Exception("insert coins");
        }
    }

    public class Working : IState
    {
        private CoffeeMachine _machine;

        public Working(CoffeeMachine machine)
        {
            _machine = machine;
        }

        public void AcceptOrder(string coffeeType)
        {
            throw new Exception("already preparing coffee");
        }

        public void CollectPayment()
        {
            throw new Exception("already preparing coffee");
        }

        public void PrepareCoffee()
        {
            Console.WriteLine("ding! please collect your coffee");
            _machine.SetState(new WaitingForCollection(_machine));
        }

        public void ServeCoffee()
        {
            throw new Exception("already preparing coffee");
        }
    }

    public class WaitingForCollection : IState
    {
        private CoffeeMachine _machine;

        public WaitingForCollection(CoffeeMachine machine)
        {
            _machine = machine;
        }

        public void AcceptOrder(string coffeeType)
        {
            // mozemy zamowic nową kawe przed odebraniem, prowadzac oczywiscie do katastrofy
            Console.WriteLine($"{coffeeType} chosen, insert coins");
            _machine.SetState(new WaitingForPayment(_machine));
        }

        public void CollectPayment()
        {
            throw new Exception("choose coffee type");
        }

        public void PrepareCoffee()
        {
            throw new Exception("choose coffee type");
        }

        public void ServeCoffee()
        {
            Console.WriteLine("have a pleasant day!");
            _machine.SetState(new Ready(_machine));
        }
    }
}