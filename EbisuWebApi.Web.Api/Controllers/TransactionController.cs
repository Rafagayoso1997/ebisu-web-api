using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Domain.Services.Contracts;
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

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;

        }

        [HttpPost]
        public async Task<IActionResult> SaveTransactionAsync(TransactionDto transactionDTO)
        {

            return Ok(await _transactionService.AddTransactionAsync(transactionDTO));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTansactionsAsync()
        {

            return Ok(await _transactionService.GetAllTransactions());


        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {

            return Ok(await _transactionService.GeTransactionById(id));


        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetTransactionByUserId()
        {

            int userId = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _transactionService.GetAllTransactionsByUserId(userId));


        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransaction(TransactionDto transactionDTO)
        {

            return Ok(await _transactionService.UpdateTransaction(transactionDTO));

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionAsync(int id)
        {

            return Ok(await _transactionService.RemoveTransaction(id));

        }
    }
}
