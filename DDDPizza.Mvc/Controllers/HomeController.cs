using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.ViewModels;
using DDDPizza.ViewModels.CostInventory;
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

            var breads = Mapper.Map<List<InventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Bread>>().GetAll());
            var toppings = Mapper.Map<List<PriceInventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Topping>>().GetAll());
            var cheeses = Mapper.Map<List<InventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Cheese>>().GetAll());
            var sauces = Mapper.Map<List<InventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Sauce>>().GetAll());
            var sizes = Mapper.Map<List<PriceInventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Size>>().GetAll());

            ViewBag.Toppings = new List<SelectListItem>(toppings.Select(w => new SelectListItem { Text = w.Name, Value = w.Id.ToString() }).ToList());
            ViewData["Breads"] = new SelectList(breads.Select(w => new SelectListItem { Text = w.Name, Value = w.Id.ToString() }).ToList());
            ViewBag.Cheeses = new List<SelectListItem>(cheeses.Select(w => new SelectListItem { Text = w.Name, Value = w.Id.ToString() }).ToList());
            ViewBag.Sauces = new List<SelectListItem>(sauces.Select(w => new SelectListItem { Text = w.Name, Value = w.Id.ToString() }).ToList());
            ViewBag.Sizes = new List<SelectListItem>(sizes.Select(w => new SelectListItem { Text = w.Name, Value = w.Id.ToString() }).ToList());

            var vm = new PizzaOrderVm();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewOrder(PizzaOrderVm vm, FormCollection form)
        {

            var breads = Mapper.Map<List<InventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Bread>>().GetAll());
            var toppings = Mapper.Map<List<PriceInventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Topping>>().GetAll());
            var cheeses = Mapper.Map<List<InventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Cheese>>().GetAll());
            var sauces = Mapper.Map<List<InventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Sauce>>().GetAll());
            var sizes = Mapper.Map<List<PriceInventoryVm>>(await _repositoryFactory().GetRepository<IInventoryRepository<Size>>().GetAll());



            if (ModelState.IsValid)
            {

                var pizzaOrder = new PizzaVm();
                //pizzaOrder.Cheese = cheeses.SingleOrDefault(x => x..Id.ToString() == vm.Cheese);
                //pizzaOrder.Bread = breads.SingleOrDefault(x => x.Id.ToString() == vm.Bread);
                //pizzaOrder.Sauce = sauces.SingleOrDefault(x => x.Id.ToString() == vm.Sauce);
                //pizzaOrder.Size = sizes.SingleOrDefault(x => x.Id.ToString() == vm.Size);
                //pizzaOrder.Bread = breads.SingleOrDefault(x => x.Id.ToString() == vm.Bread);

                var cheeseDm = Mapper.Map<Cheese>(pizzaOrder.Cheese);
                var breadDm = Mapper.Map<Bread>(pizzaOrder.Bread);
                var sauceDm = Mapper.Map<Sauce>(pizzaOrder.Sauce);
                var sizeDm = Mapper.Map<Size>(pizzaOrder.Size);

                var pizzaDm = new Pizza(new List<Topping>(), sizeDm, breadDm, sauceDm, cheeseDm);

                await _repositoryFactory().GetRepository<IPizzaRepository>().Add(pizzaDm);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

    }
}