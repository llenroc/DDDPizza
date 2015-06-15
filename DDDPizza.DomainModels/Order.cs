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
        public Order(ServiceType service, List<Pizza> pizzas, string name)
        {
            ServiceType = service;
            Pizzas = pizzas;
            Name = name;
            CalculateTotal();
            DateTimeStamp = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }
        public ServiceType ServiceType { get;  set; }
        public List<Pizza> Pizzas { get; set; }
        public DateTime DateTimeStamp { get; private set; }
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