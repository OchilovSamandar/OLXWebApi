using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;

namespace OLXWebApi.Services.IService
{
    public interface ICategoryService
    {
        ValueTask<Category> RetriveByIdAsync(long id);
        ValueTask<IEnumerable<Category>> RetriveAllAsync();
        ValueTask<Category> AddAsync(CategoryForCreationDto dto);
        ValueTask<Category> ModifyAsync(long id, CategoryForCreationDto dto);
        ValueTask<bool> RemoveAsync(long id);

    }
}
