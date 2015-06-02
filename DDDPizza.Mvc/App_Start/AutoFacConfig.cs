using System.Reflection;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Autofac;
using Autofac.Integration.Mvc;
using DDDPizza.DomainModels;
using DDDPizza.Infrastructure.MongoDb;
using DDDPizza.Infrastructure.MongoDb.Factories;
using DDDPizza.Interfaces;
using DDDPizza.Mvc.Factories;

namespace DDDPizza.Mvc.App_Start
{
    public static class AutoFacConfig
    {

        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

   

            builder.RegisterType<PizzaRepository>().As<IPizzaRepository>();
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();

            builder.RegisterType<MongoInventoryRepository<Bread>>().As<IInventoryRepository<Bread>>();
            builder.RegisterType<MongoInventoryRepository<Cheese>>().As<IInventoryRepository<Cheese>>();
            builder.RegisterType<MongoInventoryRepository<Sauce>>().As<IInventoryRepository<Sauce>>();

            builder.RegisterType<VmFactory<Bread>>().As<IVmFactory<Bread>>();
            builder.RegisterType<VmFactory<Cheese>>().As<IVmFactory<Cheese>>();
            builder.RegisterType<VmFactory<Sauce>>().As<IVmFactory<Sauce>>();

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}