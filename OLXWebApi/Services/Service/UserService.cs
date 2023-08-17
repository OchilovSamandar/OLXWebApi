using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions;
using OLXWebApi.Services.IService;
using OLXWebApi.Shared.Helper;

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

        public async ValueTask<UserForResultDto> ModifyAsync(long id, UserForCreationDto dto)
        {
            var oldUser = await this._repository.SelectByIdAsync(id);
            if (oldUser == null)
                throw new OlxException(404, "User not found");

            var exsistUser = await this._repository.SelectAll()
                .FirstOrDefaultAsync(e => e.Email == dto.Email);
            if (exsistUser != null && oldUser.Email != dto.Email)
                throw new OlxException(400, "Email is already taken");

            var user = this._mapper.Map(dto, exsistUser ?? oldUser);

            user.Id = id;
            user.Password =PasswordHelper.Hash(dto.Password);
            user.UpdatedAt = DateTime.UtcNow;
            var result = await this._repository.UpdateAsync(user);
            await this._repository.SaveChangesAsync();

            return this._mapper.Map<UserForResultDto>(result);
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var exsistUser = await this._repository.SelectByIdAsync(id);
            if (exsistUser == null)
            {
                throw new OlxException(404, "User not found");
            }

            return await this._repository.DeleteAsync(id);
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
