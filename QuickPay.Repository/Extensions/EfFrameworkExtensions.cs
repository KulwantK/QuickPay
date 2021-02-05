using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickPay.EfCore;
using QuickPay.EfCore.EfCoreService;
using QuickPay.EfCore.IEfCoreService;
using QuickPay.Repository.IRepository;
using QuickPay.Repository.Repository;

namespace QuickPay.Repository.Extensions
{
    public static class EfFrameworkExtensions
    {
        public static IServiceCollection AddEntityFrameWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuickPayDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IEfCoreDbService<>), typeof(EfCoreDbService<>));
            services.AddScoped(typeof(UnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>));
            return services;
        }
    }
}
