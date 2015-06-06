using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.Mvc.Factories;

namespace DDDPizza.Mvc.Controllers
{
    public class BreadController : InventoryBaseController<Bread>
    {
        public BreadController(IRepositoryFactory repositoryFactory, IVmFactory<Bread> vmFactory) : base(repositoryFactory, vmFactory)
        {
        }

        public override void SetEntity()
        {
            EntityName = "Bread";
        }
    }
}