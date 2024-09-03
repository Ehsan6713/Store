using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Category.Validations
{
    public class CreateCategoryDtoValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(200).WithMessage("max length for {PropertyName} is 200");
        }
    }
}
