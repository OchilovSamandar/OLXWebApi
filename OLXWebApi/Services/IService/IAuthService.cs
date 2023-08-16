using OLXWebApi.Services.Dtos;

namespace OLXWebApi.Services.IService
{
    public interface IAuthService
    {
        ValueTask<LoginResultDto> AuthenticateAsync(LoginDto dto);
    }
}
