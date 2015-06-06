namespace DDDPizza.Interfaces
{
    public interface IRepositoryFactory
    {
        T GetRepository<T>() where T : IInventoryRepository;
    }
}