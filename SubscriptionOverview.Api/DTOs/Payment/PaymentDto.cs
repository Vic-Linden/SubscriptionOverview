namespace SubscriptionOverview.Api.DTOs.Payment
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public DateTime PaidAt { get; set; }
        public decimal Amount { get; set; }
        public string SubscriptionName { get; set; } = string.Empty;
    }
}