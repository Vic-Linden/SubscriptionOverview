using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubscriptionOverview.Api.DTOs.Subscription;
using SubscriptionOverview.Api.Services.Subscriptions;

namespace SubscriptionOverview.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/subscriptions")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubscriptionDto>>> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var subscriptions = await _subscriptionService.GetAllAsync(userId);

            return subscriptions;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionDto>> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var subscription = await _subscriptionService.GetByIdAsync(id, userId);

            if(subscription is null)
            {
                return NotFound();
            }

            return subscription;
        }
    }
}