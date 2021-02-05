using QuickPay.Domain.Entities;
using QuickPay.EfCore.IEfCoreService;
using QuickPay.Repository.IRepository;

namespace QuickPay.Repository.Repository
{
    public class RepositoryService<TEntity>where TEntity:class,IRepositoryService<TEntity>,IUnitOfWork<TEntity>,IEfCorDbService<TEntity>,IEntity
    {
    }
}
