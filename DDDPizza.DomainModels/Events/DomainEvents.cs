using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels.Events
{
    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> actions;

        static DomainEvents()
        {
            //Container = ObjectFactory.Container;
        }

        //public static IContainer Container { get; set; }
        public static IComponentContext Container { get; set; }

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {

            var services = Container.ComponentRegistry.Registrations.SelectMany(x => x.Services)
            .OfType<IHandle<T>>();

            foreach (var handler in services)
            {
                handler.Handle(args); 
            }
       

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }
    }
}
