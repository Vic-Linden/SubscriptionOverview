using SubscriptionOverview.Api.Data;

namespace SubscriptionOverview.Api.Services.Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly SubscriptionDbContext _context;

        public SubscriptionService(SubscriptionDbContext context)
        {
            _context = context;
        }
    }
}