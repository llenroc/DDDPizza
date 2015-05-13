using System.Collections.Generic;

namespace DDDPizza.SharedKernel.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T obj);
        T Update(T obj);
        void Delete(int id);
    }
}
