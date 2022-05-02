using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Web.Validation;
using FluentValidation;
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
        private readonly IValidator<UserDto> _validator;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IValidator<UserDto> validator, ILogger<UserController> logger)
        {
            _userService = userService;
            _validator = validator;
            _logger = logger;
        }
       

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(UserDto userDto)
        {
            try
            {
               
                var validatorResult = await _validator.ValidateAsync(userDto);
                if (!validatorResult.IsValid)
                {
                    return BadRequest(validatorResult.Errors);
                }
                
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
                _logger.LogInformation(userDTO.UserName);
                return Ok(await _userService.LoginUser(userDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<InvoiceController>/5
        [HttpPut]
        public async Task<IActionResult> PutAsync(UserDto userDto)
        {
            try
            {
                var validatorResult = await _validator.ValidateAsync(userDto);
                if (!validatorResult.IsValid)
                {
                    return BadRequest(validatorResult.Errors);
                }
                return Ok(await _userService.UpdateUser(userDto));
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

