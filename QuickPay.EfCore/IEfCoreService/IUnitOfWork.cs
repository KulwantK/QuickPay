using QuickPay.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace QuickPay.EfCore.IEfCoreService
{

    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : class, IEntity
    {
        IEfCoreDbService<TEntity> Table { get; set; }
        Task CommitAsync();
        void Commit();
    }

}
