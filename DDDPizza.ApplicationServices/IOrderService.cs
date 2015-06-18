using System.Collections.Generic;
using System.Threading.Tasks;
using DDDPizza.ViewModels;

namespace DDDPizza.ApplicationServices
{
    public interface IOrderService
    {
        Task<OrderVm> GetOrderByIdAsync(string id);
        Task<List<OrderVm>> GetAllOrdersAsync();
        Task<OrderVm> PlaceOrderAsync(OrderVm order);
        IDictionary<string, string> GetServiceOptions();
    }
}