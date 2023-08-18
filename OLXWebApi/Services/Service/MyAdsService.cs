using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Services.Service
{
    public class MyAdsService : IMyAdsService
    {
        private readonly IRepository<MyAds> _repository;
        private readonly IRepository<Announcement> _announcementRepository;
        private readonly IRepository<User> _userRepository;

        public MyAdsService(IRepository<MyAds> repository, IRepository<Announcement> announcementRepository,
            IRepository<User> userRepository) : this(repository, announcementRepository)
        {
            _userRepository = userRepository;
        }

        public MyAdsService(IRepository<MyAds> repository, IRepository<Announcement> announcementRepository) : this(repository)
        {
            _announcementRepository = announcementRepository;
        }

        public MyAdsService(IRepository<MyAds> repository)
        {
            _repository = repository;
        }

        public async ValueTask<MyAds> AddAsync(MyAdsCreationDto dto)
        {
            var announcement = await _announcementRepository.SelectByIdAsync(dto.AnnouncementId);
            var user = await _userRepository.SelectByIdAsync(dto.UserId);


        }

        public ValueTask<MyAds> ModifyAsync(MyAdsCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<MyAds>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<MyAds> SelectByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
