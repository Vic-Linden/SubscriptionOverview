using Microsoft.AspNetCore.Identity;

namespace SubscriptionOverview.Api.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayUsername { get; set; } = string.Empty;
    }
}