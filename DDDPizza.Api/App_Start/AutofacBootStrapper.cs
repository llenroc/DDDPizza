using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using DDDPizza.Api.Factories;
using DDDPizza.DomainModels;
using DDDPizza.Infrastructure.MongoDb;
using DDDPizza.Infrastructure.MongoDb.Factories;
using DDDPizza.Interfaces;

namespace DDDPizza.Api
{
    public static class AutofacBootStrapper
    {

        public static AutofacWebApiDependencyResolver AutofacWebApiDependencyResolver()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<PizzaRepository>().As<IPizzaRepository>();
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();

            builder.RegisterType<MongoInventoryRepository<Bread>>().As<IInventoryRepository<Bread>>();
            builder.RegisterType<MongoInventoryRepository<Cheese>>().As<IInventoryRepository<Cheese>>();
            builder.RegisterType<MongoInventoryRepository<Sauce>>().As<IInventoryRepository<Sauce>>();
            builder.RegisterType<MongoInventoryRepository<Topping>>().As<IInventoryRepository<Topping>>();
            builder.RegisterType<MongoInventoryRepository<Size>>().As<IInventoryRepository<Size>>();

            builder.RegisterType<ViewModelFactory>().As<IViewModelFactory>();

            var container = builder.Build();
            return new AutofacWebApiDependencyResolver(container);
        }


    }
}