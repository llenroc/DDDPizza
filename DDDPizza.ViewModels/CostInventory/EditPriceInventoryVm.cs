using System.ComponentModel.DataAnnotations;

namespace DDDPizza.ViewModels.CostInventory
{
    public class EditPriceInventoryVm
    {
        public string Title { get; set; }
        [Required]
        public PriceInventoryVm Item { get; set; }

    }
}