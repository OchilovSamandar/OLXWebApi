using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;

namespace OLXWebApi.Services.IService
{
    public interface IAnnouncementService
    {
        ValueTask<Announcement> AddAsync(AnnouncementCreationDto dto);
        ValueTask<Announcement> ModifyAsync(long id,AnnouncementCreationDto dto);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<Announcement> RetriveByIdAsync(long id);
        ValueTask<IEnumerable<Announcement>> RetriveAllAsync();
    }
}
