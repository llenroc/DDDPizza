using System;
using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Reflection;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.BaseTypes;
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
