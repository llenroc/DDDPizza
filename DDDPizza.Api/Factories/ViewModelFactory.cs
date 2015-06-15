using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Enums;
using DDDPizza.ViewModels;

namespace DDDPizza.Api.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        public Order CreateOrder(OrderVm order)
        {
            var result = new Order(new ServiceType.DeliveryType(), order.Pizzas.Select(CreatePizza).ToList(), order.Name);
            return result;
        }

        public Pizza CreatePizza(PizzaVm pizza)
        {
            var toppingList = Mapper.Map<List<Topping>>(pizza.Topping.ToList());
            var size = Mapper.Map<Size>(pizza.Size);
            var bread = Mapper.Map<Bread>(pizza.Bread);
            var sauce = Mapper.Map<Sauce>(pizza.Sauce);
            var cheese = Mapper.Map<Cheese>(pizza.Cheese);
            return new Pizza(toppingList, size, bread,sauce, cheese);
        }

        public TOut CreateFromVm<TIn, TOut>(TIn obj)
        {
            return Mapper.Map<TOut>(obj);
        }
    }
}