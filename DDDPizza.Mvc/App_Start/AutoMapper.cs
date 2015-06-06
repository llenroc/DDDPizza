using DDDPizza.DomainModels;
using DDDPizza.ViewModels;

namespace DDDPizza.Mvc.App_Start
{
    public static class AutoMapperConfig
    {

 
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Order, OrderVm>().ForMember(x => x.ServiceType, y => y.MapFrom(src => src.ServiceType.ToString())).ReverseMap();
            AutoMapper.Mapper.CreateMap<PizzaVm, Pizza>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Bread, InventoryVm>().ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Bread)).ReverseMap();
            AutoMapper.Mapper.CreateMap<Cheese, InventoryVm>().ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Cheese)).ReverseMap();
            AutoMapper.Mapper.CreateMap<Sauce, InventoryVm>().ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Sauce)).ReverseMap();
            AutoMapper.Mapper.CreateMap<Toppings, InventoryVm>().ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Topping)).ReverseMap();
   
        
       
        }

    }
}