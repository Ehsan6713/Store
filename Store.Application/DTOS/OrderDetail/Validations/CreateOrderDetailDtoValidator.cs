using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.OrderDetail.Validations
{
    public class CreateOrderDetailDtoValidator : AbstractValidator<CreateOrderDetailDto>
    {
        public CreateOrderDetailDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("{PropertyName} can no be Less than 1");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("{PropertyName} can no be Less than 1");
            RuleFor(x => x.Discount).GreaterThan(-1).WithMessage("{PropertyName} can no be Negative");
        }
    }
}
