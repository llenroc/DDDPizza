using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.Mvc.Factories;

namespace DDDPizza.Mvc.Controllers
{
    public class SauceController : InventoryBaseController<Sauce>
    {
        public SauceController(IRepositoryFactory repositoryFactory, IVmFactory<Sauce> vmFactory) : base(repositoryFactory, vmFactory)
        {
        }

        public override void SetEntity()
        {
            EntityName = "Sauce";
        }
    }
}