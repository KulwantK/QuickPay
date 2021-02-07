using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickPay.Domain.Entities;
using System;

namespace QuickPay.Domain.Mappings
{
    class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreditCardNumber).IsRequired();
            builder.Property(x => x.CardHolder).IsRequired();
            builder.Property(x => x.ExpirationDate).IsRequired();
            builder.Property(x => x.SecurityCode);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.StateId).IsRequired();
            builder.Property(x => x.CreationTime).HasDefaultValue(DateTime.Now);
            builder.HasMany(x => x.States);
        }
    }
}
