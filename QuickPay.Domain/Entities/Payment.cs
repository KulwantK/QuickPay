using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickPay.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Payment()
        {
            States = new List<PaymentState>();
        }
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$")]
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        [StringLength(3)]
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public long StateId { get; set; }
        public List<PaymentState> States { get; set; }

    }
}
