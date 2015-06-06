using System.Collections.Generic;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.ViewModels;

namespace DDDPizza.Mvc.Factories
{
    public interface IVmFactory<in T1> where T1 : IInventoryEntity
    {
        ManageInventoryVm Create(IEnumerable<T1> list, string name);
        EditInventoryVm Create(T1 item, string name);
        EditInventoryVm Create(InventoryVm item, string name);
        EditInventoryVm CreateNew(string name);
        InventoryVm Create();

    }
}