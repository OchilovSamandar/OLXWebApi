﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions.CategoryException;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async ValueTask<Category> AddAsync(CategoryForCreationDto dto)
        {
            var exsist = await _repository.SelectAll().FirstOrDefaultAsync(u => u.Name == dto.Name);
            if (exsist != null)
                throw new CategoryNameExsistException(dto.Name);

            var category = _mapper.Map<Category>(dto);
            var result = await _repository.InsertAsync(category);

            return result;
        }

        public async ValueTask<Category> ModifyAsync(long id, CategoryForCreationDto dto)
        {
            var idExsist =await _repository.SelectByIdAsync(id);
            if(idExsist == null)
                throw new NotFoundCategoryException();

            var exsistCategory =await _repository.SelectAll().FirstOrDefaultAsync(c => c.Name == dto.Name);
            if (exsistCategory != null && !exsistCategory.Name.Equals(dto.Name))
                throw new CategoryNameAlreadyExsistException(dto.Name);

            var category = _mapper.Map(dto,exsistCategory);
            category.Id = id;
            category.UpdatedAt = DateTime.Now;
            var result = await _repository.UpdateAsync(category);

            return result;
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var category = await _repository.SelectByIdAsync(id);
            if (category == null)
                throw new NotFoundCategoryException();

           var result = await _repository.DeleteAsync(id);

            return result;
        }

        public async  ValueTask<IEnumerable<Category>> RetriveAllAsync()
        {
           IEnumerable<Category> result =_repository.SelectAll().ToList();

            return result;
        }

        public async ValueTask<Category> RetriveByIdAsync(long id)
        {
          var category = await _repository.SelectByIdAsync(id);
            if(category == null)
                throw new NotFoundCategoryException();

            return category;
        }
    }
}
