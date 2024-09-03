using FluentValidation;

namespace Store.Application.DTOS.Brand.Validations
{
    public class IBrandDtoValidator : AbstractValidator<IBrandDto>
    {
        public IBrandDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(200).WithMessage("max length for {PropertyName} is 200");
        }
    }
}
