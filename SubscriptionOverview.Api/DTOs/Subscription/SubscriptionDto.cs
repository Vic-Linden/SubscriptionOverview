using SubscriptionOverview.Api.Models.Enums;

namespace SubscriptionOverview.Api.DTOs.Subscription
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public BillingInterval BillingInterval { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}