using System;

namespace QuickPay.WebApi.Models
{
    public class PaymentDto
    {
        public PaymentDto()
        {
            State = new PaymentStateDto();
        }
        public long Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public PaymentStateDto State { get; set; }
    }
}
