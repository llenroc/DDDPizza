using System;
using System.Diagnostics;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.Mvc.Factories;

namespace DDDPizza.Mvc.Controllers
{
    public class CheeseController : InventoryBaseController<Cheese>
    {
        public CheeseController(Func<IRepositoryFactory> service, IVmFactory<Cheese> vmFactory) : base(service, vmFactory)
        {
        }

        public override void SetEntity()
        {
            EntityName = "Cheese";
        }

        public override void Logger(string msg)
        {
            Trace.TraceError("cheese should not do that!");
            base.Logger(msg);   
        }
    }
}