﻿using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Sale.Delete
{
    public class DeleteSaleCommand : IRequest 
    {
        [Required]
        public Guid Id { get; set; }
    }
    public class DeleteSaleCommandValidator : AbstractValidator<DeleteSaleCommand>
    {
        public DeleteSaleCommandValidator() 
        {
            RuleFor(DeleteSaleCommand => DeleteSaleCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
