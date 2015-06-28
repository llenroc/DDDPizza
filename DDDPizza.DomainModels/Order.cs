using System;
using System.Collections.Generic;
using Autofac.Events;
using DDDPizza.DomainModels.Enums;
using DDDPizza.DomainModels.Events;
using DDDPizza.SharedKernel;

namespace DDDPizza.DomainModels
{

    public class Order : Entity
    {

        public Order(ServiceType service, List<Pizza> pizzas, string name) 
        {
            Guard.ForNullOrEmpty(name, "Customer Name must be provided");
            Name = name;
            ServiceType = service;
            Pizzas = pizzas;
            CalculateTotal();
            DateTimeStamp = DateTime.UtcNow;
        }
 
        public string Name { get; private set; }
        public ServiceType ServiceType { get;  set; }
        public List<Pizza> Pizzas { get; set; }
        public DateTime DateTimeStamp { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal ServiceCharge { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime EstimatedReadyTime { get; private set; }
       

        private void CalculateTotal()
        {
            foreach (var order in Pizzas)
            {
                SubTotal += order.Total;
            }

            ServiceCharge = ServiceType.CalculateTotal(this.ServiceType);

            TotalAmount = SubTotal + ServiceCharge;
            
        }

        public void SetEstimatedReadyTime(long existingOrders)
        {
            EstimatedReadyTime = DateTime.UtcNow.AddMinutes(20).AddMinutes(existingOrders*2);
        }

        public void ProcessOrder(Order order, IEventPublisher eventPublisher)
        {
        
            if (Equals(order.ServiceType, ServiceType.Delivery))
            {
                eventPublisher.Publish(new OrderNeedsDelivery(this));
            }
        }

    }
}