using AutoMapper;
using EbisuWebApi.Application.DTOs;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
        {
            CategoryEntity entity = await _unitOfWork.Categories.Add(_mapper.Map<CategoryEntity>(categoryDto));
            _unitOfWork.Complete();
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _unitOfWork.Categories.GetAll()); ;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            CategoryEntity entity = await _unitOfWork.Categories.GetEntity(id);
            //_unitOfWork.Complete();
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<CategoryDto> RemoveCategory(int id)
        {
            CategoryEntity entity = await _unitOfWork.Categories.Delete(id);
            _unitOfWork.Complete();
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<CategoryDto> UpdateCategory(CategoryDto categoryDto)
        {
            CategoryEntity entity = await _unitOfWork.Categories.Update(_mapper.Map<CategoryEntity>(categoryDto));
            _unitOfWork.Complete();
            return _mapper.Map<CategoryDto>(entity);
        }
    }
}
