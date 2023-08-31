namespace OLXWebApi.Services.IService
{
    public interface IRoleService
    {
        ValueTask<bool> CheckRole(string roleName);
    }
}
