using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

using DDDPizza.DomainModels.BaseTypes;
using DDDPizza.Interfaces;
using MongoDB.Driver;

namespace DDDPizza.Infrastructure.MongoDb
{
    public class MongoInventoryRepository<T> : IInventoryRepository<T> where T : InventoryBase
    {

        private readonly IMongoCollection<T> _mongoCollection;

        public MongoInventoryRepository()
        {
            IMongoClient mongoClient = new MongoClient(ConfigurationManager.AppSettings.Get("mongoConnection"));
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(ConfigurationManager.AppSettings.Get("mongoDb"));
            _mongoCollection = mongoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await (await _mongoCollection.FindAsync(_ => true)).ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _mongoCollection.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<T> AddOrUpdate(T obj)
        {

            var existing = await GetById(obj.Id);
            if (existing == null)
            {
               await _mongoCollection.InsertOneAsync(obj);
            }
            else
            {
                var update = Builders<T>.Update.Set(y => y.Name, obj.Name);
                await _mongoCollection.UpdateOneAsync(x => x.Id == obj.Id, update);
            }
      
            return await _mongoCollection.Find(x => x.Id == obj.Id).SingleAsync();
        }

        public async Task Delete(Guid id)
        {
            await _mongoCollection.FindOneAndDeleteAsync(x => x.Id == id);
        }

      
    }
}