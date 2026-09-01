using Microsoft.EntityFrameworkCore;
using SubscriptionOverview.Api.Data;
using SubscriptionOverview.Api.DTOs.Payment;

namespace SubscriptionOverview.Api.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly SubscriptionDbContext _context;

        public PaymentService(SubscriptionDbContext context)
        {
            _context = context;
        }

        public async Task<List<PaymentDto>> GetAllAsync(string userId)
        {
            return await _context.Payments
            .Include(p => p.Subscription)
            .Where(p => p.Subscription.UserId == userId)
            .Select(p => new PaymentDto
            {
                Id = p.Id,
                PaidAt = p.PaidAt,
                Amount = p.Amount,
                SubscriptionName = p.Subscription.Name
            })
            .ToListAsync();
        }
    }
}