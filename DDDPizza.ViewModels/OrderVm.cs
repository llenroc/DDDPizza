using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDDPizza.ViewModels
{
    public class OrderVm
    {

        public string Name { get; set; }
        public Guid Id { get; set; }
        public string ServiceType { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal TotalAmount { get; set; }

        public List<PizzaVm> Pizzas { get; set; }

    }




    public class PizzaVm
    {
        
    }
}
