using FluentValidation;

namespace Store.Application.DTOS.Person.Validations
{
    public class IPersonDtoValidator : AbstractValidator<IPersonDto>
    {
        public IPersonDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("max length for {PropertyName} is 100");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("max length for {PropertyName} is 100");

            RuleFor(x => x.Gender).NotEmpty().WithMessage("{PropertyName} is required");

        }
    }
}
