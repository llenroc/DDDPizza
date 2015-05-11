using System;

namespace DDDPizza.DomainModels.BaseTypes
{
    public abstract class InventoryBase
    {
        protected InventoryBase(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        protected InventoryBase(Guid id, string name) : this(name)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }
    }
}