using System.ComponentModel.DataAnnotations;

namespace DDDPizza.ViewModels
{
    public class CostInventoryVm : InventoryVm
    {
        [Required(ErrorMessage = "Cost is required")]
        public string Cost { get; set; }
    }
}