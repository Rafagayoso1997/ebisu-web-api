using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.Services.Contracts
{
    public interface ITransactionDomainService
    {
        Task ValidateTransactionData(TransactionDataModel transactionDataModel);
    }
}
