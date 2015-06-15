using System.Collections.Generic;

namespace DDDPizza.DomainModels
{
    public class Pizza 
    {

        private List<Topping> _toppings;

        public Pizza()
        {
            
        }
        public Pizza(List<Topping> toppings, Size size, Bread bread, Sauce sause, Cheese cheese)
        {
            _toppings = toppings;
            Size = size;
            Bread = bread;
            Sauce = sause;
            Cheese = cheese;
            CalculateCost();
        }

 

        public List<Topping> Toppings
        {
            get { return new List<Topping>(_toppings); }
            protected set
            {
                _toppings = value;
            }
        }
        public Bread Bread { get; set; }
        public Sauce Sauce { get; set; }
        public Cheese Cheese { get; set; }
        public Size Size { get; set; }
        public decimal Total { get; set; }

        public void CalculateCost()
        {
            if (_toppings[0] != null)
            {
                foreach (var item in _toppings)
                {
                    Total += item.Price;
                }
            }
        
            Total += Size.Price;

            //DomainEvents.Raise<PizzaOrdered>(new PizzaOrdered(this));
        }

    }
}
