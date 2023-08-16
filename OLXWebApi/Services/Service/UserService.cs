using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ValueTask<User> CreateAsync(UserForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> ModifyAsync(long id, UserForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<User>> RetriveAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> RetriveById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
