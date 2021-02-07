using QuickPay.WebApi.Models;

namespace QuickPay.WebApi.IService
{
    public interface IExpensivePaymentGateway
    {
        bool IsAvailable();
        PaymentResponseModel ProcessExpensivePayment(PaymentDto paymentDto,PaymentResponseModel responseModel);
    }
}
