using System;

namespace QuickPay.EfRepository
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime CreationTime { get; set; }
    }
}
