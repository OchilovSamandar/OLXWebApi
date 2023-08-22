using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;

namespace OLXWebApi.Services.IService
{
    public interface IUserService
    {
        ValueTask<UserForResultDto> CreateAsync(UserForCreationDto dto);
        ValueTask<IEnumerable<UserForResultDto>> RetriveAllAsync();
        ValueTask<UserForResultDto> RetriveById(long id);
        ValueTask<UserForResultDto> ModifyAsync(long id, UserForCreationDto dto);
        ValueTask<bool> RemoveAsync(long id);

        ValueTask<UserForResultDto> ModifyRoleAsync(long id, UserRoleForUpdateDto dto);

    }
}
