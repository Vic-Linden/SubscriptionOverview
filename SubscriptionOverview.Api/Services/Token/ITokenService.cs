using SubscriptionOverview.Api.Models.Entities;

namespace SubscriptionOverview.Api.Services.Token
{
   public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
    }
}