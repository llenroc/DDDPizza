using System.ComponentModel.DataAnnotations;

namespace DDDPizza.ViewModels.Inventory
{
    public class EditInventoryVm
    {
        public string Title { get; set; }
        [Required]
        public InventoryVm Item { get; set; }

    }
}