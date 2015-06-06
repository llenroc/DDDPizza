using System.Collections.Generic;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.ViewModels;

namespace DDDPizza.Mvc.Factories
{
    public interface IVmCostFactory<in T> where T : ICostInventoryEntity
    {
        ManageCostInventoryVm Create(IEnumerable<T> list, string name);
        EditCostInventoryVm Create(T item, string name);
        EditCostInventoryVm Create(CostInventoryVm item, string name);
        EditCostInventoryVm CreateNew(string name);
        CostInventoryVm Create();
    }
}