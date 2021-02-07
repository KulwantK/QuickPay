using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QuickPay.Domain.Entities;
using System.Reflection;

namespace QuickPay.EfCore
{
    public class QuickPayDbContext : DbContext
    {
        public QuickPayDbContext(DbContextOptions<QuickPayDbContext> options) : base(options) { }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentState> PaymentStates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Seed Data

            modelBuilder.Seed();
        }
    }
    public class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<QuickPayDbContext>
    {
        public QuickPayDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuickPayDbContext>();
            optionsBuilder.UseSqlServer("add you db connection info here !");

            return new QuickPayDbContext(optionsBuilder.Options);
        }
    }
}
