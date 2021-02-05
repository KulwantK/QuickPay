using QuickPay.Domain.Entities;
using QuickPay.EfCore.IEfCoreService;
using System.Threading.Tasks;

namespace QuickPay.EfCore.EfCoreService
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class, IEntity
    {
        public IEfCorDbService<TEntity> Table { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public UnitOfWork(QuickPayDbContext dbContext)
        {
            Table = new EfCorDbService<TEntity>(dbContext);
        }

        public Task Commit()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
