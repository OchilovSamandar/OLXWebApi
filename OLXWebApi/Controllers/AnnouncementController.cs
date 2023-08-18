using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAnnouncement([FromBody] AnnouncementCreationDto dto)
        {
            try
            {
               return Ok(await _announcementService.AddAsync(dto));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
