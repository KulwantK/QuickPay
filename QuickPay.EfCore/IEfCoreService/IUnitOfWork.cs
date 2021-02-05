using QuickPay.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace QuickPay.EfCore.IEfCoreService
{

    public interface IUnitOfWork<TType> : IDisposable where TType : class, IEntity
    {
        IEfCorDbService<TType> Table { get; set; }
        Task Commit();
    }

}
