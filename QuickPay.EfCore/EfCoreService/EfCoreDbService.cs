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
    public class EfCoreDbService<TEntity> : IEfCoreDbService<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> DbEntity;
        public IQueryable<TEntity> Table { get; }
        public EfCoreDbService(QuickPayDbContext dbContext)
        {
            DbEntity = dbContext.Set<TEntity>();
            Table = DbEntity.AsNoTracking().AsQueryable();
        }
        public async Task Add(TEntity entity)
        {
            await DbEntity.AddAsync(entity);
        }
        public async Task Add(IEnumerable<TEntity> entities)
        {
            await DbEntity.AddRangeAsync(entities);
        }
        public async Task<IList<TEntity>> All()
        {
            return await DbEntity.ToListAsync();
        }
        public async Task<TEntity> GetById(long id)
        {
            return await DbEntity.FindAsync(id);
        }
        public void Update(TEntity entity)
        {
            DbEntity.Update(entity);
        }
        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> Query = DbEntity;
            return await Query.Where(expression).ToListAsync();
        }
    }
}