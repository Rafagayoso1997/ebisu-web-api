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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(UserDto userDto)
        {
            try
            {
                return Ok(await _userService.AddUserAsync(userDto));
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
                return Ok(await _userService.GetAll());
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
                return Ok(await _userService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(UserLoginDto userDTO)
        {
            try
            {

                return Ok(await _userService.LoginUser(userDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<InvoiceController>/5
        [HttpPut]
        public async Task<IActionResult> PutAsync(UserDto userDTO)
        {
            try
            {
                
                return Ok(await _userService.UpdateUser(userDTO));
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
                return Ok(await _userService.RemoveUser(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}

