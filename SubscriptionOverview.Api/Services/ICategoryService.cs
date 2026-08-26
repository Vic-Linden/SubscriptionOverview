using SubscriptionOverview.Api.DTOs.Category;

namespace SubscriptionOverview.Api.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id); //Nullable reference type
        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
        Task<CategoryDto?> UpdateAsync(int id, CreateCategoryDto dto); //Nullable reference type
        Task<bool> DeleteAsync(int id);
    }
}