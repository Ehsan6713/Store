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
            Include(new IOrderDtoValidator());
        }
    }
}
