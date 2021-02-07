using Microsoft.EntityFrameworkCore;
using QuickPay.Common.Constants;
using QuickPay.Domain.Entities;
using System;
using System.Collections.Generic;

namespace QuickPay.EfCore
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder Seed(this ModelBuilder builder)
        {
            builder.Entity<Payment>(p =>
            {
                p.HasData(new Payment
                {
                    Id = 1,
                    CreditCardNumber = "421-4453-999-301",
                    CardHolder = "James Smith",
                    ExpirationDate = DateTime.Now.AddYears(1),
                    SecurityCode = "331",
                    Amount = 451.25M,
                    StateId = 1
                });
                p.OwnsMany(x => x.States).HasData(new PaymentState
                {
                    Id = 1,
                    PaymentId = 1,
                    Status = PaymentStatus.Processed
                });
            });
            return builder;
        }
    }
}
