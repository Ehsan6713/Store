using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Order.Validations
{
    public class UpdateOrderDtoValidator:AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Total).GreaterThan(0).WithMessage("{PropertyName} can no be Less than 1");
            RuleFor(x => x.Discount).GreaterThan(-1).WithMessage("{PropertyName} can no be Less than 0");
        }
    }
}
