using System;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.Mvc.Factories;

namespace DDDPizza.Mvc.Controllers
{
    public class BreadController : InventoryBaseController<Bread>
    {
        public BreadController(Func<IRepositoryFactory> service, IVmFactory<Bread> vmFactory) : base(service, vmFactory)
        {
        }

        public override void SetEntity()
        {
            EntityName = "Bread";
        }
    }
}