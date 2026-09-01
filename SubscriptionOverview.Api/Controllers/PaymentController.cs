using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubscriptionOverview.Api.DTOs.Payment;
using SubscriptionOverview.Api.Services.Payments;

namespace SubscriptionOverview.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentDto>>> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var payments = await _paymentService.GetAllAsync(userId);

            return payments;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var payment = await _paymentService.GetByIdAsync(id, userId);

            if(payment is null)
            {
                return NotFound();
            }

            return payment;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDto>> Create(CreatePaymentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var payment = await _paymentService.CreateAsync(dto, userId);

            return payment;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentDto>> Update(int id, CreatePaymentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var payment = await _paymentService.UpdateAsync(id, dto, userId);

            if(payment is null)
            {
                return NotFound();
            }

            return payment;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var success = await _paymentService.DeleteAsync(id, userId);

            if(!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}