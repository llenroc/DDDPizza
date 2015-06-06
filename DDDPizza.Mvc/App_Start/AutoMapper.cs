using AutoMapper;
using DDDPizza.DomainModels;
using DDDPizza.ViewModels;
using DDDPizza.ViewModels.CostInventory;
using DDDPizza.ViewModels.Inventory;

namespace DDDPizza.Mvc.App_Start
{
    public static class AutoMapperConfig
    {

 
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Order, OrderVm>().ForMember(x => x.ServiceType, y => y.MapFrom(src => src.ServiceType.ToString())).ReverseMap();
            AutoMapper.Mapper.CreateMap<PizzaVm, Pizza>().ReverseMap();

            // Models with no price
            AutoMapper.Mapper.CreateMap<Bread, InventoryVm>()
                .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Bread))
                .ReverseMap();

            AutoMapper.Mapper.CreateMap<Cheese, InventoryVm>()
                .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Cheese))
                .ReverseMap();

            AutoMapper.Mapper.CreateMap<Sauce, InventoryVm>()
                .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Sauce))
                .ReverseMap();

            // Models with price
            AutoMapper.Mapper.CreateMap<Topping, PriceInventoryVm>()
                .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Topping))
                .ReverseMap();

            AutoMapper.Mapper.CreateMap<Size, PriceInventoryVm>()
                .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Size))
                .ReverseMap();    
       
       
        }

    }
}