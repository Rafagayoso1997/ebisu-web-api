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
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly IValidator<CategoryDataModel> _validator;
        private readonly ILogger<CategoryDomainService> _logger;
        

        public CategoryDomainService(IValidator<CategoryDataModel> validator, ILogger<CategoryDomainService> logger)
        {
         
            _validator = validator;
            _logger = logger;
        }
        public async Task ValidateCategoryData(CategoryDataModel categoryDataModel)
        {
            var validatorResult = await _validator.ValidateAsync(categoryDataModel);
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
