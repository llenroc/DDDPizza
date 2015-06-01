using System;
using System.Collections.Generic;
using DDDPizza.DomainModels.Enums;


namespace DDDPizza.DomainModels
{




    public class  Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }
        public Order(ServiceType service, ICollection<Pizza> pizzas)
        {
            ServiceType = service;
            Pizzas = pizzas;
            CalculateTotal();
        }

        public Guid Id { get; set; }
    
        public ServiceType ServiceType { get; private set; }
        public ICollection<Pizza> Pizzas { get; set; }

        public decimal SubTotal { get; private set; }
        public decimal ServiceCharge { get; private set; }
        public decimal TotalAmount { get; private set; }

        private void CalculateTotal()
        {
            foreach (var order in Pizzas)
            {
                SubTotal += order.Total;
            }

            ServiceCharge = ServiceType.CalculateTotal(this.ServiceType);

            TotalAmount = SubTotal + ServiceCharge;
        }

    }
}