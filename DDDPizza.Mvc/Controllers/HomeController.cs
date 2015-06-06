using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.ViewModels;
using DDDPizza.ViewModels.Inventory;

namespace DDDPizza.Mvc.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPizzaRepository _pizzaRepository;
        private readonly Func<IRepositoryFactory> _repositoryFactory;

        public HomeController(IPizzaRepository pizzaRepository, Func<IRepositoryFactory> repositoryFactory)
        {
            _pizzaRepository = pizzaRepository;
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
 
            return View(new List<OrderVm>());
        }

        

        


        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var dm =
               Mapper.Map<InventoryVm>(
                   await _repositoryFactory().GetRepository<IInventoryRepository<Bread>>().GetById(Guid.Parse(id)));
            return View(dm);

        }

        [HttpGet]
        public async Task<ActionResult> NewOrder()
        {

            ViewBag.Breads = _repositoryFactory().GetRepository<IInventoryRepository<Bread>>().GetAll();
            ViewBag.Message = "Your application description page.";


            var vm = new PlaceOrderVm()
            {
                Breads = Mapper.Map<List<InventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Bread>>().GetAll())
            };

            return View(vm);
        }


    }
}