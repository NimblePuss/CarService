using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeetrootRepository.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        int Create(T item);
        Task Remove(T item);
        Task Remove(int id);
        Task Edit(T item);

        Task<IEnumerable<T>> GetAll(int skip, int take);
        Task<IEnumerable<T>> Find(Func<T, bool> predicate);
    }
}