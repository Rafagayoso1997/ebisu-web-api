using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Infrastructure.DataModel;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.Repositories.Implementations
{
    public class TransactionRepository : GenericRepository<TransactionDataModel>, ITransactionRepository
    {
        public TransactionRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TransactionDataModel>> GetTransactionsByUserId(int userId)
        {
            return await _context.Transactions.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
