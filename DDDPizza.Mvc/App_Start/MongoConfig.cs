using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Enums;
using MongoDB.Bson.Serialization;

namespace DDDPizza.Mvc.App_Start
{
    public static class MongoConfig
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<ServiceType>(cm =>
            {
                cm.AutoMap();
                cm.SetIsRootClass(true);
            });
            BsonClassMap.RegisterClassMap<ServiceType.DeliveryType>();
            BsonClassMap.RegisterClassMap<ServiceType.InRestaurantType>();
            BsonClassMap.RegisterClassMap<ServiceType.TakeOutType>();


            BsonClassMap.RegisterClassMap<Pizza>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(c => c.Toppings).SetElementName("Topping");
            });

        }
    }
}