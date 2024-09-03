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
            Include(new IBrandDtoValidator());
        }
    }
}
