using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.Infrastructure.MongoDb
{
    public class MongoInventoryRepository<T> : BaseMongoRepository<T> where T : IInventoryEntity
    {

    }
}

