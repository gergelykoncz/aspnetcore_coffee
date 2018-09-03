using CoffeeShop.BusinessEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShop.DataAccess.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly CoffeeContext coffeeContext;
        private readonly DbSet<T> DbSet;

        public BaseRepository(CoffeeContext coffeeContext)
        {
            this.coffeeContext = coffeeContext;
            this.DbSet = this.coffeeContext.Set<T>();
        }

        public async Task Delete(T entity)
        {
            this.DbSet.Remove(entity);
            await this.coffeeContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(long id)
        {
            T entity = await this.GetById(id).ConfigureAwait(false);
            if (entity != null)
            {
                await this.Delete(entity).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.DbSet.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetByCriteria(Expression<Func<T, bool>> criteria)
        {
            return await this.DbSet.Where(criteria).ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetById(long id)
        {
            var items = await this.GetByCriteria(x => x.Id == id).ConfigureAwait(false);
            return items.FirstOrDefault();
        }

        public async Task Upsert(T entity)
        {
            if (entity.Id != 0)
            {
                this.DbSet.Update(entity);
            }
            else
            {
                this.DbSet.Add(entity);
            }
            await this.coffeeContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
