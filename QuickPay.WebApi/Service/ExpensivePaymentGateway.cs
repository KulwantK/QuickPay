using QuickPay.Common.Constants;
using QuickPay.WebApi.IService;
using QuickPay.WebApi.Models;
using System.Collections.Generic;

namespace QuickPay.WebApi.Service
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public bool IsAvailable()
        {
            return true;
        }

        public PaymentResponseModel ProcessExpensivePayment(PaymentDto paymentDto,PaymentResponseModel responseModel)
        {
            responseModel.Success = true;
            responseModel.Status = PaymentStatus.Processed;
            responseModel.State = new PaymentStateDto { Status = PaymentStatus.Processed };
            return responseModel;
        }
    }
}
