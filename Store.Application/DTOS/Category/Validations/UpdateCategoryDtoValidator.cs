using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Category.Validations
{
    public class UpdateCategoryDtoValidator:AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            Include(new ICategoryDtoValidator());
        }
    }
}
