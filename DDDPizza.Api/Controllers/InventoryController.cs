using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using DDDPizza.Api.Factories;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.ViewModels;
using DDDPizza.ViewModels.CostInventory;
using DDDPizza.ViewModels.Inventory;

namespace DDDPizza.Api.Controllers
{
    public class InventoryController : ApiController
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IViewModelFactory _viewModelFactory;

        public InventoryController(IRepositoryFactory repositoryFactory, IViewModelFactory viewModelFactory, IOrderRepository orderRepository)
        {
          
            _repositoryFactory = repositoryFactory;
            _viewModelFactory = viewModelFactory;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("api/inventory")]
        public async Task<IHttpActionResult> GetFullInventory()
        {
            var cheese = await _repositoryFactory.GetRepository<IInventoryRepository<Cheese>>().GetAll();
            var bread = await _repositoryFactory.GetRepository<IInventoryRepository<Bread>>().GetAll();
            var sauce = await _repositoryFactory.GetRepository<IInventoryRepository<Sauce>>().GetAll();
            var topping = await _repositoryFactory.GetRepository<IInventoryRepository<Topping>>().GetAll();
            var size = await _repositoryFactory.GetRepository<IInventoryRepository<Size>>().GetAll();

            var lookup = new FullInventoryVm
            {
                Cheeses = _viewModelFactory.CreateFromVm<List<Cheese>, List<InventoryVm>>(cheese.ToList()),
                Breads = _viewModelFactory.CreateFromVm<List<Bread>, List<InventoryVm>>(bread.ToList()),
                Sauces = _viewModelFactory.CreateFromVm<List<Sauce>, List<InventoryVm>>(sauce.ToList()),
                Toppings = _viewModelFactory.CreateFromVm<List<Topping>, List<PriceInventoryVm>>(topping.ToList()),
                Sizes = _viewModelFactory.CreateFromVm<List<Size>, List<PriceInventoryVm>>(size.ToList()),
            };

            return Ok(lookup);
        }

        [HttpGet]
        [Route("api/inventory/breads")]
        public async Task<IHttpActionResult> GetBreads()
        {
            var list = await _repositoryFactory.GetRepository<IInventoryRepository<Bread>>().GetAll();
            var vm = _viewModelFactory.CreateFromVm<List<Bread>, List<InventoryVm>>(list.ToList());
            return Ok(vm);
        }

        [HttpGet]
        [Route("api/inventory/breads/{id}", Name = "GetBreadById")]
        public async Task<IHttpActionResult> GetBreadById(string id)
        {
            var obj = await _repositoryFactory.GetRepository<IInventoryRepository<Bread>>().GetById(Guid.Parse(id));
            var vm = _viewModelFactory.CreateFromVm<Bread, InventoryVm>(obj);
            
            return Ok(vm);
        }

        [HttpGet]
        [Route("api/inventory/cheeses")]
        public async Task<IHttpActionResult> GetCheeses()
        {
            var list = await _repositoryFactory.GetRepository<IInventoryRepository<Cheese>>().GetAll();
            var vm = _viewModelFactory.CreateFromVm<List<Cheese>, List<InventoryVm>>(list.ToList());
            return Ok(vm);
        }

        [HttpGet]
        [Route("api/inventory/cheeses/{id}", Name = "GetCheeseById")]
        public async Task<IHttpActionResult> GetCheeseById(string id)
        {
            var obj = await _repositoryFactory.GetRepository<IInventoryRepository<Cheese>>().GetById(Guid.Parse(id));
            var vm = _viewModelFactory.CreateFromVm<Cheese, InventoryVm>(obj);

            return Ok(vm);
        }

        [HttpGet]
        [Route("api/inventory/sauces")]
        public async Task<IHttpActionResult> GetSauces()
        {
            var list = await _repositoryFactory.GetRepository<IInventoryRepository<Sauce>>().GetAll();
            var vm = _viewModelFactory.CreateFromVm<List<Sauce>, List<InventoryVm>>(list.ToList());
            return Ok(vm);
        }

        [HttpGet]
        [Route("api/inventory/sauces/{id}", Name = "GetSaucesById")]
        public async Task<IHttpActionResult> GetSaucesById(string id)
        {
            var obj = await _repositoryFactory.GetRepository<IInventoryRepository<Sauce>>().GetById(Guid.Parse(id));
            var vm = _viewModelFactory.CreateFromVm<Sauce, InventoryVm>(obj);

            return Ok(vm);
        }

        [HttpGet]
        [Route("api/inventory/toppings")]
        public async Task<IHttpActionResult> GetToppings()
        {
            var list = await _repositoryFactory.GetRepository<IInventoryRepository<Topping>>().GetAll();
            var vm = _viewModelFactory.CreateFromVm<List<Topping>, List<PriceInventoryVm>>(list.ToList());
            return Ok(vm);
        }

        [HttpGet]
        [Route("api/inventory/toppings/{id}", Name = "GetToppingsById")]
        public async Task<IHttpActionResult> GetToppingsById(string id)
        {
            var obj = await _repositoryFactory.GetRepository<IInventoryRepository<Topping>>().GetById(Guid.Parse(id));
            var vm = _viewModelFactory.CreateFromVm<Topping, PriceInventoryVm>(obj);

            return Ok(vm);
        }

        [HttpGet]
        [Route("api/inventory/sizes")]
        public async Task<IHttpActionResult> GetSizes()
        {
            var list = await _repositoryFactory.GetRepository<IInventoryRepository<Size>>().GetAll();
            var vm = _viewModelFactory.CreateFromVm<List<Size>, List<PriceInventoryVm>>(list.ToList());
            return Ok(vm);
        }

        [HttpGet]
        [Route("api/inventory/sizes/{id}", Name = "GetSizesById")]
        public async Task<IHttpActionResult> GetSizesById(string id)
        {
            var obj = await _repositoryFactory.GetRepository<IInventoryRepository<Size>>().GetById(Guid.Parse(id));
            var vm = _viewModelFactory.CreateFromVm<Size, PriceInventoryVm>(obj);

            return Ok(vm);
        }

    }
}