using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Domain.Enums;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions.UserExceptions;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.RetriveAllAsync());
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetUserById(long id)
        {
            try
            {
                return Ok(await _userService.RetriveById(id));
            }catch (NotFoundUserException e)
            {
                return NotFound(e.Message);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteUser(long id) 
        {
            try
            {
               return Ok(await _userService.RemoveAsync(id));
            }catch(NotFoundUserException e)
            {
                return NotFound(e.Message);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async ValueTask<IActionResult> PutUserAsync(long id,UserForCreationDto dto)
        {
            try
            {
               return Ok(await _userService.ModifyAsync(id, dto));
            }
            catch(NotFoundUserException e) 
            {
                return NotFound(e.Message);
            }
            catch (EmailAlreadyTakenException e) 
            {
                return Conflict(e.Message);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, AllowAnonymous]
        public async ValueTask<IActionResult> PostUser(UserForCreationDto dto)
        {
            try
            {
                return Ok(await _userService.CreateAsync(dto));
            }
            catch (EmailAlreadyTakenException e)
            {
                return Conflict(e.Message);
            }
            //}catch(Exception e)
            //{
            //    return BadRequest(e.Message);
            //}
        }

        [HttpPut("/role")]
        public async ValueTask<IActionResult> PutUserRole(long id, string role)
        {
            try
            {
                return Ok(await _userService.ModifyRoleAsync(id, role));
            }catch(NotFoundUserException e)
            {
                return Conflict(e.Message);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
