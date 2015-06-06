using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using DDDPizza.DomainModels.BaseTypes;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.Interfaces;
using DDDPizza.Mvc.Factories;
using DDDPizza.ViewModels;

namespace DDDPizza.Mvc.Controllers
{
    public abstract class InventoryBaseController<T> : Controller where T : IInventoryEntity
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IVmFactory<T> _vmFactory;
        public string EntityName;


        protected InventoryBaseController(IRepositoryFactory repositoryFactory, IVmFactory<T> vmFactory)
        {
            _repositoryFactory = repositoryFactory;
            _vmFactory = vmFactory;
            SetEntity();
        }
     
        [HttpGet]
        public virtual async Task<ActionResult> Index()
        {
            var vm = _vmFactory.Create(await _repositoryFactory.GetRepository<IInventoryRepository<T>>().GetAll(), EntityName);
            return View(vm);
        }

        [HttpGet]
        public virtual async Task<ActionResult> Create()
        {
            return View(_vmFactory.CreateNew(EntityName));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(InventoryVm item)
        {

            if (ModelState.IsValid)
            {
                var vmToDm = Mapper.Map<T>(item);
                var vm = await _repositoryFactory.GetRepository<IInventoryRepository<T>>().AddOrUpdate(vmToDm);
                return RedirectToAction("Index");
            }
           
            return View(_vmFactory.Create(item,EntityName));

        }

        [HttpGet]
        public virtual async Task<ActionResult> Edit(string id)
        {
           
            if(id == null)
                return RedirectToAction("Index");
            var vm = _vmFactory.Create(await _repositoryFactory.GetRepository<IInventoryRepository<T>>().GetById(Guid.Parse(id)), EntityName);
            return View(vm);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(InventoryVm item)
        {

            if (ModelState.IsValid)
            {
                var vmToDm = Mapper.Map<T>(item);
                var vm = await _repositoryFactory.GetRepository<IInventoryRepository<T>>().AddOrUpdate(vmToDm);
                return RedirectToAction("Index");
            }

            return View(_vmFactory.Create(item, EntityName));
           

        }


        [HttpGet]
        public virtual async Task<ActionResult> Delete(string id)
        {

            if (id == null)
                return RedirectToAction("Index");
            await _repositoryFactory.GetRepository<IInventoryRepository<T>>().Delete(Guid.Parse(id));
            return RedirectToAction("Index");

        }


        public abstract void SetEntity();


        public virtual void Logger(string msg)
        {
            Trace.TraceWarning(msg);
    
        }

    }
}