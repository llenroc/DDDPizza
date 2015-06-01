using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading.Tasks;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using MongoDB.Driver;

namespace DDDPizza.Infrastructure.MongoDb
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IMongoCollection<Order> _mongoOrdersCollection;
        private readonly IMongoDatabase _mongoDatabase;

        public PizzaRepository()
        {
            IMongoClient mongoClient = new MongoClient(ConfigurationManager.AppSettings.Get("mongoConnection"));
            _mongoDatabase = mongoClient.GetDatabase("dddpizza");
            _mongoOrdersCollection = _mongoDatabase.GetCollection<Order>("Orders");
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await (await _mongoOrdersCollection.FindAsync(_ => true)).ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _mongoOrdersCollection.Find(x => x.Id == id).SingleAsync();
        }

        public async Task<Order> Add(Order order)
        {
            await _mongoOrdersCollection.InsertOneAsync(order);
            return order;
        }

        public async Task<List<Toppings>> GetAllToppings()
        {
            return await (await _mongoDatabase.GetCollection<Toppings>("Toppings").FindAsync(_ => true)).ToListAsync();
        }

        public async Task<List<Size>> GetAllSizes()
        {
            return await (await _mongoDatabase.GetCollection<Size>("Sizes").FindAsync(_ => true)).ToListAsync();
        }

        public async Task<List<Sauce>> GetAllSauces()
        {
            return await (await _mongoDatabase.GetCollection<Sauce>("Sauces").FindAsync(_ => true)).ToListAsync();
        }

        public async Task<List<Cheese>> GetAllCheeses()
        {
            return await (await _mongoDatabase.GetCollection<Cheese>("Cheeses").FindAsync(_ => true)).ToListAsync();
        }

        public async Task<List<Bread>> GetAllBreads()
        {
            return await (await _mongoDatabase.GetCollection<Bread>("Breads").FindAsync(_ => true)).ToListAsync();
        }

        public async Task<Bread>GetBreadById(Guid id)
        {
            return await _mongoDatabase.GetCollection<Bread>("Breads").Find(x => x.Id == id).SingleAsync();
        }

        public async Task SeedToppings()
        {

            var mongoToppingsCollection = _mongoDatabase.GetCollection<Toppings>("Toppings");
            if (await mongoToppingsCollection.CountAsync(_ => true) == 0)
            {
                var seedToppings = new Collection<Toppings>
                {
                    new Toppings("Pepperoni", 0.99m),
                    new Toppings("Mushrooms", 0.99m),
                    new Toppings("Bacon", 1.99m),
                    new Toppings("Extra cheese", 1.99m),
                    new Toppings("Black olives", 1.99m),
                    new Toppings("Green peppers", 1.99m),
                    new Toppings("Sausage", 0.99m),
                    new Toppings("Pineapple", 0.99m),
                    new Toppings("Spinach", 0.99m)
                };
                foreach (var topping in seedToppings)
                {
                    await mongoToppingsCollection.InsertOneAsync(topping);
                }
            }



        }

        public async Task SeedSizes()
        {
            var mongoSizesCollection = _mongoDatabase.GetCollection<Size>("Sizes");
            if (await mongoSizesCollection.CountAsync(_ => true) == 0)
            {
                var seed = new Collection<Size>
                {
                    new Size("Small", 10.99m),
                    new Size("Medium", 12.99m),
                    new Size("Large", 14.99m),
                    new Size("Extra Large", 16.99m),
                };
                foreach (var item in seed)
                {
                    await mongoSizesCollection.InsertOneAsync(item);
                }
            }
        }

        public async Task SeedSauces()
        {
            var mongoSauceCollection = _mongoDatabase.GetCollection<Sauce>("Sauces");
            if (await mongoSauceCollection.CountAsync(_ => true) == 0)
            {
                var seed = new Collection<Sauce>
                {
                    new Sauce("Tomato"),
                    new Sauce("Pesto"),
                    new Sauce("Muhammara"),
                    new Sauce("Barbecue"),
                    new Sauce("Tapenade")
                };
                foreach (var item in seed)
                {
                    await mongoSauceCollection.InsertOneAsync(item);
                }
            }
        }

        public async Task SeedCheeses()
        {
            var mongoCheeseCollection = _mongoDatabase.GetCollection<Cheese>("Cheeses");
            if (await mongoCheeseCollection.CountAsync(_ => true) == 0)
            {
                var seed = new Collection<Cheese>
                {
                    new Cheese("Mozzarella"),
                    new Cheese("Provolone"),
                    new Cheese("Italian Hard Cheeses")
                };
                foreach (var item in seed)
                {
                    await mongoCheeseCollection.InsertOneAsync(item);
                }
            }
        }

        public async Task SeedBreads()
        {
            var mongoBreadCollection = _mongoDatabase.GetCollection<Bread>("Breads");
            if (await mongoBreadCollection.CountAsync(_ => true) == 0)
            {
                var seed = new Collection<Bread>
                {
                    new Bread("Hand Tossed"),
                    new Bread("Deep Dish"),
                    new Bread("Thin"),
                    new Bread("Stuffed")
                };
                foreach (var item in seed)
                {
                    await mongoBreadCollection.InsertOneAsync(item);
                }
            }
        }
    }
}
