using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Infrastructure.DataModel;
using FluentValidation;

namespace EbisuWebApi.Domain.Validation
{
    public class UserDataModelValidator : AbstractValidator<UserDataModel>
    {
        public UserDataModelValidator()
        {
            RuleFor(user => user.UserName)
                .Length(1, 10)
                .NotEmpty();

            RuleFor(user => user.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(user => user.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}