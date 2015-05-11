using System.Collections.Generic;
using System.Collections.ObjectModel;
using DDDPizza.DomainModels;

namespace DDDPizza.Mocks
{
    public static class PizzaMocks
    {
        public static ICollection<Cheese> GetCheese()
        {       
            return new Collection<Cheese>
            {
                new Cheese("Mozzarella"),
                new Cheese("Provolone"),
                new Cheese("Italian Hard Cheeses")
            };
        }


        public static ICollection<Sauce> GetSauces()
        {
            return new Collection<Sauce>
            {
                new Sauce("Tomato"),
                new Sauce("Pesto"),
                new Sauce("Muhammara"),
                new Sauce("Barbecue"),
                new Sauce("Tapenade")
            };
        }

        public static ICollection<Bread> BreadMocks()
        {
            return new Collection<Bread>
            {
                new Bread("Hand Tossed"),
                new Bread("Deep Dish"),
                new Bread("Thin"),
                new Bread("Stuffed")
            };
        }

        public static ICollection<Size> SizeMocks()
        {
            return new Collection<Size>
            {
                new Size("Small", 10.99m),
                new Size("Medium", 12.99m),
                new Size("Large", 14.99m),
                new Size("Extra Large", 16.99m),
            };
        }


        public static ICollection<Toppings> ToppingMocks()
        {
            return new Collection<Toppings>
            {
                new Toppings("Pepperoni", 0.99m),
                new Toppings("Mushrooms", 0.99m),
                new Toppings("Bacon", 1.99m),
                new Toppings("Extra cheese", 1.99m),
                new Toppings("Black olives", 1.99m),
                new Toppings("Green peppers", 1.99m),
                new Toppings("Sausage", 0.99m),
                new Toppings("Pineapple", 0.99m),
                new Toppings("Spinach", 0.99m)
            };
        }

    }
}









