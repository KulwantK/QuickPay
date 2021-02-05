using QuickPay.Common.Constants;
using System;

namespace QuickPay.WebApi.Models
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public PaymentState PaymentState { get; set; }
    }
}
