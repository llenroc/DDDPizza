using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DDDPizza.DomainModels;
using DDDPizza.ViewModels;

namespace DDDPizza.Api.Factories
{
    public class PizzaVmToPizzaDmConverter : ITypeConverter<PizzaVm, Pizza>
    {
        public Pizza Convert(ResolutionContext context)
        {
            var src = (PizzaVm)context.SourceValue;
            var toppingList = Mapper.Map<List<Topping>>(src.Topping.ToList());
            var size = Mapper.Map<Size>(src.Size);
            var bread = Mapper.Map<Bread>(src.Bread);
            var sauce = Mapper.Map<Sauce>(src.Sauce);
            var cheese = Mapper.Map<Cheese>(src.Cheese);
            return new Pizza(toppingList, size, bread, sauce, cheese);
        }
    }
}