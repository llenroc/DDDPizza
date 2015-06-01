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

            AutoMapper.Mapper.CreateMap<Bread, InventoryVm>().ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Bread));
            AutoMapper.Mapper.CreateMap<Cheese, InventoryVm>().ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Cheese));
            AutoMapper.Mapper.CreateMap<Sauce, InventoryVm>().ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Sauce));

            //AutoMapper.Mapper.CreateMap<InventoryVm, Bread>();
            //AutoMapper.Mapper.CreateMap<InventoryVm, Cheese>();
            //AutoMapper.Mapper.CreateMap<InventoryVm, Sauce>();
        
       
        }

    }
}