using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Order.Validations
{
    public class CreateOrderDtoValidator:AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            Include(new IOrderDtoValidator());
        }
    }
}
