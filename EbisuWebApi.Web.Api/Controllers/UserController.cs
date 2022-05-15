using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Crosscutting.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbisuWebApi.Web.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Users")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(UserDto userDto)
        {
            return Ok(await _userService.AddUserAsync(userDto));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return Ok(await _userService.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _userService.GetById(id));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(UserLoginDto userDTO)
        {

            _logger.LogInformation(userDTO.UserName);
            TokenDto token = await _userService.LoginUser(userDTO);
            return Ok(token);

        }

        // PUT api/<InvoiceController>/5
        [HttpPut]
        public async Task<IActionResult> PutAsync(UserDto userDto)
        {

            return Ok(await _userService.UpdateUser(userDto));

        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            return Ok(await _userService.RemoveUser(id));

        }

    }

}

