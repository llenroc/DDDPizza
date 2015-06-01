using DDDPizza.DomainModels.Enums;
using MongoDB.Bson.Serialization;

namespace DDDPizza.Api
{
    public static class MongoBootStrapper
    {

    
        public static void Setup()
        {
            BsonClassMap.RegisterClassMap<ServiceType>(cm =>
            {
                cm.AutoMap();
                cm.SetIsRootClass(true);
            });
            BsonClassMap.RegisterClassMap<ServiceType.DeliveryType>();
            BsonClassMap.RegisterClassMap<ServiceType.InRestaurantType>();
            BsonClassMap.RegisterClassMap<ServiceType.TakeOutType>();
        
        }

           

    }
}