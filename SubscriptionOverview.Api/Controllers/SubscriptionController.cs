using Microsoft.AspNetCore.Mvc;
using SubscriptionOverview.Api.Services.Subscriptions;

namespace SubscriptionOverview.Api.Controllers
{
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
    }
}