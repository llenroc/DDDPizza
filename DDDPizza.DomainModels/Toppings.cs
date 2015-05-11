using System;
using DDDPizza.DomainModels.BaseTypes;

namespace DDDPizza.DomainModels
{
    public class Toppings : InventoryBase
    {

        public decimal Cost { get; private set; }

        public Toppings(string name, decimal cost) : base(name)
        {
            Cost = cost;
        }

        public Toppings(Guid id, string name, decimal cost) : base(id, name)
        {
            Cost = cost;
        }

   
    }
}