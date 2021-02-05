using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace QuickPay.EfCore
{
    public class QuickPayDbContext : DbContext
    {
        public QuickPayDbContext(DbContextOptions<QuickPayDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Seed Data

            modelBuilder.Seed();
        }
    }
}
