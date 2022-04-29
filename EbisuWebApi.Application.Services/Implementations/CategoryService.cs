using AutoMapper;
using EbisuWebApi.Application.DTOs;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Infrastructure.DataModel;
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
            CategoryDataModel entityDataModel = _mapper.Map<CategoryDataModel>(_mapper.Map<CategoryEntity>(categoryDto));

            var result = await _unitOfWork.Categories.Add(entityDataModel);
            _unitOfWork.Complete();

            return _mapper.Map<CategoryDto>(_mapper.Map<CategoryEntity>(result));

        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(_mapper.Map<IEnumerable<CategoryEntity>>(await _unitOfWork.Categories.GetAll()));
        }

        public async Task<CategoryDto> GetById(int id)
        {
            return _mapper.Map<CategoryDto>(_mapper.Map<CategoryEntity>(await _unitOfWork.Categories.GetEntity(id)));   
        }

        public async Task<CategoryDto> RemoveCategory(int id)
        {
            var categoryDto = _mapper.Map<CategoryDto>(_mapper.Map<CategoryEntity>(await _unitOfWork.Categories.Delete(id)));

            _unitOfWork.Complete();
            return categoryDto;
        }

        public async Task<CategoryDto> UpdateCategory(CategoryDto categoryDto)
        {
            CategoryDataModel entityDataModel = _mapper.Map<CategoryDataModel>(_mapper.Map<CategoryEntity>(categoryDto));

            var result = await _unitOfWork.Categories.Update(entityDataModel);
            _unitOfWork.Complete();

            return _mapper.Map<CategoryDto>(_mapper.Map<CategoryEntity>(result));

            
        }
    }
}
