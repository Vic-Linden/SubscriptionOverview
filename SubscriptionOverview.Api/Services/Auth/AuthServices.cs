using Microsoft.AspNetCore.Identity;
using SubscriptionOverview.Api.Models.Entities;
using SubscriptionOverview.Api.DTOs.Auth;
using SubscriptionOverview.Api.Services.Token;
using SubscriptionOverview.Api.Exceptions;

namespace SubscriptionOverview.Api.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Username = dto.Username
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(error => error.Description));
                throw new BadRequestException($"Registration failed: {errors}");
            }

            return await _tokenService.GenerateToken(user);
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!isPasswordValid)
            {
                throw new BadRequestException("Invalid email or password");
            }

            return await _tokenService.GenerateToken(user);
        }
    }
}