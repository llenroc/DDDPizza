using System;
using DDDPizza.DomainModels.BaseTypes;

namespace DDDPizza.DomainModels
{



    public class Sauce : InventoryBase
    {
        public Sauce(string name) : base(name)
        {
        }

        public Sauce(Guid id, string name) : base(id, name)
        {
        }
    }
}