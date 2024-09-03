using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Brand.Validations
{
    public class UpdateBrandDtoValidator:AbstractValidator<UpdateBrandDto>
    {
        public UpdateBrandDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(200).WithMessage("max length for {PropertyName} is 200");
        }
    }
}
