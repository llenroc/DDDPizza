using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.Mvc.Factories;
using DDDPizza.ViewModels.CostInventory;
using DDDPizza.ViewModels.Inventory;

namespace DDDPizza.Mvc.Controllers
{
    public class SizeController : InventoryBaseController<Size>
    {
        public SizeController(IRepositoryFactory repositoryFactory, IVmFactory<Size> vmFactory) : base(repositoryFactory, vmFactory)
        {
        }

        [HttpGet]
        public async override Task<ActionResult> Edit(string id)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async override Task<ActionResult> Edit(InventoryVm item)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async override Task<ActionResult> Index()
        {
            var vm = base._vmFactory.CreatePrice(await base._repositoryFactory.GetRepository<IInventoryRepository<Size>>().GetAll(), EntityName);
            return View(vm);
        }

        [HttpGet]
        public async override Task<ActionResult> Create()
        {
            return View(_vmFactory.CreatePriceNew(EntityName, new decimal()));
        }

        

        public override void SetEntity()
        {
            EntityName = "Sizes of Pizza";
        }
    }
}