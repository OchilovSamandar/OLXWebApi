using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLXWebApi.Models;
using OLXWebApi.Services.Dtos.RolePermission;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionService rolePermissionService;

        public RolePermissionController(IRolePermissionService rolePermissionService)
        {
            this.rolePermissionService = rolePermissionService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> AddAsync(RolePermissionCreationDto dto)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "OK",
                Data = await rolePermissionService.CreateAsync(dto)
            });
        }
    }
}
