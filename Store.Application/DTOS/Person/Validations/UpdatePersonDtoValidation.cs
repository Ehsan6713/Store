﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Person.Validations
{
    public class UpdatePersonDtoValidator:AbstractValidator<UpdatePersonDto>
    {
        public UpdatePersonDtoValidator()
        {
            Include(new IPersonDtoValidator());

        }
    }
}
