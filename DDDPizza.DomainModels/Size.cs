using System;
using DDDPizza.DomainModels.BaseTypes;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels
{
    public class Size : InventoryBase, IInventoryEntity
    {

        public Size(string name, decimal price)
            : base(name, price)
        {
        
        }

        public Size(Guid id, string name, decimal price)
            : base(id, name, price)
        {

        }


    }
}