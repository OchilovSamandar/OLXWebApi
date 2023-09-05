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

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "OK",
                Data = await rolePermissionService.RetrieveByIdAsync(id)
            });
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(new Response 
            { 
                Status = 200,
                Message = "OK" ,
                Data = await rolePermissionService.RetrieveAllAsync()
            });
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "OK",
                Data = await rolePermissionService.DeleteAsync(id)
            });
        }

        [HttpPut]
        public async ValueTask<IActionResult> EditAsync(RolePermissionCreationDto dto, long id)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "OK",
                Data = await rolePermissionService.ModifyAsync(dto, id)
            });
        }
    }
}
