using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;

namespace OLXWebApi.Services.IService
{
    public interface IUserService
    {
        ValueTask<User> CreateAsync(UserForCreationDto dto);
        ValueTask<IEnumerable<User>> RetriveAllAsync();
        ValueTask<User> RetriveById(long id);
        ValueTask<User> ModifyAsync(long id, UserForCreationDto dto);
        ValueTask<bool> RemoveAsync(long id);

    }
}
