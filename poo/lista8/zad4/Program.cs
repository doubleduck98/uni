using System;

namespace zad4
{
    public class CoffeeMachine
    {
        private IState _state;

        public CoffeeMachine()
        {
            _state = new Ready(this);
        }

        public void SetState(IState newState)
        {
            _state = newState;
        }

        public void AcceptOrder(string coffeeType)
        {
            _state.AcceptOrder(coffeeType);
        }

        public void CollectPayment()
        {
            _state.CollectPayment();
        }

        public void PrepareCoffee()
        {
            _state.PrepareCoffee();
        }

        public void ServeCoffee()
        {
            _state.ServeCoffee();
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var cm = new CoffeeMachine();
            cm.AcceptOrder("latte");
            try
            {
                cm.ServeCoffee();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            cm.CollectPayment();
            try
            {
                cm.ServeCoffee();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            cm.PrepareCoffee();
            cm.ServeCoffee();
        }
    }
}