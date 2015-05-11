using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Enums;
using DDDPizza.Mocks;

namespace PizzaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Welcome to DDD Pizza!");
            Console.WriteLine("---------------------");

            var pizzaSize = PizzaMocks.SizeMocks().ElementAt(3);
            var newToppings = new List<Toppings>();
            newToppings.Add(PizzaMocks.ToppingMocks().First());
            newToppings.Add(PizzaMocks.ToppingMocks().ElementAt(2));
            newToppings.Add(PizzaMocks.ToppingMocks().ElementAt(3));

            var newPizza = new Pizza(newToppings, pizzaSize, PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));


            Console.WriteLine("Your size will be {0}", pizzaSize.Name);
            Console.WriteLine("---------------------");

            Console.WriteLine("Your toppings will be");
            Console.WriteLine("---------------------");
            foreach (var topping in newPizza.Toppings)
            {
                Console.WriteLine(topping.Name);
            }
            Console.WriteLine("---------------------");

            var pizzas = new List<Pizza> {newPizza};

            var finalOrder = new Order(ServiceType.Delivery, pizzas);

            Console.WriteLine("SubTotal: {0}", finalOrder.SubTotal);
            Console.WriteLine("Service Charge: {0}", finalOrder.ServiceCharge);
            Console.WriteLine("Total: {0}", finalOrder.TotalAmount);
           

            Console.ReadLine();
        }
    }
}
