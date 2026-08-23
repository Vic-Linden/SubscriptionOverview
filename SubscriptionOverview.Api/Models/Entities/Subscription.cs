using SubscriptionOverview.Api.Models.Enums;

namespace SubscriptionOverview.Api.Models.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public BillingInterval BillingInterval { get; set; }

        public int CategoryId { get; set; } //FK
        public Category Category { get; set; } = null!; //Navigation property

        public string UserId { get; set; } = string.Empty; //for user identity
    }
}