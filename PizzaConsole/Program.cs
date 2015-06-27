using System;
using System.Threading.Tasks;
using DDDPizza.Infrastructure.MongoDb;

namespace PizzaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("---------------------");
            Console.WriteLine(" Build my inventory! ");
            Console.WriteLine("---------------------");

            var seeder = new SeedRepository();

            var task = new Task(async () =>
            {
                await seeder.SeedBreads();
                await seeder.SeedCheeses();
                await seeder.SeedSauces();
                await seeder.SeedSizes();
                await seeder.SeedToppings();
            });
            task.Start();

            Console.WriteLine("---------------------");
            Console.WriteLine("        Done!        ");
            Console.WriteLine("---------------------");

            Console.ReadLine();

               
        }



    }
}
