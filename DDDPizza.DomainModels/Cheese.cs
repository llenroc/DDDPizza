using System;
using DDDPizza.DomainModels.BaseTypes;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels
{
    public class Cheese : InventoryBase, IInventoryEntity
    {
        public Cheese(string name) : base(name)
        {
        }

        public Cheese(Guid id, string name) : base(id, name)
        {
        }


        public override bool ShouldSerializePrice()
        {
            return true;
        }

    }

  
}