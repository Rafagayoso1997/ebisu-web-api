using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EbisuWebApi.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<CategoryDto> _validator;

        public CategoryController(ICategoryService categoryService, IValidator<CategoryDto> validator)
        {
            _categoryService = categoryService;
            _validator = validator;
        }


        [HttpPost]
        public async Task<IActionResult> SaveCategoryAsync(CategoryDto categoryDto)
        {
            try
            {
                var validatorResult = await _validator.ValidateAsync(categoryDto);
                if (!validatorResult.IsValid)
                {
                    return BadRequest(validatorResult.Errors);
                }
                return Ok(await _categoryService.AddCategoryAsync(categoryDto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                return Ok(await _categoryService.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                return Ok(await _categoryService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<InvoiceController>/5
        [HttpPut]
        public async Task<IActionResult> PutAsync(CategoryDto categoryDto)
        {
            try
            {
                var validatorResult = await _validator.ValidateAsync(categoryDto);
                if (!validatorResult.IsValid)
                {
                    return BadRequest(validatorResult.Errors);
                }
                return Ok(await _categoryService.UpdateCategory(categoryDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                return Ok(await _categoryService.RemoveCategory(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}