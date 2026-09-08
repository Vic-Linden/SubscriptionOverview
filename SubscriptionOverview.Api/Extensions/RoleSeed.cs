using Microsoft.AspNetCore.Identity;
using SubscriptionOverview.Api.Models.Entities;

namespace SubscriptionOverview.Api.Extensions
{
    public static class RoleSeed
    {
        public static async Task SeedRolesAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            if(!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var adminEmail = configuration["AdminSeed:Email"];
            var adminUser = await userManager.FindByEmailAsync(adminEmail!);

            if(adminUser is not null && !await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

        }
    }
}