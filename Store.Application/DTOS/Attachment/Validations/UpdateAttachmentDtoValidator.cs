﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Attachment.Validations
{
    public class UpdateAttachmentDtoValidator : AbstractValidator<UpdateAttachmentDto>
    {
        public UpdateAttachmentDtoValidator()
        {
            Include(new IAttachmentDtoValidator());
        }
    }
}
