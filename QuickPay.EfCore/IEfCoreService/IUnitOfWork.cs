using QuickPay.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace QuickPay.EfCore.IEfCoreService
{
    /// <summary>
    /// service of unit of work
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : class, IEntity
    {
        IEfCoreDbService<TEntity> DbEntity { get; set; }
        Task CommitAsync();
        void Commit();
    }

}
