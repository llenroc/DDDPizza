using System.ComponentModel.DataAnnotations;

namespace DDDPizza.ViewModels
{
    public class EditCostInventoryVm
    {
        public string Title { get; set; }
        [Required]
        public CostInventoryVm Item { get; set; }

    }
}