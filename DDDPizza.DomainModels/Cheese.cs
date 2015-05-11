using System;
using DDDPizza.DomainModels.BaseTypes;

namespace DDDPizza.DomainModels
{
    public class Cheese : InventoryBase
    {
        public Cheese(string name) : base(name)
        {
        }

        public Cheese(Guid id, string name) : base(id, name)
        {
        }

    }

  
}