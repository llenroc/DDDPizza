using System;
using DDDPizza.DomainModels.BaseTypes;

namespace DDDPizza.DomainModels
{
    public class Size : InventoryBase
    {

        public decimal Cost { get; private set; }

        public Size(string name, decimal cost) : base(name)
        {
            Cost = cost;
        }

        public Size(Guid id, string name, decimal cost) :  base(id, name) 
        {
            Cost = cost;
        }


    }
}