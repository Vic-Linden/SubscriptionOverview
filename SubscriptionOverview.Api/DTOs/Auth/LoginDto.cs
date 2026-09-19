using System.ComponentModel.DataAnnotations;

namespace SubscriptionOverview.Api.DTOs.Auth
{
    // Incoming data
    public class LoginDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}