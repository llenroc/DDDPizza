using Autofac;
using DDDPizza.Interfaces;

namespace DDDPizza.Infrastructure.MongoDb.Factories
{

    public class RepositoryFactory : IRepositoryFactory
    {

        public IComponentContext Container;

        public RepositoryFactory(IComponentContext container)
        {
            Container = container;
        }

        public T GetRepository<T>() where T : IInventoryRepository
        {
            return Container.Resolve<T>();
        }


    }
}
