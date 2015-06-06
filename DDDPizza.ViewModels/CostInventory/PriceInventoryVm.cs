using System.ComponentModel.DataAnnotations;
using DDDPizza.ViewModels.Inventory;

namespace DDDPizza.ViewModels.CostInventory
{
    public class PriceInventoryVm : InventoryVm
    {
        [Required(ErrorMessage = "Cost is required")]
        public string Price { get; set; }
    }
}