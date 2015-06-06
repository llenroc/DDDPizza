using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.Interfaces
{
    public interface IInventoryRepository
    {
        
    }

    public interface IInventoryRepository<T> : IInventoryRepository where T : IInventoryEntity 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> AddOrUpdate(T obj);
        Task Delete(Guid id);
    }

    public interface ICostInventoryRepository<T> : IInventoryRepository where T : ICostInventoryEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> AddOrUpdate(T obj);
        Task Delete(Guid id);
    }
}