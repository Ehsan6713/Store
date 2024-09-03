using FluentValidation;

namespace Store.Application.DTOS.Product.Validations
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        public IProductDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Title).MaximumLength(300).WithMessage("max length for {PropertyName} is 300");
            RuleFor(x => x.Description).MaximumLength(2000).WithMessage("max length for {PropertyName} is 2000");
        }
    }
}
