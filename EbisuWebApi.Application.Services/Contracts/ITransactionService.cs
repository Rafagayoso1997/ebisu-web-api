using EbisuWebApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Services.Contracts
{
    public interface ITransactionService
    {
        Task<TransactionDto> AddTransactionAsync(TransactionDto transactionDTO);

        Task<IEnumerable<TransactionDto>> GetAllTransactions();

        Task<IEnumerable<TransactionDto>> GetAllTransactionsByUserId(int userId);

        Task<TransactionDto> GeTransactionById(int id);

        Task<TransactionDto> UpdateTransaction(TransactionDto transactionDTO);

        Task<TransactionDto> RemoveTransaction(int id);
    }
}
