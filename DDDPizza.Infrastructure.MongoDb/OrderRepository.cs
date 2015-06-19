using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading.Tasks;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Enums;
using DDDPizza.Interfaces;
using MongoDB.Driver;

namespace DDDPizza.Infrastructure.MongoDb
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _mongoOrdersCollection;
        private readonly IMongoDatabase _mongoDatabase;

        public OrderRepository()
        {
            IMongoClient mongoClient = new MongoClient(ConfigurationManager.AppSettings.Get("mongoConnection"));
            _mongoDatabase = mongoClient.GetDatabase("dddpizza");
            _mongoOrdersCollection = _mongoDatabase.GetCollection<Order>("Orders");
        }


        public async Task<IEnumerable<Order>> GetAllByStatus(ServiceType type)
        {
            return await (await _mongoOrdersCollection.FindAsync(x => Equals(x.ServiceType, type))).ToListAsync();
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

        public async Task<List<Topping>> GetAllToppings()
        {
            return await (await _mongoDatabase.GetCollection<Topping>("Topping").FindAsync(_ => true)).ToListAsync();
        }

        public async Task<List<Size>> GetAllSizes()
        {
            return await (await _mongoDatabase.GetCollection<Size>("Size").FindAsync(_ => true)).ToListAsync();
        }

        public async Task<List<Sauce>> GetAllSauces()
        {
            return await (await _mongoDatabase.GetCollection<Sauce>("Sauce").FindAsync(_ => true)).ToListAsync();
        }

        public async Task<List<Cheese>> GetAllCheeses()
        {
            return await (await _mongoDatabase.GetCollection<Cheese>("Cheese").FindAsync(_ => true)).ToListAsync();
        }

        public async Task<List<Bread>> GetAllBreads()
        {
            return await (await _mongoDatabase.GetCollection<Bread>("Bread").FindAsync(_ => true)).ToListAsync();
        }

        public async Task<Bread>GetBreadById(Guid id)
        {
            return await _mongoDatabase.GetCollection<Bread>("Bread").Find(x => x.Id == id).SingleAsync();
        }

        public async Task SeedToppings()
        {

            var mongoToppingsCollection = _mongoDatabase.GetCollection<Topping>("Topping");
            if (await mongoToppingsCollection.CountAsync(_ => true) == 0)
            {
                var seedToppings = new Collection<Topping>
                {
                    new Topping("Pepperoni", 0.99m),
                    new Topping("Mushrooms", 0.99m),
                    new Topping("Bacon", 1.99m),
                    new Topping("Extra cheese", 1.99m),
                    new Topping("Black olives", 1.99m),
                    new Topping("Green peppers", 1.99m),
                    new Topping("Sausage", 0.99m),
                    new Topping("Pineapple", 0.99m),
                    new Topping("Spinach", 0.99m)
                };
                foreach (var topping in seedToppings)
                {
                    await mongoToppingsCollection.InsertOneAsync(topping);
                }
            }



        }

        public async Task SeedSizes()
        {
            var mongoSizesCollection = _mongoDatabase.GetCollection<Size>("Size");
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
