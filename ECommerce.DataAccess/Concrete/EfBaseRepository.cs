using ECommerce.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
         where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using TContext context = new();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using TContext context = new();
            var deletedEntity = await context.Set<TEntity>().FindAsync(id);
            context.Set<TEntity>().Remove(deletedEntity);
            var data = await context.SaveChangesAsync();
            return data > 0;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);

        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext context = new();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using TContext context = new();
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
