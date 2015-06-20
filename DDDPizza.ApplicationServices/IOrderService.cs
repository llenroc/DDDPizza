using System.Collections.Generic;
using System.Threading.Tasks;
using DDDPizza.ViewModels;

namespace DDDPizza.ApplicationServices
{
    public interface IOrderService
    {
        Task<OrderVm> GetOrderByIdAsync(string id);
        Task<IEnumerable<OrderVm>> GetAllOrdersAsync();
        Task<IEnumerable<OrderVm>> GetAllOrdersByServiceTypeAsync(string type);
        Task<OrderVm> PlaceOrderAsync(OrderVm order);
        IDictionary<string, string> GetServiceOptions();
        Task<long> CountPendingOrders();
    }
}