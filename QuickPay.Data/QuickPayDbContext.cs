using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace QuickPay.Dal
{
    public class QuickPaydbContext:DbContext
    {
        public QuickPaydbContext(DbContextOptions<QuickPaydbContext> options):base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Seed Data

            modelBuilder.Seed();
        }
    }
}
