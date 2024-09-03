using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Attachment.Validations
{
    public class UpdateAttachmentDtoValidator : AbstractValidator<UpdateAttachmentDto>
    {
        public UpdateAttachmentDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(200).WithMessage("max length for {PropertyName} is 200");
            RuleFor(x => x.Content).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
