using Microsoft.EntityFrameworkCore;
using SubscriptionOverview.Api.Data;
using SubscriptionOverview.Api.DTOs.Category;

namespace SubscriptionOverview.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly SubscriptionDbContext _context;

        public CategoryService(SubscriptionDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _context.Categories.Select(c => new CategoryDto
            {
                Id = c.Id, 
                Name = c.Name
            })
            .ToListAsync();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if(category is null)
            {
                return null;
            }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}