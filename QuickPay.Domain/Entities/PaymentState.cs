namespace QuickPay.Domain.Entities
{
    public class PaymentState:BaseEntity
    {
        public PaymentState()
        {
        }
        public long PaymentId { get; set; }
        public string Status { get; set; }
        
    }
}
