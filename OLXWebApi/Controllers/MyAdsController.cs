using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions.AnnouncementExceptions;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAdsController : ControllerBase
    {
        private readonly IMyAdsService _myAdsService;

        public MyAdsController(IMyAdsService myAdsService)
        {
            _myAdsService = myAdsService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostMyAds(MyAdsCreationDto dto)
        {
            try
            {
                return Ok(await _myAdsService.AddAsync(dto));
            }catch(NotFoundAnnouncementException e)
            {
                return NotFound(e.Message);
            }catch(NotFoundUserException e)
            {
                return NotFound(e.Message);
            }catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllMyAds()
        {
            try
            {
                return Ok(await _myAdsService.SelectAllAsync());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteMyAds(long id)
        {
            try
            {
                return Ok(await _myAdsService.RemoveAsync(id));
            }catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }catch(Exception)
            {
                return NotFound();
            }
        }

    }
}
