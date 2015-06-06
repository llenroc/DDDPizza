using System;

namespace DDDPizza.DomainModels.Interfaces
{
    public interface IInventoryEntity 
    {
        Guid Id { get;  }
        string Name { get;  }
    }

    public interface ICostInventoryEntity
    {
        decimal Cost { get; }
    }
}
