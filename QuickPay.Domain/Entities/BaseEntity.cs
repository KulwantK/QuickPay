using QuickPay.EfRepository;
using System;

namespace QuickPay.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
