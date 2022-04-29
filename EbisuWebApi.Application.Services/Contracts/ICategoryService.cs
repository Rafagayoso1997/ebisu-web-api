using EbisuWebApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Services.Contracts
{
    public interface ICategoryService
    {
        Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto);

        Task<IEnumerable<CategoryDto>> GetAll();

        Task<CategoryDto> GetById(int id);

        Task<CategoryDto> UpdateCategory(CategoryDto categoryDto);

        Task<CategoryDto> RemoveCategory(int id);
    }
}
