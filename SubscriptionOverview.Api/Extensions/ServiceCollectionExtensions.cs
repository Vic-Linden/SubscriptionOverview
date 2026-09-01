using SubscriptionOverview.Api.Services.Auth;
using SubscriptionOverview.Api.Services.Token;
using SubscriptionOverview.Api.Services.Categories;
using SubscriptionOverview.Api.Services.Subscriptions;
using SubscriptionOverview.Api.Services.Payments;



namespace SubscriptionOverview.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}