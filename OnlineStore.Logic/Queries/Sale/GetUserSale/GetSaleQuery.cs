﻿using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
namespace OnlineStrore.Logic.Queries.Sale.GetUserSale
{
    public class GetSaleQuery : IRequest<SaleVm>
    {
        [Required]
        public Guid UserId { get; set; }
    }
    public class GetSaleQueryValidator : AbstractValidator<GetSaleQuery>
    {
        public GetSaleQueryValidator()
        {
            RuleFor(get => get.UserId).NotEqual(Guid.Empty);
        }
    }
}
