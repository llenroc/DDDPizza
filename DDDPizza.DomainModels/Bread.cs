using System;
using DDDPizza.DomainModels.BaseTypes;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels
{
    public class Bread : InventoryBase, IInventoryEntity
    {
        public Bread(string name) : base(name)
        {
        }

        public Bread(Guid id, string name) : base(id, name)
        {
        }
    }
}