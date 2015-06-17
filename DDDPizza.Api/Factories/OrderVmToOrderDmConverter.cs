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
            var servType = Enumeration.FromDisplayName<ServiceType>(src.ServiceType);
            var result = new Order(servType, src.Pizzas.Select(Mapper.Map<Pizza>).ToList(), src.Name);
            return result;
        }
    }
}