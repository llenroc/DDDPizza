namespace DDDPizza.DomainModels.Interfaces
{
    public interface IMessageService
    {
        void NotifyDelivery(Order order);
    }
}
