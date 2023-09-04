using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLXWebApi.Models;
using OLXWebApi.Services.Dtos.Role;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostRoleAsync(RoleForCreationDto dto)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "OK",
                Data = await roleService.CreateRoleAsync(dto)
            });
        }

        [HttpDelete]
        public async ValueTask<IActionResult> RemoveRoleAsync(long id)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "OK",
                Data = await roleService.DeleteRoleAsync(id)
            });
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetRoleByIdAsync(long id)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "OK",
                Data = await roleService.RetriveRoleByIdAsync(id)
            });
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateRole(RoleForUpdateDto dto, long id)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "OK",
                Data = await roleService.UpdateRoleAsync(dto ,id)
            });
        }

        
    }
}
