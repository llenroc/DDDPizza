using System.Collections;
using System.Collections.Generic;

namespace DDDPizza.DomainModels
{
    public class Pizza
    {
        private readonly List<Toppings> _toppings;

        public Pizza(List<Toppings> toppings, Size size, Bread bread, Sauce sause, Cheese cheese)
        {
            _toppings = toppings;
            Size = size;
            Bread = bread;
            Sause = sause;
            Cheese = cheese;
            CalculateCost();
        }

        public IEnumerable<Toppings> Toppings { get { return _toppings; }}
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
        }

    }
}
