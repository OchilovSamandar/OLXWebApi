using OLXWebApi.Services.IService;
using OLXWebApi.Services.Service;

namespace OLXWebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService,IAuthService>();
            services.AddScoped<IUserService, UserService>();

        }
    }
}
