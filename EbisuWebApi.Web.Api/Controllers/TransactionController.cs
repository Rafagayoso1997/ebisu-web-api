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
    [Route("api/v{version:apiVersion}/Transactions")]
    [ApiVersion("1.0")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IValidator<TransactionDto> _validator;

        public TransactionController(ITransactionService transactionService, IValidator<TransactionDto> validator)
        {
            _transactionService = transactionService;
            _validator = validator;
        }


        [HttpPost]
        public async Task<IActionResult> SaveTransactionAsync(TransactionDto transactionDTO)
        {
            try
            {
                var validatorResult = await _validator.ValidateAsync(transactionDTO);
                if (!validatorResult.IsValid)
                {
                    return BadRequest(validatorResult.Errors);
                }
                return Ok(await _transactionService.AddTransactionAsync(transactionDTO));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTansactionsAsync()
        {
            try
            {
                return Ok(await _transactionService.GetAllTransactions());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            try
            {
                return Ok(await _transactionService.GeTransactionById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetTransactionByUserId()
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
                return Ok(await _transactionService.GetAllTransactionsByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransaction(TransactionDto transactionDTO)
        {
            try
            {
                var validatorResult = await _validator.ValidateAsync(transactionDTO);
                if (!validatorResult.IsValid)
                {
                    return BadRequest(validatorResult.Errors);
                }
                return Ok(await _transactionService.UpdateTransaction(transactionDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionAsync(int id)
        {
            try
            {
                return Ok(await _transactionService.RemoveTransaction(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
