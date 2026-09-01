using SubscriptionOverview.Api.Data;

namespace SubscriptionOverview.Api.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly SubscriptionDbContext _context;

        public PaymentService(SubscriptionDbContext context)
        {
            _context = context;
        }
    }
}