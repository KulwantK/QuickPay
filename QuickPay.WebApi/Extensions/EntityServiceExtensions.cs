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
            service.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            service.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            service.AddScoped<IPremiumPaymentService, PremiumPaymentService>();
            return service;
        }
    }
}

