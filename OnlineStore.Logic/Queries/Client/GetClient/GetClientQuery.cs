using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Queries.Client.GetClient
{
    public class GetClientQuery : IRequest<ClientVm>
    {
        [Required]
        public Guid Id { get; set; }
    }
    public class GetClientQueryValidator : AbstractValidator<GetClientQuery>
    {
        public GetClientQueryValidator() 
        {
            RuleFor(GetClientQuery => GetClientQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
