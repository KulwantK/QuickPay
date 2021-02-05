using QuickPay.WebApi.IService;
using QuickPay.WebApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPay.WebApi.Service
{
    public class PaymentProcessService : IPaymentProcessService
    {
        public PaymentProcessService()
        {

        }
        public bool IsValidRequest(PaymentResponseModel paymentResponse)
        {
            if(string.IsNullOrWhiteSpace(paymentResponse.CreditCardNumber))
            {
                paymentResponse.Errors.Add("credit card number please");
            }
            if (string.IsNullOrWhiteSpace(paymentResponse.CardHolder))
            {
                paymentResponse.Errors.Add("credit card number please");
            }
            if(paymentResponse.ExpirationDate<DateTime.Today)
            {
                paymentResponse.Errors.Add("please make sure card is not expired");
            }
            if(paymentResponse.Amount<=0.0M)
            {
                paymentResponse.Errors.Add("enter valid amount please");
            }
            return paymentResponse.Errors.Any();
        }

        public Task<PaymentResponseModel> ProcessPayment(PaymentDto payemntDto)
        {
            throw new NotImplementedException();
        }
    }
}
