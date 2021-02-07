using QuickPay.WebApi.Models;

namespace QuickPay.WebApi.IService
{
    public interface IPremiumPaymentService
    {
        PaymentResponseModel ProcessPremiumPayment(PaymentDto paymentDto, PaymentResponseModel responseModel);
    }
}
