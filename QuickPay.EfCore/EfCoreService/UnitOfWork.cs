using QuickPay.Domain.Entities;
using QuickPay.EfCore.IEfCoreService;
using System.Threading.Tasks;

namespace QuickPay.EfCore.EfCoreService
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class, IEntity
    {
        private readonly QuickPayDbContext dbContext;
        public IEfCoreDbService<TEntity> Table { get ; set ; }
        public UnitOfWork(QuickPayDbContext dbContext)
        {
            this.dbContext = dbContext;
            Table = new EfCoreDbService<TEntity>(dbContext);
        }
        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
