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
        Task<IEnumerable<Order>> GetAllCurrentOrders();
        Task<IEnumerable<Order>> GetAllPastOrders();
        Task<long> GetAllPending();
        Task<Order> GetById(Guid id);
        Task<Order> Add(Order order);

    }
}
