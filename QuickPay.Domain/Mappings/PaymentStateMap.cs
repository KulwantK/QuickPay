using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickPay.Domain.Entities;

namespace QuickPay.Domain.Mappings
{
    public class PaymentStateMap : IEntityTypeConfiguration<PaymentState>
    {
        public void Configure(EntityTypeBuilder<PaymentState> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PaymentId);
            builder.Property(x => x.Status);
        }
    }
}
