using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EbisuWebApi.Web.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Categories")]
    [ApiVersion("1.0")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost]
        public async Task<IActionResult> SaveCategoryAsync(CategoryDto categoryDto)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _categoryService.AddCategoryAsync(categoryDto, userId));

        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            
            return Ok(await _categoryService.GetAll());

        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetAllCategoriesByUserAsync()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _categoryService.GetAllByUser(userId));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {

            return Ok(await _categoryService.GetById(id));


        }

        // PUT api/<InvoiceController>/5
        [HttpPut]
        public async Task<IActionResult> PutAsync(CategoryDto categoryDto)
        {


            return Ok(await _categoryService.UpdateCategory(categoryDto));

        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            return Ok(await _categoryService.RemoveCategory(id));

        }

    }

}