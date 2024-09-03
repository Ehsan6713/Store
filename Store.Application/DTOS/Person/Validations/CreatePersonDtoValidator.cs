﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Person.Validations
{
    public class CreatePersonDtoValidator:AbstractValidator<CreatePersonDto>
    {
        public CreatePersonDtoValidator()
        {
            Include(new IPersonDtoValidator());

        }
    }
}
