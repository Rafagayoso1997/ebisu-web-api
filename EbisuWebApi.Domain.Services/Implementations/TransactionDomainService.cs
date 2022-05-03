using EbisuWebApi.Crosscutting.Exceptions;
using EbisuWebApi.Domain.Services.Contracts;
using EbisuWebApi.Infrastructure.DataModel;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.Services.Implementations
{
    public class TransactionDomainService : ITransactionDomainService
    {
        private readonly IValidator<TransactionDataModel> _validator;
        private readonly ILogger<TransactionDomainService> _logger;


        public TransactionDomainService(IValidator<TransactionDataModel> validator, ILogger<TransactionDomainService> logger)
        {

            _validator = validator;
            _logger = logger;
        }

        public async Task ValidateTransactionData(TransactionDataModel transactionDataModel)
        {
            var validatorResult = await _validator.ValidateAsync(transactionDataModel);
            if (!validatorResult.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                validatorResult.Errors.ForEach(error => sb.AppendLine(error.ErrorMessage));
                _logger.LogError(sb.ToString());
                throw new ModelValidationException(sb.ToString());
            }
        }
    }
}
