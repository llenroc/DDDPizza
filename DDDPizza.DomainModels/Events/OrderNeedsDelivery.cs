using System;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels.Events
{
    public class OrderNeedsDelivery : IDomainEvent
    {
        public Order Order { get; set; }
        public DateTime DateOccurred { get; private set; }

        public OrderNeedsDelivery(Order order, DateTime dateCreated)
        {
            Order = order;
            DateOccurred = dateCreated;
        }

        public OrderNeedsDelivery(Order order) : this(order, DateTime.UtcNow)
        {
        }

 
    }
}
