using System.Collections.Generic;
using DDDPizza.ViewModels.CostInventory;

namespace DDDPizza.ViewModels.Inventory
{
    public class ManageInventoryVm 
    {
        public string Title { get; set; }
        public List<InventoryVm> Items { get; set; }

    }
}