using FluentValidation;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.OrderDetail.Validations
{
    public class UpdateOrderDetailDtoValidator : AbstractValidator<UpdateOrderDetailDto>
    {
        public UpdateOrderDetailDtoValidator(IProductRepository productRepository)
        {
            Include(new IOrderDetailDtoValidator(productRepository));
        }
    }
}
