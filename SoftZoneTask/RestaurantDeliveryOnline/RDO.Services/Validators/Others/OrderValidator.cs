using FluentValidation;
using RDO.Core.Dtos;

namespace RDO.ServiceInterface.Validators.Others
{
    class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {
            //RuleFor(x => x.Name)
            //    .NotEmpty()
            //    .MaximumLength(50);

            
        }
    }
}
