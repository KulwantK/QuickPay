using QuickPay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuickPay.Repository.IRepository
{
    public interface IRepositoryService<TEntity>where TEntity:class,IEntity
    {
        Task Add(TEntity entity);
        Task Add(IEnumerable<TEntity> entities);
        Task<IList<TEntity>> All();
        Task<TEntity> GetById(long id);
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression);
        void Update(TEntity entity);
        IQueryable<TEntity> Table { get; }
    }
}
