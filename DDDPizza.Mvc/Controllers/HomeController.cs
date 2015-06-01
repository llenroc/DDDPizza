using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.ViewModels;

namespace DDDPizza.Mvc.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPizzaRepository _pizzaRepository;
        private readonly IRepositoryFactory _repositoryFactory; 

        public HomeController(IPizzaRepository pizzaRepository, IRepositoryFactory repositoryFactory)
        {
            _pizzaRepository = pizzaRepository;
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var result = await _pizzaRepository.GetAll();
            var convertedResult = Mapper.Map<IList<OrderVm>>(result.ToList());
            return View(convertedResult.ToList());
        }

        

        


        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var dm =
               Mapper.Map<InventoryVm>(
                   await _repositoryFactory.GetRepository<IInventoryRepository<Bread>>().GetById(Guid.Parse(id)));
            return View(dm);

        }

        [HttpGet]
        public ActionResult NewOrder()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }


    }
}