namespace DDDPizza.DomainModels.Interfaces
{
    public interface IApplicationEvent : IDomainEvent
    {
        string EventType { get; }
    }
}
