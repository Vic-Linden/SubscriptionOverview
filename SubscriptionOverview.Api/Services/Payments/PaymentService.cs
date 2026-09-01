using Microsoft.EntityFrameworkCore;
using SubscriptionOverview.Api.Data;
using SubscriptionOverview.Api.DTOs.Payment;
using SubscriptionOverview.Api.Models.Entities;

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

        public async Task<PaymentDto?> GetByIdAsync(int id, string userId)
        {
            var payment = await _context.Payments
            .Include(p => p.Subscription)
            .FirstOrDefaultAsync(p => p.Id == id && p.Subscription.UserId == userId);

            if(payment is null)
            {
                return null;
            }

            return new PaymentDto
            {
                Id = payment.Id,
                PaidAt = payment.PaidAt,
                Amount = payment.Amount,
                SubscriptionName = payment.Subscription.Name
            };
        }
    }
}