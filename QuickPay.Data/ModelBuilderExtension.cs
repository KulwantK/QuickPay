using Microsoft.EntityFrameworkCore;

namespace QuickPay.Dal
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder Seed(this ModelBuilder builder)
        {
            return builder;
        }
    }
}
