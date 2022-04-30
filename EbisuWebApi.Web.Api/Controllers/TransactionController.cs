using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbisuWebApi.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
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

        [HttpGet("GetByUser/{userId}")]
        public async Task<IActionResult> GetTransactionByUserId(int userId)
        {
            try
            {
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
