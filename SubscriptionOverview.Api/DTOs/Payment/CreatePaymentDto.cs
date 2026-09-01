using System.ComponentModel.DataAnnotations;

namespace SubscriptionOverview.Api.DTOs.Payment
{
    public class CreatePaymentDto
    {
        [Required]
        public DateTime PaidAt { get; set; }

        [Required]
        [Range(0.01, 500000)]
        public decimal Amount { get; set; }
        
        [Required]
        public int SubscriptionId { get; set; }
    }
}