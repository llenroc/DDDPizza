using System;
using System.Collections.Generic;

namespace DDDPizza.ViewModels
{
    public class OrderVm
    {
        /// <summary>
        /// Id is outbound only
        /// </summary>
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public string ServiceType { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal Total { get; set; }
        public List<PizzaVm> Pizzas { get; set; }

    }
}
