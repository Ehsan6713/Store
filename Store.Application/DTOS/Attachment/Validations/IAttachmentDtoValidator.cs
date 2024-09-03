using FluentValidation;

namespace Store.Application.DTOS.Attachment.Validations
{
    public class IAttachmentDtoValidator : AbstractValidator<IAttachmentDto>
    {
        public IAttachmentDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(200).WithMessage("max length for {PropertyName} is 200");
            RuleFor(x => x.Content).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
