using System;
using System.Collections.Generic;
using AutoMapper;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.ViewModels;
using DDDPizza.ViewModels.CostInventory;
using DDDPizza.ViewModels.Inventory;

namespace DDDPizza.Mvc.Factories
{

    public class VmFactory<T> : IVmFactory<T> where T : IInventoryEntity
    {

        /// <summary>
        /// Create a ViewModel with a list of domain inventory models
        /// </summary>
        public ManageInventoryVm Create(IEnumerable<T> list, string name)
        {
            return new ManageInventoryVm()
            {
                Title = String.Format("Manage {0}", name),
                Items = Mapper.Map<List<InventoryVm>>(list)
            };
        }

        /// <summary>
        /// Create a ViewModel from an existing domain model
        /// </summary>
        public EditInventoryVm Create(T item, string name)
        {
            return new EditInventoryVm()
            {
                Title = name,
                Item = Mapper.Map<InventoryVm>(item)
            };
        }

        /// <summary>
        /// Create a ViewModel from an existing domain model
        /// </summary>
        public EditInventoryVm Create(InventoryVm item, string name)
        {
            return new EditInventoryVm()
            {
                Title = name,
                Item = item
            };
        }

        /// <summary>
        /// Create a new blank ViewModel for a create screen
        /// </summary>
        public EditInventoryVm CreateNew(string name)
        {
            return new EditInventoryVm()
            {
                Title = name,
                Item = this.Create()
            };
        }

        /// <summary>
        /// Create a new blank ViewModel,yet to be created in the domain
        /// </summary>
        public InventoryVm Create()
        {
            return new InventoryVm()
            {
                Id = Guid.NewGuid()
            };
        }

        public ManagePriceInventoryVm CreatePrice(IEnumerable<T> list, string name)
        {
            return new ManagePriceInventoryVm()
            {
                Title = String.Format("Manage {0}", name),
                Items = Mapper.Map<List<PriceInventoryVm>>(list)
            };
        }

        public EditPriceInventoryVm CreatePrice(T item, string name)
        {
            return new EditPriceInventoryVm()
            {
                Title = name,
                Item = Mapper.Map<PriceInventoryVm>(item)
            };
        }

        public EditPriceInventoryVm CreatePrice(PriceInventoryVm item, string name)
        {
            return new EditPriceInventoryVm()
            {
                Title = name,
                Item = Mapper.Map<PriceInventoryVm>(item)
            };
        }

        public EditPriceInventoryVm CreatePriceNew(string name, decimal price)
        {
            return new EditPriceInventoryVm()
            {
                Title = name,
                Item = this.CreatePrice()
            };
        }

        public PriceInventoryVm CreatePrice()
        {
            return new PriceInventoryVm()
            {
                Id = Guid.NewGuid()
            };
        }
    }
}