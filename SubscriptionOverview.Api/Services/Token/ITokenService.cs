using SubscriptionOverview.Api.Models.Entities;

namespace SubscriptionOverview.Api.Services.Token
{
   public interface ITokenService
    {
        Task<string> GenerateToken(ApplicationUser user);
    }
}