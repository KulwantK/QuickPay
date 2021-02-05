using QuickPay.Domain.Entities;
using QuickPay.EfCore.IEfCoreService;
using QuickPay.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuickPay.Repository.Repository
{
    public class RepositoryService<TEntity> : IRepositoryService<TEntity> where TEntity : class, IEntity
    {
        private readonly IUnitOfWork<TEntity> unitOfWork;
        public RepositoryService(IUnitOfWork<TEntity> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Add(TEntity entity)
        {
            await unitOfWork.Table.Add(entity);
            await unitOfWork.Commit();
        }
        public async Task Add(IEnumerable<TEntity> entities)
        {
            await unitOfWork.Table.Add(entities);
            await unitOfWork.Commit();
        }
        public async Task<IList<TEntity>> All()
        {
            return await unitOfWork.Table.All();
        }
        public async Task<TEntity> GetById(long id)
        {
            return await unitOfWork.Table.GetById(id);
        }
        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression)
        {
            return await unitOfWork.Table.Where(expression);
        }
        public void Update(TEntity entity)
        {
            unitOfWork.Table.Update(entity);
            unitOfWork.Commit();
        }
    }
}
