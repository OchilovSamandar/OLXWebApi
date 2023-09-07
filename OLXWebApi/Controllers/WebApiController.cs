using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OLXWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class WebApiController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello OLX";
        }
    }
}
