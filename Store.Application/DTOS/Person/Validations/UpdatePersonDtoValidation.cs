using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Person.Validations
{
    public class UpdatePersonDtoValidation:AbstractValidator<UpdatePersonDto>
    {
        public UpdatePersonDtoValidation()
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
