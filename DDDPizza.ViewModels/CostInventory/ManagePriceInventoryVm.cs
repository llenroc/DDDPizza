using System.Collections.Generic;

namespace DDDPizza.ViewModels.CostInventory
{
    public class ManagePriceInventoryVm 
    {
        public string Title { get; set; }
        public List<PriceInventoryVm> Items { get; set; }

    }
}