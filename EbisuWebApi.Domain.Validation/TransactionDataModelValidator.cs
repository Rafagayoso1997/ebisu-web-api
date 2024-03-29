﻿using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Infrastructure.DataModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.Validation
{
    public class TransactionDataModelValidator : AbstractValidator<TransactionDataModel>
    {
        public TransactionDataModelValidator()
        {
            RuleFor(transaction => transaction.TransactionDate)
                .LessThanOrEqualTo(DateTime.Now)
                .NotEmpty()
                .WithMessage("A transaction date must be earlier than today's date");

            RuleFor(transaction => transaction.Description)
                .Length(1, 255)
                .NotEmpty()
                .WithMessage("A transaction Description is Required");

            RuleFor(transaction => transaction.Amount)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("A transaction Amount is Required");

            RuleFor(transaction => transaction.UserId)
               .NotNull()
               .NotEmpty()
               .GreaterThan(0)
               .WithMessage("A transaction User is Required");

            RuleFor(transaction => transaction.CategoryId)
               .NotNull()
               .NotEmpty()
               .GreaterThan(0)
               .WithMessage("A transaction User is Required");
        }
    }


}
