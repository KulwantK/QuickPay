namespace QuickPay.WebApi.Models
{
    public class PaymentStateDto
    {
        public long Id { get; set; }
        public long PaymentId { get; set; }
        public string Status { get; set; }
    }
}
