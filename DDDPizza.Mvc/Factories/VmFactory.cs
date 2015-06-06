using System;
using System.Collections.Generic;
using AutoMapper;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.ViewModels;

namespace DDDPizza.Mvc.Factories
{
    public class VmCostFactory<T> : IVmCostFactory<T> where T : ICostInventoryEntity
    {
        public ManageCostInventoryVm Create(IEnumerable<T> list, string name)
        {
            return new ManageCostInventoryVm()
            {
                Title = String.Format("Manage {0}", name),
                Items = Mapper.Map<List<CostInventoryVm>>(list)
            };
        }

        public EditCostInventoryVm Create(T item, string name)
        {
            return new EditCostInventoryVm()
            {
                Title = name,
                Item = Mapper.Map<CostInventoryVm>(item)
            };
        }

        public EditCostInventoryVm Create(CostInventoryVm item, string name)
        {
            return new EditCostInventoryVm()
            {
                Title = name,
                Item = item
            };
        }

        public EditCostInventoryVm CreateNew(string name)
        {
            return new EditCostInventoryVm()
            {
                Title = name,
                Item = this.Create()
            };
        }

        public CostInventoryVm Create()
        {
            return new CostInventoryVm()
            {
                Id = Guid.NewGuid()
            };
        }
    }

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


    }
}