using FluentValidation;
using RDO.Core.Dtos;

namespace RDO.ServiceInterface.Validators.Others
{
    class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            //RuleFor(x => x.Name)
            //    .NotEmpty()
            //    .MaximumLength(50);
        }
    }
}
