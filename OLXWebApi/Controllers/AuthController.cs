using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("login")]
        public async ValueTask<IActionResult> LoginAsync([FromBody] LoginDto dto) =>
            Ok(await authService.AuthenticateAsync(dto));
    }
}
