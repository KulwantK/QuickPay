using QuickPay.Domain.Entities;
using QuickPay.EfCore.IEfCoreService;
using QuickPay.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuickPay.Repository.Repository
{
    public class RepositoryService<TEntity> : IRepositoryService<TEntity> where TEntity : class, IEntity
    {
        private readonly IUnitOfWork<TEntity> unitOfWork;

        public IQueryable<TEntity> Table { get; set; }

        public RepositoryService(IUnitOfWork<TEntity> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.Table = unitOfWork.DbEntity.Table;
        }
        public async Task Add(TEntity entity)
        {
            await unitOfWork.DbEntity.Add(entity);
            await unitOfWork.CommitAsync();
        }
        public async Task Add(IEnumerable<TEntity> entities)
        {
            await unitOfWork.DbEntity.Add(entities);
            await unitOfWork.CommitAsync();
        }
        public async Task<IList<TEntity>> All()
        {
            return await unitOfWork.DbEntity.All();
        }
        public async Task<TEntity> GetById(long id)
        {
            return await unitOfWork.DbEntity.GetById(id);
        }
        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression)
        {
            return await unitOfWork.DbEntity.Where(expression);
        }
        public void Update(TEntity entity)
        {
            unitOfWork.DbEntity.Update(entity);
            unitOfWork.Commit();
        }
    }
}
