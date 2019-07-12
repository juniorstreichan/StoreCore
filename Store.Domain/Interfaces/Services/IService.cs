using System.Collections.Generic;

namespace Store.Domain.Interfaces.Services
{
    public interface IService<T, PK>
    {
        T Add(T t);
        T Change(T t);
        void Remove(PK id);
        T GetById(PK id);
        IEnumerable<T> GetAll();
    }
}