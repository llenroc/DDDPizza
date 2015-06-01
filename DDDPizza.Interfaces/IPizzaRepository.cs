using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDPizza.DomainModels;

namespace DDDPizza.Interfaces
{
    public interface IPizzaRepository
    {

        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<Order> Add(Order order);

        Task<List<Toppings>> GetAllToppings();
        Task<List<Size>> GetAllSizes();
        Task<List<Sauce>> GetAllSauces();
        Task<List<Cheese>> GetAllCheeses();

        Task<Bread> GetBreadById(Guid id);
        Task<List<Bread>> GetAllBreads();

        Task SeedToppings();
        Task SeedSizes();
        Task SeedSauces();
        Task SeedCheeses();
        Task SeedBreads();

    }
}
