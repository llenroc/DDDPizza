using System;
using DDDPizza.DomainModels.BaseTypes;

namespace DDDPizza.DomainModels
{
    public class Bread : InventoryBase
    {
        public Bread(string name) : base(name)
        {
        }

        public Bread(Guid id, string name) : base(id, name)
        {
        }
    }
}