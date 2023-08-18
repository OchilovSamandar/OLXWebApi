using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions;
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
        [HttpPost]
        public async ValueTask<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            //token generate bo'lmayapti xato bor
            try
            {
               return Ok(await authService.AuthenticateAsync(dto));
            }catch(EmailOrPasswordIncorrectException e)
            {
                return BadRequest(e.Message);
            }catch(Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
