using System.Configuration;
using DDDPizza.DomainModels;
using MongoDB.Driver;

namespace DDDPizza.Infrastructure.MongoDb
{
    public class MongoContext 
    {
        private readonly IMongoDatabase _mongoDatabaseBase;

        public MongoContext()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings.Get("mongoConnection"));
            _mongoDatabaseBase = client.GetDatabase(ConfigurationManager.AppSettings.Get("mongoDb"));
        }

        public IMongoCollection<Order> Orders
        {
            get { return _mongoDatabaseBase.GetCollection<Order>("Orders"); }
        }


    }
}
