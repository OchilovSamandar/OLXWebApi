using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions.AnnouncementExceptions;
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
        //Announcement HTTPost method ishlamayapti
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

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetByID(long id)
        {
            try
            {
                return Ok(await _announcementService.RetriveByIdAsync(id));
            }catch(NotFoundAnnouncementException e)
            {
                return BadRequest(e.Message);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _announcementService.RetriveAllAsync());
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAnnouncement(long id)
        {
            try
            {
                return Ok(await _announcementService.DeleteAsync(id));
            }catch(NotFoundAnnouncementException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest( e.Message);
            }
        }

        [HttpPut]
        public async ValueTask<IActionResult> PutAnnouncement(long id,AnnouncementCreationDto dto)
        {
            try
            {
                return Ok(await _announcementService.ModifyAsync(id, dto));
            }catch(NotFoundAnnouncementException ex)
            {
                return BadRequest(ex.Message);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
