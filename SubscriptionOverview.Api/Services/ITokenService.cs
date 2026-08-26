using SubscriptionOverview.Api.Models.Entities;

namespace SubscriptionOverview.Api.Services
{
   public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
    }
}