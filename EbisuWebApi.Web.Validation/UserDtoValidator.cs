using EbisuWebApi.Application.Dtos;
using FluentValidation;

namespace EbisuWebApi.Web.Validation
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(user => user.UserName)
                .Length(1, 10)
                .NotEmpty() ;
            
            RuleFor(user => user.Email)
                .EmailAddress()
                .NotEmpty();
            
            RuleFor(user => user.Password)
                .NotNull()
                .NotEmpty()
                .Length(1, 10);
        }
    }
}