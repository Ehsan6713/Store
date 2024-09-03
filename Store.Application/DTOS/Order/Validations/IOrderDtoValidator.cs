using FluentValidation;

namespace Store.Application.DTOS.Order.Validations
{
    public class IOrderDtoValidator : AbstractValidator<IOrderDto>
    {
        public IOrderDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Total).GreaterThan(0).WithMessage("{PropertyName} can no be Less than 1");
            RuleFor(x => x.Discount).GreaterThan(-1).WithMessage("{PropertyName} can no be Less than 0");
        }
    }
}
