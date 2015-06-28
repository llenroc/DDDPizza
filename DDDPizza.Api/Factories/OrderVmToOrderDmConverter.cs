using System.Linq;
using AutoMapper;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Enums;
using DDDPizza.SharedKernel;
using DDDPizza.ViewModels;

namespace DDDPizza.Api.Factories
{
    public class OrderVmToOrderDmConverter : ITypeConverter<OrderVm, Order>
    {
        public Order Convert(ResolutionContext context)
        {
            var src = (OrderVm)context.SourceValue;
            var servType = Enumeration.FromDisplayName<ServiceType>(src.ServiceType.Replace(" ", ""));
            var pizzas = src.Pizzas.Select(x => Mapper.Map<PizzaVm, Pizza>(x)).ToList();
            var result = new Order(servType, pizzas, src.Name);
            return result;
        }
    }
}