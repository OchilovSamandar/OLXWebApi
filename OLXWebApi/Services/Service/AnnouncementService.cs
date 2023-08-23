using AutoMapper;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions.AnnouncementExceptions;
using OLXWebApi.Services.Exceptions.CategoryException;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Services.Service
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepository<Announcement> _repository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public AnnouncementService(IRepository<Announcement> repository,
            IRepository<Category> categoryRepository, IRepository<User> userRepository, 
            IMapper mapper)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public AnnouncementService(IRepository<Announcement> repository,
            IRepository<Category> categoryRepository, IMapper mapper)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public AnnouncementService(IRepository<Announcement> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async ValueTask<Announcement> AddAsync(AnnouncementCreationDto dto)
        {
            var categoryId = await _categoryRepository.SelectByIdAsync(dto.CategoryId);
            if (categoryId == null)
                throw new NotFoundCategoryException();
            
            var announcement = _mapper.Map<Announcement>(dto);
            announcement.User = await _userRepository.SelectByIdAsync(dto.UserId);
            announcement.Category = await _categoryRepository.SelectByIdAsync(dto.CategoryId);
            var result = await _repository.InsertAsync(announcement);

            return result;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
           var announcementId =  await _repository.SelectByIdAsync(id);
            if (announcementId == null)
                throw new NotFoundAnnouncementException();

            var result  = await _repository.DeleteAsync(id);

            return result;
        }

        public async ValueTask<Announcement> ModifyAsync(long id, AnnouncementCreationDto dto)
        {
           var announcement =  await _repository.SelectByIdAsync(id);
            if(announcement == null)
                throw new NotFoundAnnouncementException();

            return await _repository.UpdateAsync(announcement);
        }

        public  async ValueTask<IEnumerable<Announcement>> RetriveAllAsync()
        {
           var announcements = _repository.SelectAll().ToList();

            return announcements;
        }

        public async ValueTask<Announcement> RetriveByIdAsync(long id)
        {
            var idAnnouncement = await _repository.SelectByIdAsync(id); 
            if(idAnnouncement == null)
                throw new NotFoundAnnouncementException();

            var result = await _repository.SelectByIdAsync(id);
            return result;
        }
    }
}
