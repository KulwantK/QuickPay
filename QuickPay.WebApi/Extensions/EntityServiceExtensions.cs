using Microsoft.Extensions.DependencyInjection;
using QuickPay.WebApi.IService;
using QuickPay.WebApi.Service;

namespace QuickPay.WebApi.Extensions
{
    public static class EntityServiceExtensions
    {
        public static IServiceCollection AddEntityService(this IServiceCollection service)
        {
            service.AddScoped<IPaymentProcessService, PaymentProcessService>();
            return service;
        }
    }
}

