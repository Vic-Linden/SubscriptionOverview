namespace SubscriptionOverview.Api.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaidAt { get; set; }
        public decimal Amount { get; set; }

        public int SubscriptionId { get; set; } //FK
        public Subscription Subscription { get; set; } = null!; //Navigation property
    }
}