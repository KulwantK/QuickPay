using QuickPay.Domain.Entities;
using QuickPay.EfCore.IEfCoreService;

namespace QuickPay.Repository.IRepository
{
    public interface IRepositoryService<TEntity> where TEntity : class,IUnitOfWork<TEntity>, IEfCorDbService<TEntity>, IEntity
    {

    }
}
