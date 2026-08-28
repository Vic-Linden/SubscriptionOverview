using System.ComponentModel.DataAnnotations;
using SubscriptionOverview.Api.Models.Enums;

namespace SubscriptionOverview.Api.DTOs.Subscription
{
    public class CreateSubscriptionDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 500000)]
        public decimal Price { get; set; }  

        [Required]
        public BillingInterval BillingInterval { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}