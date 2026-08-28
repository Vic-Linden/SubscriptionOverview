using SubscriptionOverview.Api.DTOs.Subscription;

namespace SubscriptionOverview.Api.Services.Subscriptions
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionDto>> GetAllAsync(string userId);
    }
}