using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLXWebApi.Models;
using OLXWebApi.Services.Dtos.Permission;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetPermissionById(long id)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "Ok",
                Data = await permissionService.GetPermission(id)
            });
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostPermission(PermissionCreationDto dto)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "Ok",
                Data = await permissionService.CreatePermission(dto)
            });
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllPermission()
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "Ok",
                Data = await permissionService.GetAllPermissions()
            });
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeletePermissionById(long id)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "Ok",
                Data = await permissionService.DeletePermission(id)
            });
        }

        [HttpPut]
        public async ValueTask<IActionResult> ModifyPermission(PermissionCreationDto dto, long id)
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "Ok",
                Data = await permissionService.UpdatePermission(dto, id)
            });
        }
    }
}
