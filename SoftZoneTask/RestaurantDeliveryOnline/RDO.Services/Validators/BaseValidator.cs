using FluentValidation;
using RDO.Core.Dtos;

namespace RDO.ServiceInterface.Validators
{
    public class BaseValidator : AbstractValidator<BaseDto<int>>
    {
        public BaseValidator()
        {

        }
    }
}
