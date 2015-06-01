using System;
using System.Collections.Generic;
using AutoMapper;
using DDDPizza.DomainModels.BaseTypes;
using DDDPizza.ViewModels;

namespace DDDPizza.Mvc.Factories
{

    public interface IVmFactory<in T> where T : InventoryBase
    {
        ManageInventoryVm Create(IEnumerable<T> list, string name);
        EditInventoryVm Create(T item, string name);
        EditInventoryVm Create(InventoryVm item, string name);
        EditInventoryVm CreateNew(string name);
        InventoryVm Create();

    }

    public class VmFactory<T> : IVmFactory<T> where T : InventoryBase
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