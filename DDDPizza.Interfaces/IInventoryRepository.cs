using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using DDDPizza.DomainModels.BaseTypes;

namespace DDDPizza.Interfaces
{

    public interface IRepositoryFactory
    {
        T GetRepository<T>() where T : IInventoryRepository;
       
    }

   

    public interface IInventoryRepository
    {
        
    }

    public interface IInventoryRepository<T> : IInventoryRepository where T : InventoryBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> AddOrUpdate(T obj);
        Task Delete(Guid id);
  
    }
}