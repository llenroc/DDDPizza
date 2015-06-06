using System.Collections.Generic;
using DDDPizza.DomainModels.BaseTypes;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.ViewModels;

namespace DDDPizza.Mvc.Factories
{
    public interface IVmFactory<in T> where T : IInventoryEntity
    {
        ManageInventoryVm Create(IEnumerable<T> list, string name);
        EditInventoryVm Create(T item, string name);
        EditInventoryVm Create(InventoryVm item, string name);
        EditInventoryVm CreateNew(string name);
        InventoryVm Create();

    }


}