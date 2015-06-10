using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using DDDPizza.Api.Factories;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.ViewModels.CostInventory;
using DDDPizza.ViewModels.Inventory;

namespace DDDPizza.Api.Controllers
{

    public class InventoryController : ApiController
    {

        private readonly IPizzaRepository _pizzaRepository;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IViewModelFactory _viewModelFactory;
        //private readonly IVmFactory<Topping> _vmFactory;

        public InventoryController(IPizzaRepository pizzaRepository, IRepositoryFactory repositoryFactory, IViewModelFactory viewModelFactory)
        {
            _pizzaRepository = pizzaRepository;
            _repositoryFactory = repositoryFactory;
            _viewModelFactory = viewModelFactory;
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
        [Route("api/inventory/sauces")]
        public async Task<IHttpActionResult> GetSauces()
        {
            var list = await _repositoryFactory.GetRepository<IInventoryRepository<Sauce>>().GetAll();
            var vm = _viewModelFactory.CreateFromVm<List<Sauce>, List<InventoryVm>>(list.ToList());
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
        [Route("api/inventory/sizes")]
        public async Task<IHttpActionResult> GetSizes()
        {
            var list = await _repositoryFactory.GetRepository<IInventoryRepository<Size>>().GetAll();
            var vm = _viewModelFactory.CreateFromVm<List<Size>, List<PriceInventoryVm>>(list.ToList());
            return Ok(vm);
        }

    }

    public class PizzaController : ApiController
    {

        private readonly IPizzaRepository _pizzaRepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        [HttpGet]
        [Route("api/orders")]
        public async Task<IHttpActionResult> GetOrders()
        {
            return Ok(await _pizzaRepository.GetAll());
        }

        [HttpGet]
        [Route("api/orders/{id}")]
        public async Task<IHttpActionResult> GetOrder(string id)
        {
            return Ok(await _pizzaRepository.GetById(Guid.Parse(id)));
        }

        [HttpPost]
        [Route("api/orders")]
        public async Task<IHttpActionResult> InsertOrder([FromBody]Order order)
        {
            //var returnOrder = await _pizzaRepository.Add(order);
            //return Created("", returnOrder);
            return Ok();
        }


        [HttpGet]
        [Route("api/toppings")]
        public async Task<IHttpActionResult> GetToppings()
        {
            return Ok(await _pizzaRepository.GetAllToppings());
        }

        [HttpGet]
        [Route("api/breads")]
        public async Task<IHttpActionResult> GetBreads()
        {
            return Ok(await _pizzaRepository.GetAllBreads());
        }

        [HttpGet]
        [Route("api/sauces")]
        public async Task<IHttpActionResult> GetSauses()
        {
            return Ok(await _pizzaRepository.GetAllSauces());
        }

        [HttpGet]
        [Route("api/sizes")]
        public async Task<IHttpActionResult> GetSizes()
        {
            return Ok(await _pizzaRepository.GetAllSizes());
        }

        [HttpGet]
        [Route("api/cheeses")]
        public async Task<IHttpActionResult> GetCheeses()
        {
            return Ok(await _pizzaRepository.GetAllCheeses());
        }

    }
}
