using System.Collections.Generic;
using System.Threading.Tasks;
using DDDPizza.ViewModels;

namespace DDDPizza.ApplicationServices
{
    public interface IOrderService
    {
        Task<OrderVm> GetOrderById(string id);
        Task<List<OrderVm>> GetAllOrders();
        void PlaceOrder(OrderVm order);
    }
}