using AutoMapper;
using OLXWebApi.Controllers;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions.AnnouncementExceptions;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Services.Service
{
    public class MyAdsService : IMyAdsService
    {
        private readonly IRepository<MyAds> _repository;
        private readonly IRepository<Announcement> _announcementRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public MyAdsService(IRepository<MyAds> repository, IRepository<Announcement> announcementRepository, IRepository<User> userRepository, IMapper mapper) : this(repository, announcementRepository, userRepository)
        {
            _mapper = mapper;
        }

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
            if (announcement == null) 
                throw new NotFoundAnnouncementException();
            var user = await _userRepository.SelectByIdAsync(dto.UserId);
            if (user == null) throw new NotFoundUserException(user.Id);

           // var map = await _mapper.Map<MyAds>(MyAdsCreationDto);
           MyAds myAds = new MyAds();
            myAds.AnnouncementId = dto.AnnouncementId;
            myAds.UserId = dto.UserId;
            
             var result =await _repository.InsertAsync(myAds);

            return result;
        }

        public ValueTask<MyAds> ModifyAsync(MyAdsCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            if(id == 0) throw new ArgumentNullException(nameof(id));    
           var result = await _repository.DeleteAsync(id);

            return result;
        }

        public IRepository<MyAds> Get_repository()
        {
            return _repository;
        }

        public async ValueTask<IEnumerable<MyAds>> SelectAllAsync()
        {
            var myAds = _repository.SelectAll().ToList();
            
            return myAds;
        }

        public ValueTask<MyAds> SelectByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
