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
        Task<TransactionDTO> AddTransactionAsync(TransactionDTO transactionDTO);

        Task<IEnumerable<TransactionDTO>> GetAllTransactions();

        Task<TransactionDTO> GeTransactionById(int id);

        Task<TransactionDTO> UpdateTransaction(TransactionDTO transactionDTO);

        Task<TransactionDTO> RemoveTransaction(int id);
    }
}
