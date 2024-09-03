using FluentValidation;

namespace Store.Application.DTOS.Category.Validations
{
    public class ICategoryDtoValidator : AbstractValidator<ICategoryDto>
    {
        public ICategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(200).WithMessage("max length for {PropertyName} is 200");
        }
    }
}
