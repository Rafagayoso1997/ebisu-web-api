using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Contracts;
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

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost]
        public async Task<IActionResult> SaveUserAsync(CategoryDto categoryDto)
        {
            try
            {
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
        public async Task<IActionResult> GetUserById(int id)
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