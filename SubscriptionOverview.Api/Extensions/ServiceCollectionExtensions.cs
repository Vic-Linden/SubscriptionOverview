using SubscriptionOverview.Api.Services.Auth;
using SubscriptionOverview.Api.Services.Token;
using SubscriptionOverview.Api.Services.Categories;



namespace SubscriptionOverview.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}