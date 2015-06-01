using System.Collections;
using System.Collections.Generic;
using DDDPizza.DomainModels.Events;

namespace DDDPizza.DomainModels
{
    public class Pizza
    {

        private List<Toppings> _toppings;

        public Pizza(List<Toppings> toppings, Size size, Bread bread, Sauce sause, Cheese cheese)
        {
            _toppings = toppings;
            Size = size;
            Bread = bread;
            Sause = sause;
            Cheese = cheese;
            CalculateCost();
        }

        public Order Order { get; set; }

        public List<Toppings> Toppings
        {
            get { return new List<Toppings>(_toppings); }
            protected set
            {
                _toppings = value;
            }
        }
        public Bread Bread { get; set; }
        public Sauce Sause { get; set; }
        public Cheese Cheese { get; set; }
        public Size Size { get; set; }
        public decimal Total { get; private set; }

        public void CalculateCost()
        {
            foreach (var item in _toppings)
            {
                Total += item.Cost;
            }
            Total += Size.Cost;

            DomainEvents.Raise<PizzaOrdered>(new PizzaOrdered(this));
        }

    }
}
