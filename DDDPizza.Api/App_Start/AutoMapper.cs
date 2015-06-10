using System.Web.Razor.Generator;
using AutoMapper;
using DDDPizza.Api.Models;
using DDDPizza.DomainModels;
using DDDPizza.ViewModels;
using DDDPizza.ViewModels.CostInventory;
using DDDPizza.ViewModels.Inventory;
using Newtonsoft.Json.Serialization;

namespace DDDPizza.Mvc.App_Start
{
    public static class AutoMapperConfig
    {

 
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Order, OrderVm>().ForMember(x => x.ServiceType, y => y.MapFrom(src => src.ServiceType.ToString())).ReverseMap();
            Mapper.CreateMap<PizzaVm, Pizza>().ReverseMap();

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
       
       
        }

    }
}