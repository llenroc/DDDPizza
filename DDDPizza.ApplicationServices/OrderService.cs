using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.ViewModels;

namespace DDDPizza.ApplicationServices
{
    public class OrderService : IOrderService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public OrderService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public async Task<OrderVm> GetOrderById(string id)
        {
            var result = await _pizzaRepository.GetById(Guid.Parse(id));
            var vm = AutoMapper.Mapper.Map<Order, OrderVm>(result);
            return vm;
        }

        public async Task<List<OrderVm>> GetAllOrders()
        {
            var result = await _pizzaRepository.GetAll();
            var vm = AutoMapper.Mapper.Map<List<Order>, List<OrderVm>>(result.OrderByDescending(x => x.DateTimeStamp).ToList());
            return vm;
        }

        public void PlaceOrder(OrderVm order)
        {
            var vm = AutoMapper.Mapper.Map<OrderVm, Order>(order);
            _pizzaRepository.Add(vm);
        }
    }
}
