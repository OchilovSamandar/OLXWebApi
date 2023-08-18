using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions.CategoryException;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostCategory(CategoryForCreationDto dto)
        {
            try
            {
                return Ok(await _categoryService.AddAsync(dto));
            }catch(CategoryNameExsistException ex)
            {
                return BadRequest(ex.Message);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async ValueTask<IActionResult> PutCategory( long id, CategoryForCreationDto dto)
        {
            try
            {
                return Ok(await _categoryService.ModifyAsync( id ,dto));
            }catch(NotFoundCategoryException ex)
            {
                return BadRequest(ex.Message);
            }catch(CategoryNameAlreadyExsistException e) 
            {
                return BadRequest(e.Message);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCategory(long id)
        {
            try
            {
                return Ok( await _categoryService.RemoveAsync(id));
            }catch (NotFoundCategoryException ex)
            {
                return BadRequest(ex.Message);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetByIdCategory(long id)
        {
            try
            {
                return Ok(await _categoryService.RetriveByIdAsync(id));
            }catch( NotFoundCategoryException ex)
            {
                return BadRequest(ex.Message);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllCategory()
        {
            try
            {
                return Ok(await _categoryService.RetriveAllAsync());
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
