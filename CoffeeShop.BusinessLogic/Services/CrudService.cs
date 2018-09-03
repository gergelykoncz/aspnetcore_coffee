using CoffeeShop.BusinessEntity.Entities;
using CoffeeShop.BusinessLogic.Services.Interfaces;
using CoffeeShop.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShop.BusinessLogic.Services
{
    public class CrudService<T> : ICrudService<T> where T : class, IEntity
    {
        private readonly IRepository<T> repository;

        public CrudService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task Delete(T entity)
        {
            await this.repository.Delete(entity).ConfigureAwait(false);
        }

        public async Task Delete(long id)
        {
            await this.repository.Delete(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.repository.GetAll().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetByCriteria(Expression<Func<T, bool>> expression)
        {
            return await this.repository.GetByCriteria(expression).ConfigureAwait(false);
        }

        public async Task<T> GetById(long id)
        {
            return await this.repository.GetById(id).ConfigureAwait(false);
        }

        public async Task Upsert(T entity)
        {
            await this.repository.Upsert(entity).ConfigureAwait(false);
        }
    }
}
