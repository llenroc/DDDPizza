using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.Interfaces;
using MongoDB.Driver;

namespace DDDPizza.Infrastructure.MongoDb
{
    public class MongoCostInventoryRepository<T> : BaseMongoRepository<T> where T : IInventoryEntity, ICostInventoryEntity
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public MongoCostInventoryRepository()
        {
            IMongoClient mongoClient = new MongoClient(ConfigurationManager.AppSettings.Get("mongoConnection"));
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(ConfigurationManager.AppSettings.Get("mongoDb"));
            _mongoCollection = mongoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public override async Task<T> AddOrUpdate(T obj)
        {
            var existing = await base.GetById(obj.Id);
            if (existing == null)
            {
                await _mongoCollection.InsertOneAsync(obj);
            }
            else
            {
                var update = Builders<T>.Update.Set(y => y.Name, obj.Name).Set(c => c.Cost, obj.Cost);
                await _mongoCollection.UpdateOneAsync(x => x.Id == obj.Id, update);
            }

            return await _mongoCollection.Find(x => x.Id == obj.Id).SingleAsync();
        }

        

 
    }

    public class MongoInventoryRepository<T> : BaseMongoRepository<T> where T : IInventoryEntity
    {

       


    }
}