using Microsoft.EntityFrameworkCore;
using SubscriptionOverview.Api.Data;
using SubscriptionOverview.Api.DTOs.Subscription;
using SubscriptionOverview.Api.Models.Entities;

namespace SubscriptionOverview.Api.Services.Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly SubscriptionDbContext _context;

        public SubscriptionService(SubscriptionDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubscriptionDto>> GetAllAsync(string userId)
        {
            return await _context.Subscriptions
            .Where(s => s.UserId == userId) //filters the right user (not jwt)
            .Include(s => s.Category)
            .Select(s => new SubscriptionDto
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                BillingInterval = s.BillingInterval,
                CategoryName = s.Category.Name
            }).ToListAsync();
        }

        public async Task<SubscriptionDto?> GetByIdAsync(int id, string userId)
        {
            var subscription = await _context.Subscriptions
            .Include(s => s.Category)
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

            if (subscription is null)
            {
                return null;
            }

            return new SubscriptionDto
            {
                Id = subscription.Id,
                Name = subscription.Name,
                Price = subscription.Price,
                BillingInterval = subscription.BillingInterval,
                CategoryName = subscription.Category.Name
            };
        }

        public async Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto dto, string userId)
        {

            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId);

            if(!categoryExists)
            {
                throw new Exception("Category not found.");
            }

            var subscription = new Subscription
            {
                Name = dto.Name,
                Price = dto.Price,
                BillingInterval = dto.BillingInterval,
                CategoryId = dto.CategoryId,
                UserId = userId
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();

            var category = await _context.Categories.FindAsync(dto.CategoryId);

            return new SubscriptionDto
            {
                Id = subscription.Id,
                Name = subscription.Name,
                Price = subscription.Price,
                BillingInterval = subscription.BillingInterval,
                CategoryName = category!.Name
            };
        }

        public async Task<SubscriptionDto?> UpdateAsync(int id, CreateSubscriptionDto dto, string userId)
        {
            var subscription = await _context.Subscriptions
            .Include(s => s.Category)
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

            if(subscription is null)
            {
                return null;
            }

            subscription.Name = dto.Name;
            subscription.Price = dto.Price;
            subscription.BillingInterval = dto.BillingInterval;
            subscription.CategoryId = dto.CategoryId;
            await _context.SaveChangesAsync();

            return new SubscriptionDto
            {
                Id = subscription.Id,
                Name = subscription.Name,
                Price = subscription.Price,
                BillingInterval = subscription.BillingInterval,
                CategoryName = subscription.Category.Name
            };
        }
    }
}