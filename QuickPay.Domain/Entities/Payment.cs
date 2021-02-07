using System;
namespace QuickPay.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Payment()
        {
            State = new PaymentState();
        }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public PaymentState State{ get; set; }

    }
}
