using EbisuWebApi.Application.DTOs;
using EbisuWebApi.Application.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbisuWebApi.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _userService.GetAllUsersAsync());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(string name, string pw, string email )
        {
            UserDTO userDTO = new();
            userDTO.UserName = name;
            userDTO.Password = pw;
            userDTO.Email = email;

            try
            {
                return Ok(await _userService.AddUserAsync(userDTO));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }

}

