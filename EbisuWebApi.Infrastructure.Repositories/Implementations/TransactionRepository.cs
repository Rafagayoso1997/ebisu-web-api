using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.Repositories.Implementations
{
    public class TransactionRepository : GenericRepository<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(DatabaseContext context) : base(context)
        {
        }

        
    }
}
