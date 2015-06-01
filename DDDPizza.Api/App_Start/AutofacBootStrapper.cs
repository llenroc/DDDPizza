using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using DDDPizza.Infrastructure.MongoDb;
using DDDPizza.Interfaces;

namespace DDDPizza.Api
{
    public static class AutofacBootStrapper
    {

        public static AutofacWebApiDependencyResolver AutofacWebApiDependencyResolver()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<PizzaRepository>().As<IPizzaRepository>().InstancePerRequest();
            var container = builder.Build();
            return new AutofacWebApiDependencyResolver(container);
        }


    }
}