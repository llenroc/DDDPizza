using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDDPizza.ViewModels.CostInventory;
using DDDPizza.ViewModels.Inventory;

namespace DDDPizza.ViewModels
{


    public class PlaceOrderVm
    {

        //[Required]
        public string Bread { get; set; }
   

        [Required]
        public string Cheese { get; set; }
  

        [Required]
        public string Sauce { get; set; }


        [Required]
        public string Size { get; set; }


        [Required(ErrorMessage = "Toppings Required")]
        public IEnumerable<string> Topping{ get; set; }


    }

    public class SubmitOrderVm
    {

        public InventoryVm Breads { get; set; }
  
        public InventoryVm Cheeses { get; set; }
  
        public InventoryVm Sauces { get; set; }
   
        public PriceInventoryVm Size { get; set; }

        [Display(Name = "Topping")]
        public List<PriceInventoryVm> Toppings { get; set; } 
    }

    public class OrderVm
    {

        public string Name { get; set; }
        public Guid Id { get; set; }
        public string ServiceType { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal TotalAmount { get; set; }

        public List<PizzaVm> Pizzas { get; set; }

    }




    public class PizzaVm
    {
        public InventoryVm Bread { get; set; }
        public InventoryVm Sause { get; set; }
        public InventoryVm Cheese { get; set; }
        public PriceInventoryVm Size { get; set; }
    }
}
