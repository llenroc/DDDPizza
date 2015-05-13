using System;
using DDDPizza.SharedKernel;

namespace DDDPizza.DomainModels.Enums
{


    public abstract class ServiceType : Enumeration
    {
        private ServiceType(int value, string displayName)
            : base(value, displayName)
        {
        }

        public static readonly ServiceType InRestaurant = new InRestaurantType();
        public static readonly ServiceType TakeOut = new TakeOutType();
        public static readonly ServiceType Delivery = new DeliveryType();


        public abstract Decimal CalculateTotal(ServiceType serviceType);


        private class InRestaurantType : ServiceType
        {
            public InRestaurantType()
                : base(1, "InRestaurant"){}

            public override decimal CalculateTotal(ServiceType serviceType)
            {
                return 0.00m;
            }
        }

        private class TakeOutType : ServiceType
        {
            public TakeOutType()
                : base(2, "TakeOut") { }

            public override decimal CalculateTotal(ServiceType serviceType)
            {
                return 0.50m;
            }
        }

        private class DeliveryType : ServiceType
        {
            public DeliveryType()
                : base(3, "Delivery") { }

            public override decimal CalculateTotal(ServiceType serviceType)
            {
                return 2.00m;
            }
        }

       

    }

}