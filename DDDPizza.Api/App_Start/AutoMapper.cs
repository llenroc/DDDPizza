using AutoMapper;
using DDDPizza.Api.Factories;
using DDDPizza.DomainModels;
using DDDPizza.ViewModels;

namespace DDDPizza.Api.App_Start
{
    public static class AutoMapperConfig
    {

        public static void RegisterMappings()
        {
            // Models with no price
            Mapper.CreateMap<Bread, InventoryVm>()
                .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Bread))
                .ReverseMap();

            Mapper.CreateMap<Cheese, InventoryVm>()
                .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Cheese))
                .ReverseMap();

            Mapper.CreateMap<Sauce, InventoryVm>()
                .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Sauce))
                .ReverseMap();

            // Models with price
            Mapper.CreateMap<Topping, PriceInventoryVm>()
                .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Topping))
                .ReverseMap();

            Mapper.CreateMap<Size, PriceInventoryVm>()
                .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Size))
                .ReverseMap();

            // Pizzas and Orders
            Mapper.CreateMap<Pizza, PizzaVm>()
                .ForMember(x => x.Topping, y => y.MapFrom(src => src.Toppings));

            Mapper.CreateMap<PizzaVm, Pizza>()
                .ConvertUsing<PizzaVmToPizzaDmConverter>();

            Mapper.CreateMap<Order, OrderVm>()
                .ForMember(x => x.Total, y => y.MapFrom(src => src.TotalAmount))
                .ForMember(x => x.ServiceType, y => y.MapFrom(src => src.ServiceType.ToString()));

            Mapper.CreateMap<OrderVm, Order>()
                .ConvertUsing<OrderVmToOrderDmConverter>();
       
        }

    }
}