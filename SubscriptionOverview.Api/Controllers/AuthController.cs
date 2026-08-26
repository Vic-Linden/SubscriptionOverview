using Microsoft.AspNetCore.Mvc;
using SubscriptionOverview.Api.Services;

namespace SubscriptionOverview.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController (IAuthService authService)
        {
            _authService = authService;
        }
    }
}