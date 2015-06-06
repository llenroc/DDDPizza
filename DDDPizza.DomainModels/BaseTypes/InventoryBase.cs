using System;

namespace DDDPizza.DomainModels.BaseTypes
{
    public abstract class InventoryBase
    {
        protected InventoryBase()
        {

        }

        protected InventoryBase(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        protected InventoryBase(string name, decimal price) : this(name)
        {
            Price = price;
 
        }

        protected InventoryBase(Guid id, string name): this(name)
        {
            Id = id;
        }

        protected InventoryBase(Guid id, string name, decimal price) : this(name, price)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }
        public virtual decimal Price { get; private set; }

        #region "Mongo Overwrite"

        public virtual bool ShouldSerializePrice()
        {
            return true;
        }

        #endregion

    }


    

}