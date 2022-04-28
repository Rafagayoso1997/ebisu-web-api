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


        [HttpPost]
        public async Task<IActionResult> SaveAsync(UserDTO userDto)
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
        public async Task<IActionResult> GetAllAsync()
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

    }

}

