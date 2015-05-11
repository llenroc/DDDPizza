using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels.Events
{
    public class PizzaOrdered : IDomainEvent
    {
        public Pizza Pizza { get; set; }
        public System.DateTime DateOccurred { get; private set; }

        public PizzaOrdered(Pizza pizza, DateTime dateCreated)
        {
            this.Pizza = pizza;
            this.DateOccurred = dateCreated;
        }

        public PizzaOrdered(Pizza pizza)
            : this(pizza, DateTime.Now)
        {
        }

 
    }
}
