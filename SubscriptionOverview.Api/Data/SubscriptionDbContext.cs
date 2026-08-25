using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubscriptionOverview.Api.Models.Entities;

namespace SubscriptionOverview.Api.Data
{
    public class SubscriptionDbContext : IdentityDbContext<ApplicationUser>
    {
        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}