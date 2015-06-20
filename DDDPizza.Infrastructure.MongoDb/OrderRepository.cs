using System;
using System.Collections.Generic;
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

        public async Task<long> GetAllPending()
        {
            return await _mongoOrdersCollection.CountAsync(x => x.EstimatedReadyTime > DateTime.UtcNow);
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


    }
}
