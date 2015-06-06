using System;
using DDDPizza.DomainModels.BaseTypes;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels
{
    public class Topping : InventoryBase, IInventoryEntity
    {

        public Topping(string name, decimal price) : base(name, price)
        {

        }

        public Topping(Guid id, string name, decimal price)
            : base(id, name, price)
        {
       
        }
   
    }
} 