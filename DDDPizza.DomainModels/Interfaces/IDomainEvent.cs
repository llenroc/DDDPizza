using System;

namespace DDDPizza.DomainModels.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}
