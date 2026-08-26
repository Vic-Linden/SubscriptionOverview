using SubscriptionOverview.Api.DTOs.Auth;

namespace SubscriptionOverview.Api.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}