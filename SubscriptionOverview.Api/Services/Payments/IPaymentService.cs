using SubscriptionOverview.Api.DTOs.Payment;

namespace SubscriptionOverview.Api.Services.Payments
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> GetAllAsync(string userId);
    }
}