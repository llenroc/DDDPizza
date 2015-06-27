using System.ComponentModel.DataAnnotations;

namespace DDDPizza.ViewModels
{
    public class PriceInventoryVm : InventoryVm
    {
        [Required(ErrorMessage = "Cost is required")]
        public string Price { get; set; }
    }
}