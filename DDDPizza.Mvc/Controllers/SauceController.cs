using System;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.Mvc.Factories;

namespace DDDPizza.Mvc.Controllers
{
    public class SauceController : InventoryBaseController<Sauce>
    {
        public SauceController(Func<IRepositoryFactory> service, IVmFactory<Sauce> vmFactory) : base(service, vmFactory)
        {
        }

        public override void SetEntity()
        {
            EntityName = "Sauce";
        }
    }
}