using EbisuWebApi.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Web.Validation
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(category => category.Name)
                .Length(1, 10)
                .NotEmpty()
                .WithMessage("A Category name is Required");

            RuleFor(category => category.Description)
                .Length(1, 255)
                .NotEmpty()
                .WithMessage("A Category Description is Required");

            RuleFor(category => category.ImageUrl)
                .NotNull()
                .NotEmpty()
                .Length(1, 10)
                .WithMessage("A Category Image URL is Required");
        }
    }
}
