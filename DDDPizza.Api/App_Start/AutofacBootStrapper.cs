using System.Reflection;
using Autofac;
using Autofac.Events;
using Autofac.Features.Variance;
using Autofac.Integration.WebApi;
using DDDPizza.Api.Factories;
using DDDPizza.ApplicationServices;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Events;
using DDDPizza.DomainModels.Handlers;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.Infrastructure;
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

            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterEventing();

            builder.RegisterType<NotifyOrderNeedsDelivery>().As<IHandleEvent<OrderNeedsDelivery>>();

            builder.RegisterType<MessageService>().As<IMessageService>();
            builder.RegisterType<OrderService>().As<IOrderService>();

            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
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