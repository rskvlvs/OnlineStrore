using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Queries.Manager.GetManager
{
    public class GetManagerQuery : IRequest<ManagerVm>
    {
        public Guid Id { get; set; }
    }
    public class GetManagerQueryValidator : AbstractValidator<GetManagerQuery>
    {
        public GetManagerQueryValidator() 
        {
            RuleFor(get => get.Id).NotEqual(Guid.Empty).WithMessage("ManagerId field is required");
        }
    }
}
