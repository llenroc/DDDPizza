using System.Collections.Generic;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.ViewModels.CostInventory;
using DDDPizza.ViewModels.Inventory;

namespace DDDPizza.Mvc.Factories
{
    public interface IVmFactory<in T1> where T1 : IInventoryEntity
    {
        ManageInventoryVm Create(IEnumerable<T1> list, string name);
        EditInventoryVm Create(T1 item, string name);
        EditInventoryVm Create(InventoryVm item, string name);
        EditInventoryVm CreateNew(string name);
        InventoryVm Create();

        ManagePriceInventoryVm CreatePrice(IEnumerable<T1> list, string name);
        EditPriceInventoryVm CreatePrice(T1 item, string name);
        EditPriceInventoryVm CreatePrice(PriceInventoryVm item, string name);
        EditPriceInventoryVm CreatePriceNew(string name, decimal price);
        PriceInventoryVm CreatePrice();
    }


}