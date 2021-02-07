using QuickPay.WebApi.Models;

namespace QuickPay.WebApi.IService
{
    public interface ICheapPaymentGateway
    {
        PaymentResponseModel ProcessCheapPayment(PaymentDto paymentDto, PaymentResponseModel responseModel);
    }
}
