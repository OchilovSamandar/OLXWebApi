﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using OLXWebApi.Controllers;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Domain.Enums;
using OLXWebApi.Models;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions;
using OLXWebApi.Services.Exceptions.UserExceptions;
using OLXWebApi.Services.IService;
using OLXWebApi.Shared.Helper;

namespace OLXWebApi.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<Role> _roleRepository;

        public UserService(IRepository<User> repository, IMapper mapper, IRepository<Role> roleRepository) : this(repository, mapper)
        {
            _roleRepository = roleRepository;
        }

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async ValueTask<UserForResultDto> CreateAsync(UserForCreationDto dto)
        {
            var user = _mapper.Map<User>(dto);

            var exsistUser =await _repository.SelectAll().FirstOrDefaultAsync(u => u.Email == user.Email);

            if (exsistUser != null)
                throw new EmailAlreadyTakenException(user.Email);

            user.Password = PasswordHelper.Hash(user.Password);
            user.Roles = await _roleRepository.SelectByIdAsync(2);
            
            
            var result = await _repository.InsertAsync(user);

            return _mapper.Map<UserForResultDto>(result);
        }

        public async ValueTask<UserForResultDto> ModifyAsync(long id, UserForCreationDto dto)
        {
            var oldUser = await this._repository.SelectByIdAsync(id);
            if (oldUser == null)
                throw new NotFoundUserException(id);

            var exsistUser = await this._repository.SelectAll()
                .FirstOrDefaultAsync(e => e.Email == dto.Email);
            if (exsistUser!=null && !exsistUser.Email.Equals(dto.Email))
                throw new EmailAlreadyTakenException(dto.Email);

            var user = this._mapper.Map(dto, exsistUser ?? oldUser);

            user.Id = id;
            user.Password =PasswordHelper.Hash(dto.Password);
            user.UpdatedAt = DateTime.UtcNow;
            var result = await this._repository.UpdateAsync(user);

            return this._mapper.Map<UserForResultDto>(result);
        }

        public async ValueTask<UserForResultDto> ModifyRoleAsync(long id, string role)
        {
           var user = await _repository.SelectByIdAsync(id);
            if(user == null)
                throw new NotFoundUserException(id);

            var role1 = await this._roleRepository.SelectAll() .FirstOrDefaultAsync(e => e.Name == role);
            user.Roles = role1 ;
            await this._repository.SaveChangesAsync();

            return this._mapper.Map<UserForResultDto>(user);
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var exsistUser = await this._repository.SelectByIdAsync(id);
            if (exsistUser == null)
                throw new NotFoundUserException(id);
            
            return await this._repository.DeleteAsync(id);
        }

        public async ValueTask<IEnumerable<UserForResultDto>> RetriveAllAsync()
        {
            var users = await this._repository.SelectAll()
                .AsNoTracking()
                .ToListAsync();
            
            return this._mapper.Map<IEnumerable<UserForResultDto>>(users);
        }

        public async ValueTask<UserForResultDto> RetriveById(long id)
        {
            User user = await _repository.SelectByIdAsync(id);
            if (user == null)
                throw new OlxWebApiException(404,"User not found");
                
            return  this._mapper.Map<UserForResultDto>(user);
        }
    }
}
