using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Crosscutting.Exceptions;
using EbisuWebApi.Crosscutting.Utils;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
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
    public class UserDomainService : IUserDomainService
    {

        private readonly IValidator<UserDataModel> _validator;
        private readonly ILogger<UserDomainService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UserDomainService(IValidator<UserDataModel> validator, ILogger<UserDomainService> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _logger = logger;
        }

        public void AddDefaultCategoriesToUser(UserDataModel userDataModel, IEnumerable<CategoryDataModel> defaultCategories)
        {
            userDataModel.Categories = new List<CategoryDataModel>();
            userDataModel.Categories.AddRangeToCollection(defaultCategories);
        }
        
        public async Task UserExist(UserDataModel userDataModel)
        {
            bool userExist = await _unitOfWork.Users.UserExist(userDataModel.UserName);
            if (userExist) throw new UserNameAlreadyExistException();
        }

        public async Task ValidateUserData(UserDataModel userDataModel)
        {
            
            var validatorResult = await _validator.ValidateAsync(userDataModel);
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
