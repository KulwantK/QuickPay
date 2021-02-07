using System;
using System.Collections.Generic;

namespace QuickPay.WebApi.Models
{
    public class PaymentResponseModel
    {
        public PaymentResponseModel()
        {
            Errors = new List<string>();
        }
        public long Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
