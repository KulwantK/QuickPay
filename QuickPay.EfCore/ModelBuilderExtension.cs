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
            //use this method if data needs to be seeded
            return builder;
        }
    }
}
