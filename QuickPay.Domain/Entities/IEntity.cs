using System;
using System.Collections.Generic;
using System.Text;

namespace QuickPay.Domain.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime CreationTime { get; set; }
    }
}
