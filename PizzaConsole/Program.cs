using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Enums;
using DDDPizza.DomainModels.Handlers;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.Infrastructure.MongoDb;
using DDDPizza.SharedKernel;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using StructureMap;

namespace PizzaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
       



            InitIoC();

            var pizzaRepository = new OrderRepository();

            try
            {
                var read = pizzaRepository.GetAllPending().Result;
                Console.WriteLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
           
            Console.ReadLine();

          

            Console.WriteLine("---------------------");
            Console.WriteLine("Welcome to DDD Pizza!");
            Console.WriteLine("---------------------");


            var pizzaSize = pizzaRepository.GetAllSizes().Result[2];
            var newToppings = new List<Topping>();
            newToppings.Add(pizzaRepository.GetAllToppings().Result[1]);
            newToppings.Add(pizzaRepository.GetAllToppings().Result[3]);
            newToppings.Add(pizzaRepository.GetAllToppings().Result[4]);
            var bread = pizzaRepository.GetAllBreads().Result[1];
            var sauce = pizzaRepository.GetAllSauces().Result[1];
            var cheese = pizzaRepository.GetAllCheeses().Result[1];

            var newPizza = new Pizza(newToppings, pizzaSize, bread, sauce, cheese);


            Console.WriteLine("Your size will be {0}", pizzaSize.Name);
            Console.WriteLine("---------------------");

            Console.WriteLine("Your toppings will be");
            Console.WriteLine("---------------------");
            foreach (var topping in newPizza.Toppings)
            {
                Console.WriteLine("{0} {1}", topping.Name, topping.Price);
            }
            Console.WriteLine("---------------------");

            var pizzas = new List<Pizza> { newPizza };

            var finalOrder = new Order(ServiceType.Delivery, pizzas,"fake name");

            Console.WriteLine("SubTotal: {0}", finalOrder.SubTotal);
            Console.WriteLine("Service Charge: {0}", finalOrder.ServiceCharge);
            Console.WriteLine("Total: {0}", finalOrder.TotalAmount);

            var task = new Task(async () =>
            {
                await pizzaRepository.Add(finalOrder);
            });
            task.Start();
   

            Console.ReadLine();

            BsonClassMap.RegisterClassMap<ServiceType>(cm =>
            {
                cm.AutoMap();
                cm.SetIsRootClass(true);
            });
            BsonClassMap.RegisterClassMap<ServiceType.DeliveryType>();
            BsonClassMap.RegisterClassMap<ServiceType.InRestaurantType>();
            BsonClassMap.RegisterClassMap<ServiceType.TakeOutType>();


          
        }



        private static void InitIoC()
        {

            ObjectFactory.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType<IDomainEvent>();
                    scan.WithDefaultConventions();
                    scan.IncludeNamespaceContainingType<NotifyPizzaCreated>(); // specify where handlers are located
                    scan.ConnectImplementationsToTypesClosing(typeof(IHandle<>));

                });


            });


        }

    }
}
