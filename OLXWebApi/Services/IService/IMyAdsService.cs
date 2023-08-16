using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;

namespace OLXWebApi.Services.IService
{
    public interface IMyAdsService
    {
        ValueTask<MyAds> AddAsync(MyAdsCreationDto dto);
        ValueTask<MyAds> ModifyAsync(MyAdsCreationDto dto);
        ValueTask<MyAds> SelectByIdAsync(long id);
        ValueTask<IEnumerable<MyAds>> SelectAllAsync();
        ValueTask<bool> RemoveAsync(long id);
    }
}
