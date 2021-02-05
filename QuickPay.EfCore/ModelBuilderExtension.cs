using Microsoft.EntityFrameworkCore;
using QuickPay.Common.Constants;
using QuickPay.Domain.Entities;
using System;

namespace QuickPay.EfCore
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder Seed(this ModelBuilder builder)
        {
            builder.Entity<Payment>().HasData(new Payment
            {
                Id = 1,
                CreditCardNumber = "421-4453-999-301",
                CardHolder = "James Smith",
                ExpirationDate = DateTime.Now.AddYears(1),
                SecurityCode = "331",
                Amount = 451.25M,
                PaymentState = PaymentState.Processed
            });
            return builder;
        }
    }
}
