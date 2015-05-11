using System;
using DDDPizza.DomainModels.Events;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels.Handlers
{
  

    public class NotifyPizzaCreated : IHandle<PizzaOrdered>
    {
        public void Handle(PizzaOrdered args)
        {
            Console.WriteLine("[EMAIL] Notification email sent to {0}", args.Pizza.Total);
        }
    }
}
