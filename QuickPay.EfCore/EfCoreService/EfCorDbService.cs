using Microsoft.EntityFrameworkCore;
using QuickPay.Domain.Entities;
using QuickPay.EfCore.IEfCoreService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuickPay.EfCore.EfCoreService
{
    public class EfCorDbService<TEntity> : IEfCorDbService<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> Table;
        
        public EfCorDbService(QuickPayDbContext dbContext)
        {
            Table = dbContext.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task Add(IEnumerable<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task<IList<TEntity>> All()
        {
            return await Table.ToListAsync();
        }

        public async Task<TEntity> GetById(long id)
        {
            return await Table.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            Table.Update(entity);
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> Query = Table;
            return await Table.Where(expression).ToListAsync();
        }
    }
}
