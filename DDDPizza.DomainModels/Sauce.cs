using System;
using DDDPizza.DomainModels.BaseTypes;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels
{

    public class Sauce : InventoryBase, IInventoryEntity
    {
        public Sauce(string name) : base(name)
        {
        }

        public Sauce(Guid id, string name) : base(id, name)
        {
        }

        public override bool ShouldSerializePrice()
        {
            return true;
        }

    }
}