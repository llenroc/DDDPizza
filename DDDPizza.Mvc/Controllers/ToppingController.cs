using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.Mvc.Factories;

namespace DDDPizza.Mvc.Controllers
{
    public class ToppingController : InventoryBaseController<Toppings>
    {
        public ToppingController(IRepositoryFactory repositoryFactory, IVmFactory<Toppings> vmFactory) : base(repositoryFactory, vmFactory)
        {
        }

        public override void SetEntity()
        {
            EntityName = "Toppings";
        }
    }
}