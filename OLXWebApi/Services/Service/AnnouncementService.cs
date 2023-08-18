using AutoMapper;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Services.Service
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepository<Announcement> _repository;
        private readonly IMapper _mapper;

        public AnnouncementService(IRepository<Announcement> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async ValueTask<Announcement> AddAsync(AnnouncementCreationDto dto)
        {
            
            var announcement = _mapper.Map<Announcement>(dto);
            var result = await _repository.InsertAsync(announcement);

            return result;
        }

        public ValueTask<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Announcement> ModifyAsync(long id, AnnouncementCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Announcement> RetriveAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Announcement> RetriveByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
