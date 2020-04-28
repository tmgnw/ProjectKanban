using KanbanApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Interface
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task<T> Delete(int id);
    }
}
