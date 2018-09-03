using CoffeeShop.BusinessEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShop.BusinessLogic.Services.Interfaces
{
    public interface ICrudService<T> where T : class, IEntity
    {
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByCriteria(Expression<Func<T, bool>> expression);
        Task Upsert(T entity);
        Task Delete(T entity);
        Task Delete(long id);
    }
}
