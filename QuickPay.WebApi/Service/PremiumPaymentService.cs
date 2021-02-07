using QuickPay.Common.Constants;
using QuickPay.WebApi.IService;
using QuickPay.WebApi.Models;

namespace QuickPay.WebApi.Service
{
    public class PremiumPaymentService : IPremiumPaymentService
    {
        public PaymentResponseModel ProcessPremiumPayment(PaymentDto paymentDto, PaymentResponseModel responseModel)
        {
            responseModel.Success = true;
            responseModel.Status = PaymentStatus.Processed;
            responseModel.State = new PaymentStateDto { Status = PaymentStatus.Processed };
            return responseModel;
        }
    }
}
