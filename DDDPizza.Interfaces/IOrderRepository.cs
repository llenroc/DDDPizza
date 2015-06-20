using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Enums;

namespace DDDPizza.Interfaces
{
    public interface IOrderRepository : IInventoryRepository
    {

        Task<IEnumerable<Order>> GetAllByStatus(ServiceType type);
        Task<IEnumerable<Order>> GetAll();
        Task<long> GetAllPending();
        Task<Order> GetById(Guid id);
        Task<Order> Add(Order order);

        Task<List<Topping>> GetAllToppings();
        Task<List<Size>> GetAllSizes();
        Task<List<Sauce>> GetAllSauces();
        Task<List<Cheese>> GetAllCheeses();

        Task<Bread> GetBreadById(Guid id);
        Task<List<Bread>> GetAllBreads();

  

    }
}
