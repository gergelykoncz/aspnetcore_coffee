using CoffeeShop.BusinessEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShop.DataAccess.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByCriteria(Expression<Func<T, bool>> criteria);

        Task Upsert(T entity);
        Task Delete(T entity);
        Task Delete(long id);
    }
}
