using System;
using DDDPizza.DomainModels.BaseTypes;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels
{
    public class Toppings : InventoryBase, IInventoryEntity, ICostInventoryEntity
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